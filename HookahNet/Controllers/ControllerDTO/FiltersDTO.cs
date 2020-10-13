using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HookahNet.Controllers.ControllerDTO
{
    public class FiltersDTO
    {
        public int FirstElement { get; set; }
        public int Quantity { get; set; }
        public OrganizationFilter.SortParameters SortParameter { get; set; }
    }
}
