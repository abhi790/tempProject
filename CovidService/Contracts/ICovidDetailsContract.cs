using CovidService.Entities;

namespace CovidService.Contracts
{
    public interface ICovidDetailsContract
    {
        List<CovidDetails> GetCovidDetails();
        CovidDetails GetCovidDetail(string CountryName);
        void UpdateCovidDetails();

    }
}
