using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
 
using System.Text;
using VG_TransportAPI.Model;
using VG_TransportAPI.Models;

namespace SmsTrial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmsController : ControllerBase
    {
        //public string from { get; set; }
        //public string[] to { get; set; }
        //public string body { get; set; }

        //public SMS(string from, string[] to, string body)
        //{
        //    this.from = from;
        //    this.to = to;
        //    this.body = body;
        //}

        //public async void sendSMS(SMS sms, string servicePlanId, string apiToken)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + apiToken);
        //        string json = JsonConvert.SerializeObject(sms);
        //        var postData = new StringContent(json, Encoding.UTF8, "application/json");
        //        var request = await client.PostAsync("https://us.sms.api.sinch.com/xms/v1/" + servicePlanId + "/batches", postData);
        //        var response = await request.Content.ReadAsStringAsync();

        //        Console.WriteLine(response);
        //    }

        //}

        [HttpPost]
        [Route("send")]
        public async Task<IActionResult> sendsms([FromBody] sms22 sm)
        {
            string servicePlanId = "8940bd6db8ed417bac052c54cb1a7e12";
                string apiToken = "93f41d684f9c4b2a8e61010e4fe5e4f3";

            var adds = new Sms12();

            adds.from = "+447520662078";
            adds.to = sm.to;
            adds.body = sm.body;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + apiToken);
                string json = JsonConvert.SerializeObject(adds);
                var postData = new StringContent(json, Encoding.UTF8, "application/json");
                var request = await client.PostAsync("https://us.sms.api.sinch.com/xms/v1/" + servicePlanId + "/batches", postData);
                var response = await request.Content.ReadAsStringAsync();

                Console.WriteLine(response);
                return Ok("hi");
            }
        }
    }
}
