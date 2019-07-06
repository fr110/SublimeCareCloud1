using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataHolders;
using System.Windows.Controls;

namespace BL
{
    public  class StockCollection : SortedDictionary<string, dhInvoice>
    {
        //private static SortedDictionary<string, dhInvoice> _Stock;

        //public static SortedDictionary<string, dhInvoice> Stock
        //{
        //    get { return StockCollection._Stock; }
        //    set { StockCollection._Stock = value; }
        //}


        // Tabs Control to Bind So For 
        private TabControl _dynamicTabs;
        private TabItem _tabAdd;
        private List<TabItem> _tabItems;
       // public void 
        
        public delegate void ChangedHandler();
        public event ChangedHandler Changed;

        private Guid _guid;
        private bool _changed = false;

        private void RaiseChanged()
        {
            _changed = true;
            if (Changed != null) Changed();
        }

        public new void Add(string key, dhInvoice value)
        {
            base.Add(key, value);
            RaiseChanged();
        }

        public new void Clear()
        {
            base.Clear();
            RaiseChanged();
        }

        public new bool Remove(string key)
        {
            bool res = base.Remove(key);

            RaiseChanged();

            return res;
        }

        public Guid Identity
        {
            get
            {
                if (_changed)
                {
                    _guid = new Guid();
                    _changed = false;
                }
                return _guid;
            }
            set
            {
                _guid = value;
            }
        }        
        
    }
}
