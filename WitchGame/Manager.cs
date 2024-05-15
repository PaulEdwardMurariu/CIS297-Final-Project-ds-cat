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

namespace WitchGame
{
    public class Manager
    {
        public interface IDrawable
        {
            void Draw(CanvasDrawingSession canvas);
        }

        public interface ICollidable
        {
            bool CollidesLeftEdge(int x, int y, int speed);
            bool ColllidesRightEdge(int x, int y, int speed);
            bool CollidesTopEdge(int x, int y, int speed);
            bool CoolidesBottomEdge(int x, int y, int speed);
        }

        public interface IDestroyable : ICollidable
        { }
        public Class1()
        {
        }
    }
    public class Manager
    {
        public static int LEFT_EDGE = 10;
        public static int TOP_EDGE = 10;
        public static int RIGHT_EDGE = 790;
        public static int BOTTOM_EDGE = 450;

        private Witch witch;

        private List<IDrawable> drawables;

        private Gamepad controller;

        private long ticks;

        public bool gameover;


        public Manager(CanvasBitmap playerImage)
        {
            drawables = new List<IDrawable>();
            ticks = 0;
            witch = new Witch(100, 100, 20, 20, playerImage);
            drawables.Add(witch);

        }


        public void DrawGame(CanvasDrawingSession canvas)
        {

        }

        public void Update()
        {
            //apply gravity
            witch.Y = +5;
            if (Gamepad.Gamepads.Count > 0)
            {
                controller = Gamepad.Gamepads.First();
                var reading = controller.GetCurrentReading();
                witch.X += (int)(reading.LeftThumbstickX * 5);
                witch.Y += (int)(reading.LeftThumbstickY * -5);
                if (reading.Buttons.HasFlag(GamepadButtons.A))
                {
                    witch.jump();
                }
            }
            if (!gameover)
            {
                foreach (var drawable in drawables)
                {
                    ICollidable colliable = drawable as ICollidable;
                    if (colliable != null)
                    {
                        if (colliable.CoolidesBottomEdge(witch.X, witch.Y, witch.speed))
                            ;
                        if (colliable.CollidesTopEdge(witch.X, witch.Y, witch.speed))
                            ;
                        if (colliable.CollidesLeftEdge(witch.X, witch.Y, witch.speed))
                            ;
                        if (colliable.ColllidesRightEdge(witch.X, witch.Y, witch.speed))
                            ;
                    }
                }
            }
            public void MovingLeft(bool k)
            {
                witch.isMovingLeft = k;
            }
            public void MovingRight(bool k)
            {
                witch.isMovingRight = k;
            }
        }

    }
