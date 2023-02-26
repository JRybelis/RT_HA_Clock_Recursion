namespace RT_HA_Clock.CLI.Interfaces;
public interface IClockCli
{
    string GetUserInput();
    bool IsUserContinuing();
    void Run();
}