using RT_HA_Clock.LIB.Models;

namespace RT_HA_Clock.LIB.Interfaces.Services;
public interface IAnalogClockService
{
    uint FindShortArmPosition(UserTimeInput userTimeInput);
    int CalculateSmallerAngleBetweenClockArms(UserTimeInput userTimeInput);
}