using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CongratulationDB
{
    public partial class App : Application
    {
        static DataBaseFunction database;

        public static DataBaseFunction Database
        {
            get
            {
                if (database == null)
                {
                    database = new DataBaseFunction(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "mydb.db"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();
            Device.SetFlags(new[] { "Brush_Experimental" });
            MainPage = new NavigationPage(new MainPage());
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
