using System;
using System.Data.Linq;

namespace DTO
{
    public partial class quanlyhokhauDataContext
    {
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
