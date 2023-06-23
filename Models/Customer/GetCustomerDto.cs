using Session4.Models.Loan;

namespace Session4.Models.Customer
{
    public class GetCustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<GetAllLoanDto>? Loans { get; set; }
    }
}
