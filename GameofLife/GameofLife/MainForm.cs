using System;
using System.Drawing;
using System.Windows.Forms;

namespace GameofLife
{
    public partial class MainForm : Form
    {
        int flyNum, deadlyNum, majesticNum, gridSizeX, gridSizeY, generations = 0;
        PictureBox[,] grid;
        Data DataStructure;
        int Gen = 0;
        bool autoRun;

        public MainForm() { InitializeComponent(); }
        private void MainForm_Load(object sender, EventArgs e)
        {
            button_Next.Visible = false;
            button_Restart.Visible = false;
        }
        private void radioButton_Auto_CheckedChanged(object sender, EventArgs e)
        {
            autoRun = true;
        }
        private void radioButton_Manual_CheckedChanged(object sender, EventArgs e)
        {
            autoRun = false;
        }
        private void button_Restart_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
        private void LoadButton_click(object sender, EventArgs e)
        {
            LoadDataButton.Visible = false;
            button_Restart.Visible = true;
            //exception handling
            try
            {
                button_Next.Visible = true;
                deadlyNum = int.Parse(textBox_DeadlyNum.Text);
                majesticNum = int.Parse(textBox_MajesticNum.Text);
                flyNum = int.Parse(textBox_FlyNum.Text);
                gridSizeX = int.Parse(textBox_Rows.Text);
                gridSizeY = int.Parse(textBox_Columns.Text);
                generations = int.Parse(textBox_generationNum.Text);
                //if there are too many organisms to fit on the board use default values
                if ((deadlyNum + majesticNum + flyNum) > (gridSizeX * gridSizeY))
                {
                    DefaultValues();
                }
                grid = new PictureBox[gridSizeX, gridSizeY];
            }//try
            catch (FormatException)
            {
                MessageBox.Show("Integers Only!", "Error");
                Application.Restart();
            }//catch
            //Show the Picture Grid
            LoadEmptyPictureGrid(gridSizeX, gridSizeY);
            //change the color of empty cells
            ClearGrid(Color.Transparent);
            //create the data structure to hold the actors
            DataStructure = new Data();
            //fill a structure with requested actors
            DataStructure.Fill2DArray(flyNum, deadlyNum, majesticNum, gridSizeX, gridSizeY);
            LoadPictures();
            label_DeadlyCount.Text = "Deadly Mimics Left: " + DataStructure.DeadlyCount;
            label_FlyCount.Text = "Flys Left: " + DataStructure.FlyCount;
            label_MajesticCount.Text = "Majestic Plants Left: " + DataStructure.MajesticCount;
            label_genCount.Text = "Generation " + Gen + " of " + generations;
        }//LoadButton_click

        private void button_Next_Click(object sender, EventArgs e)
        {
            timer_Game.Start();
        }//button_next_click

        private void timer_Game_Tick(object sender, EventArgs e)
        {
            ClearGrid(Color.Transparent);
            DataStructure.MoveFlies(gridSizeX, gridSizeY);
            LoadPictures();
            Gen++;
            //Display organism count
            label_DeadlyCount.Text = "Deadly Mimics Left: " + DataStructure.DeadlyCount;
            label_FlyCount.Text = "Flys Left: " + DataStructure.FlyCount;
            label_MajesticCount.Text = "Majestic Plant Left: " + DataStructure.MajesticCount;
            label_genCount.Text = "Generation " + Gen + " of " + generations;
            if (!autoRun)
            {
                timer_Game.Stop();
                timer_Game.Interval = 20;
            }
            else
            {
                timer_Game.Interval = 500;
            }
            if (Gen >= generations)
            {
                timer_Game.Stop();

                MessageBox.Show("Max Generation Reached", "Max Gen");
                Application.Restart();
            } 
        }

