using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Patronage.Net.Controllers.Resources;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatronageController : Controller
    {
        private readonly IPatronageRepository patronageRepository;
        public PatronageController(IPatronageRepository patronageRepository)
        {
            this.patronageRepository = patronageRepository;
        }

        [HttpGet("FizzBuzz")]
        [AllowAnonymous]
        //Z obiektem lub bez obiektu
        // public async Task<IActionResult> GetFizzBuzz([Required][Range(0, 1000)] int value)
        public async Task<IActionResult> GetFizzBuzz([FromQuery] FizzBuzzQueryResource fizzBuzzQueryResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await Task.Run(() => patronageRepository.FizzBuzz(fizzBuzzQueryResource.Value));

            return Ok(result);
        }

        [HttpGet("Mocky")]
        [AllowAnonymous]
        public async Task<IActionResult> GetMocky()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var result = await patronageRepository.GetMockyContent(client);

                    return Ok(result);
                }
                catch (HttpRequestException httpRequestException)
                {
                    return BadRequest($"Error getting content from Mocky: {httpRequestException.Message}");
                }

            }
        }
    }
}