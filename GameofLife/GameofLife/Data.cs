using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Organisms;

namespace GameofLife
{
    class Data
    {
        
        
        List<Fly> fly = new List<Fly>();
        List<MajesticPlant> plants = new List<MajesticPlant>();
        List<DeadlyMimic> deadly = new List<DeadlyMimic>();

        Random rand = new Random();

        public List<MajesticPlant> Plants
        {
            get { return plants; }
        }
        public List<Fly> Fly
        {
            get { return fly; }
        }
        public List<DeadlyMimic> Deadly
        {
            get { return deadly; }
        }

        public Data()
        {
            
        }//constructor

        public void FillList(int flyNum, int deadlyNum, int majesticNum, int gridSizeX, int gridSizeY)
        {
            for (int x = 0; x < flyNum; x++)
            {
                fly.Add(new Organisms.Fly(rand.Next(gridSizeX), rand.Next(gridSizeY)));
            }
            for (int x = 0; x < deadlyNum; x++)
            {
                deadly.Add(new Organisms.DeadlyMimic(rand.Next(gridSizeX), rand.Next(gridSizeY)));
            }
            for (int x = 0; x < majesticNum; x++)
            {
                plants.Add(new Organisms.MajesticPlant(rand.Next(gridSizeX), rand.Next(gridSizeY)));
            }
        }//FillList
        

        public void AddPlant(MajesticPlant child, int gridSizeX, int gridSizeY)
        {   
            //if table is full do not allow new organisms
            if (Plants.Count + Deadly.Count + Fly.Count < gridSizeX * gridSizeY)
            {
                child.PositionX = rand.Next(gridSizeX);
                child.PositionY = rand.Next(gridSizeY);
                plants.Add(child);
            }
            
        }//AddActor

    }
}
