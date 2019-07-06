using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataHolders;

namespace BL
{
  public  class blSaleItemList : ObservableCollection<dhSaleItem>
    {
        public blSaleItemList():base()
        {
           // Add(new dhSaleItem());
        }
    }
}
