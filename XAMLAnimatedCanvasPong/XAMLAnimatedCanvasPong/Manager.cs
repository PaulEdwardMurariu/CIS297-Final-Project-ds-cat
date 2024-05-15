using Microsoft.Graphics.Canvas;
using game;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.Gaming.Input;
using Windows.UI;
using Windows.UI.Input;
using Windows.UI.Input.Inking;
using Windows.UI.Xaml.Documents;
using Windows.Gaming.UI;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml.Controls;
using System.Diagnostics;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml;
using System.Numerics;


namespace game
{
    public interface IDrawable
    {
        void Draw(CanvasDrawingSession canvas);
    }

    public interface ICollidable
    {
        bool CollidesLeftEdge(int x, int y, int speed);
        bool CollidesRightEdge(int x, int y, int speed);
        bool CollidesTopEdge(int x, int y, int speed);
        bool CollidesBottomEdge(int x, int y, int speed);
    }

    public interface IDestroyable : ICollidable
    { }

    public class Manager
    {
        public static int LEFT_EDGE = 10;
        public static int TOP_EDGE = 10;
        public static int RIGHT_EDGE = 790;
        public static int BOTTOM_EDGE = 450;

        private Witch witch;
        private Block blockA;

        private List<IDrawable> drawables;

        private Gamepad controller;

        private long ticks;

        public bool gameover;

        private int groundY = 500;

        public int GroundY
        {
            get { return groundY; }
            set { groundY = value; }
        }
        public Manager(CanvasBitmap playerImage, CanvasBitmap blockImage) 
        {
     

            drawables = new List<IDrawable>();
            ticks = 0;
            witch = new Witch(100, 100, 20, 20,playerImage);
            blockA = new Block(100, 300, 1,1, blockImage);
            drawables.Add(witch);
            drawables.Add(blockA);

            


        }


    public void MovingLeft(bool k)
        {

            witch.isMovingLeft = k;
        }

        public void MovingRight(bool k)
        {
            witch.isMovingRight = k;
        }


        public void Update()
        {
        

            if (Gamepad.Gamepads.Count > 0)
            {
                controller = Gamepad.Gamepads.First();
                var reading = controller.GetCurrentReading();
                witch.X += (int)(reading.LeftThumbstickX * 5);
                witch.Y += (int)(reading.LeftThumbstickY * -5);
                if (reading.Buttons.HasFlag(GamepadButtons.A))
                {
                    witch.jump(true);
                }
                else
                {
                    witch.jump(false);
                }
            }
            if (!gameover)
            {
                
                foreach (var drawable in drawables)
                {
                    ICollidable collidable = drawable as ICollidable;
                    if (collidable != null)
                    {
                        if (collidable.CollidesBottomEdge(witch.X, witch.i, witch.speed))
                        {

                            Debug.Write(collidable.ToString());
                        }
                        if (collidable.CollidesTopEdge(witch.X, witch.i, witch.speed))
                        {
                            Debug.Write(collidable.ToString());

                        }
                        if (collidable.CollidesLeftEdge(witch.X, witch.i, witch.speed))
                        {
                            Debug.Write(collidable.ToString());
                        }
                            //Debug.Write("ding"); 
                        if (collidable.CollidesRightEdge(witch.X, witch.i, witch.speed))
                            {
                            Debug.Write(collidable.ToString());
                        }
                            //Debug.Write("ding");
                        
                    }
                }
                witch.Update();
            }
        }
        public void DrawGame(CanvasDrawingSession canvas)
        {
            foreach (var drawable in drawables)
            {
                drawable.Draw(canvas);
            }

            canvas.DrawText($"Ticks: {ticks++}", 300, 650, Colors.White);

        }

     
    }

   





}


