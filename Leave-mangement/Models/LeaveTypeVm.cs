using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_mangement.Models
{
    public class LeaveTypeVm
    {
        public int Id { get; set; }
        [Required]

        public string Name { get; set; }
        [Display(Name="Date Created ")]
        public DateTime? DateCreated { get; set; }
    }
   
}
