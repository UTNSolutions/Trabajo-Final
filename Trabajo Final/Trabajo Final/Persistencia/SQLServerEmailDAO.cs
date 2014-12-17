using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Trabajo_Final.DTO;
using Trabajo_Final.Excepciones;

namespace Trabajo_Final.Persistencia
{
    class SQLServerEmailDAO : IMailDAO
    {
        private SqlConnection iConexion;
        private SqlTransaction iTransaccion;

        public SQLServerEmailDAO(SqlConnection pConexion, SqlTransaction pTransaccion)
        {
            this.iConexion = pConexion;
            this.iTransaccion = pTransaccion;

        }
        public int Insertar(EmailDTO pEmail)
        {
           try
           {
               //inserto el email en la base de datos
               SqlCommand comando = new SqlCommand("insert into Email(idCuenta,remitente,cuerpo,asunto,fecha,leido) values(@idCuenta,@remitente,@cuerpo,@asunto,@fecha,@leido)", this.iConexion, this.iTransaccion);
               comando.Parameters.AddWithValue("@idCuenta", pEmail.IdCuenta);
               comando.Parameters.AddWithValue("@remitente", pEmail.Remitente);          
               comando.Parameters.AddWithValue("@asunto", pEmail.Asunto);
               comando.Parameters.AddWithValue("@cuerpo", pEmail.Cuerpo);
               comando.Parameters.AddWithValue("@fecha", pEmail.Fecha);
               comando.Parameters.AddWithValue("@leido", pEmail.Leido);
               comando.ExecuteNonQuery();
               //obtengo el Maximo idMail que se encuentra en la base de datos
               //que corresponde al ultimo Email que inserte
               SqlCommand cmd = new SqlCommand("select Max(idMail) from Email",this.iConexion,this.iTransaccion);
               int idMail = Convert.ToInt32(cmd.ExecuteScalar());
               //por cada direccion en la lista de destinatarios, creo una tupla en la base de datos
               foreach(String destinatario in pEmail.Destinatario)
               {
                   SqlCommand com = new SqlCommand("insert into DireccionXEmail(idMail,direccion,tipo) values(@idMail,@direccion,@tipo)", this.iConexion, this.iTransaccion);
                   com.Parameters.AddWithValue("@idMail", idMail);
                   com.Parameters.AddWithValue("@direccion",destinatario);
                   com.Parameters.AddWithValue("@tipo", "D");
                   com.ExecuteNonQuery();
               }
               if (pEmail.ConCopia != null)
               {
                   //por cada direccion en la lista de ConCopia, creo una tupla en la base de datos
                   foreach (String CC in pEmail.ConCopia)
                   {
                       SqlCommand com = new SqlCommand("insert into DireccionXEmail(idMail,direccion,tipo) values(@idMail,@direccion,@tipo)", this.iConexion, this.iTransaccion);
                       com.Parameters.AddWithValue("@idMail", idMail);
                       com.Parameters.AddWithValue("@direccion", CC);
                       com.Parameters.AddWithValue("@tipo", "CC");
                       com.ExecuteNonQuery();
                   }
               }
               if (pEmail.ConCopiaOculta != null)
               {
                   //por cada direccion en la lista de ConCopiaOculta, creo una tupla en la base de datos
                   foreach (String CCO in pEmail.ConCopiaOculta)
                   {
                       SqlCommand com = new SqlCommand("insert into DireccionXEmail(idMail,direccion,tipo) values(@idMail,@direccion,@tipo)", this.iConexion, this.iTransaccion);
                       com.Parameters.AddWithValue("@idMail", idMail);
                       com.Parameters.AddWithValue("@direccion", CCO);
                       com.Parameters.AddWithValue("@tipo", "CCO");
                       com.ExecuteNonQuery();
                   }
               }
               if (pEmail.Adjuntos != null)
               {
                   //por cada archivo adjunto en la lista de Adjuntos, creo una tupla en la base de datos
                   foreach (String adjuntos in pEmail.Adjuntos)
                   {
                       SqlCommand com = new SqlCommand("insert into AdjuntosXEmail(idMail,ruta) values(@idMail,@ruta)", this.iConexion, this.iTransaccion);
                       com.Parameters.AddWithValue("@idMail", idMail);
                       com.Parameters.AddWithValue("@ruta", adjuntos);
                       com.ExecuteNonQuery();
                   }
               }
               return idMail;
           }
           catch (SqlException)
            {
                throw new DAOExcepcion("No se pudo insertar el email en la base de datos");
            }
        }

        public void MarcarLeido(int pIdEmail)
        {
            SqlCommand comando = new SqlCommand("update Email set leido='true' where idMail=@idEmail", this.iConexion, this.iTransaccion);
            comando.Parameters.AddWithValue("@idEmail", pIdEmail);
            try
            {
                comando.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                throw new DAOExcepcion("No se pudo realizar la operacion");
            }
        }


