using System;
using System.IO;

namespace Auth50MB_Csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 5)
            {
                Console.WriteLine("No Arguments passed. Please Supply Arguments");
                Console.WriteLine("Arg1: ReadFrom, Arg2: WriteTo, Arg3: Year, Arg4: Naming Scheme, Arg5: Starting Number");
                return;
            }
            Console.WriteLine($"Write to {args[1]} in progress...");
            DirectoryInfo masterfolder = new DirectoryInfo(args[0].ToString());
            string path = masterfolder.FullName;
            string year = args[2];
            string namesche = args[3];
            var filesArr = masterfolder.GetFiles();
            int i = Convert.ToInt32(args[4]);
            int filesizelimit = 50000000; //Bytes. 50MB
            double totalFileSize = 0;
            double stagingFileSize = 0;
            bool stageMode = false;
            bool firstCheck = true;
            string baseWritingFolder = args[1];
            string writingFolder = baseWritingFolder + @"\" + namesche + year + "-074-" + i.ToString("00");
            string stagingFolder = baseWritingFolder + @"\Stag";
            string previousSnip = "";
            Directory.CreateDirectory(stagingFolder);
            DirectoryInfo Stag = new DirectoryInfo(stagingFolder);
            Directory.CreateDirectory(writingFolder);
            int filecount = 0;
            foreach (var file in filesArr)
            {
                string writingFile = writingFolder + @"\" + file.Name;
                //Console.ForegroundColor = ConsoleColor.White;
                //Console.WriteLine((totalFileSize / 1000000) + "MB------" + file.Name.ToString());
                string filename = file.Name.ToString();
                writingFolder = baseWritingFolder + @"\" + namesche + year + "-074-" + i.ToString("00");
                if (!Directory.Exists(writingFolder))
                {
                    Directory.CreateDirectory(writingFolder);
                }
                if (!filename.Contains("CA"))
                {
                    firstCheck = true;
                    if (stageMode == true)
                    {
                        StageMover(ref i, ref totalFileSize, ref stagingFileSize, ref stageMode, writingFolder, stagingFolder, filesizelimit, ref filecount, baseWritingFolder,year, namesche); //next file is not CA and program is in stagemode                                                                                               //
                    }
                    if (file.Length + totalFileSize < filesizelimit)
                    {

                        file.CopyTo(writingFile,true);
                        filecount += 1;
                        totalFileSize += file.Length;
                    }
                    else
                    {
                        i += 1;
                        writingFolder = baseWritingFolder + @"\" + namesche + year + "-074-" + i.ToString("00");
                        writingFile = writingFolder + @"\" + file.Name;
                        Directory.CreateDirectory(writingFolder);
                        file.CopyTo(writingFile,true);
                        filecount = 1;
                        totalFileSize = file.Length;
                    }
                }
                else //When CA in name place in stag folder
                {
                    //if snip changes AND staging folder is at least 5MB from 50MB, Move now. this prevents many folders with just 1 or 2 CAs
                    if (previousSnip != file.Name.ToString().Substring(24, 5) && firstCheck == false)// && stagingFileSize > filesizelimit - 5000000) 
                    {
                        StageMover(ref i, ref totalFileSize, ref stagingFileSize, ref stageMode, writingFolder, stagingFolder, filesizelimit, ref filecount, baseWritingFolder,year, namesche);
                    }
                    stageMode = true;
                    previousSnip = file.Name.ToString().Substring(24, 5);
                    firstCheck = false;
                    file.CopyTo(stagingFolder + @"\" + file.Name,true);
                    stagingFileSize += file.Length; //move to stag folder 
                }

            }

            if (Stag.GetFiles().Length > 0)
            {
                StageMover(ref i, ref totalFileSize, ref stagingFileSize, ref stageMode, writingFolder, stagingFolder, filesizelimit, ref filecount, baseWritingFolder,year, namesche);
            }
            Directory.Delete(stagingFolder);
            //PowerShellRunner(args);
            
            Console.WriteLine($"Task Completed Successfully, Authorizations Zipped and unzipped files/folders placed in {args[1]}");

        }

        private static void StageMover(ref int i, ref double totalFileSize, ref double stagingFileSize, ref bool stageMode, string writingFolder, string stagingFolder, int filesizelimit, ref int filecount,string baseWritingFolder,string year, string namesche)
        {
            FileInfo[] stageArr = new DirectoryInfo(stagingFolder).GetFiles();

            if (stagingFileSize + totalFileSize < filesizelimit)
            {
                foreach (var stagefile in stageArr)
                {
                    //Console.ForegroundColor = ConsoleColor.Yellow;
                    //Console.WriteLine("[[Staging Mode]] to Writing Folder");
                    //Console.WriteLine((totalFileSize / 1000000) + "MB------" + stagefile.Name.ToString());
                    string stagFile = writingFolder + @"\" + stagefile.Name;
                    stagefile.MoveTo(stagFile);               
                    totalFileSize += stagefile.Length;
                    filecount += 1;
                }
                //copy all files from stage to writing
            }
            else
            {
                //copy all files from stage to new appended folder BUT NOT if there are less than 25 files
                if (filecount >= 25)
                {
                    i += 1;
                    writingFolder = baseWritingFolder + @"\" + namesche + year + "-074-" + i.ToString("00");
                    Directory.CreateDirectory(writingFolder);
                    totalFileSize = 0;
                    filecount = 0;
                }
                
                foreach (var stagefile in stageArr)
                {
                    //Console.ForegroundColor = ConsoleColor.Yellow;
                    //Console.WriteLine("[[Staging Mode]] to New Folder(s)");
                    //Console.WriteLine((totalFileSize / 1000000) + "MB------" + stagefile.Name.ToString());
                    if (totalFileSize > 50000000)
                    {
                        i += 1;
                        writingFolder = baseWritingFolder + @"\" + namesche + year + "-074-" + i.ToString("00");
                        Directory.CreateDirectory(writingFolder);
                        totalFileSize = 0;
                        filecount = 0;
                    }
                    string stageingFile = writingFolder + @"\" + stagefile.Name;
                    stagefile.MoveTo(stageingFile);
                    filecount += 1;
                    totalFileSize += stagefile.Length;
                    
                }
            }
            stageMode = false;
            stagingFileSize = 0;        
        }
    }
}
