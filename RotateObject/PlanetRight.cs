using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RotateObject
{
    class PlanetRight
    {

        // declare fields to use in the class

        public int x, y, width, height;//variables for the rectangle
        public Image planetImage;//variable for the planet's image

        public Rectangle planetRec;//variable for a rectangle to place our image in

        //Create a constructor (initialises the values of the fields)
        public PlanetRight(int displacement)
        {
            x = 600;
            y = displacement;
            width = 20;
            height = 20;
            planetImage = Properties.Resources.dot;
            planetRec = new Rectangle(x, y, width, height);
        }

        // Methods for the Planet class
        public void draw(Graphics g)
        {
            planetRec = new Rectangle(x, y, width, height);

            g.DrawImage(planetImage, planetRec);
        }
        public void movePlanet(Graphics g)
        {
            x += -5;
            planetRec.Location = new Point(x, y);

        }
    }




}

