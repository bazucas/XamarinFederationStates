using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFederationStates.Model;
using XamarinFederationStates.Service;

namespace XamarinFederationStates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Comunes : ContentPage
    {
        private List<Comune> ComunesOriginalList { get; set; }
        private List<Comune> FilteredComunesList { get; set; }

        public Comunes(TerritoryBase state)
        {
            InitializeComponent();

            //ComuneList.ItemsSource = StateService.GetComune(state.Id).Result;
            ComunesOriginalList = StateService.GetComune(state.Id);
            ComuneList.ItemsSource = ComunesOriginalList;
        }

        private void ComuneList_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //TODO: continue navigating inside colections
        }

        private void TxtComune_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            FilteredComunesList = ComunesOriginalList.Where(c => c.Nome.Contains(e.NewTextValue)).ToList();

            ComuneList.ItemsSource = FilteredComunesList;
        }
    }
}