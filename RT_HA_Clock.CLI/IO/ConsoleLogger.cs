using RT_HA_Clock.LIB.Interfaces.Services.IO;

namespace RT_HA_Clock.CLI.IO;
public class ConsoleLogger : IWriter, IReader
{
    public void Clear()
    {
        Console.Clear();
    }

    public void Write(string text)
    {
        Console.WriteLine(text);
    }

    public string Read()
    {
        return Console.ReadLine() ?? String.Empty;
    }
}