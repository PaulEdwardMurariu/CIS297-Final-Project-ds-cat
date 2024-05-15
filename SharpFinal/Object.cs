using System;

public class Object : IDrawable
{

    public int X0 { get; set; }
    public int Y0 { get; set; }
    public int X1 { get; set; }
    public int Y1 { get; set; }


    public void Draw(CanvasDrawingSession canvas)
    {
        canvas.DrawLine(x0, y0, x1, y1, color, WIDTH);
    }

    public Monster(int X0, int Y0, int X1, int Y1)
    {

    }


    //create obstacle
    public Wall()
	{
	}

	public Floor()
	{

	}
	
	public Spikes()
	{

	}
	

}
