using System.ComponentModel.DataAnnotations;

namespace Project_CodeFirst
{
    public class AkhundovLibrary
    {
        [Key]

         public int id { get; set; }     
         public string Book { get; set; }

         public string BookAuthor { get; set; }

         public int ProductionYear { get; set; }

         public double Cost { get; set; }
    }
}
