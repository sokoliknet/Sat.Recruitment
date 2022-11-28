using System;
using System.Collections.Generic;
using AutoMapper;
using Moq;
using Sat.Recruitment.Api.Data_Access_Layer.Contracts;
using Sat.Recruitment.Api.Data_Access_Layer.Entities;
using Sat.Recruitment.Api.Domain_Layer.DomainService;
using Sat.Recruitment.Api.Mappings;
using Xunit;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UnitTest1
    {
        public Mock<IUserRepository> mock = new Mock<IUserRepository>();

        private List<User> context = new List<User>() {
            new User { Name = "Juan", Email = "Juan@marmol.com", Address = "Peru 2464,Normal", Phone= "+5491154762312", UserType = "Normal", Money=1234 },
            new User { Name = "Franco", Email = "Franco.Perez@gmail.com", Address = "Alvear y Colombres", Phone= "+534645213542", UserType = "Premium", Money=112234 },
            new User { Name = "Agustina", Email = "Agustina@gmail.com", Address = "Garay y Otra Calle", Phone= "+534645213542", UserType = "SuperUser", Money=112234 }
        };

        public MapperConfiguration mockMapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new UserMapping());
        });

        [Fact]
        public void CreateUser()
        {
            mock.Setup(u => u.ReadUsers()).Returns(context);
            var result = new UserService(mock.Object, mockMapper.CreateMapper())
                .CreateUser("Andriy","sokol@ya.com","Barcelona, Spain","+34629501214","SuperHero", "9999999");

            Assert.NotNull(result);
            Assert.Equal("Andriy", result.Name);
            Assert.True(result != null);
        }

        [Fact]
        public void IsUserDuplicated()
        {
            mock.Setup(u => u.ReadUsers()).Returns(context);
            var result = new UserService(mock.Object, mockMapper.CreateMapper())
                .CreateUser("Franco", "Agustina@gmail.com", "Alvear y Colombres", "+534645213542", "Normal", "112234");

            Assert.Null(result);
        }   
    }
}
