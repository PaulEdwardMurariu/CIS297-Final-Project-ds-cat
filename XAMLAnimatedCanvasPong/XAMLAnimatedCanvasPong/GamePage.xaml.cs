using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.UI.Xaml;
using System;
using System.Threading.Tasks;
using Windows.UI.StartScreen;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace game
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 

    public sealed partial class GamePage : Page
    {
        Manager manager;
 
        private CanvasBitmap playerImg;

        private CanvasBitmap blockImg;


        public GamePage()
        {
            this.InitializeComponent();
            Window.Current.CoreWindow.KeyDown += Canvas_KeyDown;
            Window.Current.CoreWindow.KeyUp += Canvas_KeyUp;


        }

        private void Canvas_Draw(ICanvasAnimatedControl sender, CanvasAnimatedDrawEventArgs args)
        {
            manager.DrawGame(args.DrawingSession);
        }

        private void Canvas_Update(ICanvasAnimatedControl sender, CanvasAnimatedUpdateEventArgs args)
        {
            manager.Update();
        }

        private void Canvas_KeyDown(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs e)
        {
            if (e.VirtualKey == Windows.System.VirtualKey.Left)
            {
                manager.MovingLeft(true);
            }
            else if (e.VirtualKey == Windows.System.VirtualKey.Right)
            {
                manager.MovingRight(true);
            }
            else if(e.VirtualKey == Windows.System.VirtualKey.Up)
            {
                //manager.jump();
            }
        }

        private void Canvas_KeyUp(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs e)
        {
            if (e.VirtualKey == Windows.System.VirtualKey.Left)
            {
                manager.MovingLeft(false);
            }
            else if (e.VirtualKey == Windows.System.VirtualKey.Right)
            {
                manager.MovingRight(false);
            }
        }

        private void Canvas_CreateResources(CanvasAnimatedControl sender, Microsoft.Graphics.Canvas.UI.CanvasCreateResourcesEventArgs args)
        {
            args.TrackAsyncAction(CreateResources(sender).AsAsyncAction());
        }

        async Task CreateResources(Microsoft.Graphics.Canvas.UI.Xaml.CanvasAnimatedControl sender)
        {
            playerImg = await CanvasBitmap.LoadAsync(sender, "Assets/player.png");
            blockImg = await CanvasBitmap.LoadAsync(sender, "Assets/brick.png");
            manager = new Manager(playerImg,blockImg);
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            rootFrame.Navigate(typeof(MenuPage));
        }

        private void canvas_Loaded(object sender, RoutedEventArgs e)
        {

        }


    }
}
