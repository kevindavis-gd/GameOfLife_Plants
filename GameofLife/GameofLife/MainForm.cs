using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Organisms;

namespace GameofLife
{
    public partial class MainForm : Form
    {
        PictureBox[,] grid = new PictureBox[13, 13];
        int flyNum, deadlyNum, majesticNum = 0;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //load pictureboxes into array
            //Very inefficient to rename them all
            grid[0, 0] = pictureBox1;
            grid[0, 1] = pictureBox2;
            grid[0, 2] = pictureBox3;
            grid[0, 3] = pictureBox4;
            grid[0, 4] = pictureBox5;
            grid[0, 5] = pictureBox6;
            grid[0, 6] = pictureBox7;
            grid[0, 7] = pictureBox8;
            grid[0, 8] = pictureBox9;
            grid[0, 9] = pictureBox10;
            grid[0, 10] = pictureBox11;
            grid[0, 11] = pictureBox12;
            grid[0, 12] = pictureBox13;

            grid[1, 0] = pictureBox14;
            grid[1, 1] = pictureBox15;
            grid[1, 2] = pictureBox16;
            grid[1, 3] = pictureBox17;
            grid[1, 4] = pictureBox18;
            grid[1, 5] = pictureBox19;
            grid[1, 6] = pictureBox20;
            grid[1, 7] = pictureBox21;
            grid[1, 8] = pictureBox22;
            grid[1, 9] = pictureBox23;
            grid[1, 10] = pictureBox24;
            grid[1, 11] = pictureBox25;
            grid[1, 12] = pictureBox26;

            grid[2, 0] = pictureBox27;
            grid[2, 1] = pictureBox28;
            grid[2, 2] = pictureBox29;
            grid[2, 3] = pictureBox30;
            grid[2, 4] = pictureBox31;
            grid[2, 5] = pictureBox32;
            grid[2, 6] = pictureBox33;
            grid[2, 7] = pictureBox34;
            grid[2, 8] = pictureBox35;
            grid[2, 9] = pictureBox36;
            grid[2, 10] = pictureBox37;
            grid[2, 11] = pictureBox38;
            grid[2, 12] = pictureBox39;

            grid[3, 0] = pictureBox40;
            grid[3, 1] = pictureBox41;
            grid[3, 2] = pictureBox42;
            grid[3, 3] = pictureBox43;
            grid[3, 4] = pictureBox44;
            grid[3, 5] = pictureBox45;
            grid[3, 6] = pictureBox46;
            grid[3, 7] = pictureBox47;
            grid[3, 8] = pictureBox48;
            grid[3, 9] = pictureBox49;
            grid[3, 10] = pictureBox50;
            grid[3, 11] = pictureBox51;
            grid[3, 12] = pictureBox52;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            deadlyNum = int.Parse(textBox_DeadlyNum.Text);
            majesticNum = int.Parse(textBox_MajesticNum.Text);
            flyNum = int.Parse(textBox_FlyNum.Text);






            for (int x = 0; x < 13; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    grid[y, x].BackColor = Color.Red;
                }//innerFor
            }//outerFor

            List<Actor> actors = new List<Actor>();
            Random rand = new Random();

            for (int x = 0; x < flyNum; x++)
            {
                //unabe to randomize numbers within the class
                actors.Add(new Organisms.Fly(rand.Next(4), rand.Next(13)));
            }
            for (int x = 0; x < deadlyNum; x++)
            {
                //unabe to randomize numbers within the class
                actors.Add(new Organisms.DeadlyMimic(rand.Next(4), rand.Next(12)));
            }
            for (int x = 0; x < majesticNum; x++)
            {
                //unabe to randomize numbers within the class
                actors.Add(new Organisms.MajesticPlant(rand.Next(4), rand.Next(12)));
            }

            foreach (var acts in actors)
            {
                locationCheck(acts);
            }
        }//buttonClick

        public void locationCheck(Actor pic)
        {
            Random rand = new Random();
            //while the position is taken, randomize its position
            while (grid[pic.PositionX, pic.PositionY].BackColor != Color.Red)
            {
                pic.PositionX = rand.Next(4);
                pic.PositionY = rand.Next(13);
            }//while

            if (pic.GetType() == typeof(Organisms.MajesticPlant))
            {
                grid[pic.PositionX, pic.PositionY].BackColor = Color.Green;
            }
            else if (pic.GetType() == typeof(Organisms.DeadlyMimic))
            {
                grid[pic.PositionX, pic.PositionY].BackColor = Color.Purple;
            }
            else if (pic.GetType() == typeof(Organisms.Fly))
            {
                grid[pic.PositionX, pic.PositionY].BackColor = Color.Yellow;
            }


            //Console.WriteLine(typeof(Organisms.Fly));
        }//locationCheck
    }
}
