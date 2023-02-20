using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Chow_Patty_HW2.Models
{
    public class WholesaleOrder : Order
    {
        [Display(Name = " Is this a preferred customer?")]
        public bool PreferredCustomer { get; set; }

        [Display(Name = "Customer Code:")]
        [StringLength(6, MinimumLength = 4, ErrorMessage = " Customer code must be 4-6 Characters")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Customer code may only contain letters")]
        [Required(ErrorMessage = "Specify a Customer Code")]
        public String? CustomerCode { get; set; }

        [Display(Name = "Delivery Fee:")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        [Range(minimum: 0, maximum: 250, ErrorMessage = "Please enter a number between 0 and 250.")]
        [Required(ErrorMessage = "Delivery Fee is required")]
        // Decimal? instead of Decimal for [Required] to be implemented properly
        public Decimal? DeliveryFee { get; set; }

        public void CalcTotals()
        {
            // Convert Setup from Decimal? to Decimal to be usable when calculating Total
            Decimal Delivery = (Decimal)DeliveryFee;
            base.CalcSubtotals();
            if (PreferredCustomer == true || Subtotal > 1200)
            {
                DeliveryFee = 0;
                Total = Subtotal;
            }
            else
            {
                Total = Subtotal + Delivery;
            }

        }
    }
}
