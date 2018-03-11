using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab8.Models.ViewModel
{
    public class WatchesViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "watch's Name")]
        public string Name { get; set; }

        [Display(Name = "watch's Purchase Years")]
        public int PurchaseYears { get; set; }

        [Display(Name = "Next Maintaince Date")]
        public DateTime NextMaintaince { get; set; }


        [Display(Name = "Owner's ID")]
        public string UserId { get; set; }

        public bool CheckupAlert;
    }
}