        //*******************************************************Load Empty Picture Grid ****************************************
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
                        BorderStyle = BorderStyle.None,
                        Anchor = AnchorStyles.Left,

                    };//grid
                    //add the picturebox object to this form
                    this.Controls.Add(grid[x, y]);
                }//innerFor
            }//outerFor
        }//LoadPictureGrid

        //*******************************************************Clear Grid ****************************************
        public void ClearGrid(Color color)
        {
            for (int x = 0; x < gridSizeX; x++)
            {
                for (int y = 0; y < gridSizeY; y++)
                {
                    grid[x, y].BackColor = color;
                    grid[x, y].BackgroundImage = GameofLife.Properties.Resources.BackGround;
                    grid[x, y].Image = null;
                }//innerFor
            }//outerFor
        }//SetGridColor

        //*******************************************************Load Pictures ****************************************
        public void LoadPictures()
        {
            //reset organism count
            DataStructure.FlyCount = 0;
            DataStructure.MajesticCount = 0;
            DataStructure.DeadlyCount = 0;
            DataStructure.Flies.Clear();

            for (int x = 0; x < gridSizeX; x++)
            {
                for (int y = 0; y < gridSizeY; y++)
                {
                    if (DataStructure.Actors[x, y] != null)
                    {
                        //decrement life
                        DataStructure.Actors[x, y].Life--;
                        int switchCase = 9;
                        //switches can only use variables
                        if (DataStructure.Actors[x, y].GetType() == typeof(Organisms.DeadlyMimic))
                            switchCase = 0;
                        if (DataStructure.Actors[x, y].GetType() == typeof(Organisms.MajesticPlant))
                            switchCase = 1;
                        if (DataStructure.Actors[x, y].GetType() == typeof(Organisms.Fly))
                            switchCase = 2;

                        //switch statement
                        switch (switchCase)
                        {
                            case 0:
                                if (DataStructure.Actors[x, y].Life < 0)
                                {
                                    DataStructure.Actors[x, y] = null;
                                    continue;
                                }

                                ((Organisms.DeadlyMimic)DataStructure.Actors[x, y]).Grow();

                                if (((Organisms.DeadlyMimic)DataStructure.Actors[x, y]).Size < 1)
                                {
                                    grid[x, y].Image = GameofLife.Properties.Resources.DeadlyMimic1;
                                }
                                else if (((Organisms.DeadlyMimic)DataStructure.Actors[x, y]).Size < 2)
                                {
                                    grid[x, y].Image = GameofLife.Properties.Resources.DeadlyMimic2;
                                }
                                else
                                {
                                    grid[x, y].Image = GameofLife.Properties.Resources.DeadlyMimic3;
                                }
                                //DataStructure.DeadlyCount++;
                                //Using static Variables
                                DataStructure.DeadlyCount = DataStructure.Actors[x, y].Count;
                                break;
                            case 1:
                                //plants dont die
                                ((Organisms.MajesticPlant)DataStructure.Actors[x, y]).Grow();
                                if (((Organisms.MajesticPlant)DataStructure.Actors[x, y]).Size < 1)
                                {
                                    grid[x, y].Image = GameofLife.Properties.Resources.MajesticPlant1;
                                }
                                else if (((Organisms.MajesticPlant)DataStructure.Actors[x, y]).Size < 2)
                                {
                                    grid[x, y].Image = GameofLife.Properties.Resources.MajesticPlant2;
                                }
                                else
                                {
                                    grid[x, y].Image = GameofLife.Properties.Resources.MajesticPlant3;
                                }
                                //DataStructure.MajesticCount++;
                                DataStructure.MajesticCount = DataStructure.Actors[x, y].Count;
                                break;
                            case 2:
                                if (DataStructure.Actors[x, y].Life < 0)
                                {
                                    DataStructure.Actors[x, y] = null;
                                    DataStructure.Actors[x, y] = null;   
                                    continue;
                                }
                                grid[x, y].Image = GameofLife.Properties.Resources.Fly1;
                                //DataStructure.FlyCount++;
                                DataStructure.FlyCount = DataStructure.Actors[x, y].Count;
                                DataStructure.Flies.Add(DataStructure.Actors[x, y]);
                                break;
                            default:

                                break;
                        }
                    }//if
                }//innerFor
            }//outerFor
        }//LoadPictures
        //*******************************************************Default Values****************************************
        public void DefaultValues()
        {
            MessageBox.Show("Too Many Organisms, Replacing With Default Values", "Info");
            deadlyNum = 12;
            majesticNum = 12;
            flyNum = 12;
            gridSizeX = 12;
            gridSizeY = 14;
            generations = 15;
        }//DefaultValues
    }//MainForm
}
