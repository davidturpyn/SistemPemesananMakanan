using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using SistemPemesananMakanan.Areas.Identity.Data;
using SistemPemesananMakanan.Models;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;

namespace SistemPemesananMakanan.Controllers
{
    public class PesananController : Controller
    {
        private ApplicationContext db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PesananController(ApplicationContext db, IWebHostEnvironment webHostEnvironment)
        {
            this.db = db;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Pesanan> lsData = db.Pesanan.Where(x => x.Status == "Aktif").ToList();
            return View(lsData);
        }
        public IActionResult Create()
        {
            DateTime tgl = DateTime.Now;
            var pesanan = db.Pesanan.OrderByDescending(x => x.Id).Take(1).FirstOrDefault();
            var nomorPesanan = "";

            if (pesanan != null)
            {
                nomorPesanan = "ABC" + tgl.ToString("ddMMyyyy") + "-" + (pesanan.Id + 1);
            }
            else
            {
                nomorPesanan = "ABC" + tgl.ToString("ddMMyyyy") + "-" + 1;
            }

            List<MasterMenu> makanan = db.MasterMenu.Where(x => x.Jenis == "Makanan" && x.Status == "Ready").ToList();
            List<MasterMenu> minuman = db.MasterMenu.Where(x => x.Jenis == "Minuman" && x.Status == "Ready").ToList();

            ViewBag.makanan = makanan;
            ViewBag.minuman = minuman;
            ViewBag.nomorPesanan = nomorPesanan;
            return View();
        }

        public IActionResult Insert(string nomorPesanan, int nomorMeja, int idMakanan, int idMinuman, ApplicationUser user)
        {
            Pesanan newData = new Pesanan();
            newData.NomorPesanan = nomorPesanan;
            newData.NomorMeja = nomorMeja;
            newData.Status = "Aktif";
            newData.createdBy = user.firstName;
            newData.createdDate = DateTime.Now;
            if (idMakanan != null)
            {
                newData.MakananId = idMakanan;
            }
            if (idMinuman != null)
            {
                newData.MinumanId = idMinuman;
            }
            db.Add(newData);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Policy = "kasir")]
        public IActionResult ConfirmPayment(int id, ApplicationUser user)
        {
            Pesanan update = db.Pesanan.Find(id);
            update.Status = "Selesai Dibayar";
            update.updatedBy = user.firstName;
            update.updatedDate = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult History(ApplicationUser user)
        {
            List<Pesanan> lsData = db.Pesanan.Where(x => x.Status == "Selesai Dibayar" && x.updatedBy == user.firstName).ToList();
            return View(lsData);
        }

        public IActionResult DownloadExcel(ApplicationUser user)
        {
            #region inisialisasi
            string webRootPath = _webHostEnvironment.WebRootPath;
            string tempFileName = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".xls";
            string path = "";
            path = Path.Combine(webRootPath, tempFileName);
            List<Pesanan> lsData = db.Pesanan.Where(x => x.Status == "Selesai Dibayar" && x.updatedBy == user.firstName).ToList();
            #endregion

            #region checkFileExisting
            FileInfo newFile = new FileInfo(path);
            if (newFile.Exists)
            {
                newFile.Delete();  // ensures we create a new workbook
                newFile = new FileInfo(path);
            }
            #endregion

            //if (lsData.Count > 0)
            //{
            //    using (ExcelPackage package = new ExcelPackage(newFile))
            //    {
            //        ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Laporan Pesanan");
            //        worksheet.Cells[1, 1].Value = "NOMOR PESANAN";
            //        worksheet.Cells[1, 2].Value = "NOMOR MEJA";
            //        worksheet.Cells[1, 3].Value = "Status";

            //        foreach (Pesanan p in lsData)
            //        {
            //            int count = 1;
            //            worksheet.Cells[2, count].Value = p.NomorPesanan;
            //            worksheet.Cells[2, count].Value = p.NomorMeja;
            //            worksheet.Cells[2, count].Value = p.Status;
            //            count++;
            //        }
            //        package.Save();
            //        return File(newFile.FullName, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            //    }

            //}
            return View();

        }
    }
}
