using System;
using System.Data.Linq;
using System.Text.RegularExpressions;

namespace DTO
{
    public partial class NHANKHAU
    {
        //partial void OnSDTChanging(string value)
        //{
        //    Regex sdtChecker = new Regex(@"[0]+[0-9.-]\d{8,9}$");

        //    if (!sdtChecker.IsMatch(value))
        //    {
        //        throw new Exception("Sai cau truc so dien thoai!");
        //    }
        //}

        partial void OnValidate(ChangeAction action)
        {
            Regex sdtChecker = new Regex(@"[0]+[0-9.-]\d{8,9}$");

            if (!sdtChecker.IsMatch(SDT))
            {
                throw new Exception("Sai cau truc so dien thoai!");
            }

            Regex mddChecker = new Regex(@"[0-9]{12}$");
            if (!mddChecker.IsMatch(MADINHDANH))
            {
                throw new Exception("Ma dinh danh can DU 12 so!");
            }
            if (!GIOITINH.Equals("nam")&&!GIOITINH.Equals("nu"))
            {
                throw new Exception("Gioi tinh chi co the la 'nam' hoac 'nu'!");
            }
            if (!NOITHUONGTRU.Contains(",")||!DIACHIHIENNAY.Contains(","))
            {
                throw new Exception("Dia chi nhap vao sai cu phap, can cach nhau giua cac don vi bang dau ','!");
            }
        }
    }
}
