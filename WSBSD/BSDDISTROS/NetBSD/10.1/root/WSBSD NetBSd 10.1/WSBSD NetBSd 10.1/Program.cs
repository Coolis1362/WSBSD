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
}
