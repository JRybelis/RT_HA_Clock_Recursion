using RT_HA_Clock.CLI.Interfaces;
using RT_HA_Clock.LIB.Models;
using RT_HA_Clock.LIB.Interfaces.Services;
using RT_HA_Clock.LIB.Interfaces.Services.IO;

namespace RT_HA_Clock.CLI;
public class ClockCli : IClockViewService, IClockCli
{
    private readonly IWriter _writer;
    private readonly IReader _reader;
    private readonly IInputValidationService _inputValidationService;
    private readonly IAnalogClockService _analogClockService;
    
    public ClockCli(IWriter writer, IReader reader, 
    IInputValidationService inputValidationService,
    IAnalogClockService analogClockService)
    {
        _writer = writer;
        _reader = reader;
        _inputValidationService = inputValidationService;
        _analogClockService = analogClockService;
    }

    public void Run()
    {
        bool isRunning = true;
        UserTimeInput userTimeInput = new();

        do
        {
            DisplayMainMenu();

            userTimeInput.HoursInput = CollectHourValue();
            userTimeInput.MinutesInput = CollectMinuteValue();
            
            DisplayCalculatedAngle(userTimeInput);

            if(!IsUserContinuing())
                isRunning = false;

        } while (isRunning);
    }

    public void DisplayMainMenu()
    {
        DisplayConsoleAppHeader();
        _writer.Write(@"    ^ ^                 ");
        _writer.Write(@"   (O,O)                ");
        _writer.Write(@"  (   ) How it works    ");
        _writer.Write(@"-"" - ""------------------");
        _writer.Write(Environment.NewLine);
        _writer.Write("Enter a the hour of the day.");
        _writer.Write("Then, enter a the minute of that hour.");
        _writer.Write("The Clock arm angle calculator will do its magic.");
        _writer.Write("And return the value of the smaller angle between the clock arms for the time you chose.");
        _writer.Write(Environment.NewLine);
        _writer.Write(@"█▓▒▒░░░Try it:░░░▒▒▓█");
        _writer.Write(Environment.NewLine);
    }

    private void DisplayConsoleAppHeader()
    {
        _writer.Clear();
        _writer.Write(@".'`~~~~~~~~~~~`'.");
        _writer.Write(@"(  .'11 12 1'.  )");
        _writer.Write(@"|  :10 \|   2:  |");
        _writer.Write(@"|  :9   @   3:  |");
        _writer.Write(@"|  :8       4;  |");
        _writer.Write(@"'. '..7 6 5..' .'");
        _writer.Write(@" ~-------------~ ");
        _writer.Write(Environment.NewLine);
        _writer.Write(Environment.NewLine);
        _writer.Write(Environment.NewLine);
    }

public string GetUserInput()
    {
        const int maxUserInputLength = 2;
        const int minUserInputLength = 1;
        string userInputString = _reader.Read();

        while(userInputString.Length > maxUserInputLength 
        || userInputString.Length < minUserInputLength
        || UInt32.TryParse(userInputString, out uint userInputUint) == false)
        {
            _writer.Write($"Please enter between {minUserInputLength} and {maxUserInputLength} positive digits.");
            userInputString = _reader.Read();
        }

        return userInputString;
    }

    public uint CollectHourValue()
    {
        bool doesUserInputCorrespondToAnHourOnA24hClock = false;
        uint hour = 0;

        while (!doesUserInputCorrespondToAnHourOnA24hClock)
        {
            _writer.Write("Please provide a desired hour value, on a 24 hour day, in digits:");
            hour = UInt32.Parse(GetUserInput());

            if (_inputValidationService.ValidateHours(hour))
                doesUserInputCorrespondToAnHourOnA24hClock = true;
        }
        
        return hour;
    }

    public uint CollectMinuteValue()
    {
        bool doesUserInputCorrespondToMinutes = false;
        uint minutes = 0;

        while (!doesUserInputCorrespondToMinutes)
        {
            _writer.Write("Please provide a desired minute value, in digits:");
            minutes = UInt32.Parse(GetUserInput());

            if (_inputValidationService.ValidateMinutes(minutes))
                doesUserInputCorrespondToMinutes = true;
        }

        return minutes;
    }

    public void DisplayCalculatedAngle(UserTimeInput userTimeInput)
    {
        var angle = _analogClockService.CalculateSmallerAngleBetweenClockArms(userTimeInput);

        _writer.Write(Environment.NewLine);
        _writer.Write($"Excellent, you have decided to check the time {userTimeInput.HoursInput} : {userTimeInput.MinutesInput}.");
        _writer.Write($"On an analog clock, the arms marking the time create a {angle} degree angle.");
        _writer.Write(Environment.NewLine);
    }

    public bool IsUserContinuing()
    {
        string userInput;
        do
        {
            _writer.Write("Would you like to pass another time to see the angle its clock arms form? (Y/N):");
            userInput = _reader.Read().ToUpper();
        } while (!userInput.Equals("Y") && !userInput.Equals("N"));

        if (userInput == "Y")
            return true;

        _writer.Write("Thank you for your contribution. Goodbye!");

        return false;
    }
}