using System;
using System.Data.Linq;

namespace DTO
{
    public partial class TIEUSU
    {
        partial void OnValidate(ChangeAction action)
        {
            if (THOIGIANKETTHUC < THOIGIANBATDAU)
            {
                throw new Exception("Thoi gian bat dau SAU thoi gian ket thuc!");
            }
        }
    }
}
