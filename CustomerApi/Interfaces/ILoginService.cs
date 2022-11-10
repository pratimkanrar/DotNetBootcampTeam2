using CustomerApi.Entities;

namespace CustomerApi.Interfaces
{
    public interface ILoginService
    {
        string Generate(Customer Customer);
        Customer Authenticate(CustomerLogin Customerlogin);
        void ChangePassword(CustomerLogin Customerlogin);
    }
}
