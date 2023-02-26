namespace RT_HA_Clock.CLI.Interfaces;
public interface IClockCli
{
    string GetUserInput();
    uint CollectHourValue();
    uint CollectMinuteValue();
    bool IsUserContinuing();
    void Run();
}