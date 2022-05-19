using System;

namespace Conjetura_del_Goldbach
{
    /// <summary>
    /// Clase Calculo
    /// </summary>
    public class Calculo
    {
        // Atributos
        private int numero;

        /// <summary>
        /// Constructor de la clases Calculo
        /// </summary>
        /// <param name="numero">Variable de tipo int que representa el tope a calcular</param>
        public Calculo(int numero) { Numero = numero; }

        /// <summary>
        /// Propiedad que obtiene y establece el número tope para calcular la cantidad de primos
        /// </summary>
        public int Numero
        {
            get { return numero; }
            set { numero = (value < 0) ? 0 : value ; }
        }

        /// <summary>
        /// Método que obtiene la cantidad de números primos en función de un número tope
        /// </summary>
        /// <returns>Variable de tipo int que retorna la cantidad de primos</returns>
        public int CalcularTamaño()
        {
            int primo = 0, contador = 0;

            for (int i = 1; i <= Numero; i++)
            {
                contador = 0;
                for (int j = 1; j <= i; j++)
                {
                    if (i % j == 0)
                        contador++;
                }
                if (contador == 2)
                    primo++;
            }

            return primo;
        }

        /// <summary>
        /// Método que obtiene un arreglo unidimensional de tipo int que contiene una lista de números primos
        /// </summary>
        /// <returns>Arreglo unidimensional de tipo int que contiene una lista de números primos en función de un valor tope</returns>
        public int[] CalcularPrimos()
        {
            int[] ArregloPrimos = new int[CalcularTamaño()];
            int Indice = 0, Contador = 0;
            for (int i = 1; Numero >= i; i++)
            {
                Contador = 0;
                for (int j = 1; i >= j; j++)
                {
                    if (i % j == 0)
                        Contador++;
                }
                if (Contador == 2)
                {
                    ArregloPrimos[Indice] = i;
                    Indice++;
                }
            }

            return ArregloPrimos;
        }

    }
}
