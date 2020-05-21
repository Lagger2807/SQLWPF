using System;
using System.Windows;
using System.Collections.Generic;
using System.IO;
using SQLite;

namespace borriello.sasha._5G.SQLWPF
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //var databasePath = Path.Combine(
            //    Environment.CurrentDirectory,
            //    "chinook.db"
            //);

            //var db = new SQLiteConnection(databasePath);
            //db.CreateTable<Dipendente>();

            //var risultato = db.Query<Dipendente>("SELECT * FROM Dipendente");

            //DG_DB.ItemsSource = risultato;

        }

        private void Btn_1_Click(object sender, RoutedEventArgs e)
        {

            var databasePath = Path.Combine(
                Environment.CurrentDirectory,
                "chinook.db"
            );

            SQLiteConnection cn1 = new SQLiteConnection("chinook.db");
            List<Record> retVal = cn1.Query<Record>("select * from albums");

            DG_DB.ItemsSource = retVal;

        }

        private void Btn_2_Click(object sender, RoutedEventArgs e)
        {

            var databasePath = Path.Combine(
                Environment.CurrentDirectory,
                "chinook.db"
            );

            SQLiteConnection cn1 = new SQLiteConnection("chinook.db");
            List<Record> retVal = cn1.Query<Record>("select albums.Title, artists.Name from albums inner join artists ON albums.ArtistId = artists.ArtistId order by albums.Title ASC");

            DG_DB.ItemsSource = retVal;

        }

        private void Btn_3_Click(object sender, RoutedEventArgs e)
        {

            var databasePath = Path.Combine(
                Environment.CurrentDirectory,
                "chinook.db"
            );

            SQLiteConnection cn1 = new SQLiteConnection("chinook.db");
            List<Record> retVal = cn1.Query<Record>("select albums.Title, artists.Name from albums inner join artists ON albums.ArtistId = artists.ArtistId order by artists.Name ASC");

            DG_DB.ItemsSource = retVal;

        }

        private void Btn_4_Click(object sender, RoutedEventArgs e)
        {

            var databasePath = Path.Combine(
                Environment.CurrentDirectory,
                "chinook.db"
            );

            SQLiteConnection cn1 = new SQLiteConnection("chinook.db");
            List<Record> retVal = cn1.Query<Record>("select albums.Title, count(tracks.TrackId) NTracks from albums inner join tracks ON albums.AlbumId = tracks.AlbumId group by albums.Title order by NTracks DESC");

            DG_DB.ItemsSource = retVal;

        }

        private void Btn_5_Click(object sender, RoutedEventArgs e)
        {

            var databasePath = Path.Combine(
                Environment.CurrentDirectory,
                "chinook.db"
            );

            SQLiteConnection cn1 = new SQLiteConnection("chinook.db");
            List<Record> retVal = cn1.Query<Record>("select artists.Name, albums.Title from artists inner join albums ON artists.ArtistId = albums.ArtistID");

            DG_DB.ItemsSource = retVal;

        }
    }

    public class Record
    {
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public int ArtistId { get; set; }
        public string Name { get; set; }
        public string NTracks { get; set; }
        public string NAlbums { get; set; }
    }

}
