using System;
using System.Collections.Generic;
using System.Linq;
using HomeApplianceMaintenanceSystem.Models;

namespace HomeApplianceMaintenanceSystem.Services;

public sealed class RepairCenter
{
    private readonly List<Appliance> appliances = [];

    public void AddAppliance(Appliance appliance)
    {
        ArgumentNullException.ThrowIfNull(appliance);

        if (appliances.Any(item => item.DeviceId.Equals(appliance.DeviceId, StringComparison.OrdinalIgnoreCase)))
        {
            throw new InvalidOperationException($"الجهاز بالمعرّف {appliance.DeviceId} موجود مسبقًا.");
        }

        appliances.Add(appliance);
        Console.WriteLine($"تمت إضافة الجهاز {appliance.DeviceId} بنجاح.");
    }

    public bool UpdateStatus(string deviceId, string newStatus)
    {
        if (string.IsNullOrWhiteSpace(deviceId))
        {
            throw new ArgumentException("معرّف الجهاز مطلوب.", nameof(deviceId));
        }

        if (string.IsNullOrWhiteSpace(newStatus))
        {
            throw new ArgumentException("الحالة الجديدة مطلوبة.", nameof(newStatus));
        }

        Appliance? appliance = appliances.FirstOrDefault(item =>
            item.DeviceId.Equals(deviceId, StringComparison.OrdinalIgnoreCase));

        if (appliance is null)
        {
            Console.WriteLine("الجهاز غير موجود.");
            return false;
        }

        appliance.Status = newStatus;
        Console.WriteLine($"تم تحديث حالة الجهاز {deviceId} إلى: {newStatus}");
        return true;
    }

    public void ListAllAppliances()
    {
        Console.WriteLine("\n--- قائمة الأجهزة في مركز الصيانة ---");

        if (appliances.Count == 0)
        {
            Console.WriteLine("لا توجد أجهزة مسجلة.");
            return;
        }

        foreach (Appliance appliance in appliances)
        {
            appliance.DisplayDetails();
            Console.WriteLine("-------------------------------------------");
        }
    }

    public decimal GetTotalRevenue()
    {
        decimal total = appliances.Sum(appliance => appliance.RepairCost);
        Console.WriteLine($"\nإجمالي الإيرادات المتوقعة: {total:0.00} ر.س");
        return total;
    }
}
