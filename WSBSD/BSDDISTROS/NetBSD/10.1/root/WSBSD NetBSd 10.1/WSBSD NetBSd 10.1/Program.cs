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
        Console.WriteLine($"System Uptime: {GetUptime()}");
        while (true)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string fixedPath = currentDirectory.Replace('\\', '/');
            Console.Write("\n# ");
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
                Console.WriteLine("Available commands: neofetch, clear, exit, help, ls, cd, echo, cat, about, pkg install, wine, whoami (More Commands Are In The Works)");
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
                Console.WriteLine("WSBSD Terminal v1.0.0.1 - A simple terminal emulator (And Windows Subsystem) for BSD distros.");
                Console.WriteLine("Developed by Coolis1362");
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
                Console.WriteLine("USER: root (Administrator)");
                Thread.Sleep(1000);
                Console.WriteLine($"WINDOWS USER: {Environment.UserName}");
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
        string asciiLogo = @" 
                                        ........:::::::.......                                      
                                  .....-=+******************+=-:....                                
                                ..=+*******************************=:.                              
                            ..-+**************************************+=:.                          
                         ..-+********************************************+=:.                       
                       .:+**************************************************+-..                    
                    ..-+******************************************************+=..                  
                  ..-+***********************************************************-..                
                 .:+**************************************************************+-.               
               ..=******************************************************************=:.             
               :+********************************************************#########****-.            
             .:*************************************************+=:.........    .........           
            .-******************************************+=-:....           ....:-===++++-.          
           .-*************************************+=-:..             ...-=++*************=.         
          ..:-==+*************************++=--:..              ...-=+********************-.        
          .+-.  ...::--====++++====---:....                 ..:-=+**+++=========+++********:.       
        ...:+-.                                         ...:-==::...               ..:-=+**+:.      
        .::.:+-.                                        ...             .....::--=======---=-..     
       ..++..-*-.                                                  ....-=********************:.     
       .:**+..-*-                                               ..-+*************************-.     
       .=***+..-*-.                                         ..-+*****************************+..    
      ..+****=..-*-.                                    ..-+**********************************:.    
      .:******= .=*-.                                .-=+*************************************:.    
      .:*******- .=*-.                           .-=+*****************************************-.    
      .:*******+: .=*-.                    ...:=+*********************************************-.    
      .:********+: .=*-....         .....:-+**************************************************-.    
      .:*********+. .=***+==-::::--=++********************************************************:.    
      ..+*********+. .=***********************************************************************:.    
       .=**********=..:=*********************************************************************+..    
       .:***********-..:+********************************************************************-.     
       ..+***********-..:+******************************************************************+:.     
        .-***********+:..:+*****************************************************************-.      
         .=***********+:..:+***************************************************************+..      
         .:+***********=:..-***************************************************************:.       
          .:************=.  -*************************************************************-.        
           .:************=.  -***********************************************************-.         
            .:************-. .=*********************************************************-..         
             .:************-. .=*******************************************************-.           
              ..=**********+:  .=****************************************************+:.            
               ..-**********+:  .=**************************************************=..             
                 .:=*********+:  .+***********************************************+:.               
                   .:+********=.  :+********************************************+-.                 
                     .:+*******-.  :+*****************************************+-.                   
                       .:=******-.  :+**************************************+:.                     
                          .:+****-.  :+**********************************+-.                        
                            ..:=*+:. .:+******************************+-...                         
                               .....  .-+*************************=-:..                             
                                       .:=++**************++=-::...                                 
                                            .....::::.....                             
        ";
        string systemInfo = $"\u001b[38;2;203;65;44m" + $@"
        User: {Environment.UserName}
        Machine: {Environment.MachineName}
        OS: FreeBSD 14.2-RELEASE On {Environment.OSVersion.VersionString} amd64 (x64 or 64 Bits)
        Kernel: FREEBSDKERNEL: NetBSD 10.1 | BSDKENREL: 4.4BSD-Lite | UNIXKERNEL: Unix Kernel v7.0 | WSBSDKERNEL: WSBSD1.0.0.2
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
                Console.WriteLine("\u001b[38;2;203;65;44m" + line + "\u001b[0m");
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
    }
 }
