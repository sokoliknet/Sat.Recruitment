using AutoMapper;
using Sat.Recruitment.Api.Data_Access_Layer.Contracts;
using Sat.Recruitment.Api.Data_Access_Layer.Entities;
using Sat.Recruitment.Api.Domain_Layer.Contracts;
using Sat.Recruitment.Api.Domain_Layer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sat.Recruitment.Api.Domain_Layer.DomainService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public UserDto CreateUser(string name, string email, string address, string phone, string userType, string money)
       {
            var users = _mapper.Map<List<User>, List<UserDto> >(_userRepository.ReadUsers());

            var isDuplicated = false;

            if (users.Where(u => u.Email == email || u.Phone == phone).Any())
            {
                isDuplicated = true;
            }

            if (users.Where(u => u.Name == name || u.Address == address).Any())
            {
                isDuplicated = true;
            }

            if (!isDuplicated)
            {
                var newUser = new User
                {
                    Name = name,
                    Email = email,
                    Address = address,
                    Phone = phone,
                    UserType = userType,
                    Money = decimal.Parse(money)
                };


                // Spaghetti & nesting Code :) let's talk about it in interview 
                if (newUser.UserType == "Normal")
                {
                    if (decimal.Parse(money) > 100)
                    {
                        var percentage = Convert.ToDecimal(0.12);
                        //If new user is normal and has more than USD100
                        var gif = decimal.Parse(money) * percentage;
                        newUser.Money = newUser.Money + gif;
                    }
                    if (decimal.Parse(money) < 100)
                    {
                        if (decimal.Parse(money) > 10)
                        {
                            var percentage = Convert.ToDecimal(0.8);
                            var gif = decimal.Parse(money) * percentage;
                            newUser.Money = newUser.Money + gif;
                        }
                    }
                }
                if (newUser.UserType == "SuperUser")
                {
                    if (decimal.Parse(money) > 100)
                    {
                        var percentage = Convert.ToDecimal(0.20);
                        var gif = decimal.Parse(money) * percentage;
                        newUser.Money = newUser.Money + gif;
                    }
                }
                if (newUser.UserType == "Premium")
                {
                    if (decimal.Parse(money) > 100)
                    {
                        var gif = decimal.Parse(money) * 2;
                        newUser.Money = newUser.Money + gif;
                    }
                }

               return _mapper.Map<User, UserDto>(newUser);
            }

            return null;
        }
    }
}
