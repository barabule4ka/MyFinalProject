using Bogus;
using Core.Configuration;
using MyFinalProject.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinalProject.Models
{
    public class UserBuilder
    {
        static Faker FakeTD = new();
        public static UserAuthModel UseRealUser()
        {
            return new UserAuthModel()
            {
                Email = AppConfig.RealUser.RealUserEmail,
                Password = AppConfig.RealUser.RealUserPassword
            };
        }

        //PasswordLength should be <5 for test passing
        public static UserAuthModel UseRealUserWitIncorrectPass()
        {
            return new UserAuthModel()
            {
                Email = AppConfig.RealUser.RealUserEmail,
                Password = FakeTD.Internet.Password(5) //не забыть заменить, чтоб кейс не падал
            };

        }

        public static UserAuthModel LoginAsFakeUser() {
            return new UserAuthModel()
            {
                Email = FakeTD.Internet.Email(),
                Password = FakeTD.Internet.Password(6)
            };
        }
    }
}
