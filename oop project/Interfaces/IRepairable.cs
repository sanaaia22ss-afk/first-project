namespace HomeApplianceMaintenanceSystem.Models
{
    public interface IRepairable
    {
        void DisplayDetails();
        string GetStatus();
    }
}