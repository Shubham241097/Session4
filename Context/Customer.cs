using System.ComponentModel.DataAnnotations;

namespace Session4.Context
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<Loan> Loans { get; set; }
    }
}
