using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Organisms;

namespace GameofLife
{
    public partial class MainForm : Form
    {
        
        int flyNum, deadlyNum, majesticNum, GridSizeX, GridSizeY = 0;
        PictureBox[,] grid = new PictureBox[13, 13];

        public PictureBox[,] Grid 
        {
            get { return grid; }
        }

        
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void LoadButton_click(object sender, EventArgs e)
        {
            deadlyNum = int.Parse(textBox_DeadlyNum.Text);
            majesticNum = int.Parse(textBox_MajesticNum.Text);
            flyNum = int.Parse(textBox_FlyNum.Text);

            LoadEmptyPictureGrid();
            SetGridColor(Color.Red);

            Data DataStructure = new Data();
            //fill an array list with requested actors
            DataStructure.FillList(flyNum, deadlyNum, majesticNum);
            //randomize placement of actors
            foreach (var actor in DataStructure.Actors)
            {
                RandomGridPlacement(actor);
            }
        }//buttonClick



        public void SetGridColor (Color color)
        {
            for (int x = 0; x < 13; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    grid[y, x].BackColor = color;
                }//innerFor
            }//outerFor

        }

        public void LoadEmptyPictureGrid(int NumOfRows = 13, int NumOfCols = 13)
        {
            for (int x = 0; x < NumOfRows; x++)
            {
                for (int y = 0; y < NumOfRows; y++)
                {
                    //place anonymous picture box object in grid cells
                    grid[x, y] = new PictureBox
                    {   //set empty cells background color
                        BackColor = Color.Red,
                        //increment the location the picturebox bases on the iteration
                        Location = new Point(50 * x, 50 * y),
                        Size = new System.Drawing.Size(50, 50),
                        BorderStyle = BorderStyle.Fixed3D,
                        Anchor = AnchorStyles.Left,
                    };
                    //add the picturebox object to this form
                    this.Controls.Add(grid[x, y]);
                }
            }
        }//LoadPictureGrid
        public void RandomGridPlacement(Actor picture)
        {
            Random rand = new Random();
            //while the position is taken, randomize its position
            while (grid[picture.PositionX, picture.PositionY].BackColor != Color.Red)
            {
                //randomize position of object's X and Y position
                picture.PositionX = rand.Next(4);
                picture.PositionY = rand.Next(13);
            }//while
            if (picture.GetType() == typeof(Organisms.MajesticPlant))
            {
                //change the background colour to represent Majestic Plant
                grid[picture.PositionX, picture.PositionY].BackColor = Color.Green;
                //set picture in the grid based on the object's X and Y position
                grid[picture.PositionX, picture.PositionY].Image = GameofLife.Properties.Resources.Plant;
            }
            else if (picture.GetType() == typeof(Organisms.DeadlyMimic))
            {
                //change the background colour to represent DeadlyMimic
                grid[picture.PositionX, picture.PositionY].BackColor = Color.Purple;
                grid[picture.PositionX, picture.PositionY].Image = GameofLife.Properties.Resources.Deadly_Mimic1;
            }
            else if (picture.GetType() == typeof(Organisms.Fly))
            {
                //change the background colour to represent Fly
                grid[picture.PositionX, picture.PositionY].BackColor = Color.Yellow;
                grid[picture.PositionX, picture.PositionY].Image = GameofLife.Properties.Resources.Fly1;
            }
        }//RandomGridPlacement
    }
}
