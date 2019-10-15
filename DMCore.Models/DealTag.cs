using System;
using System.Collections.Generic;
using System.Text;

namespace DMCore.Models
{
    public class DealTag
    {
        public DealTag()
        {
            Deals = new HashSet<Deal>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Deal> Deals { get; set; }
    }
}
