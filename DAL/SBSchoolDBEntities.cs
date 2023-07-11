using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DAL
{
    public partial class SBSchoolDBEntities 
    {
        public bool IsContextDirty()
        {
            return ObjectStateManager.GetObjectStateEntries(EntityState.Added | EntityState.Deleted | EntityState.Modified).Any();
        }
    }
}
