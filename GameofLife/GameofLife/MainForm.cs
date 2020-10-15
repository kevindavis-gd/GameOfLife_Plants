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
        int populationMax = 0;

        int flyNum, deadlyNum, majesticNum, gridSizeX, gridSizeY = 0;
        PictureBox[,] grid;
        Data DataStructure;

        public int PopulationMax
        {
            get { return populationMax; }
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }
        private void LoadButton_click(object sender, EventArgs e)
        {   //exception handling
            try
            {
                deadlyNum = int.Parse(textBox_DeadlyNum.Text);
                majesticNum = int.Parse(textBox_MajesticNum.Text);
                flyNum = int.Parse(textBox_FlyNum.Text);
                gridSizeX = int.Parse(textBox_Rows.Text);
                gridSizeY = int.Parse(textBox_Columns.Text);
                //if there are too many organisms to fit on the board use default values
                if ((populationMax = deadlyNum + majesticNum + flyNum) > (gridSizeX * gridSizeY))
                {
                    DefaultValues();
                }//if
                grid = new PictureBox[gridSizeX, gridSizeY];
            }//try
            catch (FormatException)
            {
                MessageBox.Show("Whole Numbers Only!", "Error");
            }//catch
            //Show the Picture Grid
            LoadEmptyPictureGrid(gridSizeX, gridSizeY);
            //change the color of empty cells
            ClearGrid(Color.Red);
            //create the data structure to hold the actors
            DataStructure = new Data();
            //fill a structure with requested actors
            //DataStructure.Fill2DArray(flyNum, deadlyNum, majesticNum, gridSizeX, gridSizeY);
            DataStructure.Flies.Add(new Organisms.Fly(3, 3));
            DataStructure.Actors[3, 3] = DataStructure.Flies[0];
            LoadPictures();
        }//LoadButton_click

        private void button_Next_Click(object sender, EventArgs e)
        {
            ClearGrid(Color.Red);
            DataStructure.Move(gridSizeX, gridSizeY);
            LoadPictures();
            // DataStructure.AddPlant((Organisms.MajesticPlant)DataStructure.Actors[1,1].Pollinate(), gridSizeX, gridSizeY);
        }//button_next_click

        public void LoadPictures()
        {
            for (int x = 0; x < gridSizeX; x++)
            {
                for (int y = 0; y < gridSizeY; y++)
                {
                    if (DataStructure.Actors[x, y] != null)
                    {
                        if (DataStructure.Actors[x, y].GetType() == typeof(Organisms.DeadlyMimic))
                        {
                            grid[x, y].Image = GameofLife.Properties.Resources.Deadly_Mimic1;
                        }
                        else if (DataStructure.Actors[x, y].GetType() == typeof(Organisms.Fly))
                        {
                            grid[x, y].Image = GameofLife.Properties.Resources.Fly1;
                        }
                        else if (DataStructure.Actors[x, y].GetType() == typeof(Organisms.MajesticPlant))
                        {
                            grid[x, y].Image = GameofLife.Properties.Resources.Plant1;
                        }
                    }//if
                }//innerFor
            }//outerFor
        }//LoadPictures

        public void DefaultValues()
        {
            MessageBox.Show("Too Many Organisms, Replacing With Default Values", "Info");
            deadlyNum = 5;
            majesticNum = 5;
            flyNum = 5;
            gridSizeX = 5;
            gridSizeY = 5;
        }//DefaultValues

        public void ClearGrid(Color color)
        {
            for (int x = 0; x < gridSizeX; x++)
            {
                for (int y = 0; y < gridSizeY; y++)
                {
                    grid[x, y].BackColor = color;
                    grid[x, y].Image = null;
                }//innerFor
            }//outerFor
        }//SetGridColor

        public void LoadEmptyPictureGrid(int NumOfRows, int NumOfCols)
        {
            for (int x = 0; x < NumOfRows; x++)
            {
                for (int y = 0; y < NumOfCols; y++)
                {
                    //place anonymous picture box object in grid cells
                    grid[x, y] = new PictureBox
                    {   //set empty cells background color
                        BackColor = Color.Red,
                        //increment the location the picturebox bases on the iteration
                        Location = new Point(50 * y, 100 + 50 * x),
                        Size = new System.Drawing.Size(50, 50),
                        BorderStyle = BorderStyle.Fixed3D,
                        Anchor = AnchorStyles.Left,
                    };//grid
                    //add the picturebox object to this form
                    this.Controls.Add(grid[x, y]);
                }//innerFor
            }//outerFor
        }//LoadPictureGrid





        /*
        public void FlyMovement()
        {
            //randomize placement of plants
            foreach (var actor in DataStructure.Plants)
            {
                RandomFlysOnly(actor);
            }
            //animals came on this earth last
            foreach (var actor in DataStructure.Fly)
            {
                RandomFlysOnly(actor);
            }
            foreach (var actor in DataStructure.Deadly)
            {
                RandomFlysOnly(actor);
            }
        }//FlyMovement
        */



























        public void RandomGridPlacement(Actor picture)
        {
            Random rand = new Random();
            //while the position is taken, randomize its position
            while (grid[picture.PositionX, picture.PositionY].BackColor != Color.Red)
            {
                //randomize position of object's X and Y position
                picture.PositionX = rand.Next(gridSizeX);
                picture.PositionY = rand.Next(gridSizeY);
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

        public void RandomFlysOnly(Actor picture)
        {
            Random rand = new Random();
            //while the position is taken, randomize its position

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
                picture.PositionX = rand.Next(gridSizeX);
                picture.PositionY = rand.Next(gridSizeY);

                while (grid[picture.PositionX, picture.PositionY].BackColor != Color.Red)
                {
                    //randomize position of object's X and Y position
                    picture.PositionX = rand.Next(gridSizeX);
                    picture.PositionY = rand.Next(gridSizeY);
                }//while

                //change the background colour to represent Fly
                grid[picture.PositionX, picture.PositionY].BackColor = Color.Yellow;
                grid[picture.PositionX, picture.PositionY].Image = GameofLife.Properties.Resources.Fly1;
            }
        }//RandomGridPlacement
    }//MainForm
}
