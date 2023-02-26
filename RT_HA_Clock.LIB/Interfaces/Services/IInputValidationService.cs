namespace RT_HA_Clock.LIB.Interfaces.Services;
public interface IInputValidationService
{
    bool ValidateHours(uint hours);
    bool ValidateMinutes(uint minutes);
}