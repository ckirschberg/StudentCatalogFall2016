using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentCatalogFall2016.Models
{
    public class CompetencyModel
    {
        public int CompetencyModelId { get; set; }
        public string Name { get; set; }

        public int CompetencyHeaderModelId { get; set; }
        public virtual CompetencyHeaderModel CompetencyHeaderModel { get; set; }
    }
}