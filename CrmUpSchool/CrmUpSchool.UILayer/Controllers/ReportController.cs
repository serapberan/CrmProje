using ClosedXML.Excel;
using Crm.UpSchool.DataAccessLayer.Concrete;
using CrmUpSchool.UILayer.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CrmUpSchool.UILayer.Controllers
{
    [AllowAnonymous] 
    public class ReportController : Controller
    {
        //Static Excell Listesi
        public IActionResult ReporList()  //yönlrndirme için ekledik
        {
            return View();
        }

        #region Static Excell Kodları
        public IActionResult ExcelStatic()
        {
            ExcelPackage excelPackage = new ExcelPackage();
            var workSheet = excelPackage.Workbook.Worksheets.Add("Sayfa1");
            workSheet.Cells[1,1].Value="Personel Id";
            workSheet.Cells[1,2].Value="Personel Adı";
            workSheet.Cells[1,3].Value="Personel Soyadı";

            workSheet.Cells[2, 1].Value = "0001";
            workSheet.Cells[2, 2].Value = "Tuba";
            workSheet.Cells[2, 3].Value = "Zorlu";

            workSheet.Cells[3, 1].Value = "0002";
            workSheet.Cells[3, 2].Value = "Serap";
            workSheet.Cells[3, 3].Value = "Beran";

            var bytes = excelPackage.GetAsByteArray();
          
            return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "personeller.xlsx");  //google excel content type uzantıyı alıyoruz
        }
     

        public List<CustomerViewModel> CustomerList()
        {
            List<CustomerViewModel> customerViewModels = new List<CustomerViewModel>();
            using (var context = new Context())
            {
                customerViewModels = context.Customers.Select(x => new CustomerViewModel
                {
                    Name = x.CustomerName,
                    Surname = x.CustomerSurname,
                    Phone = x.CustomerPhone,
                    Mail = x.CustomerMail
                }).ToList();
            }
            return customerViewModels;
        }
        #endregion


        #region DynamicExcel Kodları
        public IActionResult DynamicExcel()
        {
            using(var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Müşteri Listesi");
            
                workSheet.Cell(1, 2).Value = "Müsteri Adı";
                workSheet.Cell(1, 3).Value = "Müsteri Soyadı";
                workSheet.Cell(1, 1).Value = "Müsteri Telefon";
                workSheet.Cell(1, 4).Value = "Müsteri Mail";

                int rowCount = 2;
                foreach (var item in CustomerList())
                {
                    workSheet.Cell(rowCount, 1).Value = item.Name;
                    workSheet.Cell(rowCount,2).Value = item.Surname;
                    workSheet.Cell(rowCount, 3).Value = item.Phone;
                    workSheet.Cell(rowCount, 4).Value = item.Mail;
                    rowCount++;
                }
                using (var stream = new MemoryStream())  //stream dosya işlemlerinde kullanılan yapı
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "müşteri_listesi.xlsx");
                    
                } 
            }
           
        }
        #endregion


        #region Static PDF Kodları

        public IActionResult StaticPdfReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/PdfReports/" + "musteri.pdf");
            var stream = new FileStream(path, FileMode.Create);

            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);
            document.Open();
            Paragraph paragraph = new Paragraph("Akbank Full Stack Programı");
            document.Add(paragraph);
            document.Close();
            return File("/Pdfreports/musteri.Pdf", "aplication/pdf", "musteri.pdf");
        }

        #endregion


        //pdf dinamic ekle
    }
}
