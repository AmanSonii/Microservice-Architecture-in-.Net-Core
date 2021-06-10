using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Product.Microservices.Model
{
    public class ProductData
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        public string ProductNumber { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }       

        [Required]
        [StringLength(15)]
        public string Condition { get; set; }
              

        [Column(TypeName = "money")]
        public decimal? StandardCost { get; set; }

        
        [StringLength(15)]
        public string Color { get; set; }        

        public int Stock { get; set; }       

    }
}
