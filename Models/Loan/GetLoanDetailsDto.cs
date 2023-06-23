namespace Session4.Models.Loan
{
    public class GetLoanDetailsDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int CustomerId { get; set; }
    }
}
