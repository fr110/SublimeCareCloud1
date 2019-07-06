using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using DataHolders;
using System.IO;
using System.Xml;
using System.Web;
using System.Windows.Controls;
using System.Collections;
using System.Windows.Media;
using System.Windows;
using System.Reflection;

namespace BL
{
  public static class blUtil
    {
        //public static string VeriFicationCodeGen()
        //{
        //    Random rnd = new Random();

        //    string[] s = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c",
        //              "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "p", "q", "r", "s", "t",
        //                 "u", "v", "w", "x", "y", "z"};

        //    int i;

        //    StringBuilder sb = new StringBuilder(4);
        //    for (i = 0; i < 3; i++)
        //    {
        //        sb.Append(s[rnd.Next(11, s.Length)]);
        //    }
        //    for (i = 0; i <= 3; i++)
        //    {

        //        sb.Append(s[rnd.Next(1, 10)]);

        //    }
        //    return sb.ToString();
        //}
        //public static string GetMd5Hash(string input)
        //{
        //    MD5 md5Hash = MD5.Create();

        //    // Convert the input string to a byte array and compute the hash.
        //    byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

        //    // Create a new Stringbuilder to collect the bytes
        //    // and create a string.
        //    StringBuilder sBuilder = new StringBuilder();

        //    // Loop through each byte of the hashed data 
        //    // and format each one as a hexadecimal string.
        //    for (int i = 0; i < data.Length; i++)
        //    {
        //        sBuilder.Append(data[i].ToString("x2"));
        //    }

        //    // md5Hash.Dispose();
        //    // Return the hexadecimal string.
        //    return sBuilder.ToString();
        //}
        //public static bool VerifyMd5Hash(string input, string hash)
        //{
        //    MD5 md5Hash = MD5.Create();
        //    // Hash the input.
        //    string hashOfInput = GetMd5Hash(input);

        //    // Create a StringComparer an compare the hashes.
        //    StringComparer comparer = StringComparer.OrdinalIgnoreCase;

        //    // md5Hash.Dispose();

        //    if (0 == comparer.Compare(hashOfInput, hash))
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
        //public static string FormatDate(dhDBnames objDBnames, DateTime dDate, bool isTime)
        //{
        //    string retstr = "";
        //    string FormatType = "";
        //    //FormatType = "dd/mm/yyyy";
        //    //FormatType = "mm/dd/yyyy";


        //    FormatType = objDBnames.DateFormat;

        //    if (dDate != null)
        //    {
        //        if (FormatType == "dd/mm/yyyy")
        //        {
        //            retstr = String.Format("{0:dd/MM/yyyy}", dDate);
        //        }
        //        else if (FormatType == "mm/dd/yyyy")
        //        {
        //            retstr = String.Format("{0:MM/dd/yyyy}", dDate);
        //        }
        //        else
        //            retstr = String.Format("{0:dd/MM/yyyy}", dDate);

        //        if (isTime)
        //        {
        //            retstr = retstr + " " + String.Format("{0:hh:mm tt}", dDate);
        //        }

        //    }
        //    return retstr;
        //}
        //public static string FormatDateForDatePicker(dhDBnames objDBnames)
        //{
        //    string retstr = "";
        //    string FormatType = "";
        //    //FormatType = "dd/mm/yyyy";
        //    //FormatType = "mm/dd/yyyy";


        //    FormatType = objDBnames.DateFormat;

        //    if (FormatType != null)
        //    {
        //        if (FormatType == "dd/mm/yyyy")
        //        {
        //            retstr = "DayMonthYear";
        //        }
        //        else if (FormatType == "mm/dd/yyyy")
        //        {
        //            retstr = "MonthDayYear";
        //        }
        //    }
        //    else
        //    {
        //        retstr = "MonthDayYear";
        //    }
        //    return retstr;
        //}

