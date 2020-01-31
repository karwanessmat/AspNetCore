using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DealDouble.Web.ViewModels.Production
{
    public class ProductionViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Fill in")]
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Please Fill in")]
        public decimal ActualAmount { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd,MM,yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Please Fill in")]
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartingDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd,MM,yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Please Fill in")]
        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime EndingDate { get; set; }
    }
}
