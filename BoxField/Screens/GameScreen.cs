using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoxField
{
    public partial class GameScreen : UserControl
    {
        //player1 button control keys
        Boolean leftArrowDown, rightArrowDown;

        //used to draw boxes on screen
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush greenBrush = new SolidBrush(Color.Green);

        //create a list to hold a column of boxes   
        List<Box> boxes = new List<Box>();
        int countdown = 0;
        Random randGen = new Random();
        int newXPosition;
        int stayToSide = 5;
        public GameScreen()
        {
            InitializeComponent();
            OnStart();
        }

        /// <summary>
        /// Set initial game values here
        /// </summary>
        public void OnStart()
        {
            //TODO - set game start values
            int colourValue = randGen.Next(1, 4);
            string colour = "white";
            if (colourValue == 1)
            {
                colour = "red";
            }
            else if (colourValue == 2)
            {
                colour = "green";
            }
            else
            {
                colour = "white";
            }
            Box b = new Box(350,0,30,4, colour);
            boxes.Add(b);
            Box b3 = new Box(700,0,30,4, colour);
            boxes.Add(b3);
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //player 1 button presses
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;           
            }
        }


        private void gameLoop_Tick(object sender, EventArgs e)
        {
            //shifting the boxes randomly
            if (stayToSide == 0)
            {
                newXPosition = randGen.Next(-10, 10);
                stayToSide = 30;
            }
            else stayToSide--;
            
            //TODO - update location of all boxes (drop down screen)
            foreach (Box b in boxes)
            {
                b.y += b.speed;
            }
            //TODO - remove box if it has gone of screen
            if (boxes[0].y > this.Height)
            {
                boxes.RemoveAt(0);
            }
            //TODO - add new box if it is time
            if (countdown == 0)
            {
                int colourValue = randGen.Next(1, 4);
                string colour = "white";
                if (colourValue == 1)
                {
                    colour = "red";
                }
                else if (colourValue == 2)
                {
                    colour = "green";
                }
                else
                {
                    colour = "white";
                }
                Box b2 = new Box(350+newXPosition, 0, 30, 4, colour);
                boxes.Add(b2);
                Box b4 = new Box(700+newXPosition, 0, 30, 4, colour);
                boxes.Add(b4);

                countdown = 9;
                
            }
            else countdown--;

            

            Refresh();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            //TODO - draw boxes to screen
            foreach (Box b in boxes)
            {
                if (b.colour == "red")
                {
                    e.Graphics.FillRectangle(redBrush, b.x, b.y, b.size, b.size);
                }
                else if (b.colour == "green")
                {
                    e.Graphics.FillRectangle(greenBrush, b.x, b.y, b.size, b.size);
                }
                else
                {
                    e.Graphics.FillRectangle(whiteBrush, b.x, b.y, b.size, b.size);
                }

            }
        }
    }
}
