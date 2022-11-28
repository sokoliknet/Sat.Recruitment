using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace Sat.Recruitment.Api.Domain_Layer.Dto
{
    public class UserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string UserType { get; set; }
        public decimal Money { get; set; }
    }

}
