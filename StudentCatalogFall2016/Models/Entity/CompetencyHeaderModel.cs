using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentCatalogFall2016.Models
{
    public class CompetencyHeaderModel
    {
        public int CompetencyHeaderModelId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CompetencyModel> Competencies { get; set; }
    }
}