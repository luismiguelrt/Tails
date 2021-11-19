/**
 * Enemy.cs 
 * 
 * Luis Miguel Rubio Toledo, 2015
 * 
 * Changes:
 * 0.05  28-05-2015: create class Enemy 
 * 0.19  05-06-2015: create sprite animation
 * 0.20  05-06-2015: create method for movement
 */
using System;
namespace Tails
{
    /// <summary>
    /// Enemy class
    /// </summary>
    class Enemy : Sprite
    {
        protected DateTime dateNow;
        

        public Enemy()
        {

            dateNow = DateTime.Now;
        }

        /// <summary>
        /// use override for animate items
        /// </summary>
        public override void Animate()
        {
            if (DateTime.Now > dateNow.AddMilliseconds(500))
            {
                NextFrame();
                dateNow = DateTime.Now;
            }

        }

    }
}
