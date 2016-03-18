using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeeSolution.Models
{ 
    public enum BeeType
    {
        Queen,
        Worker,
        Drone
    }
    public enum BeeStatus
    {
        Alive,
        Dead
    }
    public class Bee
    {
        public BeeType beeType { get; set; }
        public int lifeSpan { get; set; }
        public BeeStatus status { get; set; }
        public Bee(BeeType beetype, int lifespan)
        {
            beeType = beetype;
            lifeSpan = lifespan;
            status = BeeStatus.Alive;
        }
    }
    public class Hive
    {
        public List<Bee> BeeHive { get; set; }
        public string HitMessage { get; set; }
        static Random rnd = new Random();
        public Hive()
        {
            CreateHive();
        }
        public void CreateHive()
        {
            BeeHive = new List<Bee>();
            // create queen
            Bee queen = new Bee(BeeType.Queen, 100);
            BeeHive.Add(queen);
            // create workers
            for (int i = 0; i < 5; i++)
            {
                Bee worker = new Bee(BeeType.Worker, 75);
                BeeHive.Add(worker);
            }
            // create drones
            for (int i = 0; i < 8; i++)
            {
                Bee drone = new Bee(BeeType.Drone, 50);
                BeeHive.Add(drone);
            }
            HitMessage = "Hive created!";
        }
        public List<Bee> HitBee()
        {
            if (!AllDead())
            {
                // select random bee
                int r = rnd.Next(BeeHive.Count);
                whackBee(r);
            }
            return BeeHive;
        }
        private bool AllDead()
        {
            bool result = true;
            HitMessage = "All bees dead!";
            foreach (Bee b in BeeHive)
            {
                if (b.status == BeeStatus.Alive)
                    result = false;
            }
            return result;
        }
        private void whackBee(int whichBee)
        {
            Bee hitBee = BeeHive[whichBee];
            if (hitBee.beeType == BeeType.Queen)
            {
                HitMessage = "Queen whacked!  ";
                BeeHive[whichBee].lifeSpan = BeeHive[whichBee].lifeSpan - 8;
                if (BeeHive[whichBee].lifeSpan < 1)
                {
                    BeeHive[whichBee].status = BeeStatus.Dead;
                    foreach (Bee b in BeeHive)
                    {
                        b.lifeSpan = 0;
                        b.status = BeeStatus.Dead;
                    }
                    HitMessage = "Queen dead - GAME OVER!";
                }
            }
            else if (hitBee.beeType == BeeType.Worker)
            {
                HitMessage = "Worker whacked!  ";
                BeeHive[whichBee].lifeSpan = BeeHive[whichBee].lifeSpan - 10;
                if (BeeHive[whichBee].lifeSpan < 1)
                {
                    BeeHive[whichBee].status = BeeStatus.Dead;
                    HitMessage = "Worker dead";
                }
            }
            else if (hitBee.beeType == BeeType.Drone)
            {
                HitMessage = "Drone whacked!  ";
                BeeHive[whichBee].lifeSpan = BeeHive[whichBee].lifeSpan - 12;
                if (BeeHive[whichBee].lifeSpan < 1)
                {
                    BeeHive[whichBee].status = BeeStatus.Dead;
                    HitMessage = "Drone dead";
                }
            }
            else
            {
                //error
                HitMessage = "Error!";
            }
        }
    }
}

