using Sat.Recruitment.Api.Data_Access_Layer.Entities;
using System.Collections.Generic;

namespace Sat.Recruitment.Api.Data_Access_Layer.Contracts
{
    public interface IUserRepository
    {
        List<User> ReadUsers();
    }
}
