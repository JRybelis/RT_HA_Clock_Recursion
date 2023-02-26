using RT_HA_Clock.LIB.Models;

namespace RT_HA_Clock.LIB.Interfaces.Services;
public interface IClockViewService
{
    void DisplayCalculatedAngle(UserTimeInput userTimeInput);
}