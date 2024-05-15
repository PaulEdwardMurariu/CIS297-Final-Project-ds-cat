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


namespace WitchGame
{
    class Witch : IDrawable, ICollidable
    {

        public bool isMovingLeft;
        public bool isMovingRight;
        //gravity
        public int gravity = 5;
        //grounded
        public bool isGrouned;
        //movement
        public bool movingLeft;
        public bool movingRight;
        public bool isJumping;
        public int jumpLength = 10;
        public bool isJumpEnd;
        public int jumpHeight = 10;
        public Rect rect;
        public int speed;
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
        private CanvasBitmap playerImage;
        StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
        StorageFile sampleFile;


        public Witch(int x, int y, int width, int height, CanvasBitmap image)
        {
            playerImage = image;

            X = x;
            Y = y;
            Width = image.Size.Width;
            Height = image.Size.Height;
            Color = Colors.White;
            movingLeft = false;
            movingRight = false;


        }

        public void jump()
        {

        }



        public virtual void Update()
        {
            if (movingRight)
            {
                X += 5;
            }
            else if (movingLeft)
            {
                X -= 5;
            }
            Y += gravity;//gravity 
            if (CoolidesBottomEdge(X, Y, 1))//check for grounded
            {
                isGrouned = true;
                jumpLength = 10;
            }
            else
            {
                isGrouned = false;
            }
            if (isJumping && jumpLength > 0)
            {
                jumpLength -= 1;
                Y -= jumpHeight;
            }
        }


        public void Draw(CanvasDrawingSession canvas)
        {

            canvas.DrawImage(playerImage, X, Y);
        }

        public bool CollidesLeftEdge(int x, int y, int speed)
        {
            return x == X && y >= Y && y <= Y + Height;
        }

        public bool ColllidesRightEdge(int x, int y, int speed)
        {
            return x == X + Width && y >= Y && y <= Y + Height;
        }

        public bool CollidesTopEdge(int x, int y, int speed)
        {
            return x >= X && x <= X + Width && Math.Abs(y - Y) - speed <= 0;
        }

        public bool CoolidesBottomEdge(int x, int y, int speed)
        {
            return x >= X && x <= X + Width && Math.Abs(y - (Y + Height)) - speed <= 0;
        }
    }

}

