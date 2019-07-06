using System;
namespace DataHolders
{
    interface IdhSaleItem
    {
        double? FGrossAmount { get; set; }
        double? FUnitePrice { get; set; }
        int? IItemID { get; set; }
        int? IQuantity { get; set; }
        long ISaleid { get; set; }
        int ISaleItemid { get; set; }
        int? ISerialNumber { get; set; }
        int? IUpdate { get; set; }
        int? IUserId { get; set; }
        event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        string VItemName { get; set; }
    }
}
