using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHolders
{
   public class JournalDetailList: ObservableCollection<dhJournalDetail> , ICollection
    {
        public JournalDetailList()
            : base()
        {
            //Add(new dhItems());
        }
   
        public JournalDetailList AddRange(ObservableCollection<dhJournalDetail> ObjItemCollection)
        {
            foreach (dhJournalDetail item in ObjItemCollection)
            {
                this.Add(item);
            }
            return this;
        }

    }
}