
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DTO
{
    public partial class NHANKHAUTHUONGTRU
    {
        partial void OnValidate(ChangeAction action)
        {
            Regex mddChecker = new Regex(@"[0-9]{12}$");

            if (!string.IsNullOrEmpty(MANHANKHAUTHUONGTRU) && 
                (!MANHANKHAUTHUONGTRU.StartsWith("TH")||MANHANKHAUTHUONGTRU.Length!=9))
            {
                throw new Exception("Ma nhan khau thuong tru can gom 9 ky tu va bat dau bang 'TH'!");
            }
            if (!string.IsNullOrEmpty(MADINHDANH) && !mddChecker.IsMatch(MADINHDANH))
            {
                throw new Exception("Ma dinh danh can DU 12 so!");
            }
            if (!string.IsNullOrEmpty(SOSOHOKHAU) && 
                (!SOSOHOKHAU.StartsWith("08") || SOSOHOKHAU.Length != 9))
            {
                throw new Exception("So so ho khau can gom 9 ky tu va bat dau bang '08'!");
            }
            if (DIACHITHUONGTRU != null && !DIACHITHUONGTRU.Contains(","))
            {
                throw new Exception("Dia chi nhap vao sai cu phap, can cach nhau giua cac don vi bang dau ','!");
            }
        }
    }
}
