namespace Rasot.Core.Domain.Customers
{
    public class Customer:BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public int PasswordFormatType { get; set; }
    }
}
