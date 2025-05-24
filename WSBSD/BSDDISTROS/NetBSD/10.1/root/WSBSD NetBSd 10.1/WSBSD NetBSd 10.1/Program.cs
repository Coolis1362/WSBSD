using System;
using System.Runtime.InteropServices; // Required for DllImport
using System.Windows.Forms;
using System.Management;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;

class Program
{
    [DllImport("kernel32.dll")]
    public static extern ulong GetTickCount64(); // Use Windows API instead

    static string GetUptime()
    {
        ulong uptime = GetTickCount64(); // Call Windows API
        TimeSpan time = TimeSpan.FromMilliseconds(uptime);
        return $"{time.Days} days, {time.Hours} hours, {time.Minutes} mins";
    }
    static void RunCommand(string command)
    {
        ProcessStartInfo psi = new ProcessStartInfo
        {
            FileName = "cmd.exe",
            Arguments = $"/C {command}",
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using (Process process = new Process { StartInfo = psi })
        {
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            Console.WriteLine(output);
        }
    }
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("WSBSD BSD LOADER 1.0.0.2");
        Thread.Sleep(1000);
        Console.WriteLine("Starting WSBSD 1.0.0.2...");
        Thread.Sleep(1000);
        Console.WriteLine("Starting WSBSD UNIX 7.0...");
        Thread.Sleep(1000);
        Console.WriteLine("Starting WSBSD 4.4BSDLite...");
        Thread.Sleep(1000);
        Console.WriteLine("Starting WSBSD NetBSD 10.1 Kernel...");
        Thread.Sleep(1000);
        Console.WriteLine("Starting WSBSD NetBSD 10.1...");
        Thread.Sleep(1000);
        Console.WriteLine("All Kernels started Now Starting WSBSD NetBSD 10.1");
        Thread.Sleep(1000);
        Console.WriteLine("NetBSD Started Booting sh...");
        Thread.Sleep(1000);
        Console.Clear();

    }
}
