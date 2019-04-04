using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvy.Ordonez.Model.Items
{
    public class ItemVM
    {
        public int IdItem { get; set; }
        public string TypeItem { get; set; }
        public string Name { get; set; }
        public decimal Quantity { get; set; }
        public decimal SalePrice { get; set; }
        public string Photo { get; set; }
        public bool IsTax { get; set; }
        public bool IsInventory { get; set; }
    }
}
