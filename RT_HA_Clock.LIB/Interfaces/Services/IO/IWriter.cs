namespace RT_HA_Clock.LIB.Interfaces.Services.IO;
public interface IWriter
{
    void Clear();
    void Write(string text);
}