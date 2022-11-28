using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Api.Domain_Layer.Contracts;
using Sat.Recruitment.Api.Domain_Layer.Dto;
using Sat.Recruitment.Api.Infrastructure;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Sat.Recruitment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public partial class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        private readonly List<UserDto> _users = new List<UserDto>();
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        /// <summary>
        ///  Creates a new User object
        /// </summary>
        /// <returns>Nortification about user creating or dublicated</returns>
        /// <response code="200">Nortification User creating</response>
        /// <response code="400">Nortification money format is not valid</response>
        /// <response code="400">Nortification email format is not valid</response>
        /// <response code="400">Nortification User is duplicated</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost]
        [Route("/create-user")]
        public IActionResult CreateUser([Required] string name, [Required] string email, [Required] string address, [Required] string phone, string userType, string money)
        {
            if (!DecimalValidator.IsDecimal(money))
            {

                return BadRequest(new
                {
                    IsSuccess = false,
                    Errors = "Format of money is not valid"
                });
            }

            if (!EmailValidator.IsValidEmailAddress(email, true, true))
            {

                return BadRequest(new
                {
                    IsSuccess = false,
                    Errors = "Format of email is not valid"
                });
            }

            var user = _userService.CreateUser(name, email, address, phone, userType, money);
 

            if (user != null)
            {
                return new ObjectResult(new
                {
                    IsSuccess = true,
                    Message = "User Created"
                });
            }
            else
            {
                return BadRequest(new
                {
                    IsSuccess = false,
                    Errors = "The user is duplicated"
                });
            }

        }
    }
}
