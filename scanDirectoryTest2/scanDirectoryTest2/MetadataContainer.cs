using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IUnification.Models.Interfaces;

namespace scanDirectoryTest2
{
    class MetadataContainer : IMetadataContainer
    {
        Uri Datasource;

        public static void Main(string Title, string[] Artist, string Album, uint Year, TimeSpan Duration)
        {

        Hashtable FileMetadata = new Hashtable();
        FileMetadata.Add("Title", Title);
        FileMetadata.Add("Artist", Artist);
        FileMetadata.Add("Album", Album);
        FileMetadata.Add("Year", Year);
        FileMetadata.Add("Length", Duration);
        }


        /*public static void AddFileMetadata (string Title, string[] Artist, string Album, uint Year, TimeSpan Duration, Hashtable FileMetadata){

            foreach (DictionaryEntry de in FileMetadata)
            {

            }

        }*/


    }
}
