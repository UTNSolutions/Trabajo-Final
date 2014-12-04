using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Trabajo_Final.Excepciones;

namespace Trabajo_Final.Persistencia
{
    class SQLServerCuentaDAO : ICuentaDAO 
    {
        private SqlConnection iConexion;
        private SqlTransaction iTransaccion;

        public SQLServerCuentaDAO(SqlConnection pConexion,SqlTransaction pTransaccion)
        {
            this.iConexion = pConexion;
            this.iTransaccion = pTransaccion;
        }
        public void Insertar(CuentaDTO pCuenta)
        {
            try
            {
                SqlCommand comando = new SqlCommand("insert into Cuenta(nombre,direccion,servicio,contraseña) values(@nombre,@direccion,@servicio,@contraseña)", this.iConexion, this.iTransaccion);
                comando.Parameters.AddWithValue("@nombre", pCuenta.Nombre);
                comando.Parameters.AddWithValue("@servicio", pCuenta.NombreServicio);
                comando.Parameters.AddWithValue("@direccion", pCuenta.Direccion);
                comando.Parameters.AddWithValue("@contraseña", pCuenta.Contraseña);
                comando.ExecuteNonQuery();
            }
            catch(SqlException)
            {
                throw new DAOExcepcion("No se pudo insertar la cuenta en la base de datos");
            }
        }

        public void Modificar(CuentaDTO pCuenta)
        {
            SqlCommand comando = new SqlCommand("update Cuenta set nombre=@nombre, servicio=@servicio, direccion= @direccion , contraseña = @contraseña where idCuenta=@idCuenta", this.iConexion, this.iTransaccion);
            comando.Parameters.AddWithValue("@idCuenta", pCuenta.IdCuenta);
            comando.Parameters.AddWithValue("@nombre", pCuenta.Nombre);
            comando.Parameters.AddWithValue("@servicio", pCuenta.NombreServicio);
            comando.Parameters.AddWithValue("@direccion", pCuenta.Direccion);
            comando.Parameters.AddWithValue("@contraseña", pCuenta.Contraseña);
            try
            {
                comando.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                throw new DAOExcepcion("No se pudo modificar los datos de la cuenta");
            }
        }

        public void Eliminar(CuentaDTO pCuenta)
        {
            SqlCommand comando = new SqlCommand("delete from Cuenta where idCuenta=@idCuenta", this.iConexion, this.iTransaccion);
            comando.Parameters.AddWithValue("@idCuenta", pCuenta.IdCuenta);
            try
            {
                comando.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                throw new DAOExcepcion("No se pudo eliminar la cuenta");
            }
        }

        public IList<CuentaDTO> Obtener()
        {
            SqlCommand comando = new SqlCommand("select * from Cuenta", this.iConexion);
            DataTable tabla = new DataTable();
            IList<CuentaDTO> listaCuentas = new List<CuentaDTO>();
            try
            {
                SqlDataAdapter operacion = new SqlDataAdapter(comando);
                operacion.Fill(tabla);
                foreach (DataRow fila in tabla.Rows)
                {
                    listaCuentas.Add(new CuentaDTO(Convert.ToInt32(fila["idCuenta"]),Convert.ToString(fila["nombre"]),Convert.ToString(fila["direccion"]),Convert.ToString(fila["servicio"]),Convert.ToString(fila["contraseña"])));
                }
                return listaCuentas;
            }
            catch (SqlException)
            {
                throw new DAOExcepcion("No se pudo obtener de los datos de las cuentas");
            }
        }
    }
}
