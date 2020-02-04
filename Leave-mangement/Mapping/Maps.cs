using AutoMapper;
using Leave_mangement.Data;
using Leave_mangement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_mangement.Mapping
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<LeaveType, DetailsLeaveTypeVm>().ReverseMap();
            CreateMap<LeaveType, CreateLeaveTypeVm>().ReverseMap();
            CreateMap<LeaveHistory, LeaveHistoryVm>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationVm>().ReverseMap();
            CreateMap<Employee, EmployeeVm>().ReverseMap();
           
        }
    }
}
