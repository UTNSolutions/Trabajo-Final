using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Trabajo_Final.DTO;

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
            

        }

        public void Eliminar(EmailDTO pEmail)
        {
       
        }

        public IList<EmailDTO> Obtener(CuentaDTO pCuenta)
        {
            throw new NotImplementedException();
        }
    }
}
