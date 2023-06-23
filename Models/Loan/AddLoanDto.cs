namespace Session4.Models.Loan
{
    public class AddLoanDto
    {
        public decimal Amount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int CustomerId { get; set; }
    }
}
