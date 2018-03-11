using Lab8.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab8.Data.Entities
{
    public class Watches
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Watch's Name")]
        public string Name { get; set; }

        [Display(Name = "Watch's Purchase years")]
        public int PurchaseYears{ get; set; }

        [Display(Name = "Next Maintaince")]
        public DateTime NextMaintaince { get; set; }

   
        [Display(Name = "Owner's ID")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}