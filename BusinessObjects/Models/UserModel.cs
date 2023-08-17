namespace BusinessObjects.Models
{
    public class UserModel
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }



        public override string? ToString()
        {
            if (FirstName != null && LastName != null)
                return ($"Email: {Email} Password:{Password}, FirstName: {FirstName} LastName:{LastName}");
            else
                return ($"Email: {Email} Password:{Password}");
        }
    }
}
