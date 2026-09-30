using algoritm.utils;

namespace algoritm.algoritm
{
    public class BuscaBinario
    {
        public void Execute()
        {
            List<int> lista = Enumerable.Range(1, 2000).ToList();

            Professor.Speak("A busca binária é um algoritmo que elimina metade da busca a cada passo. "
                + "O fator de a lista estar ordenada é importante: em lista desordenada ela não funciona.");

            Professor.Speak("Imagine uma lista de 1 a 2000. Escolha um número e vamos mostrar passo a passo "
                + "como a busca binária encontra o número escolhido.");

            int numeroEscolhido = Professor.ReadInt("Digite um número entre 1 e 2000: ", 1, 2000);

            List<(int de, int ate)> cortes = new();
            int baixo = 0;
            int alto = lista.Count - 1;
            int passo = 0;

            while (baixo <= alto)
            {
                int meio = (baixo + alto) / 2;
                passo++;

                Desenho.Janela(lista, baixo, alto, meio, passo, cortes);

                if (lista[meio] == numeroEscolhido)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"  ✓ {numeroEscolhido} é o número do meio!");
                    Console.ResetColor();
                    Professor.Speak($"Encontrado no passo {passo}, com {passo} comparações.");
                    return;
                }

                if (numeroEscolhido < lista[meio])
                {
                    cortes.Add((lista[meio], lista[alto]));
                    Professor.Speak($"Como o número escolhido é menor que {lista[meio]}, "
                        + $"manteremos a lista {lista[baixo]}–{lista[meio - 1]} "
                        + $"e eliminaremos a lista {lista[meio]}–{lista[alto]} ✂");
                    alto = meio - 1;
                }
                else
                {
                    cortes.Add((lista[baixo], lista[meio]));
                    Professor.Speak($"Como o número escolhido é maior que {lista[meio]}, "
                        + $"manteremos a lista {lista[meio + 1]}–{lista[alto]} "
                        + $"e eliminaremos a lista {lista[baixo]}–{lista[meio]} ✂");
                    baixo = meio + 1;
                }
            }

            Professor.Speak($"{numeroEscolhido} não está na lista (foram feitas {passo} comparações).");
        }
    }
}
