using RT_HA_Clock.LIB.Interfaces.Services;
using RT_HA_Clock.LIB.Models;

namespace RT_HA_Clock.Logic.Services;
public class AnalogClockService : IAnalogClockService
{
    public uint CalculateSmallerAngleBetweenClockArms(UserTimeInput userTimeInput)
    {
        const int clockCircumferenceDegree = 360;
        const int halfOfClockCircumferenceDegree = 180;
        const int clockArmPositionMarkDegree = 6;

        var shortArmPosition = FindShortArmPosition(userTimeInput);
        var shortArmPositionDegree = shortArmPosition * clockArmPositionMarkDegree;
        var longArmPositionDegree = userTimeInput.MinutesInput * clockArmPositionMarkDegree;

        var lesserAngle = (uint) Math.Abs(shortArmPositionDegree - longArmPositionDegree);
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

    private uint FindShortArmPositionAdjustmentMark(uint minutes)
    {
        uint positionAdjustmentMark = 0;

        if (minutes < 15)
            positionAdjustmentMark = 1;
        if (minutes >= 15 && minutes < 30)
            positionAdjustmentMark = 2;
        if (minutes >= 30 && minutes < 45)
            positionAdjustmentMark = 3;
        if (minutes >= 45)
            positionAdjustmentMark = 4;

        return positionAdjustmentMark;
    }

    private uint NormalizeHours(uint hours)
    {
        switch (hours)
        {
            case 13:
                hours = 1;
                break;
            case 14:
                hours = 2;
                break;
            case 15:
                hours = 3;
                break;
            case 16:
                hours = 4;
                break;
            case 17:
                hours = 5;
                break;
            case 18:
                hours = 6;
                break;
            case 19:
                hours = 7;
                break;
            case 20:
                hours = 8;
                break;
            case 21:
                hours = 9;
                break;
            case 22:
                hours = 10;
                break;
            case 23:
                hours = 11;
                break;
            case 24:
                hours = 12;
                break;
        }

        return hours;
    }
}