namespace HomeApplianceMaintenanceSystem.Models;

public sealed class AirConditioner : Appliance
{
    public AirConditioner(string deviceId, string customerName, string issueDescription, bool underWarranty)
        : base(deviceId, customerName, issueDescription, underWarranty)
    {
        CalculateRepairCost();
    }

    public override void CalculateRepairCost() => RepairCost = IsUnderWarranty ? 0m : 250m;
}
