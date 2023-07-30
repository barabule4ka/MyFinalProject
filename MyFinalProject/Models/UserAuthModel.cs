using Bogus.DataSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyFinalProject.Models
{
    public class UserAuthModel
    {
        public string Email { get; set; }
        public string Password { get; set; }


        public override string? ToString()
        {
            return $"Email: {Email} Password:{Password}";
        }
    }
}
