using System.Net;
using CovidService.Contracts;
using CovidService.Entities;
using CovidService.Models;
using Newtonsoft.Json;

namespace CovidService.Repositories
{

    public class CovidDetailsRepository : ICovidDetailsContract
    {

        private static ApplicationDbContext applicationDbContext; 
        public CovidDetailsRepository()
        {
            applicationDbContext = new ApplicationDbContext();

        }
        private static void RefreshCovidRecords()
        {
            List<CovidDetails> record = applicationDbContext.CovidDetails.Where(p => p.Id >= 0).ToList();
            foreach (var item in record)
            {
                //Console.WriteLine(item);
                applicationDbContext.Remove(item);
                applicationDbContext.SaveChanges();
            }

        }
        private static List<CovidDetails> fetchUpdatedDetails()
        {
            //delete old records
            CovidDetailsRepository.RefreshCovidRecords();


            List<CovidDetails> list = new List<CovidDetails>();
            string path = "https://disease.sh/v3/covid-19/countries";
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string jsonString = (new WebClient()).DownloadString(path);

            dynamic json = JsonConvert.DeserializeObject(jsonString);

            for (int i = 0; i < 230; i++)
            {
                CovidDetails covidDetails = new CovidDetails()
                {
                    Id = i,
                    CountryName = json[i].country != null ? json[i].country : "",
                    DeceasedCases = json[i].deaths != null ? json[i].deaths : 0,
                    RecoveredCases = json[i].recovered != null ? json[i].recovered : 0,
                    InfectedCases = json[i].cases != null ? json[i].cases : 0
                };
                list.Add(covidDetails);

            }


            return list;
        }
        

        public void UpdateCovidDetails()
        {
            try
            {

                List<CovidDetails> allRecords = fetchUpdatedDetails();
                foreach (CovidDetails covidDetails in allRecords)
                {
                    applicationDbContext.Add(covidDetails);
                    applicationDbContext.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public CovidDetails GetCovidDetail(string Countryname)
        {
            try
            {

                CovidDetails details = applicationDbContext.CovidDetails.SingleOrDefault(x => x.CountryName == Countryname);
                return details;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<CovidDetails> GetCovidDetails()
        {
            try
            {

                return applicationDbContext.CovidDetails.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }


}

