namespace HomeApplianceMaintenanceSystem.Models;

public sealed class WashingMachine : Appliance
{
    public WashingMachine(string deviceId, string customerName, string issueDescription, bool underWarranty)
        : base(deviceId, customerName, issueDescription, underWarranty)
    {
        CalculateRepairCost();
    }

    public override void CalculateRepairCost() => RepairCost = IsUnderWarranty ? 0m : 150m;
}
