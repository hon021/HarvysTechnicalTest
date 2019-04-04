using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvy.Ordonez.Model.InvoicesDetail
{
    class InvoceDetailRequest
    {
        public int IdInvoiceDetail { get; set; }
        public int IdItem { get; set; }
        public int IdInvoice { get; set; }
        public decimal TaxValue { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
