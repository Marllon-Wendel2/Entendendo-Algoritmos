using System;

namespace algoritm.algoritm
{
    public class BreadthFirstSearch
    {
        public void Execute()
        {
            Dictionary<string, List<String>> grafo =
                new Dictionary<string, List<string>>(){
                { "I", new List<string> { "Superior", "InferiorEsq" } },
                { "Superior", new List<string> { "F", "Medio" } },
                { "InferiorEsq", new List<string> { "InferiorDir", "Medio" } },
                { "InferiorDir", new List<string> { "F" } },
                { "Medio", new List<string>() },
                { "F", new List<string>() }
                };

            Dictionary<string, List<string>> grafo2 = new Dictionary<string, List<string>>()
                {
                    { "JATO", new List<string> { "GATO", "TATO" } },
                    { "TATO", new List<string> { "GATO", "CHATO" } },
                    { "GATO", new List<string> { "GRATO", "GADO" } },
                    { "GRATO", new List<string> { "GADO" } },
                    { "CHATO", new List<string> { "GADO" } },
                    { "GADO", new List<string>() }
                };

            FindSmallPath(grafo, "I", "F");
            FindSmallPath(grafo2, "JATO", "GATO");
        }
        private void FindSmallPath(Dictionary<string, List<string>> grafo, string inicio, string fim)
        {
            Queue<string> filaDePesquisa = new Queue<string>();

            HashSet<string> jaVerificados = new HashSet<string>();

            Dictionary<string, string> pais = new Dictionary<string, string>();

            filaDePesquisa.Enqueue(inicio);
            jaVerificados.Add(inicio);

            bool finded = false;

            while (filaDePesquisa.Count > 0)
            {
                string pessoaOuNoAtual = filaDePesquisa.Dequeue();

                if (pessoaOuNoAtual == fim)
                {
                    finded = true;
                    break;
                }

                foreach (string neigboor in grafo[pessoaOuNoAtual])
                {
                    if (!jaVerificados.Contains(neigboor))
                    {
                        jaVerificados.Add(neigboor);
                        filaDePesquisa.Enqueue(neigboor);
                        pais[neigboor] = pessoaOuNoAtual;
                    }
                }
            }

            if (finded)
            {
                List<string> path = new List<string>();

                string current = fim;

                while (current != inicio)
                {
                    path.Add(current);
                    current = pais[current];
                }

                path.Add(inicio);
                path.Reverse();

                Console.WriteLine("Menor caminho encontrado: " + string.Join(" -> ", path));
            }
            else
            {
                Console.WriteLine("Não existe caminho até ao destino.");
            }
        }
    }

}