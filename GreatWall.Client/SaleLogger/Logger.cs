namespace GreatWall.Client.SaleLogger
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using GreatWall.Entities.Interfaces;
    using iTextSharp.text;
    using iTextSharp.text.pdf;

    public static class Logger
    {
        public static void ExportPdfLog(IList<string> customerDetails, IProduct currentProduct)
        {
            string name = customerDetails[0];
            string address = customerDetails[1];
            string telephone = customerDetails[2];
            string boughtQuantity = customerDetails[3];
            currentProduct.Quantity = int.Parse(boughtQuantity);
            string dataOfSale = $"{DateTime.Now.Day}-{DateTime.Now.Month}-{DateTime.Now.Year}-{DateTime.Now.Hour}-{DateTime.Now.Minute}";

            FileStream fs = new FileStream("..\\..\\ExportSales" + "\\" + $"{dataOfSale} Sale.pdf", FileMode.Create);

            Document document = new Document(PageSize.A5);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();
            document.AddHeader("Date of sale", DateTime.Now.ToString());
            document.AddAuthor("Admin");

            Font calibri = new Font(Font.FontFamily.COURIER, 14, Font.ITALIC);

            Paragraph p1 = new Paragraph($"Customer Name: {name}", calibri);
            Paragraph p2 = new Paragraph($"Address to deliver: {address}", calibri);
            Paragraph p3 = new Paragraph($"Telephone number: {telephone}", calibri);
            Paragraph p4 = new Paragraph($"Product price: {currentProduct.Price}$", calibri);
            Paragraph p5 = new Paragraph($"Total price: {currentProduct.Price * currentProduct.Quantity}$", calibri);
            Paragraph p6 = new Paragraph($"____________________________", calibri);
            Paragraph p7 = new Paragraph("Product info:", calibri);
            Paragraph p8 = new Paragraph($"{currentProduct.ToString()}", calibri);

            document.Add(p1);
            document.Add(p2);
            document.Add(p3);
            document.Add(p4);
            document.Add(p5);
            document.Add(p6);
            document.Add(p7);
            document.Add(p8);

            document.Close();
            writer.Close();
            fs.Close();
        }
    }
}