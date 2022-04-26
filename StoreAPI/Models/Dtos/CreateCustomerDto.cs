

namespace StoreAPI.Models.Dtos
{
    //TODO can get rid because we don't need it

    //Create so that FK Address object didn't return null
    public class CreateCustomerDto
    {
        public string Name { get; set; } 

        public Address address { get; set; } //send address object, insert to address table then get back address id to insert in customer table

    }
}
