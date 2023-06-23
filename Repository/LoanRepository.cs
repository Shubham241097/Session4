using Session4.Context;

namespace Session4.Repository
{
    public class LoanRepository : ILoanRepository
    {
        public readonly LoanAppDbContext _context;

        public LoanRepository(LoanAppDbContext context)
        {
            _context = context;
        }

        public Loan AddLoan(Loan loan)
        {
            _context.Loans.Add(loan);
            _context.SaveChanges();
            return loan;
        }

        public bool DeleteLoan(Loan loan)
        {
            _context.Loans.Remove(loan);
            return _context.SaveChanges() == 1;
        }

        public List<Loan> GetAllLoans()
        {
            return _context.Loans.ToList();
        }

        public Loan GetLoanById(int id)
        {
            return _context.Loans.FirstOrDefault(a => a.Id == id);
        }

        public Loan LoanDetails(int id)
        {
            return _context.Loans.FirstOrDefault(l => l.Id == id);
        }

        public bool UpdateLoan(Loan loan)
        {
            _context.Loans.Update(loan);
            return _context.SaveChanges() == 1;
        }
    }
}
