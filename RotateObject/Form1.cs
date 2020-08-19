using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;



namespace RotateObject
{
    public partial class Form1 : Form
    {



        Graphics g; //declare a graphics object called g so we can draw on the Form
        Spaceship spaceship = new Spaceship(); //create an instance of the Spaceship Class called spaceship

        bool turnLeft, turnRight, moveUp, moveLeft, moveRight, moveDown;

        string move;

        //declare a list  missiles from the Missile class
        List<Missile> missiles = new List<Missile>();
        List<Planet> planets = new List<Planet>();


        public Form1()
        {
            InitializeComponent();

            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, PnlGame, new object[] { true });
           
            for (int i = 0; i < 7; i++)
            {
                int displacement = 10 + (i * 70);
                planets.Add(new Planet(displacement));
            }
        }




        private void tmrSpaceship_Tick(object sender, EventArgs e)
        {

            if (turnRight)
            {
                spaceship.rotationAngle += 5;
            }
            if (turnLeft)
                spaceship.rotationAngle -= 5;

            if (moveRight) // if right arrow key pressed
            {
                move = "right";
                spaceship.MoveSpaceship(move);
            }
            if (moveLeft) // if left arrow key pressed
            {
                move = "left";
                spaceship.MoveSpaceship(move);
            }

            if (moveUp) // if right arrow key pressed
            {
                move = "up";
                spaceship.MoveSpaceship(move);
            }
            if (moveDown) // if left arrow key pressed
            {
                move = "down";
                spaceship.MoveSpaceship(move);
            }

            PnlGame.Invalidate();

        }

      




      
        private void PnlGame_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                missiles.Add(new Missile(spaceship.spaceRec, spaceship.rotationAngle));
            }
        }

        private void PnlGame_Paint(object sender, PaintEventArgs e)
        {
            //get the graphics used to paint on the Form control
            g = e.Graphics;
            foreach (Planet p in planets)
            {
                p.draw(g);//Draw the planet
                p.movePlanet(g);//move the planet

                //if the planet reaches the bottom of the form relocate it back to the top
                if (p.y >= ClientSize.Height)
                {
                    p.y = -20;
                }

            }//Draw the spaceship
            spaceship.drawSpaceship(g);

            foreach (Missile m in missiles)
            {
                m.drawMissile(g);
                m.moveMissile(g);

            }

            
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Left) { turnLeft = false; }
            if (e.KeyData == Keys.Right) { turnRight = false; }
            if (e.KeyData == Keys.W) { moveUp = false; }
            if (e.KeyData == Keys.A) { moveRight = false; }
            if (e.KeyData == Keys.S) { moveDown = false; }
            if (e.KeyData == Keys.D) { moveLeft = false; }
        }

        private void MnuStart_Click(object sender, EventArgs e)
        {
            tmrSpaceship.Enabled = true;
        }

        private void MnuStop_Click(object sender, EventArgs e)
        {
            tmrSpaceship.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Instructions", "Game Instructions");
            txtName.Focus();


        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Left) { turnLeft = true; }
            if (e.KeyData == Keys.Right) { turnRight = true; }
            if (e.KeyData == Keys.W) { moveUp = true; }
            if (e.KeyData == Keys.A) { moveRight = true; }
            if (e.KeyData == Keys.S) { moveDown = true; }
            if (e.KeyData == Keys.D) { moveLeft = true; }
            if (e.KeyData == Keys.E) { missiles.Add(new Missile(spaceship.spaceRec, spaceship.rotationAngle)); }
        }

    }
}
