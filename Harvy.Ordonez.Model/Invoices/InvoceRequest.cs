using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvy.Ordonez.Model.Invoices
{
    class InvoceRequest
    {
        public int IdInvoice { get; set; }
        public System.DateTime InvoiceDate { get; set; }
        public decimal Amount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalTax { get; set; }
    }
}
