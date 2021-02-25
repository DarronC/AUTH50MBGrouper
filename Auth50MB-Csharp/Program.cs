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
            string writingFolder = @"C:\Users\DCharles\Desktop\New folder\AUTH2023-074-" + i.ToString("00");
            string stagingFolder = @"C:\Users\DCharles\Desktop\New folder\Stag";
            foreach (var file in filesArr)
            {
                
                string writingFile = writingFolder + @"\"+file.Name;
                
                Directory.CreateDirectory(writingFolder);
                Directory.CreateDirectory(stagingFolder);
                Console.WriteLine(file.Name);
                if  (!file.Name.ToString().Contains("CA"))
                {
                    if (stageMode == true)
                    {
                        Stager(ref i, ref totalFileSize, ref stagingFileSize, writingFolder, stagingFolder);
                    }
                    if (file.Length + totalFileSize < 50000000)
                    {
                        file.CopyTo(writingFile);
                        totalFileSize += file.Length;
                    }
                    else
                    {                    
                        i += 1;
                        file.CopyTo(writingFile);
                        totalFileSize = file.Length;
                    }                    
                }
                else
                {
                    stageMode = true;
                    file.CopyTo(stagingFolder + @"\"+file.Name);
                    stagingFileSize += file.Length;
                }

                

            }
            DirectoryInfo Stag = new DirectoryInfo(stagingFolder);
            if (Stag.GetFiles().Length > 0)
            {
                Stager(ref i, ref totalFileSize, ref stagingFileSize, writingFolder, stagingFolder);
            }           

        }

        private static void Stager(ref int i, ref double totalFileSize, ref double stagingFileSize, string writingFolder, string stagingFolder)
        {
            FileInfo[] stageArr = new DirectoryInfo(stagingFolder).GetFiles();

            if (stagingFileSize + totalFileSize < 50000000)
            {
                foreach (var stagefile in stageArr)
                {
                    string stagFile = writingFolder + @"\" + stagefile.Name;
                    stagefile.CopyTo(stagFile);
                    totalFileSize += stagefile.Length;
                    stagefile.Delete();
                }
                //copy all files from stage to writing
            }
            else
            {
                //copy all files from stage to new appended folder
                foreach (var stagefile in stageArr)
                {
                    i += 1;
                    string stageingFile = writingFolder + @"\" + stagefile.Name;
                    stagefile.CopyTo(stageingFile);
                    totalFileSize = stagefile.Length;
                    stagefile.Delete();
                }

            }
            stagingFileSize = 0;
        }
    }
}
