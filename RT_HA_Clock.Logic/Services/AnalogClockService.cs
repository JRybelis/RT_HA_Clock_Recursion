using RT_HA_Clock.LIB.Interfaces.Services;
using RT_HA_Clock.LIB.Models;

namespace RT_HA_Clock.Logic.Services;
public class AnalogClockService : IAnalogClockService
{
    public int CalculateSmallerAngleBetweenClockArms(UserTimeInput userTimeInput)
    {
        const int clockCircumferenceDegree = 360;
        const int halfOfClockCircumferenceDegree = 180;
        const int clockArmPositionMarkDegree = 6;

        var shortArmPosition = FindShortArmPosition(userTimeInput);
        var shortArmPositionDegree = (int) shortArmPosition * clockArmPositionMarkDegree;
        var longArmPositionDegree = (int) userTimeInput.MinutesInput * clockArmPositionMarkDegree;

        var lesserAngle = Math.Abs(shortArmPositionDegree - longArmPositionDegree);
        if(lesserAngle > halfOfClockCircumferenceDegree)
            lesserAngle = clockCircumferenceDegree - lesserAngle;

        return lesserAngle;
    }

    public uint FindShortArmPosition(UserTimeInput userTimeInput)
    {
        var hours = NormalizeHours(userTimeInput.HoursInput);
        var positionByTheHour = hours * 5;
        uint positionAdjustmentMark = 
        FindShortArmPositionAdjustmentMark(userTimeInput.MinutesInput);

        var shortArmPosition = positionByTheHour + positionAdjustmentMark;

        // if past midday or midnight, treat it as past 00 mark
        if(shortArmPosition > 60)
            shortArmPosition -= 60;

        return shortArmPosition;
    }

    private static uint FindShortArmPositionAdjustmentMark(uint minutes)
    {
        uint positionAdjustmentMark = 0;

        switch (minutes)
        {
            case > 0 and < 15:
                positionAdjustmentMark = 1;
                break;
            case >= 15 and < 30:
                positionAdjustmentMark = 2;
                break;
            case >= 30 and < 45:
                positionAdjustmentMark = 3;
                break;
            case >= 45:
                positionAdjustmentMark = 4;
                break;
        }

        return positionAdjustmentMark;
    }

    private static uint NormalizeHours(uint hours)
    {
        if (hours > 12)
            hours -= 12;

        return hours;
    }
}