using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Microsoft.Win32;
using TagLib;
using System.ComponentModel;
using System.Data;
using System.Drawing;


namespace audiofilemetadata
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Mp3 Files | *.mp3";
            if (ofd.ShowDialog() == true)
            {
                lblFile.Text = ofd.FileName;
            }

        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            TagLib.File mp3 = TagLib.File.Create(lblFile.Text);
            lblAlbum.Text = mp3.Tag.Album;
            lblArtist.Text = GetAllStringsFromArray(mp3.Tag.AlbumArtists, ",");   // Tag.AlbumAritst is a string array 
            lblGenre.Text = GetAllStringsFromArray(mp3.Tag.Genres, ",");
            lblTitle.Text = mp3.Tag.Title;
            lblYear.Text = mp3.Tag.Year.ToString();
            lblDuration.Text = mp3.Properties.Duration.ToString();
            //lblLyrics.Text = GetAllStringsFromArray(mp3.Tag.Lyrics, ",");
   
        }

        public string GetAllStringsFromArray(string[] strArray, string strDelimeter)
        {
            string strFinal = string.Empty;

            for (int i = 0; i < strArray.Length; i++)
            {
                strFinal += strArray[i];

                if (i != strArray.Length - 1)
                {
                    strFinal += strDelimeter;
                }
            }
            return strFinal;
        }
             
 


    }
}
