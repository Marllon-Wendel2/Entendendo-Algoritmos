using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using algoritm.utils;

namespace algoritm.algoritm
{
    public class Hash
    {
        private HashSet<string> voters = new HashSet<string>();
        private int juanVotes = 0;
        private int anaVotes = 0;

        public void Execute()
        {
            Professor.Speak("Sistema de votação simples, para demonstrar como funciona tabelas hash: ");

            while (true)
            {
                string name = QuestName();
                if (name == "0") break;

                bool canVote = CanVote(name);

                if (!canVote)
                {
                    Console.WriteLine("Você já votou");
                    continue;
                }

                int candidato = Professor.ReadInt("1 - Juan | 2 - Ana: ", 1, 2);

                switch (candidato)
                {
                    case 1:
                        juanVotes++;
                        voters.Add(name);
                        break;
                    case 2:
                        anaVotes++;
                        voters.Add(name);
                        break;

                }
            }

            Professor.Speak($"Resultado final:\n"

               + $"Juan: {juanVotes}\n"
               + $"Ana: {anaVotes}\n"
               );


        }

        private bool CanVote(string name)
        {
            return !voters.Contains(name);
        }

        private string QuestName()
        {
            while (true)
            {
                Console.WriteLine("Informe seu nome completo");

                string? name = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("Nome não pode ser vazio. Tente novamente.");

                    continue;
                }

                return name;

            }

        }
    }
}