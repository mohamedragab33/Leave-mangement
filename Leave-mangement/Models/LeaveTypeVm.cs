using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_mangement.Models
{
    public class DetailsLeaveTypeVm
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
    }
    public class CreateLeaveTypeVm
    {
      
        [Required]
        public string Name { get; set; }
      
    }
}
