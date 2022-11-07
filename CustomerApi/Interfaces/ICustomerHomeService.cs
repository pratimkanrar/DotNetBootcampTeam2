using CustomerApi.Entities;

namespace CustomerApi.Interfaces
{
    public interface ICustomerHomeService
    {
        Customer GetCustomerDetails(string username, string email);
    }
}
