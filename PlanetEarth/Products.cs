//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PlanetEarth
{
    using System;
    using System.Collections.Generic;
    
    public partial class Products
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Manufacturer { get; set; }
        public int Country { get; set; }
        public int Branch { get; set; }
        public int Amount { get; set; }
        public System.DateTime ProdDate { get; set; }
    
        public virtual Branches Branches { get; set; }
        public virtual Countries Countries { get; set; }
        public virtual Manufacturer Manufacturer1 { get; set; }
        public string CountryName { get { return Branches.Name; } }
        public string BranchName { get { return Countries.Name; } }
        public string ManufacturerName { get { return Manufacturer1.Name; } }
    }
}
