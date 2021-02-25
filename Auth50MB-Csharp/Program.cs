using System;
using System.IO;

namespace Auth50MB_Csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo masterfolder = new DirectoryInfo(@"C:\Users\DCharles\Desktop\Auths_21");
            
            var filesArr = masterfolder.GetFiles();
            int i = 1;
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
                Console.WriteLine((totalFileSize / 1000000)+"MB------"+file.Name.ToString());
                string filename = file.Name.ToString();
                writingFolder = @"C:\Users\DCharles\Desktop\New folder\AUTH2023-074-" + i.ToString("00");
                if (!Directory.Exists(writingFolder))
                {
                    Directory.CreateDirectory(writingFolder);
                } 
                if (!filename.Contains("CA"))
                {
                    if (stageMode == true)
                    {
                        Stager(ref i, ref totalFileSize, ref stagingFileSize, ref stageMode, writingFolder, stagingFolder); //next file is not CA and program is in stagemode                                                                                               //
                    }
                    if (file.Length + totalFileSize < 50000000)
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
                    

                    if (previousSnip != file.Name.ToString().Substring(24, 5) && firstCheck == false)
                    {
                       
                        Stager(ref i, ref totalFileSize, ref stagingFileSize, ref stageMode, writingFolder, stagingFolder);
                    }
                    stageMode = true;
                    previousSnip = file.Name.ToString().Substring(24, 5);
                    firstCheck = false;
                    file.CopyTo(stagingFolder + @"\" + file.Name);
                    stagingFileSize += file.Length;
                }

            }

            if (Stag.GetFiles().Length > 0)
            {
                Stager(ref i, ref totalFileSize, ref stagingFileSize, ref stageMode, writingFolder, stagingFolder);
            }
            //batch file here for /d %%X in (*) do "%ProgramFiles%\7-Zip\7z.exe" a "%%X.zip" ".\%%X\*"

        }

        private static void Stager(ref int i, ref double totalFileSize, ref double stagingFileSize, ref bool stageMode, string writingFolder, string stagingFolder)
        {
            FileInfo[] stageArr = new DirectoryInfo(stagingFolder).GetFiles();

            if (stagingFileSize + totalFileSize < 50000000)
            {
                foreach (var stagefile in stageArr)
                {
                    string stagFile = writingFolder + @"\" + stagefile.Name;
                    stagefile.CopyTo(stagFile);                    
                    stagefile.Delete();
                    stageMode = false;
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
                    string stageingFile = writingFolder + @"\" + stagefile.Name;
                    stagefile.CopyTo(stageingFile);                    
                    stagefile.Delete();
                    stageMode = false;
                    totalFileSize += stagefile.Length;
                }

            }
            stagingFileSize = 0;
        }
    }
}
