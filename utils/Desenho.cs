namespace algoritm.utils
{
    public static class Desenho
    {
        private const int Raio = 5;

        public static void Janela(List<int> lista, int baixo, int alto, int meio,
                                  int passo, List<(int de, int ate)> cortes)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"Passo {passo}  ");
            Console.ResetColor();

            int inicio = Math.Max(0, meio - Raio);
            int fim = Math.Min(lista.Count - 1, meio + Raio);

            for (int i = inicio; i <= fim; i++)
            {
                bool eMeio = i == meio;
                bool cortado = i < baixo || i > alto;

                Console.ForegroundColor = eMeio ? ConsoleColor.Yellow
                                     : cortado ? ConsoleColor.DarkGray
                                     : ConsoleColor.White;

                if (i == inicio && inicio > 0)
                {
                    Console.Write("… ");
                }

                Console.Write(eMeio ? $"[{lista[i]}]" : lista[i].ToString());

                if (cortado)
                {
                    Console.Write("✗");
                }

                Console.Write(' ');

                if (i == fim && fim < lista.Count - 1)
                {
                    Console.Write("…");
                }
            }

            Console.ResetColor();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"  A lista atual é: {lista[baixo]}–{lista[alto]} ({alto - baixo + 1}) ");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("✂ cortes: " +
                (cortes.Count == 0 ? "—" : string.Join(", ", cortes.Select(c => $"{c.de}–{c.ate}"))));
            Console.ResetColor();
        }
    }
}
