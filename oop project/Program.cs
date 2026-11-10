using System;
using System.Text;
using HomeApplianceMaintenanceSystem.Models;
using HomeApplianceMaintenanceSystem.Services;

namespace HomeApplianceMaintenanceSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);
            Console.InputEncoding = Encoding.UTF8;
            RepairCenter center = new RepairCenter();

            center.AddAppliance(new WashingMachine("WM-001", "أحمد العلي", "عطل في المحرك", true));
            center.AddAppliance(new Refrigerator("REF-002", "محمد أحمد", "مشكلة في التبريد", true));
            center.AddAppliance(new AirConditioner("AC-003", "ساره حسن", "تعبئة غاز", true));

            center.ListAllAppliances();
            center.GetTotalRevenue();

            center.UpdateStatus("WM-001", "تم الإصلاح");
            center.ListAllAppliances();

            Console.WriteLine("\nاضغط على أي مفتاح للخروج...");
            if (Console.IsInputRedirected)
            {
                Console.ReadLine();
            }
            else
            {
                Console.ReadKey();
            }
        }
    }
}