using DDD_Dropshipping.Ordering.Domain.SeedWork;

namespace DDD_Dropshipping.Ordering.Domain.OrderAggregate
{
    public class Address : ValueObject
    {
        public string Country { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string Street { get; private set; }
        public string StreetNumber { get; set; }
        public int? ApartmentNumber { get; set; }


        public Address(
            string country, 
            string city, 
            string postalCode, 
            string street,
            string streetNumber,
            int? apartmentNumber)
        {
            // ?? Validation
            Country = country;
            City = city;
            PostalCode = postalCode;
            Street = street;
            StreetNumber = streetNumber;
            ApartmentNumber = apartmentNumber;
        }


    }
}
