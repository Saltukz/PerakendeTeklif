using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace PerakendeTeklif.Models
{
    public class AboneViewModel
    {
        [Required]
        public int Mesken { get; set; }


        [Required]
        public int Gerilim { get; set; }

        [Required]
        public List<SelectListItem> Gerilimler { get; private set; }

        [Required(ErrorMessage ="Tüketim bedeli kwh cinsinden girilmesi zorunludur.")]
        [Range(1,100000000000)]
        public double? AylikTuketim { get; set; }

        [Required]
        [Range(3,10)]
        public int AnlastmaKatsayisi { get; set; }


        public AboneViewModel()
        {
            var ortaGerilim = new SelectListGroup { Name = "Orta Gerilim" };
            var alcakGerilim = new SelectListGroup { Name = "Alçak Gerilim" };


            Gerilimler = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text ="Çift Terimli",
                    Value = "0",
                    Group = ortaGerilim
                },
                 new SelectListItem
                {
                    Text ="Tek Terimli",
                    Value = "1",
                    Group = ortaGerilim
                },
                   new SelectListItem
                {
                    Text ="Tek Terimli",
                    Value = "2",
                    Group = alcakGerilim
                },
            };
        }
    }

   
}
