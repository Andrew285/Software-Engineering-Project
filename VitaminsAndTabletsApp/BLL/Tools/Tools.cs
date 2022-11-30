using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace VitaminsAndTabletsApp.BLL.Tools
{
    static class Tools
    {
        public static void ChangeInfoLabel(string str, Label label, bool isVisible)
        {

            // Create a background worker to sleep for 2 seconds...
            var backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += (s, ea) => Thread.Sleep(TimeSpan.FromSeconds(2));

            // ...and then set the text back to the original when the sleep is done
            // (also, re-enable the button)
            backgroundWorker.RunWorkerCompleted += (s, ea) =>
            {
                label.Visibility = Visibility.Collapsed;
            };

            if (isVisible)
            {
                label.Visibility = Visibility.Visible;
            }
            else
            {
                label.Visibility = Visibility.Collapsed;
            }
            label.Content = str;
            label.Foreground = new SolidColorBrush(Colors.White);
            label.Background = new SolidColorBrush(Colors.Black);

            // Start the background worker
            backgroundWorker.RunWorkerAsync();
        }

        //public void MoveToWindow(Window nextWindow)
        //{
        //    nextWindow window = new nextWindow();
        //}
    }
}
