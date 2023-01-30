using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shope.BL.Dto
{
    public class ProductDto
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public int VersionNum { get; set; }

        public int? RevisionNum { get; set; }

        public DateTime? VersionDate { get; set; }

        public DateTime? EditDate { get; set; }

        public DateTime? NextRevieweDate { get; set; }

        public string? EditBy { get; set; }

        public string? ReviewedBy { get; set; }

        public string? ApprovedBy { get; set; }

        //public byte[]? UploadFiles { get; set; }
        
       public List<Product_VersionDto> Product_Versions { get; set; }
    }
}
