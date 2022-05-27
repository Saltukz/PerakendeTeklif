using Microsoft.AspNetCore.Mvc;
using PerakendeTeklif.Constants;
using PerakendeTeklif.Models;
using System.Diagnostics;
using static PerakendeTeklif.Constants.Tedas;

namespace PerakendeTeklif.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new AboneViewModel();
        
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(AboneViewModel model)
        {
            if (ModelState.IsValid)
            {
                if(model.AylikTuketim < 8250)
                {
                
                    TempData["message"] = "Sayın Müşteri, aktif enerji fiyatiniz bir yil boyunca sabit xxx krs/kWh olacaktir. Ustelik dagitim sirketinden guvence bedelinizi iade alabileceksiniz.";
                    return View(model);
                }
                else
                {
                    double cereanBirimFiyat = 0.42 * (1 + model.AnlastmaKatsayisi);


                    var gerilim =Enum.GetName(typeof(Gerilim), model.Gerilim);
                    var mesken = Enum.GetName(typeof(Mesken), model.Mesken);

                   

                    int yuzde = yuzdeHesapla(cereanBirimFiyat, Tedas.BirimFiyatAl(gerilim,mesken));

                    int aylik = indirimHesapla(yuzde, (double)model.AylikTuketim, Tedas.BirimFiyatAl(gerilim, mesken), mesken);

                    TempData["message"] = $"Sayın Müşteri,Faturanıze {yuzde}% indirim uygulanacaktır. Aylık kazancınız {aylik} TL olacaktır.";

                    return View(model);
                }
            }

            return View(model);
        }

        private int indirimHesapla(int yuzde, double aylikTuketim, double tedasBirimFiyat, string mesken)
        {
            if(mesken == "Sanayi")
            {
                return ((int)(aylikTuketim * 1.2036 * tedasBirimFiyat)* yuzde)/100;
            }
            else
            {
                return ((int)(aylikTuketim * 1.2744 * tedasBirimFiyat) * yuzde) / 100;

            }
            
        }

        private int yuzdeHesapla(double cereanBirimFiyat, double tedasBirimFiyat)
        {
            return (int)(cereanBirimFiyat / tedasBirimFiyat) - 1;
        }
    }
}