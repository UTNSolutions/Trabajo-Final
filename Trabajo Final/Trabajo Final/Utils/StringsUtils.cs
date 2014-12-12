using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Final.Utils
{
    /// <summary>
    /// Representa funciones para tratar strings
    /// </summary>
    class StringsUtils
    {
        /// <summary>
        /// Obtiene la direccion de Email de una cadena, donde el email esta entre "<" y ">"
        /// </summary>
        /// <param name="pCadena"></param>
        public static String ObtenerEmail(String pCadena)
        {
            int indice = 0;
            //itera hasta encontrar el primer '<'
            while (indice < pCadena.Length && pCadena[indice] != '<')
            {
                indice++;
            }
            String email = "";
            indice++;
            //itera concatenando cada letra que conforma el email hasta encontrar '>'
            while (indice < pCadena.Length && pCadena[indice] != '>')
            {
                email += pCadena[indice];
                indice++;
            }
            //si no encontro el email entre '< >' entonces devuelvo la cadena original
            if (email == "")
            {
                email = pCadena;
            }
            return email;
        }
    }
}
