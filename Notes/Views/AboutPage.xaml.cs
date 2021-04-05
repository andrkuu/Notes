using System;
using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Notes.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        async void OnButtonClicked(object sender, EventArgs e)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            string filename = System.IO.Path.Combine(path, "memorytype.txt");
            if (InternalButton.IsChecked)
            {
                using (var streamWriter = new StreamWriter(filename, true))
                {
                    streamWriter.WriteLine("internal");
                }
            }
            else if (ExternalButton.IsChecked)
            {
                using (var streamWriter = new StreamWriter(filename, true))
                {
                    streamWriter.WriteLine("external");
                }
            }         
        }

        private async System.Threading.Tasks.Task RadioButton_CheckedChangedAsync(object sender, CheckedChangedEventArgs e)
        {
            
        }
    }
}
