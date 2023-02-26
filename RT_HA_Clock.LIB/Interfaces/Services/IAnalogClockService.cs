namespace RT_HA_Clock.LIB.Interfaces.Services;
public interface IAnalogClockService
{
    int FindShortArmPosition();
    int FindLongArmPosition();
    int FindSmallerAngleBetweenClockArms();
    int CalculateSmallerAngleBetweenClockArms();
}