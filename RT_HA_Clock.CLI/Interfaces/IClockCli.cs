namespace RT_HA_Clock.CLI.Interfaces;
public interface IClockCli
{
    void Run();
    void DisplayMainMenu();
    string GetUserInput();
    uint CollectHourValue();
    uint CollectMinuteValue();
    bool IsUserContinuing();
}