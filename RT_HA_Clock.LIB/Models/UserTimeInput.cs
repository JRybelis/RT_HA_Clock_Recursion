using System.ComponentModel.DataAnnotations;

namespace RT_HA_Clock.LIB.Models;
public class UserTimeInput
{
    [Range(0, 24)]
    public uint HoursInput { get; set; }
    
    [Range(0, 59)]
    public uint MinutesInput { get; set; }
}