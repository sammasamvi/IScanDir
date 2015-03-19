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
        public static void Main(string[] args)
        {
            DirectoryInfo di = new DirectoryInfo("E:\\");
            FullDirList(di, "*.mp3");

            Console.WriteLine("Scan Complete");
           
            Console.Read();
        }

        public static List<FileInfo> files = new List<FileInfo>();  
        public static List<DirectoryInfo> folders = new List<DirectoryInfo>(); 
        public static void FullDirList(DirectoryInfo dir, string searchPattern)
        {

            try
            {
                foreach (FileInfo f in dir.GetFiles(searchPattern))
                {
                    Console.WriteLine("File {0}", f.FullName);
                    files.Add(f);


                    //Using ID3 lib

                    //Using TagLib
                    TagLib.File file = TagLib.File.Create(f.FullName);
                    string Title = file.Tag.Title;
                    string[] Artist = file.Tag.Performers;
                    string Album = file.Tag.Album;
                    uint Year = file.Tag.Year;
                    TimeSpan Duration = file.Properties.Duration;
                    //Uri Datasource = file.Properties;


   

                }
                
            }
            catch
            {
                Console.WriteLine("Directory {0}  \n could not be accessed!!!!", dir.FullName);
                return;  
            }

  
            foreach (DirectoryInfo d in dir.GetDirectories())
            {
                folders.Add(d);
                FullDirList(d, searchPattern);
            }
            


        }
    }
}
