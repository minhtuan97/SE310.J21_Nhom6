using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DTO
{
    public partial class TIENANTIENSU
    {
        partial void OnValidate(ChangeAction action)
        {
            Regex mddChecker = new Regex(@"[0-9]{12}$");

            if (!MATIENANTIENSU.StartsWith("TA") || MATIENANTIENSU.Length != 9)
            {
                throw new Exception("Ma tien an tien su can gom 9 ky tu va bat dau bang 'TA'!");
            }
            if (string.IsNullOrEmpty(MADINHDANH) && !mddChecker.IsMatch(MADINHDANH))
            {
                throw new Exception("Ma dinh danh can DU 12 so!");
            }
        }
    }
}
