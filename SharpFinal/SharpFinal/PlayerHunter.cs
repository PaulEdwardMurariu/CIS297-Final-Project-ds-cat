using Microsoft.Graphics.Canvas;
using System;
using System.Collections.Generic;
using Windows.Gaming.Input;


namespace SharpFinal
{

    public interface IDrawable
    {
        void Draw(CanvasDrawingSession canvas);
    }

    public interface ICollidable
    {
        bool CollidesLeft(int x, int y);
        bool CollidesRight(int x, int y);
        bool CollidesTop(int x, int y);
        bool CollidesBottom(int x, int y);

    }

    public interface IDestroyable: ICollidable { }

    public class PlayerHunter
    {
        private Random Random;
        private Gamepad Controller;
        private List<IDrawable> drawables;
        private bool gameOver;
        

     



        public PlayerHunter()
        {
           



        }

        //Powerup
        //Gravity
        //Collision
        //Jump
        //Controls
        //InvincibilityFrame


    }
}