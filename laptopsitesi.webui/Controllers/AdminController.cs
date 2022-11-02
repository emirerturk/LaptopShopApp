using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using laptopsitesi.webui.Data;
using laptopsitesi.webui.Models;

namespace laptopsitesi.webui.Controllers
{
    public class AdminController : Controller
    {

        public IActionResult list(int? id)
        {
            var products = ProductRepository.Products;

            var productViewModel = new ProductViewModel()
            {
                Products = products
            };
            return View(productViewModel);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {

            return View(ProductRepository.GetProductById(id));
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            var laptop = new MySqlLaptopDal();
            var ekle = new Laptop()
            {
                Fiyat = product.Fiyat,
                Baslik = product.Baslik,
                Marka = product.Marka,
                Model = product.Model,
                EkranBoyutu = product.EkranBoyutu,
                EkranKarti = product.EkranKarti,
                IslemciModeli = product.IslemciModeli,
                IsletimSistemi = product.IsletimSistemi,
                DiskKapasitesi = product.DiskKapasitesi,
                BellekKapasitesi = product.BellekKapasitesi,
                DiskTuru = product.DiskTuru,
                Puan = product.Puan

            };

            laptop.Update(product);
            return RedirectToAction("list");
        }
        [HttpGet]
        public IActionResult CreateProduct(int id)
        {

            return View(ProductRepository.GetProductById(id));
        }
        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            var laptop = new MySqlLaptopDal();

            var ekle = new Laptop()
            {
                Fiyat = product.Fiyat,
                Baslik = product.Baslik,
                Marka = product.Marka,
                Model = product.Model,
                EkranBoyutu = product.EkranBoyutu,
                EkranKarti = product.EkranKarti,
                IslemciModeli = product.IslemciModeli,
                IsletimSistemi = product.IsletimSistemi,
                DiskKapasitesi = product.DiskKapasitesi,
                BellekKapasitesi = product.BellekKapasitesi,
                DiskTuru = product.DiskTuru,
                Puan = product.Puan

            };
            string kontrol = laptop.Kontrol(ekle);
            if (kontrol == null)
            {
                return NotFound();
            }
            else
            {
                return RedirectToAction("list");
            }

        }

        public IActionResult DeleteProduct(int laptopid)
        {
            var laptop = new MySqlLaptopDal();

            int kontrol = laptop.Delete(laptopid);

            if ((kontrol == 0))
            {
                return NotFound();
            }
            else
            {

                return RedirectToAction("list");

            }



        }
    }
}