        public void Eliminar(int pIdEmail)
        {
            SqlCommand comando = new SqlCommand("delete from Email where idMail=@idEmail", this.iConexion, this.iTransaccion);
            comando.Parameters.AddWithValue("@idEmail", pIdEmail);
            try
            {
                comando.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                throw new DAOExcepcion("No se pudo eliminar el email");
            }
        }

        public IList<EmailDTO> Obtener(int pIdCuenta)
        {
            SqlCommand comando = new SqlCommand("select * from Email where idCuenta= @idCuenta", this.iConexion);
            comando.Parameters.AddWithValue("@idCuenta", pIdCuenta);
            DataTable tabla = new DataTable();
            IList<EmailDTO> listaEmails = new List<EmailDTO>();
            try
            {
                SqlDataAdapter operacion = new SqlDataAdapter(comando);
                operacion.Fill(tabla);
                //itera por cada Email encontrado que pertenece a una cuenta especifica
                foreach (DataRow fila in tabla.Rows)
                {
                    //obtengo una lista de destinatarios asociados a cada email, osea cada fila del data table
                    SqlCommand cmd = new SqlCommand("select direccion from DireccionXEmail where idMail = @idMail and tipo='D'", this.iConexion);
                    //obtengo una lista de direcciones con Copia de cada Email
                    SqlCommand cmdCC = new SqlCommand("select direccion from DireccionXEmail where idMail = @idMail and tipo='CC'", this.iConexion);
                    //obtengo una lista de direccion con Copia Oculta de cada Email
                    SqlCommand cmdCCO = new SqlCommand("select direccion from DireccionXEmail where idMail = @idMail and tipo='CCO'", this.iConexion);
                    //obtengo una lista de los archivos adjuntos de cada Email
                    SqlCommand cmdAdjuntos = new SqlCommand("select ruta from AdjuntosXEmail where idMail = @idMail", this.iConexion);
                    cmd.Parameters.AddWithValue("@idMail", fila["idMail"]);
                    cmdCC.Parameters.AddWithValue("@idMail", fila["idMail"]);
                    cmdCCO.Parameters.AddWithValue("@idMail", fila["idMail"]);                        
                    cmdAdjuntos.Parameters.AddWithValue("@idMail", fila["idMail"]);
                    //declaro 4 DataTable para llenarlos con las consultas anteriores
                    DataTable tablaDestinatarios = new DataTable();
                    DataTable tablaCC = new DataTable();
                    DataTable tablaCCO = new DataTable();                    
                    DataTable tablaAdjuntos = new DataTable();
                    //declaro 4 listas para cargarlas con los datos de cada una de las consultas
                    IList<String> listaDestinatarios = new List<String>();
                    IList<String> listaCC = new List<String>();
                    IList<String> listaCCO = new List<String>();                    
                    IList<String> listaAdjuntos = new List<String>();
                    //realizo las 4 consultas a la base de datos
                    SqlDataAdapter operacion1 = new SqlDataAdapter(cmd);
                    SqlDataAdapter operacion2 = new SqlDataAdapter(cmdCC);
                    SqlDataAdapter operacion3 = new SqlDataAdapter(cmdCCO);
                    SqlDataAdapter operacion4 = new SqlDataAdapter(cmdAdjuntos);
                    operacion1.Fill(tablaDestinatarios);
                    operacion2.Fill(tablaCC);
                    operacion3.Fill(tablaCCO);
                    operacion4.Fill(tablaAdjuntos);
                    //por cada destinatario encontrado lo agrego a la listaDestinatarios
                    foreach (DataRow fila1 in tablaDestinatarios.Rows)
                    {
                        listaDestinatarios.Add(Convert.ToString(fila1["direccion"]));
                    }
                    //por cada direccion con Copia encontrado lo agrego a la listaCC
                    foreach (DataRow fila1 in tablaCC.Rows)
                    {
                        listaCC.Add(Convert.ToString(fila1["direccion"]));
                    }
                    //por cada direccion con Copia Oculta encontrada lo agrego a la listaCCO
                    foreach (DataRow fila1 in tablaCCO.Rows)
                    {
                        listaCCO.Add(Convert.ToString(fila1["direccion"]));
                    }
                    //por cada archivo adjunto encontrado lo agrego a la listaAdjuntos
                    foreach (DataRow fila1 in tablaAdjuntos.Rows)
                    {
                        listaAdjuntos.Add(Convert.ToString(fila1["ruta"]));
                    }
                    //por ultimo inserto el Email a la listaEmails para luego devolverla 
                    listaEmails.Add(new EmailDTO(Convert.ToInt32(fila["idMail"]), Convert.ToInt32(fila["idCuenta"]), Convert.ToString(fila["remitente"]), listaDestinatarios, listaCC, listaCCO, Convert.ToString(fila["cuerpo"]), Convert.ToString(fila["asunto"]), listaAdjuntos,Convert.ToDateTime(fila["fecha"]),Convert.ToBoolean(fila["leido"])));
                }
                return listaEmails;
            }
            catch (SqlException)
            {
                throw new DAOExcepcion("No se pudo obtener de los datos de los emails asociado a la cuenta");
            }
        }
    }
}
