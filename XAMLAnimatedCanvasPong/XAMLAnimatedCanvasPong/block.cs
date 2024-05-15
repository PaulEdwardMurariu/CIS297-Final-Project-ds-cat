using Microsoft.Graphics.Canvas;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Gaming.Input;
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
using System.Diagnostics;
using System.Numerics;

namespace game
{
    class Block : IDrawable, ICollidable
    {

        public bool isMovingLeft { get; set; }

        public bool isMovingRight { get; set; }
        public bool isMovingDown { get; set; }

        public bool isMovingUp { get; set; }
        //gravity
        public int gravity = 5;
        //grounded
        public bool isGrouned;
        //movement
        public bool isJumping;
        public int jumpLength = 20;
        public bool isJumpEnd;
        public int jumpHeight = 20;
        public Rect rect;
        public int speed = 1;
        //hasPowerUp
        public bool hasPowerUP;
        //Iframe
        //location
        public int X;
        public int Y;
        //size
        public double Width;
        public double Height;
        //color
        public Color Color;
        private CanvasBitmap blockImage;
        StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
        StorageFile sampleFile;
        int i = 0;
       


        public Block(int x, int y, int w, int h, CanvasBitmap image)
        {
            blockImage = image;
            Height = h;
            Width = w;
            X = x;
            i = y;
           
           
        }





        public virtual void Update()
        {
            
    


          
        }


        public void Draw(CanvasDrawingSession canvas)
        {
            canvas.DrawImage(blockImage, X, i);
        }



        public bool CollidesLeftEdge(int x, int y, int speed)
        {
            return x == X && y >= Y && y <= Y + Height;
        }

        public bool CollidesRightEdge(int x, int y, int speed)
        {
            return x == X + Width && y >= Y && y <= Y + Height;
        }

        public bool CollidesTopEdge(int x, int y, int speed)
        {
            return x >= X && x <= X + Width && Math.Abs(y - Y) - speed <= 0;
        }

        public bool CollidesBottomEdge(int x, int y, int speed)
        {
            return x >= X && x <= X + Width && Math.Abs(y - (Y + Height)) - speed <= 0;

        }

    }

}

