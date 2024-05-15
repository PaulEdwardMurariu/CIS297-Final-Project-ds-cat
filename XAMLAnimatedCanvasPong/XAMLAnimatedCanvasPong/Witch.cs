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
    class Witch : IDrawable, ICollidable
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
        private CanvasBitmap playerImage;
        StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
        StorageFile sampleFile;
        public int i = 0;
       


        public Witch(int x, int y, int width, int height, CanvasBitmap image)
        {
            playerImage = image;

            X = x;
            i = y;
            Width = image.Size.Width;
            Debug.Write(width);
            Height = image.Size.Height;
            Color = Colors.White;
            jumpLength = 10;
           
        }

        
        public void jump(bool j)
        {
            isJumping = j;
        }



        public virtual void Update()
        {
            
            if (isMovingRight)
            {
                X += 5;
            }
            if (isMovingLeft)
            {
                X -= 5;
            }


            if(i>400)//check for grounded
            {
                isGrouned = true;
                jumpLength = 10;
              
            }
            else
            {
                i = i + gravity;//gravity 
                isGrouned = false;
            }
            if (isJumping && jumpLength > 0)
            {
                jumpLength -= 1;
                i -= jumpHeight;
            }
        }


        public void Draw(CanvasDrawingSession canvas)
        {
            canvas.DrawImage(playerImage, X, i);
        }



        public bool CollidesLeftEdge(int x, int y, int speed)
        {
            return x == X && y >= i && y <= i + Height;
        }

        public bool CollidesRightEdge(int x, int y, int speed)
        {
            return x == X + Width && y >= i && y <= i + Height;
        }

        public bool CollidesTopEdge(int x, int y, int speed)
        {
            return x >= X && x <= X + Width && Math.Abs(y - i) - speed <= 0;
        }

        public bool CollidesBottomEdge(int x, int y, int speed)
        {
            return x >= X && x <= X + Width && Math.Abs(y - (i + Height)) - speed <= 0;

        }

    }

}

