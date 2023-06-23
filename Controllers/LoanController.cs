using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Session4.Context;
using Session4.Models.Loan;
using Session4.Repository;

namespace Session4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : Controller
    {
        public readonly ILoanRepository _loanRepository;
        public readonly IMapper _mapper;

        public LoanController(ILoanRepository loanRepository, IMapper mapper)
        {
            _loanRepository = loanRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetAllLoans()
        {
            List<Loan> allLoans = _loanRepository.GetAllLoans();
            var records = _mapper.Map<List<GetAllLoanDto>>(allLoans);
            return Ok(records);
        }

        [HttpGet("{id}")]
        public ActionResult<GetLoanDetailsDto> GetLoanById(int id)
        {
            Loan loan = _loanRepository.GetLoanById(id);
            var loanDto = _mapper.Map<GetLoanDetailsDto>(loan);
            return Ok(loanDto);
        }

        [HttpPost]
        public IActionResult AddLoan(AddLoanDto addLoanDto)
        {
            if (ModelState.IsValid)
            {
                var loan = _mapper.Map<Loan>(addLoanDto);
                _loanRepository.AddLoan(loan);
                return CreatedAtAction(nameof(GetLoanById), new { id = loan.Id }, loan);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateLoanDetails(int id, AddLoanDto addLoan)
        {
            var existingLoan = _loanRepository.GetLoanById(id);
            if (existingLoan == null)
            {
                return NotFound();
            }

            _mapper.Map(addLoan, existingLoan);

            if (_loanRepository.UpdateLoan(existingLoan))
            {
                return NoContent();
            }

            return StatusCode(StatusCodes.Status500InternalServerError, "Failed to update the loan details");
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteLoan(int id)
        {
            var existingLoan = _loanRepository.GetLoanById(id);
            if (existingLoan == null)
            {
                return NotFound();
            }

            if (_loanRepository.DeleteLoan(existingLoan))
            {
                return NoContent();
            }

            return StatusCode(StatusCodes.Status500InternalServerError, "Failed to delete the Loan.");
        }
    }
}
