namespace MyFinalProject.Models
{
    public class UserDeliveryAddressModel

    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string HomePhone { get; set; }
        public string State { get; set; }
        public string Alias { get; set; }

        public override string? ToString()
        {
            return ($"FirstName: {FirstName}, " +
                $"LastName: {LastName}, " +
                $"Address: {Address}, " +
                $"PostalCode: {PostalCode}, " +
                $"City: {City}, " +
                $"Country: {Country}, " +
                $"HomePhone: {HomePhone}, " +
                $"State: {State}, " +
                $"Alias: {Alias}");
        }
    }
}

