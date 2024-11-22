using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace MauiAppTempoAgoraLocal
{
    public class TempoService
    {
        private const string ApiUrl = "https://api.openweathermap.org/data/2.5/weather";
        private const string ApiKey = "568fe45de2741308c9635ea0ef86d7ec";

        public async Task<TempoData> GetWeatherAsync(string city)
        {
            using var httpClient = new HttpClient();

            try
            {
                
                string url = $"{ApiUrl}?q={city}&appid={ApiKey}&units=metric";         
                var response = await httpClient.GetStringAsync(url);
                var json = JObject.Parse(response);

               
                return new TempoData
                {
                    Cidade = json["name"]?.ToString(),
                    Temperatura = json["main"]["temp"]?.ToString(),
                    Descricao = json["weather"][0]["description"]?.ToString(),
                    QueryDate = DateTime.Now
                };
            }
            catch (HttpRequestException ex)
            {
                // Tratar erros de requisição
                Console.WriteLine($"Erro ao buscar dados da API: {ex.Message}");
                return null;
            }
        }
    }

}
