using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Reflection;

namespace DTO
{
    public partial class NHANKHAUSummary
    {
        public string madinhdanh { get; set; }
        public string hoten { get; set; }
        public string ngaysinh { get; set; }
    }

    public partial class quanlyhokhauDataContext
    {
        public NHANKHAUSummary getNHANKHAUByIDSummary(string id)
        {
            return ExecuteQuery<NHANKHAUSummary>(@"SELECT MADINHDANH, HOTEN, NGAYSINH FROM NHANKHAU WHERE MADINHDANH={0}", id).First();
        }

        public NHANKHAU getNHANKHAUByIDExcutequery(string id)
        {
            return ExecuteQuery<NHANKHAU>(@"SELECT * FROM NHANKHAU WHERE MADINHDANH={0}", id).First();
        }

        public NHANKHAU getNHANKHAUByIDContext(string id)
        {
            return this.NHANKHAUs.Single(q => q.MADINHDANH == id);
        }

        [Function(Name = "getByShape")]
        [ResultType(typeof(NHANKHAU))]
        [ResultType(typeof(TIEUSU))]
        public IMultipleResults GetByShape(System.Nullable<int> shape)
        {
            IExecuteResult result = this.ExecuteMethodCall(this,
                ((MethodInfo)(MethodInfo.GetCurrentMethod())), shape);

            return (IMultipleResults)result.ReturnValue;
        }

        public override void SubmitChanges(ConflictMode failureMode)
        {
            ChangeSet changes = this.GetChangeSet();
            //foreach (ObjectChangeConflict obj in this.ChangeConflicts)
            //{
            //    foreach (MemberChangeConflict m in obj.MemberConflicts)
            //    {
            //        //m.CurrentValue.toString();
            //    }
            //}
            base.SubmitChanges(failureMode);
        }

        partial void InsertTIEUSU(TIEUSU instance)
        {
            this.ExecuteDynamicInsert(instance);
        }

        partial void UpdateTIEUSU(TIEUSU instance)
        {
            //TIEUSU origin = (TIEUSU)TIEUSUs.GetOriginalEntityState(instance);
            //this.UpdateTIEUSU(instance.MATIEUSU, instance.MADINHDANH, instance.THOIGIANBATDAU, instance.THOIGIANKETTHUC,
            //    instance.CHOO, instance.NGHENGHIEP, instance.NOILAMVIEC, origin.MATIEUSU);
            this.ExecuteDynamicUpdate(instance);
        }
        //[Function(Name ="dbo.UpdateTIEUSU")]
        //public int UpdateTIEUSU([Parameter(Name ="MATIEUSU", DbType ="char(9)")] string matieusu, [Parameter(Name = "MADINHDANH", DbType = "char(12)")] string madinhdanh, [Parameter(Name = "THOIGIANBATDAU", DbType = "smalldatetime")] DateTime tgbd,
        //    [Parameter(Name = "THOIGIANKETHUC", DbType = "smalldatetime")] string tgkt, [Parameter(Name = "CHOO", DbType = "nvarchar(100)")] string choo, [Parameter(Name = "NGHENGHIEP", DbType = "nvarchar(100)")] string nghenghiep,
        //    [Parameter(Name = "NOILAMVIEC", DbType = "nvarchar(100)")] string noilamviec)
        //{
        //    IExecuteResult result = this.ExecuteMethodCall(this, (MethodInfo)MethodInfo.GetCurrentMethod(), matieusu, madinhdanh, tgbd, tgkt,
        //        choo, nghenghiep, noilamviec, matieusu);
        //    return (int)result.ReturnValue;
        //}

        partial void DeleteTIEUSU(TIEUSU instance)
        {
            //ExecuteCommand("DELETE FROM TIEUSU WHERE MATIEUSU={0}", instance.MATIEUSU);
            this.ExecuteDynamicDelete(instance);
        }
    }
}
