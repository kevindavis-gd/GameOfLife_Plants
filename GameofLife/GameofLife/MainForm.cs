using System;
using System.Drawing;
using System.Windows.Forms;

namespace GameofLife
{
    public partial class MainForm : Form
    {
        int flyNum, deadlyNum, majesticNum, gridSizeX, gridSizeY, generations = 0;
        PictureBox[,] grid;
        DataStructure DataStructure = new DataStructure();
        GameLogic Logic = new GameLogic();
        int Gen = 0;
        

        public MainForm() { InitializeComponent(); }
        private void MainForm_Load(object sender, EventArgs e)
        {
            button_Next.Visible = false;
            button_Restart.Visible = false;
        }
        private void radioButton_Auto_CheckedChanged(object sender, EventArgs e)
        {
            // let game run automatically
            Logic.AutoRun = true;
        }
        private void radioButton_Manual_CheckedChanged(object sender, EventArgs e)
        {
            // requires button click to iterate
            Logic.AutoRun = false;
        }
        private void button_Restart_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
        private void LoadButton_click(object sender, EventArgs e)
        {
            
            LoadDataButton.Visible = false;
            button_Restart.Visible = true;
            //load the data structure into the game logic
            Logic.LoadGameLogic(DataStructure);
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

                if (gridSizeX > 15 || gridSizeY > 15)
                   DefaultValues("Grid Size Exceeds Form, Replacing With Default Values");
                //if there are too many organisms to fit on the board use default values
                if ((deadlyNum + majesticNum + flyNum) > (gridSizeX * gridSizeY))
                    DefaultValues("Too Many Organisms, Replacing With Default Values");
               
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
            DataStructure = new DataStructure();
            //fill a structure with requested actors
            Logic.DataArr.Fill2DArray(flyNum, deadlyNum, majesticNum, gridSizeX, gridSizeY);
            ScanAndUpdate();

            label_DeadlyCount.Text = "Deadly Mimics Left: " + Logic.DataArr.DeadlyCount;
            label_FlyCount.Text = "Flys Left: " + Logic.DataArr.FlyCount;
            label_MajesticCount.Text = "Majestic Plants Left: " + Logic.DataArr.MajesticCount;
            label_genCount.Text = "Generation " + Gen + " of " + generations;
        }//LoadButton_click

        private void button_Next_Click(object sender, EventArgs e)
        {
            timer_Game.Start();
        }//button_next_click

        private void timer_Game_Tick(object sender, EventArgs e)
        {
            ClearGrid(Color.Transparent);
            Logic.MoveFlies(gridSizeX, gridSizeY);
            ScanAndUpdate();
            Gen++;
            //Display organism count
            label_DeadlyCount.Text = "Deadly Mimics Left: " + Logic.DataArr.DeadlyCount;
            label_FlyCount.Text = "Flys Left: " + Logic.DataArr.FlyCount;
            label_MajesticCount.Text = "Majestic Plant Left: " + Logic.DataArr.MajesticCount;
            label_genCount.Text = "Generation " + Gen + " of " + generations;
            if (!Logic.AutoRun)
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
        //loop through entire picture array and set picture box image to null
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

        //******************************************************* ScanAndUpdate ****************************************
        //loop through the entire object array, perform movement then update the pictures
        public void ScanAndUpdate()
        {
            //reset organism count
            Logic.ResetOrganismCount();
            for (int x = 0; x < gridSizeX; x++)
            {
                for (int y = 0; y < gridSizeY; y++)
                {
                    //Logic.LoadGameLogic(Logic.DataArr);

                    grid[x, y].Image = Logic.UpdateGrid(x, y, gridSizeX, gridSizeY);
                }//innerFor
            }//outerFor
        }//ScanAndUpdate
        //*******************************************************Default Values****************************************
        public void DefaultValues(string text)
        {
            MessageBox.Show(text, "Info");
            deadlyNum = 20;
            majesticNum = 20;
            flyNum = 20;
            gridSizeX = 12;
            gridSizeY = 16;
            generations = 15;
        }//DefaultValues
    }//MainForm
}
