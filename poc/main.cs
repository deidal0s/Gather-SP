using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class get_system_process
{
    public static void GetAllProcesses()
    {
        Process[] processes = Process.GetProcesses();
        foreach (Process p in processes)
        {
            Console.WriteLine("Name     PID     Memory      CPU     Start Time      User        Status      Priority        Name\n");
            Console.WriteLine(
                "{0,-10} {1,-5} {2,-10} {3,-10} {4,-20} {5,-10} {6,-10} {7,-10} {8,-10}",
                p.ProcessName, 
                p.Id, 
                p.WorkingSet64, 
                p.TotalProcessorTime, 
                p.StartTime, 
                p.UserProcessorTime, 
                p.Responding, 
                p.BasePriority, 
                p.MainModule.ModuleName
            );
        }
    }
}

public class Check_for_vm
{
    public static void Check_VM()
    {
        string[] lines = System.IO.File.ReadAllLines(@"C:\ProgramData\Microsoft\Virtualization\Virtualization Platform\VMInfo.txt");
        foreach (string line in lines)
        {
            if (line.Contains("VM"))
            {
                Console.WriteLine("[ DEBUG ] Virtual Machine Detected");
                System.Threading.Thread.Sleep(2000);
            }
        }
    }
}

public class admin_rights
{
    public static void Check_admin_rights()
    {
        string[] lines = System.IO.File.ReadAllLines(@"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Startup\admin.txt");
        foreach (string line in lines)
        {
            if (line.Contains("admin"))
            {
                Console.WriteLine("[ DEBUG ] Admin rights are enabled");
                System.Threading.Thread.Sleep(2000);
                Console.Clear();
            }
        }
    }
}

public class Main
{
    public static void Main()
    {   
        Check_for_vm.Check_VM();
        admin_rights.Check_admin_rights();
        get_system_process.GetAllProcesses();
    }
}
