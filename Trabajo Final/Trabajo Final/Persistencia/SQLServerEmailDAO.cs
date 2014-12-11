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
        public void Insertar(EmailDTO pEmail)
        {
          //  try
           // {
                //inserto el email en la base de datos
                SqlCommand comando = new SqlCommand("insert into Email(idCuenta,remitente,cuerpo,asunto,fecha) values(@idCuenta,@remitente,@cuerpo,@asunto,@fecha)", this.iConexion, this.iTransaccion);
                comando.Parameters.AddWithValue("@idCuenta", pEmail.IdCuenta);
                comando.Parameters.AddWithValue("@remitente", pEmail.Remitente);          
                comando.Parameters.AddWithValue("@asunto", pEmail.Asunto);
                comando.Parameters.AddWithValue("@cuerpo", pEmail.Cuerpo);
                comando.Parameters.AddWithValue("@fecha", pEmail.Fecha);
                comando.ExecuteNonQuery();
                SqlCommand cmd = new SqlCommand("select Max(idMail) from Email",this.iConexion,this.iTransaccion);
                int idMail = Convert.ToInt32(cmd.ExecuteScalar());
                // por cada direccion en la lista de destinatarios, creo una tupla en la base de datos
                foreach(String destinatario in pEmail.Destinatario)
                {
                    SqlCommand com = new SqlCommand("insert into DireccionXEmail(idMail,direccion,tipo) values(@idMail,@direccion,@tipo)", this.iConexion, this.iTransaccion);
                    com.Parameters.AddWithValue("@idMail", idMail);
                    com.Parameters.AddWithValue("@direccion",destinatario);
                    com.Parameters.AddWithValue("@tipo", "D");
                    com.ExecuteNonQuery();
                }
         /*   }
           catch (SqlException)
            {
                throw new DAOExcepcion("No se pudo insertar el email en la base de datos");
            } */

        }

        public void Eliminar(int pIdEmail)
        {
            SqlCommand comando = new SqlCommand("delete from Email where idMail=@idEmail", this.iConexion, this.iTransaccion);
            comando.Parameters.AddWithValue("@idCuenta", pIdEmail);
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
            SqlCommand comando = new SqlCommand("select * from Email where idCuenta= @idCuenta order by fecha desc", this.iConexion);
            comando.Parameters.AddWithValue("@idCuenta", pIdCuenta);
            DataTable tabla = new DataTable();
            IList<EmailDTO> listaEmails = new List<EmailDTO>();
            try
            {
                SqlDataAdapter operacion = new SqlDataAdapter(comando);
                operacion.Fill(tabla);
                foreach (DataRow fila in tabla.Rows)
                {
                    //obtengo una lista de destinatarios asociados a cada email, osea cada fila del data table
                    SqlCommand cmd = new SqlCommand("select direccion from DireccionXEmail where idMail = @idMail and tipo='D'", this.iConexion);
                    cmd.Parameters.AddWithValue("@idMail", fila["idMail"]);
                    DataTable tablaDestinatarios = new DataTable();
                    IList<String> listaDestinatarios = new List<String>();
                    SqlDataAdapter operacion1 = new SqlDataAdapter(cmd);
                    operacion1.Fill(tablaDestinatarios);
                    //por cada direccion (destinatario) encontrado lo agrego a una lista 
                    foreach (DataRow fila1 in tablaDestinatarios.Rows)
                    {
                        listaDestinatarios.Add(Convert.ToString(fila1["direccion"]));
                    }
                    listaEmails.Add(new EmailDTO(Convert.ToInt32(fila["idMail"]), Convert.ToInt32(fila["idCuenta"]), Convert.ToString(fila["remitente"]), listaDestinatarios, Convert.ToString(fila["cuerpo"]), Convert.ToString(fila["asunto"]),Convert.ToDateTime(fila["fecha"])));
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
