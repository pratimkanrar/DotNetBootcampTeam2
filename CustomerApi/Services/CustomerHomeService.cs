using CustomerApi.Database;
using CustomerApi.Entities;
using CustomerApi.Interfaces;

namespace CustomerApi.Services
{
    public class CustomerHomeService : ICustomerHomeService
    {
        private readonly CustomerDBContext context;
        public CustomerHomeService()
        {
            context =  new CustomerDBContext();
        }
        public Customer GetCustomerDetails(string username, string email)
        {
            Customer customer = this.context.Customers.SingleOrDefault(o=>o.Username == username && o.Email == email);
            return customer;
        }
    }
}