        // Function For Reports File To Clean PDF Files That we are converting From rpt To PDF in Bl Class
      public static IEnumerable<DataGridRow> GetDataGridRows(DataGrid grid)
      {
          var itemsSource = grid.ItemsSource as IEnumerable;
          if (null == itemsSource) yield return null;
          foreach (var item in itemsSource)
          {
              var row = grid.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
              if (null != row) yield return row;
          }
      }
        public static void DeleteLastReports()
        {
            if (UpdateLastCleanDate())
            {
                string filePath = HttpContext.Current.Server.MapPath("~") + "\\Reports\\";
                DirectoryInfo Dir = new DirectoryInfo(filePath);

                FileInfo[] FileList = Dir.GetFiles("*.pdf", SearchOption.TopDirectoryOnly);

                var query = from FI in FileList

                            where FI.LastWriteTime.Date < DateTime.Now.Date
                            select FI.FullName;
                            //select FI.FullName + " " + FI.LastWriteTime;

                foreach (string s1 in query)
                {

                    //Console.WriteLine(s1);
                    System.IO.File.Delete(s1);

                }
                //string[] filePaths = Directory.GetFiles(filePath, "*.pdf", SearchOption.AllDirectories);
                //string Test = DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString();
                //for (int i = 0; i < filePaths.Length; i++)
                //{
                //    string[] a = filePaths[i].Split('-');
                //    if ((a.Length == 3) && (Convert.ToInt32(a[1]) < Convert.ToInt32(Test)))
                //    {
                //        System.IO.File.Delete(filePaths[i]);
                //    }
                //}
            }

        }
        public static Boolean UpdateLastCleanDate()
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            //String NewValue = Dated.Day.ToString() + Dated.Month.ToString() + Dated.Year.ToString();
            String NewValue = DateTime.Now.ToShortDateString();// Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString();

            string filePath = HttpContext.Current.Server.MapPath("~") + "\\XMLFiles\\" + "rptXML.xml";
            if (!(System.IO.File.Exists(filePath)))
            {
                // its First Time Creat an Xml File 
                XmlWriter writer = XmlWriter.Create(filePath, settings);
                writer.WriteStartDocument();
                writer.WriteComment("This file is generated by the program.");
                writer.WriteStartElement("FileCleaner");
                writer.WriteStartElement("CleanDate");
                writer.WriteAttributeString("Dated", NewValue);
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.Flush();
                writer.Close();

                return true;
            }
            else
            {
                //   XmlTextWriter writer = new XmlTextWriter(filePath, null);
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(filePath);
                XmlNode node = xmlDoc.SelectSingleNode("FileCleaner/CleanDate");
                // we have the Value Of the Attribute Now  let us Chek it 
                // as the Pased Date will be Greater Alwaz
                if (Convert.ToString(node.Attributes[0].Value) != (Convert.ToString(NewValue)))
                {
                    node.Attributes[0].Value = NewValue;
                    xmlDoc.Save(filePath);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        // Exception handling 
 
        public static Boolean LeavingWindows()
        {
            string messageBoxText = " After  leaving the window insaved data will be loss, are you sure to leave?";
            string caption = "Are you sure to leave this working window?";
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Warning;

            MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);
            if (result != MessageBoxResult.Yes)
            {
                return true;
            }
            else
            {
                return false;

            }
        }
        public static Boolean OverrideInformation(string partyname = null, string commonWord=null)
        {
            string messageBoxText = "A party with With common word ' " + commonWord + "' for the name ' " + partyname + "'is already exist are you sure to save party with this name?";
            string caption = "Override Information";
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Warning;

            MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);
            if (result == MessageBoxResult.Yes)
            {
                return true;
            }
            else
            {
                return false;

            }
        }
        //public static void PropertyCopyTo<T, T>(this T source, T destination)
        //{
        //    Type firstType = source.GetType();
        //    foreach (PropertyInfo propertyInfo in firstType.GetProperties())
        //    {
        //        if (propertyInfo.CanRead)
        //        {

        //            object firstValue = propertyInfo.GetValue(source, null);
        //            object secondValue = propertyInfo.GetValue(destination, null);
        //           // propertyInfo.SetValue()
        //            //if (!object.Equals(firstValue, secondValue))
        //            //{
        //            //    return false;
        //            //}
        //        }
        //    }
        //    // details elided
        //}
    }
}
