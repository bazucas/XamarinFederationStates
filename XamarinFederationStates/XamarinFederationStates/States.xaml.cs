using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFederationStates.Model;
using XamarinFederationStates.Service;

namespace XamarinFederationStates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class States : ContentPage
    {
        public States()
        {
            InitializeComponent();

            //StateList.ItemsSource = StateService.GetStates().Result;
            StateList.ItemsSource = StateService.GetStates();
        }

        private void StateList_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var state = (State)e.SelectedItem;

            Navigation.PushAsync(new Comunes(state));
        }
    }
}