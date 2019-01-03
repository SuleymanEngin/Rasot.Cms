using Rasot.Web.Models.Customers;

namespace Rasot.Web.Factories
{
    public interface ICustomerModelFactory
    {
        CustomerShortModel PrepareCustomerShortModel(int Id);
    }
}
