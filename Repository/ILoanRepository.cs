using Session4.Context;

namespace Session4.Repository
{
    public interface ILoanRepository
    {
        public Loan AddLoan(Loan loan);
        public bool UpdateLoan(Loan loan);
        public bool DeleteLoan(Loan loan);
        public Loan LoanDetails(int id);
        public List<Loan> GetAllLoans();
        public Loan GetLoanById(int id);
    }
}
