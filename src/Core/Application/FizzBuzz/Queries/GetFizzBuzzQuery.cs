using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Application.FizzBuzz.Queries
{
    public class GetFizzBuzzQuery : IRequest<string>
    {
        [Required]
        [Range(0,1000)]
        public int Value { get; set; }
    }
}
