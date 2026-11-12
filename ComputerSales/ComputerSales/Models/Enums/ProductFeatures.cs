using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerSales.Models.Enums
{
    [Flags]
    public enum ProductFeatures
    {
        None = 0,
        Fragile = 1,       
        Heavy = 2,         
        NeedsAssembly = 4  
    }
}