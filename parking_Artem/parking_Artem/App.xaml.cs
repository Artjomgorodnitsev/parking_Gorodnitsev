using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace parking_Artem
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "parking.db";
        public static ParkingRepository database;
        public static ParkingRepository Database {
            get {
                if (database == null)
                {
                    database = new ParkingRepository(DATABASE_NAME);
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();
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
