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
    public sealed partial class HowToPlay : Page
    {
        public HowToPlay()
        {
            this.InitializeComponent();
            howToPlayTextBox.Text = "On keyboard " +
                                "\n Left Arrow to Move Left" +
                                "\n Right Arrow Key to Move Right" +
                                "\n Spacebar to Jump " +
                                "\n On Controller" +
                                "\n Left on Dpad to Move Left" +
                                "\n Right on Dpad to Move Right" +
                                "\n A Button to Jump";
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

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}
