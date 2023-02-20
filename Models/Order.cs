using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Chow_Patty_HW2.Models
{
    public enum CustomerType { Wholesale, Direct }
    public abstract class Order
    {
        // Price constants
        const Decimal HARDBACK_PRICE = 17.95m;
        const Decimal PAPERBACK_PRICE = 9.50m;
        [Display(Name = "Customer Type:")]
        public CustomerType Customer_Type { get; set; }

        [Display(Name = "Number of Hardbacks:")]
        [Required(ErrorMessage = "Specify a number of hardbacks")]
        [Range(minimum: 0, maximum: double.PositiveInfinity, ErrorMessage = "Please enter a positive number")]
        [DisplayFormat(DataFormatString = "{0}")]
        // Use Int32? instead of Int32 for [Required] to be implemented properly
        public Int32? NumberOfHardbacks { get; set; }

        [Display(Name = "Number of Paperbacks:")]
        [Required(ErrorMessage = "Specify a number of paperbacks")]
        [Range(minimum: 0, maximum: double.PositiveInfinity, ErrorMessage = "Please enter a positive number")]
        [DisplayFormat(DataFormatString = "{0}")]

        public Int32? NumberOfPaperbacks { get; set; }
        [Display(Name = "Number of Total Items:")]
        [DisplayFormat(DataFormatString = "{0}")]
        public Decimal TotalItems { get; set; }
        [Display(Name = "Hardback Subtotal:")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal HardbackSubtotal { get; set; }

        [Display(Name = "Paperback Subtotal:")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal PaperbackSubtotal { get; set; }

        [Display(Name = "Subtotal:")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal Subtotal { get; set; }

        [Display(Name = "Total:")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal Total { get; set; }

        public void CalcSubtotals()
        {
            Int32 Paperbacks = (Int32)NumberOfPaperbacks;
            Int32 Hardbacks = (Int32)NumberOfHardbacks;
            TotalItems = Hardbacks + Paperbacks;
            // Throws an exception if total items == 0
            if (TotalItems == 0)
            {
                throw new ArgumentException("Total items cannot be 0");
            }
            HardbackSubtotal = Hardbacks * HARDBACK_PRICE;
            PaperbackSubtotal = Paperbacks * PAPERBACK_PRICE;
            Subtotal = HardbackSubtotal + PaperbackSubtotal;
        }
    }
}