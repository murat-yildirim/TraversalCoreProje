﻿using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace TraversalCoreProje.Controllers
{
	public class PdfReportController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult StaticPdfReport()
		{
			string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreports/" + "dosya1.pdf");
			var stream = new FileStream(path, FileMode.Create);
			Document document = new Document(PageSize.A4);
			PdfWriter.GetInstance(document, stream);

			document.Open();
			Paragraph paragraph = new Paragraph("Traversal Rezervasyon Pdf Raporu");

			document.Add(paragraph);
			document.Close();

			return File("/pdfreports/dosya1.pdf", "application/pdf", "dosya1.pdf");
		}

		public IActionResult StaticCustomerReport()
		{
			string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreports/" + "dosya2.pdf");
			var stream = new FileStream(path, FileMode.Create);
			Document document = new Document(PageSize.A4);
			PdfWriter.GetInstance(document, stream);

			document.Open();

			PdfPTable pdfPTable = new PdfPTable(3);

			pdfPTable.AddCell("Misafir Adı");
			pdfPTable.AddCell("Misafir Soyadı");
			pdfPTable.AddCell("Misafir TC");


			pdfPTable.AddCell("Ayşe");
			pdfPTable.AddCell("Kaya");
			pdfPTable.AddCell("11111111111");

			pdfPTable.AddCell("Remzi");
			pdfPTable.AddCell("Altun");
			pdfPTable.AddCell("11112222221");

			pdfPTable.AddCell("Fatih");
			pdfPTable.AddCell("Koz");
			pdfPTable.AddCell("11111166666");

			pdfPTable.AddCell("Cemal");
			pdfPTable.AddCell("Çakır");
			pdfPTable.AddCell("88888811111");

			document.Add(pdfPTable);

			document.Close();

			return File("/pdfreports/dosya2.pdf", "application/pdf", "dosya2.pdf");
		}
	}
}
