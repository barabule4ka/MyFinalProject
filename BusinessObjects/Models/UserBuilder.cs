using Bogus;
using Core.Configuration;
using MyFinalProject.Models;
using OpenQA.Selenium;
using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Models
{
    public class UserBuilder
    {
        static Faker FakeTD = new();
        public static UserModel UseRealUser()
        {
            return new UserModel()
            {
                Email = AppConfig.RealUser.RealUserEmail,
                Password = AppConfig.RealUser.RealUserPassword
            };
        }

        //PasswordLength should be <5 for test passing
        public static UserModel UseRealUserWitIncorrectPass()
        {
            return new UserModel()
            {
                Email = AppConfig.RealUser.RealUserEmail,
                Password = FakeTD.Internet.Password(5) //не забыть заменить, чтоб кейс не падал
            };

        }

        public static UserModel LoginAsFakeUser() {
            return new UserModel()
            {
                Email = FakeTD.Internet.Email(),
                Password = FakeTD.Internet.Password(6)
            };
        }

        public static UserModel CreateFakeUser()
        {
            return new UserModel()
            {
                Email = FakeTD.Internet.Email(),
                FirstName = FakeTD.Name.FirstName(),
                LastName = FakeTD.Name.LastName(),
                Password = FakeTD.Internet.Password(8)
            };
        }

        public static UserDeliveryAddressModel CreateDeliveryAddress()
        {
            return new UserDeliveryAddressModel()
            {
                FirstName = FakeTD.Name.FirstName(),
                LastName = FakeTD.Name.LastName(),
                Address = FakeTD.Address.StreetAddress(),
                PostalCode = String.Join("", FakeTD.Random.Digits(5)),
                City = FakeTD.Address.City(),
                Country = "Украина",
                HomePhone = FakeTD.Phone.PhoneNumber(),
                State = "Украина",
                Alias = FakeTD.Random.Word()
            };
        }
    }
}
