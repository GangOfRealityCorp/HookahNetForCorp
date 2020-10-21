using HookahNet.Controllers.ControllerDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HookahNet.Models
{
    public class Organization : IOrganizationInfo
    {
        public Guid Id { get; private set; }
        public string SKU { get; private set; }
        public string Name { get; private set; }
        public virtual Catalog? Catalog { get; private set; }

        public Organization()
        {
        }
        public Organization(OrganizationDTO DTO)
        {
            this.SKU = DTO.SKU;
            this.Name = DTO.Name;
        }

        //public Catalog GetCatalog()
        //{
        //    return Catalog;
        //}
    }
}
