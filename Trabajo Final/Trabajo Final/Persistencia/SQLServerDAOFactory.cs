using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using Trabajo_Final.Excepciones;

namespace Trabajo_Final.Persistencia
{
    /// <summary>
    /// Representa un conjunto de funcionalidades para el acceso a base de datos SQL Server
    /// </summary>
    class SQLServerDAOFactory : DAOFactory
    {
        private SqlConnection iConexion;
        private SqlTransaction iTransaccion;
        private String conexion = "Data Source=MATI-D; INITIAL Catalog=CuentasCorreo; Persist Security Info=True;User ID=sa;Password=06qiad";
        //private String conexion = "Data Source=BRIAN-PC; INITIAL Catalog=CuentasCorreo; Persist Security Info=True;User ID=sa;Password=brianfellin";


        public override ICuentaDAO CuentaDAO
        {
            get
            {
                return new SQLServerCuentaDAO(Conexion, this.iTransaccion);
            }
        }

        public override IMailDAO MailDao
        {
            get
            {
                return new SQLServerEmailDAO(Conexion, this.iTransaccion);
            }
        }

        private SqlConnection Conexion
        {
            get
            {
                if (this.iConexion.State == System.Data.ConnectionState.Closed)
                {
                    try
                    {
                        this.iConexion.Open();
                    }
                    catch (SqlException)
                    {
                        throw new DAOExcepcion("No se pudo realizar la conexión a la base de datos, reintente mas tarde");
                    }
                }
                return this.iConexion;
            }
        }

        public override void ComenzarTransaccion()
        {
            this.iTransaccion = this.iConexion.BeginTransaction();
        }

        public override void Commit()
        {
            this.iTransaccion.Commit();
        }

        public override void IniciarConexion()
        {
            if (this.iConexion == null)
            {
                this.iConexion = new SqlConnection(this.conexion);
            }
            this.iConexion = Conexion;
        }

        public override void FinalizarConexion()
        {
            this.iConexion.Close();
        }
        public override void RollBack()
        {
            this.iTransaccion.Rollback();
        }

    }
}
