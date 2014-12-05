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
            try
            {
                SqlCommand comando = new SqlCommand("insert into Email(idCuenta,destinatario,cuerpo,asunto) values(@idCuenta,@destinatario,@cuerpo,@asunto)", this.iConexion, this.iTransaccion);
                comando.Parameters.AddWithValue("@idCuenta", pEmail.IdCuenta);
                comando.Parameters.AddWithValue("@destinatario", pEmail.Destinatario);
                comando.Parameters.AddWithValue("@cuerpo", pEmail.Cuerpo);
                comando.Parameters.AddWithValue("@asunto", pEmail.Asunto);
                comando.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                throw new DAOExcepcion("No se pudo insertar el email en la base de datos");
            }

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
            SqlCommand comando = new SqlCommand("select * from Email where idCuenta= @idCuenta", this.iConexion);
            comando.Parameters.AddWithValue("@idCuenta", pIdCuenta);
            DataTable tabla = new DataTable();
            IList<EmailDTO> listaEmails = new List<EmailDTO>();
            try
            {
                SqlDataAdapter operacion = new SqlDataAdapter(comando);
                operacion.Fill(tabla);
                foreach (DataRow fila in tabla.Rows)
                {
                    listaEmails.Add(new EmailDTO(Convert.ToInt32(fila["idEmail"]),Convert.ToInt32(fila["idCuenta"]),Convert.ToString(fila["destinatario"]),Convert.ToString(fila["cuerpo"]),Convert.ToString(fila["asunto"])));
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
