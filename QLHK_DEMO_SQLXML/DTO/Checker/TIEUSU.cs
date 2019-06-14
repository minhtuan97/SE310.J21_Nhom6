using System;
using System.Data.Linq;
using System.Text.RegularExpressions;

namespace DTO
{
    public partial class TIEUSU
    {
        partial void OnValidate(ChangeAction action)
        {
            Regex mddChecker = new Regex(@"[0-9]{12}$");

            if (!MATIEUSU.StartsWith("TS")||MATIEUSU.Length!=9)
            {
                throw new Exception("Ma tieu su can gom 9 ky tu va bat dau bang 'TS'!");
            }
            if (!string.IsNullOrEmpty(MADINHDANH) && !mddChecker.IsMatch(MADINHDANH))
            {
                throw new Exception("Ma dinh danh can DU 12 so!");
            }
            if (THOIGIANKETTHUC < THOIGIANBATDAU)
            {
                throw new Exception("Thoi gian bat dau SAU thoi gian ket thuc!");
            }
        }
    }
}
