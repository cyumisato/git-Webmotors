using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using Webmotors.ViewModels;

namespace Webmotors.Classes
{
    public class ConsultaHttp
    {
        string _dados = "";

        public string Consultar(string url)
        {
            GetAsync(url).Wait();

            return _dados;
        }

        public async Task GetAsync(string url)
        {
            try
            {
                var listaPadrao = new List<ListaPadraoViewModel>();

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = client.GetAsync(url).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        //listaPadrao = JsonConvert.DeserializeObject<List<ListaPadraoViewModel>>(response.Content.ReadAsStringAsync().Result);
                        _dados = response.Content.ReadAsStringAsync().Result;
                    }
                    else
                    {
                        //return null;
                    }

                    //return listaPadrao;
                }
            }
            catch(Exception e)
            {
                //return null;
            }
        }
    }
}