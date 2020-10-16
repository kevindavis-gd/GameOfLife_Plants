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
        

        int flyNum, deadlyNum, majesticNum, gridSizeX, gridSizeY = 0;
        PictureBox[,] grid;
        Data DataStructure;
        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
        }
        private void LoadButton_click(object sender, EventArgs e)
        {
            //exception handling
            try
            {
                deadlyNum = int.Parse(textBox_DeadlyNum.Text);
                majesticNum = int.Parse(textBox_MajesticNum.Text);
                flyNum =  int.Parse(textBox_FlyNum.Text);
                gridSizeX = int.Parse(textBox_Rows.Text);
                gridSizeY = int.Parse(textBox_Columns.Text);
                //if there are too many organisms to fit on the board use default values
                if ((deadlyNum + majesticNum + flyNum) > (gridSizeX * gridSizeY))
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
            DataStructure.OrganismCountInitilize(deadlyNum, flyNum, majesticNum);
            DataStructure.Fill2DArray(flyNum, deadlyNum, majesticNum, gridSizeX, gridSizeY);
            /*
            DataStructure.Flies.Add(new Organisms.Fly(3, 3));
            DataStructure.Actors[3, 3] = DataStructure.Flies[0];
            DataStructure.Actors[0, 2] = new Organisms.DeadlyMimic(0,2);
            //DataStructure.Actors[3, 2] = new Organisms.DeadlyMimic(3, 2);
            DataStructure.Actors[3, 1] = new Organisms.DeadlyMimic(4, 1);
            DataStructure.Actors[0, 4] = new Organisms.MajesticPlant(0, 4);
            DataStructure.Actors[2, 1] = new Organisms.MajesticPlant(2, 1);
            DataStructure.Actors[1, 4] = new Organisms.MajesticPlant(1, 4);
            */
            LoadPictures();
            label_DeadlyCount.Text = "Deadly Mimics Left: " + DataStructure.DeadlyCount;
            label_FlyCount.Text = "Flys Left: " + DataStructure.FlyCount;
            label_MajesticCount.Text = "Majestic Plant Left: " + DataStructure.MajesticCount;
        }//LoadButton_click
        
        private void button_Next_Click(object sender, EventArgs e)
        {
            ClearGrid(Color.Red);
            DataStructure.Move(gridSizeX, gridSizeY);
            LoadPictures();
            // DataStructure.AddPlant((Organisms.MajesticPlant)DataStructure.Actors[1,1].Pollinate(), gridSizeX, gridSizeY);

            //Display organism count
            label_DeadlyCount.Text = "Deadly Mimics Left: " + DataStructure.DeadlyCount;
            label_FlyCount.Text = "Flys Left: " + DataStructure.FlyCount;
            label_MajesticCount.Text = "Majestic Plant Left: " + DataStructure.MajesticCount;
        }//button_next_click
        //*******************************************************Load Pictures ****************************************
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
                        if (DataStructure.Actors[x, y].GetType() == typeof(Organisms.MajesticPlant))
                        {
                            grid[x, y].Image = GameofLife.Properties.Resources.Plant1;
                        }  
                        if (DataStructure.Actors[x, y].GetType() == typeof(Organisms.Fly))
                        {
                            grid[x, y].Image = GameofLife.Properties.Resources.Fly1;
                            Console.WriteLine("" + x + " " + y);
                        } 
                    }//if
                }//innerFor
                
            }//outerFor
            Console.WriteLine("-----------");
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
        }//LoadPictureGrid\
    }//MainForm
}
