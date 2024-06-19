using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace WebUI.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class DownloadController : Controller
    {
        private readonly IDestinationService _destinationService;
        private readonly ITeamService _teamService;
        private readonly IExcelService _excelService;
        public DownloadController(IDestinationService destinationService, ITeamService teamService, IExcelService excelService)
        {
            _destinationService = destinationService;
            _teamService = teamService;
            _excelService = excelService;
        }

        public IActionResult Index()
        {
            ViewBag.downloadActive = "active";
            return View();
        }
        
        public IActionResult ExelPage()
        {
            // eklenen nuget : dotnet add package EPPlus --version 7.2.0 

            // 1.ADIM - VERİ ALINDI --------------------------------------------------------------
            var destinations = _destinationService.DestinationAndReservationAndCommentCount();

            // 2.ADIM - VERİ EKLENDİ --------------------------------------------------------------
            ExcelPackage excel = new ExcelPackage();

            // Sayfa adı
            var workSheet = excel.Workbook.Worksheets.Add("Sayfa1");

            // Başlık satırı
            workSheet.Cells[1,1].Value = "DestinasyonId";
            workSheet.Cells[1,2].Value = "DestinasyonCity";
            workSheet.Cells[1,3].Value = "DestinasyonDayNight";
            workSheet.Cells[1,4].Value = "DestinasyonPrice";
            workSheet.Cells[1,5].Value = "DestinasyonImage";
            workSheet.Cells[1,6].Value = "DestinasyonDescription";
            workSheet.Cells[1,7].Value = "DestinasyonStatus";
            workSheet.Cells[1,8].Value = "DestinasyonCapacity";
            workSheet.Cells[1,9].Value = "CommentCount";
            workSheet.Cells[1,10].Value = "ReservationCount";

            // Alt satırlar
            var row = 2;
            foreach (var destination in destinations)
            {
                workSheet.Cells[row,1].Value = destination.DestinationId;
                workSheet.Cells[row,2].Value = destination.DestinationCity;
                workSheet.Cells[row,3].Value = destination.DestinationDayNight;
                workSheet.Cells[row,4].Value = destination.DestinationPrice;
                workSheet.Cells[row,5].Value = destination.DestinationImage;
                workSheet.Cells[row,6].Value = destination.DestinationDescription;
                workSheet.Cells[row,7].Value = destination.DestinationStatus;
                workSheet.Cells[row,8].Value = destination.DestinationCapacity;
                workSheet.Cells[row,9].Value = destination.Comments.Count();
                workSheet.Cells[row,10].Value = destination.Reservations.Count();
                row++;
            }

            // 3.ADIM - İNDİRME İŞLEMİ --------------------------------------------------------------
            var bytes = excel.GetAsByteArray();
            return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "destinations.xlsx");
        }

        public IActionResult PdfPage()
        {
            // Eklenecek olan nuget
            // dotnet add package iTextSharp --version 5.5.13.3

            // 1.ADIM - VERİ ALINDI --------------------------------------------------------------
            var teams = _teamService.GetAll();

            // 2.ADIM - DOSYA YOLU OLUŞTURMA --------------------------------------------------------------
                // Dosya yolu oluşturuldu
            string dosyaYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreports/" + "team.pdf");
                // Dosya yolu eklendi
            var stream = new FileStream(dosyaYolu, FileMode.Create);

                // Yeni bir document oluşturuldu.
            Document pdfDoc = new Document();
                // Document, dosya yolu ile birleştirild.
            PdfWriter.GetInstance(pdfDoc, stream);

            // 3.ADIM - VERİ EKLEME --------------------------------------------------------------
            pdfDoc.Open();

            // Tablo oluşturma
            PdfPTable pdfPTable = new PdfPTable(6); // Sütun Sayısı

            pdfPTable.AddCell("TeamId");
            pdfPTable.AddCell("TeamFullname");
            pdfPTable.AddCell("TeamDescription");
            pdfPTable.AddCell("TeamImage");
            pdfPTable.AddCell("TeamTwitterUrl");
            pdfPTable.AddCell("TeamInstagramUrl");

            foreach (var item in teams)
            {
                pdfPTable.AddCell(item.TeamId.ToString());
                pdfPTable.AddCell(item.TeamFullname);
                pdfPTable.AddCell(item.TeamDescription);
                pdfPTable.AddCell(item.TeamImage);
                pdfPTable.AddCell(item.TeamTwitterUrl);
                pdfPTable.AddCell(item.TeamInstagramUrl);
            }

            pdfDoc.Add(pdfPTable); // Tablo,document'a eklenir

            pdfDoc.Close();

            // 4.ADIM - İNDİRME İŞLEMİ --------------------------------------------------------------
            byte[] fileBytes = System.IO.File.ReadAllBytes(dosyaYolu);
            return File(fileBytes, "application/pdf", "team.pdf");
        }
    
        public IActionResult ServiceExelPage()
        {
            // Sadece Busines içine excelService ve Manager tanımladık
            // Herhangi bir başlık vs tanımlama yapmadan, tablodaki değerler ne ise, onları yazdırır. Başlığı kendisi prop isimlerini tanımlar
            return File(_excelService.ExelList(_destinationService.GetAll()), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "YeniExcel.xlsx");
        }
    }
}