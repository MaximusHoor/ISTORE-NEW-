using Domain.EF_Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Business.Service
{
    public class ImportExportService
    {
        public List<Product> ExcelToObject(MemoryStream memoryStream)
        {
            using (var package = new ExcelPackage(memoryStream))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                var rowCount = worksheet.Dimension.Rows;
                var list = new List<Product>();
                if (rowCount > 1)
                {
                    for (int row = 2; row <= rowCount; row++)
                    {
                        var pr = new Product();
                        pr.Title = worksheet.Cells[row, 1].Value.ToString().Trim();
                        pr.Type = worksheet.Cells[row, 2].Value.ToString().Trim();
                        pr.VendorCode = worksheet.Cells[row, 3].Value.ToString().Trim();
                        pr.Description = worksheet.Cells[row, 4].Value.ToString().Trim();
                        pr.BrandId = int.Parse(worksheet.Cells[row, 5].Value.ToString().Trim());
                        pr.RetailPrice = double.Parse(worksheet.Cells[row, 6].Value.ToString().Trim());
                        pr.CategoryId = int.Parse(worksheet.Cells[row, 7].Value.ToString().Trim());
                        pr.PackageId = int.Parse(worksheet.Cells[row, 8].Value.ToString().Trim());
                        pr.CountInStorage = int.Parse(worksheet.Cells[row, 9].Value.ToString().Trim());
                        pr.Rating = 0;
                        pr.WarrantyMonth = int.Parse(worksheet.Cells[row, 10].Value.ToString().Trim());
                        pr.Series = worksheet.Cells[row, 11].Value.ToString().Trim();
                        pr.Model = worksheet.Cells[row, 12].Value.ToString().Trim();
                        //PreviewImage = worksheet.Cells[row, 13].Value.ToString().Trim(),
                        //Images = new List<Image>()

                        list.Add(pr);
                    }
                }
                return list;
            }
        }
    }
}
