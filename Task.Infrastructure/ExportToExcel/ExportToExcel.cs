using ClosedXML.Excel;
using Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ExportToExcel
{
    public class ExportToExcel
    {
        public ExportToExcel()
        {
        }

        public byte[] Export(List<DashboardResponseDto> data)
        {
            byte[] excelFile = null;
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Report");

            worksheet.Cell(1, 1).Value = "CustomerId";
            worksheet.Cell(1, 2).Value = "Customer Name";
            worksheet.Cell(1, 3).Value = "ProductId";
            worksheet.Cell(1, 4).Value = "Product Name";
            worksheet.Cell(1, 5).Value = "Unit Price";
            worksheet.Cell(1, 6).Value = "Monthly Usage";
            worksheet.Cell(1, 7).Value = "Monthly Cost";

            int row = 2;
            foreach (var item in data)
            {
                foreach (var product in item.UsedProductsList)
                {
                    worksheet.Cell(row, 1).Value = item.CustomerId;
                    worksheet.Cell(row, 2).Value = $"{item.CustomerName} {item.CustomerSurname}";
                    worksheet.Cell(row, 3).Value = product.ProductId;
                    worksheet.Cell(row, 4).Value = product.Name;
                    worksheet.Cell(row, 5).Value = product.UnitPrice;
                    worksheet.Cell(row, 6).Value = product.TotalUsed;
                    worksheet.Cell(row, 7).Value = product.UnitPricePerMounth;
                    row++;
                }
            }

            var stream = new MemoryStream();
            try
            {
                workbook.SaveAs(stream);
                excelFile = stream.ToArray();
                stream.Position = 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
            }

            if (!stream.CanRead)
            {
                stream = new MemoryStream();
                workbook.SaveAs(stream);
                excelFile = stream.ToArray();

            }

            stream.Position = 0;
            return excelFile;
        }
    }

}

