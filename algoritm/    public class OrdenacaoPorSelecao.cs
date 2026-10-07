using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using algoritm.utils;

namespace algoritm.algoritm
{
    public class OrdenacaoPorSelecao
    {
        public void Execute()
        {
            Professor.SlowWrite("A ordenação simples é um algoritmo, mas primeiro informe um array de números desordenados: Exemplo: [7,5,2,1,4,6,8]");
            Console.WriteLine();
            Console.Write("> ");

            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                throw new InvalidOperationException("A entrada não pode estar vazia.");
            }

            string conteudo = input.Trim('[', ']').Trim();

            if (conteudo.Length == 0)
            {
                throw new InvalidOperationException("A lista precisa ter pelo menos um número.");
            }

            List<int> lista = new List<int>();

            foreach (string parte in conteudo.Split(','))
            {
                if (!int.TryParse(parte.Trim(), out int numero))
                {
                    throw new InvalidOperationException($"Entrada inválida: '{parte.Trim()}' não é um número inteiro. Use o formato [7,5,2,1,4,6,8].");
                }
                lista.Add(numero);
            }

            List<int> listOrdened = ordenacaoPorSelecao(lista);

            Professor.Speak($"A lista ordenada agora fica: [{string.Join(", ", listOrdened)}]");
        }

        public List<int> ordenacaoPorSelecao(List<int> array)
        {
            List<int> newList = new List<int>();
            int originalLength = array.Count;

            for (int i = 0; i < originalLength; i++)
            {
                int smallestIndex = this.findSmallestNumber(array);
                newList.Add(array[smallestIndex]);
                array.RemoveAt(smallestIndex);
            }

            return newList;
        }
        private int findSmallestNumber(List<int> array)
        {
            if (array.Count == 0)
            {
                throw new InvalidOperationException("Não é possível buscar o menor número de uma lista vazia.");
            }

            int smallestIndex = 0;
            int smallestValue = array[0];

            for (int i = 1; i < array.Count; i++)
            {
                if (array[i] < smallestValue)
                {
                    smallestIndex = i;
                    smallestValue = array[i];
                }
            }

            return smallestIndex;
        }

    }


}