/**
 * CrabMeat.cs - Partial sonic clone
 * 
 * Luis Miguel Rubio Toledo, 2015
 * 
 *
 * Changes:
 * 
 * 0.27  28-05-2015: create class "Motorbug"
 * 0.27  06-06-2015: inplement methods
 * 
 */
namespace Tails
{
    class CrabMeat : Enemy
    {
        public CrabMeat()
        {
            x = 980;
            y = 385;
            startX = 980;
            startY = 385;
            width = 46;
            height = 36;
            xSpeed = 2;
            ySpeed = 2;
            LoadSequence(RIGHT, new string[] {"data/CrabMeat_01.png", "data/CrabMeat_02.png",
                "data/CrabMeat_03.png", "data/CrabMeat_04.png", "data/CrabMeat_05.png"});
        }
    }
}
