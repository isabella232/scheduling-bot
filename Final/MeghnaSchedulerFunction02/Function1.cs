using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace MeghnaSchedulerFunction02
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public async static void Run([TimerTrigger("0 */1 * * * *")]TimerInfo myTimer, ILogger log)
        {
            using (var httpClient = new HttpClient())
            {
                string geturl = $"https://schedulebotwebapp.azurewebsites.net/GetSchedules";
                var response = await httpClient.GetAsync(new Uri(geturl));
                List<Schedule> schedules = new List<Schedule>();

                if (response.IsSuccessStatusCode)
                {
                    schedules = JsonConvert.DeserializeObject<List<Schedule>>(await response.Content.ReadAsStringAsync());
                }

                foreach (var schedule in schedules)
                {
                    // Your Account SID from twilio.com/console
                    var accountSid = "";
                    // Your Auth Token from twilio.com/console
                    var authToken = "";

                    TwilioClient.Init(accountSid, authToken);

                    var message = MessageResource.Create(
                        to: new PhoneNumber(""),
                        from: new PhoneNumber(""),
                        body: $"Reminder from SchedulerBot. {schedule.EventName} at {schedule.EventDate}");

                    string updateurl = $"https://schedulebotwebapp.azurewebsites.net/CompleteSchedule";
                    var content = new StringContent(JsonConvert.SerializeObject(schedule), Encoding.UTF8, "application/json");

                    using (var _httpClient = new HttpClient())
                    {
                        var r = await _httpClient.PostAsync(updateurl, content);
                    }

                }
            }

            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        }
    }
}
