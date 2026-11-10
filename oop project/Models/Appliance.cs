using System;

namespace HomeApplianceMaintenanceSystem.Models;

public abstract class Appliance : IRepairable
{
    protected Appliance(string deviceId, string customerName, string issueDescription, bool underWarranty)
    {
        DeviceId = string.IsNullOrWhiteSpace(deviceId) ? throw new ArgumentException("معرّف الجهاز مطلوب.", nameof(deviceId)) : deviceId;
        CustomerName = string.IsNullOrWhiteSpace(customerName) ? throw new ArgumentException("اسم العميل مطلوب.", nameof(customerName)) : customerName;
        IssueDescription = string.IsNullOrWhiteSpace(issueDescription) ? throw new ArgumentException("وصف العطل مطلوب.", nameof(issueDescription)) : issueDescription;
        IsUnderWarranty = underWarranty;
        Status = "قيد الفحص";
    }

    public string DeviceId { get; }
    public string CustomerName { get; }
    public string IssueDescription { get; }
    public string Status { get; set; }
    public bool IsUnderWarranty { get; }
    public decimal RepairCost { get; protected set; }

    public abstract void CalculateRepairCost();

    public virtual void DisplayDetails()
    {
        Console.WriteLine($"معرّف الجهاز: {DeviceId}");
        Console.WriteLine($"اسم العميل: {CustomerName}");
        Console.WriteLine($"وصف المشكلة: {IssueDescription}");
        Console.WriteLine($"الحالة: {Status}");
        Console.WriteLine($"تكلفة الإصلاح: {RepairCost:0.00} ر.س");
    }

    public string GetStatus() => Status;
}
