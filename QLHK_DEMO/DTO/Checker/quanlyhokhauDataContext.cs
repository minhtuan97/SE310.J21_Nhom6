using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Reflection;

namespace DTO
{
    public partial class quanlyhokhauDataContext
    {
        public NHANKHAU getNHANKHAU(string id)
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
            this.ExecuteDynamicUpdate(instance);
        }

        partial void DeleteTIEUSU(TIEUSU instance)
        {
            this.ExecuteDynamicDelete(instance);
        }
    }
}
