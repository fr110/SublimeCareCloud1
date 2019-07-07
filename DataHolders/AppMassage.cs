using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DataHolders
{
    public class AppMassage
    {
        private String _msg;

        public String Msg
        {
            get { return _msg; }
            set { _msg = value; }
        }

        private MsgType _msgTypeProperty;

        public MsgType MsgTypeProperty
        {
            get { return _msgTypeProperty; }
            set { _msgTypeProperty = value; }
        }

        public void ShowMsg(Label lblErrorMsg)
        {
            if (Msg != null)
            {
                lblErrorMsg.Margin = new Thickness(10, 5, 10, 5);
                lblErrorMsg.FontSize = 12;
                lblErrorMsg.FontWeight = FontWeights.Bold;
                lblErrorMsg.Height = 35;
                if (MsgTypeProperty == MsgType.Error)
                {
                    System.Media.SystemSounds.Beep.Play();
                    lblErrorMsg.Visibility = System.Windows.Visibility.Visible;
                    lblErrorMsg.Foreground = Brushes.White;
                    lblErrorMsg.Content = Msg;
                }

                if (MsgTypeProperty == DataHolders.MsgType.Info)
                {
                    lblErrorMsg.Visibility = System.Windows.Visibility.Visible;
                    lblErrorMsg.Foreground = Brushes.Green;
                    lblErrorMsg.Content = Msg;
                }
            }
            else
            {
                lblErrorMsg.Visibility = System.Windows.Visibility.Hidden;
            }
        }
    }

    public enum MsgType
    {
        Error,
        Info,
        Warning
    }
}