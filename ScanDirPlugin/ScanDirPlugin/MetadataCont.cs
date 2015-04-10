using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IUnification.Models.Interfaces;

namespace ScanDirPlugin
{
    class MetadataCont : IMetadataContainer
    {
        /// <summary>
        /// This variable will be set when the user decides which scanned file to retreive metadata from.
        /// </summary>
        public string AudioFileName { get; set; }

        
        string myTitle;
        public string myArtist;
        public string myAlbum;
        public uint myYear;
        public TimeSpan myDuration;

        public string[] MetadataFieldNames = new string[] { "Title", "Artist", "Album", "Year", "Duration" };


        /// <summary>
        /// Extract metadata for audio file.
        /// </summary>
        /// <param name="AudioFileName"></param>
        public MetadataCont(string AudioFileName)
        {
           

            //Using TagLib third party Library to find audio file metadata.
            TagLib.File file = TagLib.File.Create(AudioFileName);
            string myTitle = file.Tag.Title;
            string[] myArtist = file.Tag.Performers;
            string myAlbum = file.Tag.Album;
            uint myYear = file.Tag.Year;
            TimeSpan myDuration = file.Properties.Duration;
        }

        //******* Maybe change uri to string
        public Uri Datasource
        {
            get { return DirPath; }
        }

        public IUnification.Models.Enums.DatasourceFormat DatasourceFormat
        {
            get { throw new NotImplementedException(); }
        }

        public TimeSpan Duration
        {
            get { return myDuration; }
        }

        public string Metadata(string MetadataField)
        {
            //******Add switch statement to get, to go through metadata values.
            
            
            throw new NotImplementedException();
        }

        public string[] MetadataFields
        {
            get { return MetadataFieldNames; }
        }
    }
}
