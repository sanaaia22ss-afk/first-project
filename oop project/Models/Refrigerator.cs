namespace HomeApplianceMaintenanceSystem.Models;

public sealed class Refrigerator : Appliance
{
    public Refrigerator(string deviceId, string customerName, string issueDescription, bool underWarranty)
        : base(deviceId, customerName, issueDescription, underWarranty)
    {
        CalculateRepairCost();
    }

    public override void CalculateRepairCost() => RepairCost = IsUnderWarranty ? 0m : 200m;
}
