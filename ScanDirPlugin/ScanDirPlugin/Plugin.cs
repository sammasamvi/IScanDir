using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TagLib;
using IUnification.Models.Interfaces;

namespace ScanDirPlugin
{
    /// <summary>
    /// Class Designed to scan a directory for audio files and save the full name of each file in a list of strings.
    /// </summary>
    public class Plugin 
    {
        /// <summary>
        /// Directory to be scanned.
        /// </summary>
        public string DirPath { get; set; }


        public static void Main(string DirPath)
        {
            DirectoryInfo di = new DirectoryInfo(DirPath);
            FullDirList(di, "*.mp3");

            //Console.WriteLine("Scan Complete");

            //Console.Read();
        }

        /// <summary>
        /// List holding all audio files found inside directory. To be binded to List Box.
        /// </summary>
        public static List<string> files = new List<string>();

        /// <summary>
        /// Create list of directories 
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
                    //Console.WriteLine("File {0}", f.FullName);
                    files.Add(f.FullName);
                }
            }
            catch
            {
                //Console.WriteLine("Directory {0}  \n could not be accessed.", dir.FullName);
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
