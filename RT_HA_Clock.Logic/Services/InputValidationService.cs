using RT_HA_Clock.LIB.Interfaces.Services;

namespace RT_HA_Clock.Logic.Services;
public class InputValidationService : IInputValidationService
{
    public bool ValidateHours(uint hours)
    {
        return hours <= 24;
    }
    public bool ValidateMinutes(uint minutes)
    {
        return minutes <= 59;
    }
}