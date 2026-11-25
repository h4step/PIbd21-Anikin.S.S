using System;

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