using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace game
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CreditsPage : Page
    {
        public CreditsPage()
        {
            this.InitializeComponent();
            creditsTextBlock.Text = "Daniel Feldman\nMyles Spaulding\nPaul Murariu\nSebastian Kuka";
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            rootFrame.Navigate(typeof(MenuPage));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //creditsTextBlock.Text += "\n" + (string)e.Parameter;
        }

        private void creditsTextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}
