using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EliasIT.API.Models
{
    public partial class ArchiveModel
    {
        [Key]
        [Column(Order = 1)]
        public int pId { get; set; }
        [Display(Name = "Navn")]
        public string pName { get; set; }
        [Display(Name = "Antall")]
        public int pTotal { get; set; }
        [Display(Name = "Kostnad")]
        public decimal pPrice { get; set; }
        [Display(Name = "Beskrivelse")]
        public string pDescription { get; set; }
        [Display(Name = "Lagertype")]
        public string pStorageType { get; set; }
        [Display(Name = "Forfatter")]
        public string pAuthor { get; set; }
        [Display(Name = "ImagePath")]
        public string pImagePath { get; set; }
        [Display(Name = "Status")]
        public string pStatus { get; set; }

        [ForeignKey("Categories")]
        [Column(Order = 2)]
        public int Categories_Id { get; set; }
        public virtual CategoriesModel Categories { get; set; }
        //public virtual ApplicationUser User { get; set; }
        //public string ApplicationUserId { get; set; }

    }
}