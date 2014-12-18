using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Trabajo_Final.Excepciones;
using Trabajo_Final.DTO;
using Trabajo_Final.Utils;

namespace Trabajo_Final.Persistencia.SQLServer
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
                //declaro un encriptador para poder encriptar la contraseña antes de insertarla
                //en la base de datos
                EncriptadorCesar encriptador = new EncriptadorCesar(4);
                String contraseñaEncriptada = encriptador.Encriptar(pCuenta.Contraseña);
                SqlCommand comando = new SqlCommand("insert into Cuenta(nombre,direccion,servicio,contraseña,directorioDeAdjuntos) values(@nombre,@direccion,@servicio,@contraseña,@directorio)", this.iConexion, this.iTransaccion);
                comando.Parameters.AddWithValue("@nombre", pCuenta.Nombre);
                comando.Parameters.AddWithValue("@servicio", pCuenta.NombreServicio);
                comando.Parameters.AddWithValue("@direccion", pCuenta.Direccion);
                comando.Parameters.AddWithValue("@contraseña", contraseñaEncriptada);
                comando.Parameters.AddWithValue("@directorio", pCuenta.DirectorioDeAdjuntos);
                comando.ExecuteNonQuery();
            }
            catch(SqlException)
            {
                throw new DAOExcepcion("No se pudo insertar la cuenta en la base de datos");
            }
        }

        public void Modificar(CuentaDTO pCuenta)
        {
            EncriptadorCesar encriptador = new EncriptadorCesar(4);
            String contraseñaEncriptada = encriptador.Encriptar(pCuenta.Contraseña);
            SqlCommand comando = new SqlCommand("update Cuenta set nombre=@nombre, servicio=@servicio, direccion= @direccion , contraseña = @contraseña where idCuenta=@idCuenta", this.iConexion, this.iTransaccion);
            comando.Parameters.AddWithValue("@idCuenta", pCuenta.IdCuenta);
            comando.Parameters.AddWithValue("@nombre", pCuenta.Nombre);
            comando.Parameters.AddWithValue("@servicio", pCuenta.NombreServicio);
            comando.Parameters.AddWithValue("@direccion", pCuenta.Direccion);
            comando.Parameters.AddWithValue("@contraseña", contraseñaEncriptada);
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
                //creo un encriptador para desencriptar la contraseña de cada cuenta de correo
                EncriptadorCesar encriptador = new EncriptadorCesar(4);
                foreach (DataRow fila in tabla.Rows)
                {
                    String contraseñaDesencriptada = encriptador.Desencriptar(Convert.ToString(fila["contraseña"]));
                    listaCuentas.Add(new CuentaDTO(Convert.ToInt32(fila["idCuenta"]), Convert.ToString(fila["nombre"]), Convert.ToString(fila["direccion"]), Convert.ToString(fila["servicio"]), contraseñaDesencriptada));
                }
                return listaCuentas;
            }
            catch (SqlException)
            {
                throw new DAOExcepcion("No se pudo obtener los datos de las cuentas");
            }
        }

        public CuentaDTO BuscarCuenta(string pNombreCuenta)
        {
            SqlCommand comando = new SqlCommand("select * from Cuenta where nombre = @NombreCuenta", this.iConexion);
            comando.Parameters.AddWithValue("@NombreCuenta", pNombreCuenta);
            try
            {
                CuentaDTO cuenta = null;
                DataTable tabla = new DataTable();
                EncriptadorCesar encriptador = new EncriptadorCesar(4);
                SqlDataAdapter operacion = new SqlDataAdapter(comando);
                operacion.Fill(tabla);
                foreach (DataRow fila in tabla.Rows)
                {
                    String contraseñaDesencriptada = encriptador.Desencriptar(Convert.ToString(fila["contraseña"]));
                    cuenta = new CuentaDTO(Convert.ToInt32(fila["idCuenta"]), Convert.ToString(fila["nombre"]), Convert.ToString(fila["direccion"]), Convert.ToString(fila["servicio"]), contraseñaDesencriptada);
                }
                return cuenta;
            }
            catch (SqlException)
            {
                throw new DAOExcepcion("No se pudo obtener los datos de la cuenta");
            }
        }

        public void EstablecerUltimaConexion(DateTime pUltimaConexion, String pNombreCuenta)
        {
            SqlCommand comando = new SqlCommand("update Cuenta set ultimaConexion=@ultimaConexion where nombre=@nombreCuenta", this.iConexion, this.iTransaccion);
            comando.Parameters.AddWithValue("@nombreCuenta", pNombreCuenta);
            comando.Parameters.AddWithValue("@ultimaConexion", pUltimaConexion);
            try
            {
                comando.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                throw new DAOExcepcion("Ocurrio un error en base de datos, no se pudo realizar la operacion");
            }
        }


        public DateTime ObtenerUltimaConexion(String pNombreCuenta)
        {
            SqlCommand comando = new SqlCommand("select ultimaConexion from Cuenta where nombre =@nombreCuenta", this.iConexion);
            comando.Parameters.AddWithValue("@nombreCuenta", pNombreCuenta);
            try
            {  
                object consulta = comando.ExecuteScalar();
                DateTime ultimaConexion = DateTime.Now;
                if (consulta == DBNull.Value)
                {
                    ultimaConexion = new DateTime();
                }
                else
                {
                    ultimaConexion = Convert.ToDateTime(consulta);
                }
                return ultimaConexion;
            }
            catch (SqlException)
            {
                throw new DAOExcepcion("No se pudo obtener la ultima conexion de dicha cuenta");
            }
        }
    }
}
