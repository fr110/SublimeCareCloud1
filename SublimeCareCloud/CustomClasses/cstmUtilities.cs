using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SublimeCareCloud.CustomClasses
{
   public static class cstmUtilities
    {

       ////public static void LoadImage(byte[] imgebytdata, Image img_)
       ////{
       ////    if (imgebytdata != null)
       ////    {
       ////        byte[] blob = imgebytdata;
       ////        MemoryStream stream = new MemoryStream();
       ////        stream.Write(blob, 0, blob.Length);
       ////        stream.Position = 0;

       ////        System.Drawing.Image img = System.Drawing.Image.FromStream(stream);
       ////        BitmapImage bi = new BitmapImage();
       ////        bi.BeginInit();

       ////        MemoryStream ms = new MemoryStream();
       ////        img.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
       ////        ms.Seek(0, SeekOrigin.Begin);
       ////        bi.StreamSource = ms;
       ////        bi.EndInit();
       ////        img_.Source = bi;
       ////    }
       ////    else
       ////    {
       ////        img_.Source = null;
       ////    }
       ////}

       //public static void GetBindingSourcesRecursive(string propertyName, DependencyObject root, List<object> sources)
       //{
       //    List<BindingBase> bindings = DependencyObjectHelper.GetBindingObjects(root);
       //    Predicate<Binding> condition =
       //        (b) =>
       //        {
       //            return (b.Path is PropertyPath)
       //                && (((PropertyPath)b.Path).Path == propertyName)
       //                && (!sources.Contains(root));
       //        };

       //    foreach (BindingBase bindingBase in bindings)
       //    {
       //        if (bindingBase is Binding)
       //        {
       //            if (condition(bindingBase as Binding))
       //                sources.Add(root);
       //        }
       //        else if (bindingBase is MultiBinding)
       //        {
       //            MultiBinding mb = bindingBase as MultiBinding;
       //            foreach (Binding b in mb.Bindings)
       //            {
       //                if (condition(bindingBase as Binding))
       //                    sources.Add(root);
       //            }
       //        }
       //        else if (bindingBase is PriorityBinding)
       //        {
       //            PriorityBinding pb = bindingBase as PriorityBinding;
       //            foreach (Binding b in pb.Bindings)
       //            {
       //                if (condition(bindingBase as Binding))
       //                    sources.Add(root);
       //            }
       //        }
       //    }

       //    int childrenCount = VisualTreeHelper.GetChildrenCount(root);
       //    if (childrenCount > 0)
       //    {
       //        for (int i = 0; i < childrenCount; i++)
       //        {
       //            DependencyObject child = VisualTreeHelper.GetChild(root, i);
       //            GetBindingSourcesRecursive(propertyName, child, sources);
       //        }
       //    }
       //}
       private static List<object> lstChildren;

       public static List<object> GetChildren(Visual p_vParent, int p_nLevel)
       {
           if (p_vParent == null)
           {
               throw new ArgumentNullException("Element {0} is null!", p_vParent.ToString());
           }

          lstChildren = new List<object>();

           GetChildControls(p_vParent, p_nLevel);

           return lstChildren;

       }
       private static void GetChildControls(Visual p_vParent, int p_nLevel)
       {
           int nChildCount = VisualTreeHelper.GetChildrenCount(p_vParent);

           for (int i = 0; i <= nChildCount - 1; i++)
           {
               Visual v = (Visual)VisualTreeHelper.GetChild(p_vParent, i);

               lstChildren.Add((object)v);

               if (VisualTreeHelper.GetChildrenCount(v) > 0)
               {
                   GetChildControls(v, p_nLevel + 1);
               }
           }
       }
       public static T FindChildByType<T>(DependencyObject parent) where T : DependencyObject
       {
           for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
           {
               DependencyObject child = VisualTreeHelper.GetChild(parent, i);
               if (child is T)
                   return child as T;
               DependencyObject grandchild = FindChildByType<T>(child);
               if (grandchild != null)
                   return grandchild as T;
           }
           return default(T);
       }
    }
}
