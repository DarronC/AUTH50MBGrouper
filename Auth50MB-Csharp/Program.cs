using System;
using System.IO;

namespace Auth50MB_Csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please Supply Arguments");
                Console.WriteLine("Arg1: ReadFrom, Arg2: WriteTo");
            } 

            
            DirectoryInfo masterfolder = new DirectoryInfo(@"C:\Users\DCharles\Desktop\Auths_21");
            
            var filesArr = masterfolder.GetFiles();
            int i = 1;
            int filesizelimit = 50000000; //Bytes. 50MB
            double totalFileSize = 0;
            double stagingFileSize = 0;
            bool stageMode = false;
            bool firstCheck = true;
            string writingFolder = @"C:\Users\DCharles\Desktop\New folder\AUTH2023-074-" + i.ToString("00");
            string stagingFolder = @"C:\Users\DCharles\Desktop\New folder\Stag";
            string previousSnip = "";
            Directory.CreateDirectory(stagingFolder);
            DirectoryInfo Stag = new DirectoryInfo(stagingFolder);
            Directory.CreateDirectory(writingFolder);
            foreach (var file in filesArr)
            {                
                string writingFile = writingFolder + @"\"+file.Name;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine((totalFileSize / 1000000)+"MB------"+file.Name.ToString());
                string filename = file.Name.ToString();
                writingFolder = @"C:\Users\DCharles\Desktop\New folder\AUTH2023-074-" + i.ToString("00");
                if (!Directory.Exists(writingFolder))
                {
                    Directory.CreateDirectory(writingFolder);
                } 
                if (!filename.Contains("CA"))
                {
                    firstCheck = true;
                    if (stageMode == true)
                    {
                        StageMover(ref i, ref totalFileSize, ref stagingFileSize, ref stageMode, writingFolder, stagingFolder, filesizelimit); //next file is not CA and program is in stagemode                                                                                               //
                    }
                    if (file.Length + totalFileSize < filesizelimit)
                    {
                       
                        file.CopyTo(writingFile);
                        totalFileSize += file.Length;
                    }
                    else
                    {
                        i += 1;
                        writingFolder = @"C:\Users\DCharles\Desktop\New folder\AUTH2023-074-" + i.ToString("00");
                        Directory.CreateDirectory(writingFolder);
                        file.CopyTo(writingFile);
                        totalFileSize = file.Length;
                    }
                }
                else //When CA in name place in stag folder
                {   
                    //if snip changes AND staging folder is at least 5MB from 50MB, Move now. this prevents many folders with just 1 or 2 CAs
                    if (previousSnip != file.Name.ToString().Substring(24, 5) && firstCheck == false)// && stagingFileSize > filesizelimit - 5000000) 
                    {
                        StageMover(ref i, ref totalFileSize, ref stagingFileSize, ref stageMode, writingFolder, stagingFolder, filesizelimit);
                    }
                    stageMode = true;
                    previousSnip = file.Name.ToString().Substring(24, 5);
                    firstCheck = false;
                    file.CopyTo(stagingFolder + @"\" + file.Name);
                    stagingFileSize += file.Length; //move to stag folder 
                }

            }

            if (Stag.GetFiles().Length > 0)
            {
                StageMover(ref i, ref totalFileSize, ref stagingFileSize, ref stageMode, writingFolder, stagingFolder, filesizelimit);
            }
            //batch file here for /d %%X in (*) do "%ProgramFiles%\7-Zip\7z.exe" a "%%X.zip" ".\%%X\*"

        }

        private static void StageMover(ref int i, ref double totalFileSize, ref double stagingFileSize, ref bool stageMode, string writingFolder, string stagingFolder, int filesizelimit)
        {
            FileInfo[] stageArr = new DirectoryInfo(stagingFolder).GetFiles();

            if (stagingFileSize + totalFileSize < filesizelimit)
            {
                foreach (var stagefile in stageArr)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("[[Staging Mode]] to Writing Folder");
                    Console.WriteLine((totalFileSize / 1000000) + "MB------" + stagefile.Name.ToString());
                    string stagFile = writingFolder + @"\" + stagefile.Name;
                    stagefile.MoveTo(stagFile);               
                    totalFileSize += stagefile.Length;
                }
                //copy all files from stage to writing
            }
            else
            {
                //copy all files from stage to new appended folder
                i += 1;
                writingFolder = @"C:\Users\DCharles\Desktop\New folder\AUTH2023-074-" + i.ToString("00");
                Directory.CreateDirectory(writingFolder);
                totalFileSize = 0;
                foreach (var stagefile in stageArr)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("[[Staging Mode]] to New Folder(s)");
                    Console.WriteLine((totalFileSize / 1000000) + "MB------" + stagefile.Name.ToString());
                    if (totalFileSize > 50000000)
                    {
                        i += 1;
                        writingFolder = @"C:\Users\DCharles\Desktop\New folder\AUTH2023-074-" + i.ToString("00");
                        Directory.CreateDirectory(writingFolder);
                        totalFileSize = 0;
                    }
                        string stageingFile = writingFolder + @"\" + stagefile.Name;
                        stagefile.MoveTo(stageingFile);
                        totalFileSize += stagefile.Length;
                    
                }
            }
            stageMode = false;
            stagingFileSize = 0;
        }
    }
}
