using System.Drawing;
using Organisms;

namespace GameofLife
{
    class GameLogic
    {
        bool autoRun;
        DataStructure Data;
        ///************************************************* Properties *******************************************
        public DataStructure DataArr
        {
            get { return Data; }
        }
        public bool AutoRun
        {
            get { return autoRun; }
            set { autoRun = value; }
        }

        ///************************************************* Methods *******************************************
        public GameLogic()
        {
        }//constructor

        public void LoadGameLogic(DataStructure D)
        {
            Data = D;
        }

        ///************************************************* Reset Organism Count *******************************************
        public void ResetOrganismCount()
        {
            //reset all the counts to 0
            DataArr.FlyCount = 0;
            DataArr.MajesticCount = 0;
            DataArr.DeadlyCount = 0;
            //delete every thing in the fly List
            DataArr.Flies.Clear();
        }

        ///************************************************* Update Grid *******************************************
        public Image UpdateGrid(int x, int y, int gridSizeX, int gridSizeY)
        {
            Image ret = null;

            if (DataArr.Actors[x, y] != null)
            {
                //decrement life
                if (DataArr.Actors[x, y].Name != "MajesticPlant")
                {
                    DataArr.Actors[x, y].Life--;
                }
                if (DataArr.Actors[x, y].Life < 0)
                {
                    //if organism is dead remove it from the 2D object array
                    DataArr.Actors[x, y] = null;
                    System.GC.Collect();
                    return null;
                }
                //perform the grow action
                DataArr.Actors[x, y].Grow();

                if (DataArr.Actors[x, y].Name == "MajesticPlant")
                {
                    if (DataArr.Actors[x, y].Size < 1)
                    {
                        ret = GameofLife.Properties.Resources.MajesticPlant1;
                    }
                    else if (DataArr.Actors[x, y].Size < 2)
                    {
                        ret = GameofLife.Properties.Resources.MajesticPlant2;
                    }
                    else
                    {
                        ret = GameofLife.Properties.Resources.MajesticPlant3;
                    }
                    //static count
                    DataArr.MajesticCount = DataArr.Actors[x, y].Count;
                }
                if (DataArr.Actors[x, y].Name == "DeadlyMimic")
                {
                    if (DataArr.Actors[x, y].Size < 1)
                    {
                        ret = GameofLife.Properties.Resources.DeadlyMimic1;
                    }
                    else if (DataArr.Actors[x, y].Size < 2)
                    {
                        ret = GameofLife.Properties.Resources.DeadlyMimic2;
                    }
                    else
                    {
                        ret = GameofLife.Properties.Resources.DeadlyMimic3;
                    }
                    //static count

                    DataArr.DeadlyCount = DataArr.Actors[x, y].Count;
                }
                if (DataArr.Actors[x, y].Name == "Fly")
                {
                    ret = GameofLife.Properties.Resources.Fly1;
                    //add each fly back into the fly List
                    DataArr.Flies.Add(DataArr.Actors[x, y]);
                    //static count

                    DataArr.FlyCount = DataArr.Actors[x, y].Count;
                }
            }//if
            else
            {
                //in position is null, set ret to null
                ret = null;
            }
            System.GC.Collect();
            //return what ever ret is
            return ret;
        }

        ///************************************************* Move Flies *******************************************
        public void MoveFlies(int gridSizeX, int gridSizeY)
        {
            int originalX = 0;
            int originalY = 0;
            int newPosX;
            int newPosY;
            //only goes through the list of flies
            for (int x = 0; x < Data.Flies.Count; x++)
            {
                //delete the fly from the 2D array
                Data.Actors[Data.Flies[x].PositionX % gridSizeX, Data.Flies[x].PositionY % gridSizeY] = null;
                //store original values to use incase there is a colision that isnt with a deadly mimic
                originalX = Data.Flies[x].PositionX % gridSizeX;
                originalY = Data.Flies[x].PositionY % gridSizeY;
                //add random number to the object's positions by calling Move()
                Data.Flies[x].Move();
                //new position mod the grid sizes so that it will wrap around
                newPosX = Data.Flies[x].PositionX % gridSizeX;
                newPosY = Data.Flies[x].PositionY % gridSizeY;

                //if actor position is null skip
                if (Data.Actors[newPosX, newPosY] != null)
                {
                    //if the fly collided with a majestic fly, keep original position
                    if (Data.Actors[newPosX, newPosY].Name == "MajesticPlant")
                    {
                        Data.Flies[x].Eat();
                        //create a new plant object
                        Data.AddPlant(((MajesticPlant)Data.Actors[newPosX, newPosY]).Pollinate(), gridSizeX, gridSizeY);
                        //fly eats some of the plant then goes back to its original position
                        Data.Flies[x].PositionX = originalX;
                        Data.Flies[x].PositionY = originalY;
                        Data.Actors[originalX, originalY] = Data.Flies[x];
                    }
                    //if the fly collided with a Deadly Mimic, delete the fly
                    else if (Data.Actors[newPosX, newPosY].Name == "DeadlyMimic")
                    {

                        //increase the life of deadly mimic
                        Data.Actors[newPosX, newPosY].Eat();
                        Data.Flies[x] = null;
                    }
                    else if (Data.Actors[newPosX, newPosY].Name == "Fly")
                    {
                        //fly says hello then goes back to its original position
                        Data.Flies[x].PositionX = originalX;
                        Data.Flies[x].PositionY = originalY;
                        Data.Actors[originalX, originalY] = Data.Flies[x];
                    }
                }//outerIf
                else
                {
                    Data.Actors[newPosX, newPosY] = Data.Flies[x];
                }
            }//for
            //remove all the null items from the fly list
            Data.Flies.RemoveAll(item => item == null);
            System.GC.Collect();
        }//Move
        }
    }//Class Data
