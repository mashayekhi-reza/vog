using AutoMapper;
using System.Collections.Generic;
using VogCodeChallenge.API.DTOs;
using VogCodeChallenge.Domain;

namespace VogCodeChallenge.API.Helpers
{
    public interface IEmployeeMapper
    {
        IEnumerable<EmployeeDTO> MapToDTO(IEnumerable<Employee> employees);
    }

    public class EmployeeMapper : IEmployeeMapper
    {
        private readonly IMapper _mapper;

        public EmployeeMapper()
        {
            _mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDTO>()
                    .ForMember(dest => dest.Company, opt => opt.MapFrom(src => src.Department.Company.Name))
                    .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department.Name));
            }));
        }

        public IEnumerable<EmployeeDTO> MapToDTO(IEnumerable<Employee> employees)
        {
            return _mapper.Map<IEnumerable<EmployeeDTO>>(employees);
        }
    }
}
