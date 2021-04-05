using System;
using System.IO;
using Notes.Data;
using Xamarin.Forms;

namespace Notes
{
    public partial class App : Application
    {
        static NoteDatabase database;
        static string ExternalPath;
        
        public static NoteDatabase Database
        {
            get
            {
                if (database == null)
                {
                    string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
                    string filename = System.IO.Path.Combine(path, "memorytype.txt");

                    using (var streamWriter = new StreamWriter(filename, true))
                    {
                        streamWriter.WriteLine("internal");
                    }


                    using (var streamReader = new StreamReader(filename))
                    {
                        string content = streamReader.ReadToEnd();
                        System.Diagnostics.Debug.WriteLine(content);
                        if (content.Equals("internal"))
                        {
                            database = new NoteDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Notes.db3"));
                        }
                        else
                        {
                            database = new NoteDatabase(Path.Combine(ExternalPath, "Notes.db3"));
                        }
                    }

                }
                return database;
            }
        }

        public App(string ExternalPath)
        {
            InitializeComponent();
            MainPage = new AppShell();
            App.ExternalPath = ExternalPath;

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
