using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace parking_Artem
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ParkingFormList : ContentPage
    {
        public ParkingFormList()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            parkingList.ItemsSource = App.Database.GetItems();
            base.OnAppearing();
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Parking selectedParking = (Parking)e.SelectedItem;
            ParkingPage parkingPage = new ParkingPage();
            parkingPage.BindingContext = selectedParking;
            await Navigation.PushAsync(parkingPage);
            

        }

        private async void CreateParking1(object sender, EventArgs e)
        {
            Parking parking = new Parking();
            ParkingPage parkingpage = new ParkingPage();
            parkingpage.BindingContext = parking;
            await Navigation.PushAsync(parkingpage);
        }
    }
}