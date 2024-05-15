using Microsoft.Graphics.Canvas;
using SharpFinal;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.Gaming.Input;
using Windows.UI;
using Windows.UI.Input;
using Windows.UI.Input.Inking;
using Windows.UI.Xaml.Documents;

public class Manager
{
    
    public int X { get; set; }
    public int Y { get; set; }
    public bool isMovingLeft;
    public bool isMovingRight;

    private Gamepad controller;

    private List<IDrawable> drawables;

    public Manager(CanvasBitmap playerImage)
    {
        drawables = new List<IDrawable>();
    }

    public void DrawGame(CanvasDrawingSession canvas)
    {

    }

    public class Witch : IDrawable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Radius { get; set; }
        private CanvasBitmap image;
        public int Grav = 5;
        public int Speed { get; set; }

        public Witch(int x, int y, int radius, CanvasBitmap image)
        {
            X = x;
            Y = y;
            Radius = radius;
            this.image = image;
            Speed = 1;

        }

        public void Update()
        {
            //apply gravity 
            Y -= Grav;
        }

        public void Draw(CanvasDrawingSession canvas)
        {
            // when using image, account for x and y being top left
            canvas.DrawImage(image, X, Y);

        }
    }

    public void Update() { }

    public void MovingLeft(bool k)
    {
        isMovingLeft = k;
    }
    public void MovingRight(bool k)
    {
        isMovingRight = k;
    }
}

