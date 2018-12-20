using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Patronage.Application.FizzBuzz.Queries
{
    public class GetFizzBuzzQuery : IRequest<string>
    {
        [Required]
        [Range(0,1000)]
        public int Value { get; set; }
    }
}
