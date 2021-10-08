using covid19.Dtos;
using covid19.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace covid19.Services
{
	public class CovidService : RestService<Covid>
    {
        private const string url = "https://api.covid19api.com/country/brazil/status/confirmed"; 
       
        //regras de negocios, devem estar aqui

        public List<Covid> Get()
		{
            var data = base.Get<string>(url);
            return JsonConvert.DeserializeObject<List<Covid>>(data);
        }

        public List<CovidMonthlyDto> GetMonthly()
        {
            var data = base.Get<string>(url);
            var result = JsonConvert.DeserializeObject<List<Covid>>(data);
            ILookup<DateTime, Covid> casesByMonth = result.ToLookup(o => new DateTime(o.Date.Year, o.Date.Month, 1));
            List<CovidMonthlyDto> ocurrences = new List<CovidMonthlyDto>();
            foreach (var monthly in casesByMonth)
            {
                ocurrences.Add(new CovidMonthlyDto
                {
                    Year = monthly.Key.Year,
                    Month = monthly.Key.Month,
                    Total = monthly.Sum(o => o.Cases)
                });
            }
            return ocurrences;
        }
    }
}
