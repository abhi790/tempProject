using CovidService.Entities;
using CovidService.Models;
using CovidService.Repositories;
using Microsoft.AspNetCore.Http;
using CovidService.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CovidService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CovidServicesController : ControllerBase
    {
        private readonly ICovidDetailsContract _covidDetailsRepository;
        public CovidServicesController(ICovidDetailsContract covidDetailsRepository)
        {
            _covidDetailsRepository = covidDetailsRepository;
        }

        [HttpGet, Route("GetCovidDetails")]
        public IActionResult GetAll()
        {
            try
            {
                List<CovidDetails> covidDetails = _covidDetailsRepository.GetCovidDetails();
                return StatusCode(200, covidDetails);
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        [HttpGet, Route("GetByCountry/{CountryName}")]
        public IActionResult Get(string CountryName)
        {
            try
            {
                CovidDetails covidDetails = _covidDetailsRepository.GetCovidDetail(CountryName);
                if (covidDetails != null)
                    return StatusCode(200, covidDetails);
                else
                    return StatusCode(404, "Invalid id");
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }


        [HttpPost, Route("UpdateDetails")]
        public IActionResult UpdateCovidDetails()
        {
            try
            {
                _covidDetailsRepository.UpdateCovidDetails();
                return StatusCode(200, "Covid Details Uptodate");

            }

            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }


    }

}
