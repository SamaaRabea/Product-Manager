//using MessagePack;
using System;
using System.Collections.Generic;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;
namespace Shop.DAL;

public partial class Product
{
    [Key]
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

    public byte[]? UploadFiles { get; set; }

    public virtual ICollection<Product_Version> Product_Version { get; set; }=new HashSet<Product_Version>();
}