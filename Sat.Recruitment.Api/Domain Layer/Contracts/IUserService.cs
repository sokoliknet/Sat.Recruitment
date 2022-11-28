using Sat.Recruitment.Api.Domain_Layer.Dto;

namespace Sat.Recruitment.Api.Domain_Layer.Contracts
{
    public interface IUserService
    {
        UserDto CreateUser(string name, string email, string address, string phone, string userType, string money);
    }
}
