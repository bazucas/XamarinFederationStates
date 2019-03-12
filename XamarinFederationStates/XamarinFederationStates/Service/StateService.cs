using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using XamarinFederationStates.Model;
using Newtonsoft.Json;

namespace XamarinFederationStates.Service
{
    public static class StateService
    {
        public static readonly string UrlState = "https://servicodados.ibge.gov.br/api/v1/localidades/estados";
        public static readonly string UrlComune = "https://servicodados.ibge.gov.br/api/v1/localidades/estados/{0}/municipios";

        public static List<State> GetStates()
        {
            var wc = new WebClient();
            var content = wc.DownloadString(UrlState);
            return JsonConvert.DeserializeObject<List<State>>(content);
        }

        public static List<Comune> GetComune(int state)
        {
            var newUrl = string.Format(UrlComune, state);
            var wc = new WebClient();
            var content = wc.DownloadString(newUrl);
            return JsonConvert.DeserializeObject<List<Comune>>(content);
        }

        public static async Task<List<State>> GetStatesAsync()
        {
            var wc = new WebClient();
            var content = await wc.DownloadStringTaskAsync(UrlState);
            return JsonConvert.DeserializeObject<List<State>>(content);
        }

        public static async Task<List<Comune>> GetComuneAsync( int state)
        {
            var newUrl = string.Format(UrlComune, state);
            var wc = new WebClient();
            var content = await wc.DownloadStringTaskAsync(newUrl);
            return JsonConvert.DeserializeObject<List<Comune>>(content);
        }
    }
}
