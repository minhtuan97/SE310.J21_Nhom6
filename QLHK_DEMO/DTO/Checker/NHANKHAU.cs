using System;
using System.Text.RegularExpressions;

namespace DTO
{
    public partial class NHANKHAU
    {
        partial void OnSDTChanging(string value)
        {
            Regex sdtChecker = new Regex(@"[0]+[0-9.-]\d{8,9}$");

            //if (!sdtChecker.IsMatch(value))
            //{
            //    throw new Exception("Sai cau truc so dien thoai!");
            //}
        }
    }
}
