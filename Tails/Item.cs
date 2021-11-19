/**
 * Item.cs 
 * 
 * Luis Miguel Rubio Toledo, 2015
 * 
 * Changes:
 * 0.05  28-05-2015: create class Item 
 * 0.15  05-06-2015: create movement sprite animation to ring
 * 0.16  05-06-2015: control of time in movements of sprites
 */

using System;
namespace Tails
{

    class Item : Sprite
    {
        DateTime dateNow;
         public Item()
        {
            x = 200;
            y = 480;
            startX = 0;
            startY = 0;
            width = 16;
            height = 16;
            xSpeed = 2;
            ySpeed = 2;
            //LoadImage("data/Ring.png");
            LoadSequence(RIGHT, new string[] { "data/Ring_01.png", 
            "data/Ring_02.png", "data/Ring_03.png", "data/Ring_04.png" });
            
        }

        /// <summary>
        /// use override for animate items
        /// </summary>
         public override void Animate()
         {
             if (DateTime.Now > dateNow.AddMilliseconds(50))
             {
                 NextFrame();
                 dateNow = DateTime.Now;
             }
             
         }

    }
}
