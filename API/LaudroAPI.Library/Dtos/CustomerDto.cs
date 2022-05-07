

using System;

namespace LaundroAPI.Library.Dtos
{
    public record CustomerDto(int Id, string FirstName, string LastName, string Address, string Phone, string Email, DateTime CreatedDate, int Points);
    public record CreateCustomerDto(string FirstName, string LastName, string Address, string Phone, string Email);
    public record CustomerNameAndIdDto(string FullnameWithId, int Id);

}
