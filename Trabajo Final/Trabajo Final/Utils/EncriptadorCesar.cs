using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Final.Utils
{
    /// <summary>
    /// Representa un Encriptador Cesar que se basa en desplazamientos
    /// </summary>
    public class EncriptadorCesar
    {
        private int iDesplazamiento;

        public EncriptadorCesar(int pDesplazamiento)
        {         
            this.iDesplazamiento = pDesplazamiento;
        }

        /// <summary>
        /// Encripta una cadena, tomando en cuenta un cierto desplazamiento
        /// </summary>
        /// <param name="pCadena"></param>
        /// <returns></returns>
        public String Encriptar(String pCadena)
        {
            String cadenaCifrada = "";
            char letra;
            int codigo;
            for (int indice = 0; indice < pCadena.Length; indice++)
            {
                letra =  pCadena[indice];
                codigo = Convert.ToChar(letra);
                codigo += this.iDesplazamiento;
                cadenaCifrada+= Convert.ToChar(codigo);
            }
            return cadenaCifrada;
        }

        /// <summary>
        /// Desencripta una cadena, tomando en cuenta un cierto desplazamiento
        /// </summary>
        /// <param name="pCadena"></param>
        /// <returns></returns>
        public String Desencriptar(String pCadena)
        {
            String cadenaDescifrada = "";
            char letra;
            int codigo;
            //itera toda la cadena, tratando cada caracter para poder desencriptar la
            for (int indice = 0; indice < pCadena.Length; indice++)
            {
                //Obtengo la letra correspondiente para poder desencriptarla
                letra = pCadena[indice];
                //Obtengo el codigo ASCII de dicha letra
                codigo = Convert.ToChar(letra);
                //Como estoy desencriptando, el desplazamiento tiene que ser
                //a la izquierda por lo que tengo que restarle el desplazamiento
                //al codigo ASCII de dicha letra
                codigo -= this.iDesplazamiento;
                //concateno letra desencriptada
                cadenaDescifrada += Convert.ToChar(codigo);
            }
            return cadenaDescifrada;
        } 
    }
}
