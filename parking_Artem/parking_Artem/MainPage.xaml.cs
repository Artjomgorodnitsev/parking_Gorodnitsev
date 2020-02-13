using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace parking_Artem
{

    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            /*parkingList.ItemsSource = App.Database.GetItems();
            base.OnAppearing();*/
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            /*Parking selectedParking = (Parking)e.SelectedItem;
            ParkingPage parkingPage = new ParkingPage();
            parkingPage.BindingContext = selectedParking;
            await Navigation.PushAsync(parkingPage);*/

            Parking selectedParking = (Parking)e.SelectedItem;
            ParkingFormList parkingFormList = new ParkingFormList();
            parkingFormList.BindingContext = selectedParking;
            await Navigation.PushAsync(parkingFormList);

        }


        private async void CreateParking(object sender, EventArgs e)
        {
            /*Parking parking = new Parking();
            ParkingPage parkingpage = new ParkingPage();
            parkingpage.BindingContext = parking;
            await Navigation.PushAsync(parkingpage);*/
            await Navigation.PushAsync(new ParkingFormList());
        }

        private void ParkingList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}
