////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Name: Kevin Davis 
// Class : CMPS4143
// Assignment: Program 5
// Date: 10/23/2020
//
// Description :
// To create a library (dll) of critters; to instantiate objects of classes in an inheritance hierarchy and 
// polymorphically output each object’s attributes; to use static variables; to use a labels, text boxes and buttons;
// to use the switch statement; to use exception handling; to use a data structure to hold references to objects.
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

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
        string ManualSelection = "1";
        int Gen = 1;
        bool editForm = false;


        public MainForm() { InitializeComponent(); }
        private void MainForm_Load(object sender, EventArgs e)
        {
        }
        //*************************************************** Radio Buttons *******************************************
        private void radioButton_Auto_CheckedChanged(object sender, EventArgs e)
        {
            // let game run automatically
            Logic.AutoRun = true;
        }
        private void radioButton_Manual_CheckedChanged(object sender, EventArgs e)
        {
            // game will require button click to iterate
            Logic.AutoRun = false;
        }

        private void radioButton_ManualFly_CheckedChanged(object sender, EventArgs e)
        {
            ManualSelection = "1";
        }

        private void radioButton_ManualMimic_CheckedChanged(object sender, EventArgs e)
        {
            ManualSelection = "2";
        }

        private void radioButton_ManualDeadly_CheckedChanged(object sender, EventArgs e)
        {
            ManualSelection = "3";
        }

        //*************************************************** Normal Buttons *******************************************
        private void button_Restart_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }


        private void button_Next_Click(object sender, EventArgs e)
        {
            timer_Game.Start();
        }//button_next_click
         //*************************************************** Auto Load Button*******************************************

        private void button_AutoLoad_Click(object sender, EventArgs e)
        {

            button_AutoLoad.Visible = false;
            button_Restart.Visible = true;
            button_ContinueFromManualSelect.Visible = false;
            button_ManualLoad.Visible = false;
            button_Next.Visible = true;
            label_DeadlyNums.Visible = true;
            label_FlyNum.Visible = true;
            label_MajesticNum.Visible = true;
            label_MajesticNum.Visible = true;
            textBox_DeadlyNum.Visible = true;
            textBox_FlyNum.Visible = true;
            textBox_MajesticNum.Visible = true;
            groupBox_manualSelect.Visible = false;
            editForm = false;
            Logic.LoadGameLogic(DataStructure);
            try
            {
                button_Next.Visible = true;
                deadlyNum = int.Parse(textBox_DeadlyNum.Text);
                majesticNum = int.Parse(textBox_MajesticNum.Text);
                flyNum = int.Parse(textBox_FlyNum.Text);
                gridSizeX = int.Parse(textBox_Rows.Text);
                gridSizeY = int.Parse(textBox_Columns.Text);
                generations = int.Parse(textBox_generationNum.Text);
                //I didnt like the scroll bars with auto scroll so I limited it to size of form
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
        }//AutoLoadButton


        //*************************************************** Manual Load Button *******************************************
        private void button_ManualLoad_Click(object sender, EventArgs e)
        {
            button_AutoLoad.Visible = false;
            button_Restart.Visible = true;
            button_ContinueFromManualSelect.Visible = true;
            button_ManualLoad.Visible = false;
            button_ManualLoad.Visible = false;
            button_Next.Visible = false;
            label_DeadlyNums.Visible = false;
            label_FlyNum.Visible = false;
            label_MajesticNum.Visible = false;
            label_MajesticNum.Visible = false;
            textBox_DeadlyNum.Visible = false;
            textBox_FlyNum.Visible = false;
            textBox_MajesticNum.Visible = false;
            groupBox_manualSelect.Visible = true;
            editForm = true;
            try
            {
                gridSizeX = int.Parse(textBox_Rows.Text);
                gridSizeY = int.Parse(textBox_Columns.Text);
                generations = int.Parse(textBox_generationNum.Text);
                //I didnt like the scroll bars with auto scroll so I limited it to size of form
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
            DataStructure = new DataStructure(gridSizeX, gridSizeY);
        }//ManualLoad_Click

        //*************************************************** Manual Continue Button *******************************************
        private void button_ContinueFromManualSelect_Click(object sender, EventArgs e)
        {
            button_ContinueFromManualSelect.Visible = false;
            button_Next.Visible = true;
            button_ManualLoad.Visible = false;
            editForm = false;
            Logic.LoadGameLogic(DataStructure);
            LoadFromGrid();
            ClearGrid(Color.Transparent);
            ScanAndUpdate();
            label_DeadlyCount.Text = "Deadly Mimics Left: " + Logic.DataArr.DeadlyCount;
            label_FlyCount.Text = "Flys Left: " + Logic.DataArr.FlyCount;
            label_MajesticCount.Text = "Majestic Plants Left: " + Logic.DataArr.MajesticCount;
            label_genCount.Text = "Generation " + Gen + " of " + generations;
        }

        //*************************************************** Game Timer *************************************************
        private void timer_Game_Tick(object sender, EventArgs e)
        {

            ClearGrid(Color.Transparent);
            Logic.MoveFlies(gridSizeX, gridSizeY);
            ScanAndUpdate();

            //Display organism count
            label_DeadlyCount.Text = "Deadly Mimics Left: " + Logic.DataArr.DeadlyCount;
            label_FlyCount.Text = "Flys Left: " + Logic.DataArr.FlyCount;
            label_MajesticCount.Text = "Majestic Plant Left: " + Logic.DataArr.MajesticCount;
            label_genCount.Text = "Generation " + Gen + " of " + generations;

            if (!Logic.AutoRun)
            {
                timer_Game.Stop();
                //increase speed to make button click feel quick
                timer_Game.Interval = 20;
            }
            else
            {
                //reduce speed to view picture movement
                timer_Game.Interval = 500;
            }

            if (Gen >= generations)
            {
                timer_Game.Stop();
                MessageBox.Show("Max Generation Reached" +
                    "  Flies Left: " + Logic.DataArr.FlyCount +
                    "  Deadly Mimics Left: " + Logic.DataArr.DeadlyCount +
                    "  Majestic Plants Left: " + Logic.DataArr.MajesticCount,
                    "Max Gen");
                Application.Restart();
            }
            Gen++;
            //fly count will not update on first iteration, but will update correctly afterwards
            System.GC.Collect();
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
                    grid[x, y].Click += MainForm_Click;
                    //add the picturebox object to this form
                    this.Controls.Add(grid[x, y]);
                }//innerFor
            }//outerFor
        }//LoadPictureGrid



        //*******************************************************Click Picture Boxes ****************************************
        private void MainForm_Click(object sender, EventArgs e)
        {
            if (editForm == true)
            {
                ((PictureBox)sender).Image = GameofLife.Properties.Resources.Fly1;

                int a = Int32.Parse(ManualSelection);
                switch (a)
                {
                    case 1:
                        ((PictureBox)sender).Image = GameofLife.Properties.Resources.Fly1;
                        ((PictureBox)sender).Name = ManualSelection.ToString();
                        break;
                    case 2:
                        ((PictureBox)sender).Image = GameofLife.Properties.Resources.DeadlyMimic1;
                        ((PictureBox)sender).Name = ManualSelection.ToString();
                        break;
                    case 3:
                        ((PictureBox)sender).Image = GameofLife.Properties.Resources.MajesticPlant1;
                        ((PictureBox)sender).Name = ManualSelection.ToString();
                        break;
                }
            }
        }

        //*******************************************************Load Actors from picture Grid******************************
        public void LoadFromGrid()
        {
            for (int x = 0; x < gridSizeX; x++)
            {
                for (int y = 0; y < gridSizeY; y++)
                {
                    if (grid[x, y].Image != null)
                    {
                        Logic.DataArr.LoadSingleActorfromPictureGrid(grid[x, y].Name.ToString(), x, y, gridSizeX, gridSizeY);
                    }

                }//innerFor
            }//outerFor
        }


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
