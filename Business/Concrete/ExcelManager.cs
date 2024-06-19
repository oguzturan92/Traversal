using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using OfficeOpenXml;

namespace Business.Concrete
{
    public class ExcelManager : IExcelService
    {
        public byte[] ExelList<T>(List<T> entity) where T : class
        {
            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("Sayfa1");

            workSheet.Cells["A1"].LoadFromCollection(entity, true, OfficeOpenXml.Table.TableStyles.Light10);

            return excel.GetAsByteArray();
        }
    }
}