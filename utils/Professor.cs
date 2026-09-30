namespace algoritm.utils
{
    public static class Professor
    {
        private const int Speed = 20;
        public static void Speak(string text)
        {
            SlowWrite(text);
            Console.WriteLine();
            Console.WriteLine("ENTER para continuar...");
            Console.ReadLine();
        }

        public static void SlowWrite(string text)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                if (c != '\n')
                {
                    Thread.Sleep(Speed);
                }
            }
        }

        public static int ReadInt(string message, int min, int max)
        {
            while (true)
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out int value) && value >= min && value <= max)
                {
                    return value;
                }
                Console.WriteLine($"Por favor, digite um número entre {min} e {max}.");
            }
        }
    }
}
