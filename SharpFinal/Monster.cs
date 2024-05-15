using System;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using System.Windows.Forms;
public class Monster:Player
{
	public Monster()
	{

	}


    //hitbox
    public partial class Form1 : Form
    {
        private Image player;
        private Image monster;
        private int playerX = 0;
        private int playerY = 0;
        private int monsterX = 100;
        private int monsterY = 0;
        private bool monsterIsAlive = true;

        public Form1()
        {
            InitializeComponent();

            // Load the player and monster images
            player = Image.FromFile("player.png");
            monster = Image.FromFile("monster.png");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Move the monster down by 5 pixels
            monsterY += 5;

            // Redraw the form to update the monster's position
            Invalidate();

            // Check if the player and monster collide
            if (monsterIsAlive)
            {
                Rectangle playerRect = new Rectangle(playerX, playerY, player.Width, player.Height);
                Rectangle monsterRect = new Rectangle(monsterX, monsterY, monster.Width, monster.Height);

                if (playerRect.IntersectsWith(monsterRect))
                {
                    // Destroy the monster
                    monsterIsAlive = false;
                }
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // Draw the player and monster at their current positions
            e.Graphics.DrawImage(player, playerX, playerY);

            if (monsterIsAlive)
            {
                e.Graphics.DrawImage(monster, monsterX, monsterY);
            }
        }
    }





    //Collision
    public partial class Form1 : Form
    {
        private Image monster;
        private int monsterX = 100;
        private int monsterY = 0;
        private int monsterSpeed = 5;
        private bool monsterIsMovingRight = true;

        public Form1()
        {
            InitializeComponent();

            // Load the monster image
            monster = Image.FromFile("monster.png");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Move the monster left or right based on its current direction
            if (monsterIsMovingRight)
            {
                monsterX += monsterSpeed;
            }
            else
            {
                monsterX -= monsterSpeed;
            }

            // Redraw the form to update the monster's position
            Invalidate();

            // Check if the monster collides with an object
            if (/* code to detect collision */)
            {
                // Change the monster's direction
                monsterIsMovingRight = !monsterIsMovingRight;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // Draw the monster at its current position
            e.Graphics.DrawImage(monster, monsterX, monsterY);
        }
    }






    //Move
    public partial class Form1 : Form
{
    private Image monster;
    private int x = 0;

    public Form1()
    {
        InitializeComponent();

        // Load the monster image
        monster = Image.FromFile("monster.png");
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
        // Move the monster to the left by 5 pixels
        x -= 5;

        // Redraw the form to update the monster's position
        Invalidate();
    }

    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        // Draw the monster at its current position
        e.Graphics.DrawImage(monster, x, 0);
    }
}
	

}
