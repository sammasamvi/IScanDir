using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TagLib;
using Mp3Lib;
using IUnification.Models.Interfaces;

namespace scanDirectoryTest2
{
    class ScanDir : IMetadataContainer
    {




        /// <summary>
        /// Test only: fo testing scanDir code in console application.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            DirectoryInfo di = new DirectoryInfo("E:\\");
            FullDirList(di, "*.mp3");

            Console.WriteLine("Scan Complete");
           
            Console.Read();
        }

        public static List<FileInfo> files = new List<FileInfo>();  

        /// <summary>
        /// 
        /// </summary>
        public static List<DirectoryInfo> folders = new List<DirectoryInfo>(); 

        /// <summary>
        /// Try-Catch statment to find all files in the directory and sub directory. And for each file find
        /// metadata.
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="searchPattern"></param>
        public static void FullDirList(DirectoryInfo dir, string searchPattern)
        {

            try
            {
                foreach (FileInfo f in dir.GetFiles(searchPattern))
                {
                    Console.WriteLine("File {0}", f.FullName);
                    files.Add(f);

                    /*Using TagLib third party Library to find audio file metadata.
                    TagLib.File file = TagLib.File.Create(f.FullName);
                    string Title = file.Tag.Title;
                    string[] Artist = file.Tag.Performers;
                    string Album = file.Tag.Album;
                    uint Year = file.Tag.Year;
                    TimeSpan Duration = file.Properties.Duration;*/
                }
            }
            catch
            {
                Console.WriteLine("Directory {0}  \n could not be accessed!!!!", dir.FullName);
                return;  
            }
            ///
            foreach (DirectoryInfo d in dir.GetDirectories())
            {
                folders.Add(d);
                FullDirList(d, searchPattern);
            }
        }

        /// <summary>
        /// Method for looking up metadata for audio file. 
        /// </summary>
        /// <param name="f"></param>
        public void FileMetadata(FileInfo f)
        {
            //Using TagLib third party Library to find audio file metadata.
            TagLib.File file = TagLib.File.Create(f.FullName);
            string Title = file.Tag.Title;
            string[] Artist = file.Tag.Performers;
            string Album = file.Tag.Album;
            uint Year = file.Tag.Year;
            TimeSpan Duration = file.Properties.Duration;
        }

    }
}
