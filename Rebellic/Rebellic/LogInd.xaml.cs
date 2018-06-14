using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Rebellic
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LogInd : Page
    {
        public LogInd()
        {
            this.InitializeComponent();
        }

        private void MenuOpen_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            //if (LeftMenu.Visibility == Visibility.Visible)
            //{
            //    LeftMenu.Visibility = Visibility.Collapsed;
            //    MenuOpen.Visibility = Visibility.Visible;
            //}
            //else
            //{
            //    LeftMenu.Visibility = Visibility.Visible;
            //    MenuOpen.Visibility = Visibility.Collapsed;
            //}
        }

        private void MenuItem_OnPointerEntered2(object sender, PointerRoutedEventArgs e)
        {
            int index = int.Parse(((TextBlock)e.OriginalSource).AccessKey);

            hoverEffect1.Margin = new Thickness(0, 20 + (index * 50), 0, 0);

            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 1);
            hoverEffect1.Visibility = Visibility.Visible;
        }

        private void MenuItem_OnPointerExited2(object sender, PointerRoutedEventArgs e)
        {
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 2);
            hoverEffect1.Visibility = Visibility.Collapsed;
        }

        private void ChangeCursorEnter(object sender, PointerRoutedEventArgs e)
        {
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 1);
        }

        private void ChangeCursorExit(object sender, PointerRoutedEventArgs e)
        {
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 2);
        }

        private void ChangeMenu(object sender, TappedRoutedEventArgs e)
        {
            string navTo = ((TextBlock)e.OriginalSource).Name;

            switch (navTo)
            {
                case "NavMainPage":
                    Frame.Navigate(typeof(MainPage));
                    break;
                case "NavLogInd":
                    Frame.Navigate(typeof(LogInd));
                    break;
                case "NavCustProfile":
                    Frame.Navigate(typeof(CustProfile));
                    break;
            }
        }

        private void BtnShowPane_OnClick(object sender, TappedRoutedEventArgs e)
        {
            if (MenuPopup.IsOpen == false)
            {
                MenuPopup.IsOpen = true;
            }
            else
            {
                MenuPopup.IsOpen = false;
            }
        }

        private void BtnShowPane_OnPointerEntered(object sender, PointerRoutedEventArgs e)
        {
            btnShowPaneBack.Visibility = Visibility.Visible;
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 1);
        }

        private void BtnShowPane_OnPointerExited(object sender, PointerRoutedEventArgs e)
        {
            btnShowPaneBack.Visibility = Visibility.Collapsed;
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 2);
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (myPopup.IsOpen)
            {
                myPopup.IsOpen = false;
            }
            else
            {
                myPopup.IsOpen = true;
            }
        }

        private void ProfileOpen_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            if (myPopup.IsOpen == false)
            {
                myPopup.IsOpen = true;
                InfoPopup.IsOpen = false;
                ProfileArrowUp.Visibility = Visibility.Visible;
                ProfileArrowDown.Visibility = Visibility.Collapsed;
            }
            else
            {
                myPopup.IsOpen = false;
                ProfileArrowDown.Visibility = Visibility.Visible;
                ProfileArrowUp.Visibility = Visibility.Collapsed;
            }
        }

        private void Profile_OnPointerEntered(object sender, PointerRoutedEventArgs e)
        {
            if (myPopup.IsOpen)
            {
                int index = int.Parse(((TextBlock)e.OriginalSource).AccessKey);

                Window.Current.CoreWindow.PointerCursor =
                    new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 1);
            }
        }

        private void Profile_OnPointerExited(object sender, PointerRoutedEventArgs e)
        {
            if (myPopup.IsOpen)
            {
                Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 2);
            }
        }

        private void ProfileOpener_OnPointerEntered(object sender, PointerRoutedEventArgs e)
        {
            profileOpen.Background = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        }

        private void ProfileOpener_OnPointerExited(object sender, PointerRoutedEventArgs e)
        {
            if (!myPopup.IsOpen)
            {
                profileOpen.Background = new SolidColorBrush(Color.FromArgb(237, 255, 255, 255));
            }
            else
            {
                profileOpen.Background = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            }
        }

        private void LogIndBtn_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            LogIndBtnBack.Fill = new SolidColorBrush(Color.FromArgb(255, 68, 138, 255));
            OpretBrugerBtnBack.Fill = new SolidColorBrush(Color.FromArgb(255, 68, 138, 255));
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 1);
        }

        private void LogIndBtn_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            LogIndBtnBack.Fill = new SolidColorBrush(Color.FromArgb(204, 68, 138, 255));
            OpretBrugerBtnBack.Fill = new SolidColorBrush(Color.FromArgb(204, 68, 138, 255));
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 2);
        }

        private void OpretBrugerLogInd_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //string getName = ((TextBlock)e.OriginalSource).Name;
            //if (getName == "LogIndd")
            //{
            //    LogIndGrid.Visibility = Visibility.Visible;
            //    OpretBrugerGrid.Visibility = Visibility.Collapsed;
            //}
            //else
            //{
            //    LogIndGrid.Visibility = Visibility.Collapsed;
            //    OpretBrugerGrid.Visibility = Visibility.Visible;
            //}
        }

        private void InfoPointerEnter(object sender, PointerRoutedEventArgs e)
        {
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 1);
            InfoPopupBackground.Fill = new SolidColorBrush(Color.FromArgb(230, 255, 255, 255));
        }

        private void InfoPointerExit(object sender, PointerRoutedEventArgs e)
        {
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 2);
            if (!InfoPopup.IsOpen)
            {
                InfoPopupBackground.Fill = new SolidColorBrush(Color.FromArgb(153, 255, 255, 255));
            }
        }

        private void InfoPopup_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (InfoPopup.IsOpen)
            {
                InfoPopup.IsOpen = false;
                InfoPopupBackground.Fill = new SolidColorBrush(Color.FromArgb(153, 255, 255, 255));
            }
            else
            {
                InfoPopup.IsOpen = true;
                myPopup.IsOpen = false;
                InfoPopupBackground.Fill = new SolidColorBrush(Color.FromArgb(230, 255, 255, 255));
            }
        }
    }
}
