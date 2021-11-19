/**
 * Animals.cs - Partial sonic clone
 * 
 * Luis Miguel Rubio Toledo, 2015
 * 
 * Changes:
 * 0.33 07-07-2015: create class Animals and show
 *                   

 */

using System;
namespace Tails
{
    class Animals : Sprite
    {
        DateTime dateNow;
        private Random rnd;
        private int choose;
        public Animals()
        {
            rnd = new Random();
            choose = rnd.Next(0, 3);

            xSpeed = 4;
            ySpeed = 4;
            LoadSequence(RIGHT, new string[] {"data/Dog_01.png", 
                "data/Dog_02.png"});
            LoadSequence(1, new string[] {"data/Pig_01.png", 
                "data/Pig_02.png"});
            LoadSequence(2, new string[] {"data/Rabbit_01.png", 
                "data/Rabbit_02.png"});
            LoadSequence(3, new string[] {"data/Squirrel_01.png", 
                "data/Squirrel_02.png"});
        }

        /// <summary>
        /// animation for animals
        /// </summary>
        public override void Animate()
        {
            
            switch(choose)
            {
                case 0:
                    ChangeDirection(0);
                    x += xSpeed;
                    TimeFrame();
                    break;
                case 1:
                    ChangeDirection(1);
                    x += xSpeed;
                    TimeFrame();
                    break;
                case 2:
                    ChangeDirection(2);
                    x += xSpeed;
                    TimeFrame();
                    break;
                case 3:
                    ChangeDirection(3);
                    x += xSpeed;
                    TimeFrame();
                    break;
            }
            
        }

        /// <summary>
        /// time for frame animals
        /// </summary>
        public void TimeFrame()
        {
            if (DateTime.Now > dateNow.AddMilliseconds(500))
            {
                NextFrame();
                dateNow = DateTime.Now;
            }
        }
    }
}
