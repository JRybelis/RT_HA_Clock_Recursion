using System.ComponentModel.DataAnnotations;

namespace RT_HA_Clock.LIB.Models;
public class UserInput
{
    [Range(0, 24)]
    public int HoursInput { get; set; }
    
    [Range(0, 59)]
    public int MinutesInput { get; set; }
}