using WpfApp1.Integration.Models;

namespace WpfApp1.Integration.Contracts;

public interface IMarkingService
{
    Marking? GetMission();
}