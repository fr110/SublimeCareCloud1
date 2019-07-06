using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using DataHolders;

namespace SublimeCareCloud.CustomClasses
{
    [ValueConversion(typeof(bool), typeof(bool))]
    public class InverseBooleanConverter: IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            if (targetType != typeof(bool))
                throw new InvalidOperationException("The target must be a boolean");
            dhSaleItem oj = (dhSaleItem)value;
            if (oj.BIsEditAbleInInvoice == "False")
            {
                return "False";
            }
            else
            {
                return "True";
            }

            //Boolean invers = ( Convert.ToBoolean( oj.BIsEditAbleInInvoice) != false ? false : true);
            //return oj.BIsEditAbleInInvoice;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        #endregion
    }
}
