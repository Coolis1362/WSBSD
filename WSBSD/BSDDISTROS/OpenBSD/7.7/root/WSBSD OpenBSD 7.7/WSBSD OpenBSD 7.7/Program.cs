using System;
using System.Runtime.InteropServices; // Required for DllImport
using System.Windows.Forms;
using System.Management;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using Microsoft.Win32;

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
        Console.WriteLine("WSBSD BSD LOADER 1.0.0.4-1");
        Thread.Sleep(1000);
        Console.WriteLine("Starting WSBSD 1.0.0.4-1...");
        Thread.Sleep(1000);
        Console.WriteLine("Starting WSBSD UNIX 7.0...");
        Thread.Sleep(1000);
        Console.WriteLine("Starting WSBSD 4.4BSDLite...");
        Thread.Sleep(1000);
        Console.WriteLine("Starting WSBSD OpenBSD 7.7 Kernel...");
        Thread.Sleep(1000);
        Console.WriteLine("Starting WSBSD OpenBSD 7.7...");
        Thread.Sleep(1000);
        Console.WriteLine("All Kernels started Now Starting WSBSD OpenBSD 7.7");
        Thread.Sleep(1000);
        Console.WriteLine("OpenBSD Started Booting sh...");
        Thread.Sleep(1000);
        Console.Clear();
        Console.WriteLine($"System Uptime: {GetUptime()}\n");
        Console.WriteLine($"OpenBSD/amd64 ({Environment.MachineName}.wsbsd.openbsd)\n");
        Console.Write($"(PASSWORD IS '{Environment.MachineName}') LOGIN: ");
        string domain = $"{Environment.MachineName}.wsbsd.openbsd";
        string username = Console.ReadLine()?.Trim(); // Read username input
        bool IsRoot; // Declare IsRoot variable here
        string password = Environment.MachineName; // Set password to the machine name
        if (username == "root")
        {
            Console.Write($"PASSWORD: ");
            string inputPassword = Console.ReadLine()?.Trim(); // Read password input
            if (inputPassword == $"{Environment.MachineName}")
            {
                Console.WriteLine("Login successful.");
            }
            else
            {
                Console.WriteLine("Incorrect password. Exiting WSBSD terminal.");
                return; // Exit if the password is incorrect
            }
            Console.WriteLine($"Welcome,  root");
            IsRoot = true; // Set IsRoot to true if the user is root
        }
        else
        {
            Console.Write($"PASSWORD: ");
            string inputPassword = Console.ReadLine()?.Trim(); // Read password input
            if (inputPassword == $"{Environment.MachineName}")
            {
                Console.WriteLine("Login successful.");
            }
            else
            {
                Console.WriteLine("Incorrect password. Exiting WSBSD terminal.");
                return; // Exit if the password is incorrect
            }
            Console.WriteLine($"Welcome,  root");
            IsRoot = false; // Set IsRoot to false if the user is not root
        }
            Console.WriteLine($"Login Time: {DateTime.Now.ToString()}");
            Console.WriteLine($"OpenBSD 7.7 (GENERIC) #619: Sun Apr 13 08:19:34 MDT 2025\n");
            Console.WriteLine($"Welcome to OpenBSD: The proactively secure Unix-like operating system\n");
            Console.WriteLine($"Please Report Bugs In This Link In Your Windows Browser: https://github.com/TTSConsulting/WSBSD/issues\n");
            
            while (true)
            {
                string currentDirectory = Directory.GetCurrentDirectory();
                string fixedPath = currentDirectory.Replace('\\', '/');
                string prompt = IsRoot ? $"{Environment.MachineName}#" : $" {Environment.MachineName}$"; // Switch prompt dynamically
                Console.Write($"{prompt} ");
                string command = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(command))
                    continue;
                if (command == "neofetch")
                {
                    Neofetch();
                }
                else if (command == "clear")
                {
                    Console.Clear();
                }
                else if (command == "exit")
                {
                    Console.WriteLine("Exiting WSBSD terminal.");
                    break;
                }
                else if (command == "help")
                {
                    Console.WriteLine("Available commands: neofetch, clear, exit, help, ls, cd, echo, cat, about, pkg install, wine, whoami, vi, uname (More Commands Are In The Works)");
                }
                else if (command == "ls")
                {
                    string[] files = Directory.GetFiles(currentDirectory);
                    foreach (string file in files)
                    {
                        Console.WriteLine(Path.GetFileName(file));
                    }
                }
                else if (command.StartsWith("cd "))
                {
                    string path = command.Substring(3).Trim();
                    if (Directory.Exists(path))
                    {
                        Directory.SetCurrentDirectory(path);
                    }
                    else
                    {
                        Console.WriteLine($"Directory '{path}' not found.");
                    }
                }
                else if (command.StartsWith("echo "))
                {
                    string print_request = command.Substring(5);
                    Console.WriteLine(print_request);

                }
                else if (command.StartsWith("cat "))
                {
                    string filePath = command.Substring(4).Trim();
                    CatCommand(filePath);
                }
                else if (command == "about")
                {
                    Console.WriteLine("WSBSD Terminal v1.0.0.4-1 - A simple terminal emulator (And Windows Subsystem) for BSD distros.");
                    Console.WriteLine("Developed by Coolis1362");
                    Console.WriteLine("Made On: Visual Studio 2022 17.14.2 Preview 1.0");
                    Console.WriteLine("Written in: C# 8.0");
                    Console.WriteLine("Compiled With: .NET Framework v4.7.2");
                    Console.WriteLine("License (Source Code): MIT License (No rights Reserved)");
                    Console.WriteLine("License (Binary): Copyright (All Rights Reserved), and you can not use this for illegal purposes.");
                }
                else if (command.StartsWith("pkg install "))
                {
                    string msi_name = command.Substring(12).Trim();
                    RunCommand($"{currentDirectory}\\{msi_name}.msi");
                }
                else if (command.StartsWith("wine "))
                {
                    string exe_name = command.Substring(5).Trim();
                    RunCommand($"{currentDirectory}\\{exe_name}.exe");
                }
                else if (command == "whoami")
                {
                    Console.WriteLine($"WSBSD USER: {username}");
                    Thread.Sleep(1000);
                    Console.WriteLine($"WINDOWS USER: {Environment.UserName}");
                }
                else if (command.StartsWith("vi "))
                {
                    string filePath = command.Substring(3).Trim();
                    Vi(filePath);
                }
                else if (command == "uname")
                {
                Console.WriteLine($"OpenBSD {domain} 7.7 GENERIC#619 amd64 (x64 or 64-Bits)");
                }
                else
                {
                Console.WriteLine($"Command '{command}' not recognized. Type 'help' for a list of commands.");
                }

            }
            static string GetCPUInfo()
            {
                ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
                foreach (ManagementObject mo in mos.Get())
                {
                    return mo["Name"].ToString();
                }
                return "Unknown CPU";

            }
            static string GetRAMInfo()
            {
                ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem");
                foreach (ManagementObject mo in mos.Get())
                {
                    return $"{Math.Round(Convert.ToDouble(mo["TotalPhysicalMemory"]) / 1073741824, 2)} GB";
                }
                return "Unknown RAM";
            }
            static void Neofetch()
            {
                Console.WriteLine("Starting Neofetch..."); // Debug message
                string asciiLogo = @"      :=*####*+:.. =*#######***+-.  .:+#####*###########***=:..    
    .:*%*--+%%+--#%-.                              :#%%*****%%****%%+%#**%@@#***%%#****#%#***#%@=.  
   :##=--*%+.:#=--+%=:-==-===:.   .-===-...::-=-:===:.@%****@+@****#@#**%#=:-#%*%@@****%#-*@#***%#:.
 .-%=---%#:. :%=---+====#====*#-+%#====+%%====+%+===#*@%****@%%****%@#*****#%%@%%%%****%#. +%****##.
.:#=---#@:  .**---+%#---#@#---%%=--*@*--#@#---+*%---*#@%*********#%%*%%********%%#%****%#. :%#***#%.
.=#---=%=  .*%---=%%---#@@*--=%=--=*-=*%%@=--=@%+--+%:@%****@*%%****%%%%%%##****#@@****%#. -%****%#.
.=%---*%. :##---#@@*--+@@#--=%*---%@@@*%%+--+%@*---%%%@%****@-*%****#*#%=.:-%#**#@%****%#.-%#***%%-.
 .+%=--#%%#=-=#%*=#=--##=-=#%#%=--=+==%@%--=#%%=---+%%%#****%%%***#@%***#%%%%**#@%%****%%%#**#%%*.  
=#%%@@%%#%%%@@@#+%+--*%%%@@@%%@@@%%%@@@@@%%@@%@@%%@@@@@@@@@@@@@@@@@@@%@@%%%%%@@@@@@@@@@@@@@@@@@%%#*-
%%%%%%%%%%%%%%%@@#---@%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%@%
..------------=#%%%%%%%#------------------------------------------------------------------:::::::::.";
                string BSDDISTRONAME = "OpenBSD";
                string BSDDISTROVERSION = "7.7";
                string systemInfo = $"\u001b[38;5;226m" + $@"
        User: {Environment.UserName}
        Machine: {Environment.MachineName}
        OS: {BSDDISTRONAME} {BSDDISTROVERSION} On {Environment.OSVersion.VersionString} amd64 (x64 or 64 Bits)
        Kernel: FREEBSDKERNEL: OpenBSD 7.7 Kernel | BSDKENREL: 4.4BSD-Lite | UNIXKERNEL: Unix Kernel v7.0 | WSBSDKERNEL: WSBSD1.0.0.4-1
        Uptime: {GetUptime()}
        Shell: sh (Unix V7, 1979)
        CPU: {GetCPUInfo()}
        RAM: {GetRAMInfo()} GB" + "\u001b[0m";


                // 🛠️ **Updated printing method to prevent buffer overload**
                if (!Console.IsOutputRedirected)
                {
                    string[] logoLines = asciiLogo.Split('\n');
                    foreach (string line in logoLines)
                    {
                        Console.WriteLine("\u001b[38;5;226m" + line + "\u001b[0m");
                        System.Threading.Thread.Sleep(10); // Slight delay to prevent buffer issues
                    }
                    ;
                    Console.WriteLine("ASCII Logo Loaded."); // Debug message
                }
                Console.WriteLine(systemInfo);
                Console.WriteLine("System Info Loaded."); // Debug message
                Console.ReadKey(); // Prevents console from closing immediately
            }
            static void CatCommand(string filePath)
            {
                if (File.Exists(filePath))
                {
                    string content = File.ReadAllText(filePath);
                    Console.WriteLine(content);
                }
                else
                {
                    Console.WriteLine($"Error: File '{filePath}' not found.");
                }
            }
            static void Vi(string FilePath)
            {
                Process process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.Arguments = "/c where edit"; // Check if Edit is in the PATH
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true; // Capture errors
                process.StartInfo.UseShellExecute = false;
                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                process.WaitForExit();

                if (!string.IsNullOrWhiteSpace(output))
                {
                    Console.WriteLine("Edit is installed:\n" + output);
                }
                else
                {
                    Console.WriteLine("Edit is NOT installed. Please install it using:\nwinget install --id Microsoft.Edit");
                    if (!string.IsNullOrWhiteSpace(error))
                        Console.WriteLine("Error: " + error);
                }
            }
    }
}