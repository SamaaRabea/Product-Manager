using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Shop.DAL;

public partial class Product_Version
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Product_Version_Id { get; set; }

    [ForeignKey("Product")]
    public string Code { get; set; }

    public int ItemNo { get; set; }

    public DateTime? VersionDate { get; set; }

    public byte[]? FileUp { get; set; }
    public virtual Product Product { get; set; } = null!;
}