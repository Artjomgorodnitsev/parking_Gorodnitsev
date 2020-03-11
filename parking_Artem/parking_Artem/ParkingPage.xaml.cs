using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        DateTime _triggerTime;
        int limit = 6;
        public ParkingPage()
        {
            InitializeComponent();
            Device.StartTimer(TimeSpan.FromSeconds(1), OnTimerTick);
            nubmr.TextChanged += (sender, args) =>
            {
                string _text = nubmr.Text;
                if (_text.Length > limit)
                {
                    _text = _text.Remove(_text.Length - 1);
                    nubmr.Text = _text; 
                }
            };





            //DP.MaximumDate = DateTime.Now;

        }
        bool OnTimerTick()
        {
            if (_switch.IsToggled && DateTime.Now >= _triggerTime)
            {
                _switch.IsToggled = false;
                DisplayAlert("Время парковки", "Время вашей парквоки вышло'" , "OK");
                var parking = (Parking)BindingContext;
                App.Database.DeleteItem(parking.Id);
                this.Navigation.PopAsync();
            }
            return true;
        }

        void OnTimePickerPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == "Time")
            {
                _switch.IsToggled = true;
                SetTriggerTime();
            }
        }

        void OnSwitchToggled(object sender, ToggledEventArgs args)
        {
            SetTriggerTime();
        }

        void SetTriggerTime()
        {
            if (_switch.IsToggled)
            {
                _triggerTime = DateTime.Today + _timePicker.Time;
                if (_triggerTime < DateTime.Now)
                {
                    _triggerTime += TimeSpan.FromDays(1);
                }
            }
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
