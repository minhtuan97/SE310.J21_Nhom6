using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public partial class SOHOKHAU
    {
        partial void OnValidate(ChangeAction action)
        {
            if (!SOSOHOKHAU.StartsWith("08") || SOSOHOKHAU.Length != 9)
            {
                throw new Exception("So so ho khau can gom 9 ky tu va bat dau bang '08'!");
            }
            if ( string.IsNullOrEmpty(MACHUHO) &&
                (!MACHUHO.StartsWith("TH") || MACHUHO.Length != 9))
            {
                throw new Exception("Ma chu ho can gom 9 ky tu va bat dau bang 'TH'!");
            }
            if (!DIACHI.Contains(","))
            {
                throw new Exception("Dia chi nhap vao sai cu phap, can cach nhau giua cac don vi bang dau ','!");
            }
            if (SODANGKY.Length!=7)
            {
                throw new Exception("So dang ky chi duoc gom 7 ky tu!");
            }
        }
    }
}
