using System.Reflection;

List<Type> exercicios = Assembly.GetExecutingAssembly()
    .GetTypes()
    .Where(EhExercicio)
    .OrderBy(t => t.Name, StringComparer.OrdinalIgnoreCase)
    .ToList();

if (args.Length > 0)
    return ExecutarPorArgumento(exercicios, args);

return MenuInterativo(exercicios);

static bool EhExercicio(Type type) =>
    type.IsClass
    && !type.IsAbstract
    && type.Name != "Program"
    && type.GetMethod("Execute", BindingFlags.Public | BindingFlags.Instance, binder: null, types: Type.EmptyTypes, modifiers: null) is { ReturnType: var retorno } && retorno == typeof(void);

static int ExecutarPorArgumento(List<Type> exercicios, string[] args)
{
    Type? tipo = Selecionar(exercicios, args[0]);

    if (tipo is null)
    {
        Console.WriteLine($"Exercício {args[0]} não encontrado.");
        return 1;
    }

    Console.WriteLine($"--- {FormatarNome(tipo.Name)} ---");
    Executar(tipo);
    return 0;
}

static string FormatarNome(string nome) =>
    string.Join(' ', nome.Replace('_', ' '));

static void Executar(Type type)
{
    try
    {

        object instancia = Activator.CreateInstance(type)!;
        type.GetMethod("Execute")!.Invoke(instancia, null);

    }
    catch (TargetInvocationException ex)
    {
        Console.WriteLine($"Erro ao executar o exercício: {ex.InnerException?.Message}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro ao executar o exercício: {ex.Message}");
    }
}

static Type? Selecionar(List<Type> exercicios, string entrada)
{
    if (int.TryParse(entrada, out int numero))
    {
        return numero >= 1 && numero <= exercicios.Count ? exercicios[numero - 1] : null;
    }

    List<Type> encontrados = exercicios.Where(t => t.Name.Contains(entrada, StringComparison.OrdinalIgnoreCase)).ToList();

    return encontrados.Count == 1 ? encontrados[0] : null;
}

static int MenuInterativo(List<Type> exercicios)
{
    if (exercicios.Count == 0)
    {
        Console.WriteLine("Nenhum exercício encontrado.");
        Console.WriteLine("Crie um arquivo .cs dentro da pasta 'algoritm/' assim:");
        Console.WriteLine("  public class Cap01_MeuAlgoritmo { public void Execute() { ... } }");
        return 0;
    }

    while (true)
    {
        Console.WriteLine();
        Console.WriteLine("Escolha uma das opções abaixo para executar e entender o algoritmo desejado:");
        for (int i = 0; i < exercicios.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {FormatarNome(exercicios[i].Name)}");
        }
        Console.WriteLine("0. Sair");
        Console.Write("> ");

        string? entrada = Console.ReadLine()?.Trim();

        if (entrada is null or "" or "0" or "sair" or "exit")
        {
            return 0;
        }

        Type? alvo = Selecionar(exercicios, entrada);

        if (alvo is null)
        {
            Console.WriteLine("Opção inválida. Digite um número da lista ou parte do nome.");
            continue;
        }

        Console.WriteLine($"\n--- {FormatarNome(alvo.Name)} ---");
        Executar(alvo);

        Console.Write("\nPressione ENTER para voltar ao menu...");
        Console.ReadLine();
    }
}