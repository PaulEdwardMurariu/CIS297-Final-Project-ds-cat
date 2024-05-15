using System;
using Windows.Security.Cryptography.Core;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Graphics.Capture;
using Windows.Graphics.Imaging;
using Windows.Media.SpeechRecognition;
using Windows.Storage.Streams;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Input;
using Windows.UI.Input.Inking;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Shapes;

public class Player
{
    public class Player : IDrawable
    {
        public int X;
        public int Y; 
        

        public Player(int x, int y)
        {
            X = x;
            Y = y;
        }


    }
}
