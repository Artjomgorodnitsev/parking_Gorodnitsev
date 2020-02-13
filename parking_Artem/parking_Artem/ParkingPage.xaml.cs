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
    public partial class ParkingPage : ContentPage
    {
        public ParkingPage()
        {
            InitializeComponent();




            //DP.MaximumDate = DateTime.Now;

        }



        private void SaveParking(object sender, EventArgs e)
        {
            var parking = (Parking)BindingContext;


            if (!String.IsNullOrEmpty(parking.Name))
            {
                App.Database.SaveItem(parking);
            }
            this.Navigation.PopAsync();


        }
        private void DeleteParking(object sender, EventArgs e)
        {
            var parking = (Parking)BindingContext;
            App.Database.DeleteItem(parking.Id);
            this.Navigation.PopAsync();
        }
        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (picker.SelectedIndex == 0)
            {
                picker2.IsEnabled = true;
                picker3.IsVisible = false;
                picker2.IsVisible = true;
            }
            else if (picker.SelectedIndex == 1)
            {
                picker2.IsVisible = false;
                picker3.IsEnabled = true;
                picker3.IsVisible = true;
            }
            else
            {
                picker2.IsEnabled = false;
            }
        }
    }
}
