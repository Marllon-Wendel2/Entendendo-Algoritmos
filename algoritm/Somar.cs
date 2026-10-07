using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using algoritm.utils;

namespace algoritm.algoritm
{
    public class Somar
    {
        public void Execute()
        {
            Professor.Speak("Algoritmo de somar utilizando o pensamento de 'Dividir para conquistar' mencionado no cápitulo 4");

            Professor.Speak("Imagine que você tenha um array: [1,2,3,4,5,6,7,8] e você queira somar todos os números. ");

            Professor.Speak("Poderia criar um loop para pecorrer e somar e isso seria mais eficiente em questão de memoria, mas o algoritmo  busca utilizar o pensamento 'Dividir para conquistar', assim transformando buscando qual seria o caso-base.");

            Professor.Speak("O caso base é seria o menor caso possível, na situação de um array seria um único número. ");

            int[] values = { 1, 2, 3, 4, 5 };
            int result = SomarRecurse(values);

            Professor.Speak($"Assim a soma fica: {result}");

        }

        private int SomarRecurse(int[] values)
        {
            if (values.Length == 0)
            {
                return 0;
            }
            if (values.Length == 1)
            {
                return values[0];
            }

            return values[0] + SomarRecurse(values[1..]);
        }
    }
}