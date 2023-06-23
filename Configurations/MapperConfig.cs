using AutoMapper;
using Session4.Context;
using Session4.Models.Customer;
using Session4.Models.Loan;

namespace Session4.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Loan, AddLoanDto>().ReverseMap();
            CreateMap<Loan, GetAllLoanDto>().ReverseMap();
            CreateMap<Loan, GetLoanDetailsDto>().ReverseMap();
            CreateMap<Customer, GetCustomerDto>().ReverseMap();            
        }
    }
}
