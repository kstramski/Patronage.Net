using System.ComponentModel.DataAnnotations;

namespace Patronage.Net.Controllers.Resources
{
    public class FizzBuzzQueryResource
    {
        [Required]
        [Range(0, 1000)]
        public int Value { get; set; }
    }
}