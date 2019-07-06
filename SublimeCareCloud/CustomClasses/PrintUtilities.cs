using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows;
using System.Windows.Xps.Packaging;
using CodeReason.Reports;
using System.IO;
using System.Data;
using System.Printing;
using System.Windows.Xps;
using System.Windows.Xps.Serialization;
using System.Windows.Documents.Serialization;
using System.Windows.Markup;
using DataHolders;
using BL;
using iFacedeLayer;
using SublimeCareCloud.Views;
namespace SublimeCareCloud.CustomClasses
{
   public static class PrintUtilities
    {
       public static void printDoc(string TemplateName, DataSet ReportDatatables, String ReportName, Boolean ShowPreview=false, string ReportDisc =null)
       {
       //DocumentViewer docview1,
           try
           {
               ReportDocument reportDocument = new ReportDocument();
               StreamReader reader = new StreamReader(new FileStream(@"Templates\" + TemplateName, FileMode.Open, FileAccess.Read));
               reportDocument.XamlData = reader.ReadToEnd();
               reportDocument.XamlImagePath = Path.Combine(Environment.CurrentDirectory, @"Templates\");
               reader.Close();

               ReportData data = new ReportData();
               // Add tables to report Data 

                foreach (DataTable DT in ReportDatatables.Tables)
                {
                    //if (DT.Rows.Count < 10)
                    //{
                    //    DataRow abc = null;
                    //    DT.Rows.Add(abc);
                    //    DT.Rows.Add(abc);
                    //    DT.Rows.Add(abc);
                    //    DT.Rows.Add(abc);
                    //}
                    data.DataTables.Add(DT);
                }
                data.ReportDocumentValues.Add("PrintDate", DateTime.Now); // print date is now
               dhAppPreference obj = new dhAppPreference();
               dsGeneral.dtAppPreferenceDataTable dt =      iFacede.GetAppPreference(Globalized.ObjDbName, obj);
               data.DataTables.Add(dt);

               DateTime dateTimeStart = DateTime.Now; // start time measure here
               data.ReportDocumentValues.Add("ReportDisc", ReportDisc);
               XpsDocument xps = reportDocument.CreateXpsDocument(data);
               // chek have to show or not 
               if (!ShowPreview)
               {
                   PrintDialog dlg = new PrintDialog();
                   dlg.PrintDocument(xps.GetFixedDocumentSequence().DocumentPaginator, ReportName);
               }
               else
               {
                   PrintPreview objPre = new PrintPreview();
                   objPre.docview1.Document = xps.GetFixedDocumentSequence();
                   Window window = new Window
                   {
                       Title = "Print Preview",
                       Content = objPre,
                       Height = 800,  // just added to have a smaller control (Window)
                       Width = 750
                   };

                   window.ShowDialog();
               }
           }
           catch (Exception ex)
           {
               // show exception
              MessageBox.Show(ex.Message + "\r\n\r\n" + ex.GetType() + "\r\n" + ex.StackTrace, ex.GetType().ToString(), MessageBoxButton.OK, MessageBoxImage.Stop);
           }
       }
    }
}
