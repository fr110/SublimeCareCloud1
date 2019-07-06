using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHolders
{
    public class ItemsList : ObservableCollection<dhSaleItem> , ICollection
    {
        public ItemsList()
            : base()
        {
            //Add(new dhItems());
        }
        //public void AddRange(ObservableCollection<dhSaleItem> ObjItemCollection)
        //{
        //    foreach (dhSaleItem item in ObjItemCollection)
        //    {
        //        this.Add(item);
        //    }
        //}

        public ItemsList AddRange(ObservableCollection<dhSaleItem> ObjItemCollection)
        {
            foreach (dhSaleItem item in ObjItemCollection)
            {
                this.Add(item);
            }
            return this;
        }

    }
}
