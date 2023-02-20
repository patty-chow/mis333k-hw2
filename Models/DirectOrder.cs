using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Chow_Patty_HW2.Models
{
    public class DirectOrder : Order
    {
        // Rate and fee constants
        const Decimal SALES_TAX_RATE = 0.0825m;

        [Display(Name = "Customer Name:")]
        public String? CustomerName { get; set; }


        [Display(Name = "Sales Tax:")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal SalesTax { get; set; }
        public void CalcTotals()
        {
            base.CalcSubtotals();
            // Convert Int32?s to Int32 to be usable for calculating ProcessingFee
            Int32 Paperbacks = (Int32)NumberOfPaperbacks;
            Int32 Hardbacks = (Int32)NumberOfHardbacks;
            SalesTax = Subtotal * SALES_TAX_RATE;
            Total = Subtotal + SalesTax;
        }
    }
}
