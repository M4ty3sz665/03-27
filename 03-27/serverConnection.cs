using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace _03_27
{
    public class serverConnection
    {
        HttpClient client = new HttpClient();
        string serverurl = "";
        public serverConnection(string serverurl)
        {
            this.serverurl = serverurl;
        }

        public async Task<List<JsonData>> getKolbasz()
        {
            string url = serverurl + "/kolbaszok";
            List<JsonData> all = new List<JsonData>();
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string result = await response.Content.ReadAsStringAsync();
                all = JsonConvert.DeserializeObject<List<JsonData>>(result);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return all;
        }

        public async Task<bool> createKolbasz(string kolbaszNameConsole, float kolobaszErtekelesConsole, int kolbaszAraConsole)
        {
            string url = serverurl + "/createKolbasz";
            try
            {
                var jsoninfo = new
                {
                    KolbaszName = kolbaszNameConsole,
                    kolbaszErtekeles = kolobaszErtekelesConsole,
                    kolbaszAra = kolbaszAraConsole
                };

                string jsonstringify = JsonConvert.SerializeObject(jsoninfo);
                HttpContent sendthis = new StringContent(jsonstringify, Encoding.UTF8, "Application/json");
                HttpResponseMessage response = await client.PostAsync(url, sendthis);
                string result = await response.Content.ReadAsStringAsync();
                JsonData data = JsonConvert.DeserializeObject<JsonData>(result);
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        public async Task<List<string>> deleteKolbasz(int id)
        {
            List<string> all = new List<string>();
            string url = serverurl + "/deleteKolbasz/"+ id;
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string result = await response.Content.ReadAsStringAsync();
                all = JsonConvert.DeserializeObject<List<JsonData>>(result).Select(item => item.kolbaszName).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return all;
        }

    }
}
