using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;



namespace Prueba_B2B
{
    class Program
    {

       static float total= 0;

        static async Task Main(string[] args)
        {
            string url = "https://us-central1-b2b-hub-82515.cloudfunctions.net/app/api/Ej1?userID=kevinjor117@gmail.com&companyID=123456789&portalID=oaXh7EU0ExaygAvvZM3y&facturaID=L90107";
            HttpClient client = new HttpClient();

            var response = await client.GetAsync(url);

            var content = await response.Content.ReadAsStringAsync();

            Orden Object = JsonConvert.DeserializeObject<Orden>(content);

            foreach (var par in Object.partidas) {
                Console.WriteLine("ID log: "+par.id);
                ImporteGlobal(par.Precio);
            }

            Console.WriteLine("----------------------------------------");


            if (total == Object.total || total+0.10 == Object.total || total-0.10 == Object.total)
            {
                string url2 = "https://us-central1-b2b-hub-82515.cloudfunctions.net/app/api/Ej1";
                HttpClient client2 = new HttpClient();

                Put post = new Put()
                {
                    userID = "kevinjor117@gmail.com",
                    companyID = "123456789",
                    portalID = "oaXh7EU0ExaygAvvZM3y",
                    facturaID = "L90107",
                    notification = "La factura fue adendada correctamente"
                };


                var data = System.Text.Json.JsonSerializer.Serialize<Put>(post);

                HttpContent cont = new StringContent(data, System.Text.Encoding.UTF8, "application/json");

                var httpResp = await client2.PutAsync(url2,cont);

                if (httpResp.IsSuccessStatusCode)
                {
                    Console.WriteLine("La revision de la factura se notifico correctamente");
                }
                else {
                    Console.WriteLine("Ocurrio un error al notificar la revision, intentelo mas tarde");
                }

            }
            else {
                Console.WriteLine("El total de la factura: " + Object.total+" es distinto a la suma de las partidas: "+total);
            }
        }

        static void ImporteGlobal(float precio) {
            total +=precio;
            Console.WriteLine("Total de la factura: " + total);
        }
    }
}
