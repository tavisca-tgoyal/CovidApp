using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class FindAge
    {
        public static async Task<DeathDataResponseModel> GetAverageDeathAsync()
        {
            int deadButAgeNotAvailable = 0;
            int totalDeath = 0;
            int totalDeathDataWithAgeAvaiable = 0;
            HashSet<string> status = new HashSet<string>();
            int casesWithNoStatusAvailable = 0;

            var jsonString = await GetJsonStringDataLiveAsync();
            List<DataModel> data = JsonConvert.DeserializeObject<List<DataModel>>(jsonString);
            List<int> age = new List<int>();
            foreach(var item in data[0].raw_data)
            {
                if (!string.IsNullOrEmpty(item.currentstatus))
                {
                    if(!status.Contains(item.currentstatus.ToString()))
                        status.Add(item.currentstatus.ToString());

                    if (item.currentstatus == "Deceased")
                    {
                        totalDeath++;
                        if (!string.IsNullOrEmpty(item.agebracket))
                        {
                            totalDeathDataWithAgeAvaiable++;
                            age.Add(Convert.ToInt32(item.agebracket.ToString()));
                        }
                        else
                            deadButAgeNotAvailable++;
                    }
                }
                else
                {
                    casesWithNoStatusAvailable++;
                }
                
            }
            double averageAge =  AverageFrom(age);
            DeathDataResponseModel deathDataResponseModel = new DeathDataResponseModel()
            {
                AverageAge = averageAge,
                DeadButAgeNotAvailable = deadButAgeNotAvailable,
                TotalCases = data[0].raw_data.Length,
                TotalDeath = totalDeath,
                TotalDeathDataWithAgeAvaiable = totalDeathDataWithAgeAvaiable,
                Status = status,
                CasesWithNoStatusAvailable = casesWithNoStatusAvailable 
               
            };
            return deathDataResponseModel;
        }

        private static async Task<string> GetJsonStringDataLiveAsync()
        {
            string api = "https://api.covid19india.org/raw_data.json";
            string temp = await new WebClient().DownloadStringTaskAsync(api);
            temp = "[" + temp + "]";
            return temp;            
        }

        private static double AverageFrom(List<int> age)
        {
            int count = age.Count;
            int sum = 0;
            foreach(var item in age)
            {
                sum = sum + item;
            }
            return sum / count;
        }
    }
}
