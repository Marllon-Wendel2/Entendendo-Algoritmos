using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using algoritm.utils;

namespace algoritm.algoritm
{
    public class QuicksortBase
    {
        public void Execute()
        {
            int[] array = Enumerable.Range(1, 20).OrderBy(x => Guid.NewGuid()).ToArray();

            Professor.Speak($"O algoritmo de ordenação base do Quick utiliza recurção e utiliza caso-base, em uma lista como {string.Join(", ", array)}." + "Assim vamos escolher um pivô para dividir a lista em três partes, valores menores que o pivô, o pivô, e valores maiores que o pivô.");

            int[] arrayOrdenado = Quicksort(array);

            Professor.Speak("Aplicando o algoritmo recursivamente nos sub-arrays, obtivemos a lista ordenada: " + string.Join(", ", arrayOrdenado));

        }

        private int[] Quicksort(int[] array)
        {
            if (array.Length < 2)
            {
                return array;
            }
            else
            {
                int pivo = array[array.Length / 2];

                int[] menores = array.Where(x => x < pivo).ToArray();
                int[] maiores = array.Where(x => x > pivo).ToArray();
                int[] iguais = array.Where(x => x == pivo).ToArray();

                return Quicksort(menores)
                    .Concat(iguais)
                    .Concat(Quicksort(maiores))
                    .ToArray();
            }
        }
    }
}