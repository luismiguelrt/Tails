/**
 * Map.cs 
 * 
 * Luis Miguel Rubio Toledo, 2015
 * 
 * Changes:
 * 0.05  28-05-2015: create class Map
 * 0.10  04-06-2015: show map
 * 0.31, 07-06-2015: new parameters
 */

namespace Tails
{
    class Map : Sprite
    {
        // protected const int MAXBACKGROUNDS = 5;
        protected Image background;
        // protected Image [] back;
        //protected int x;
        //protected int y;

        public Map()
        {
            //back = new Image[MAXBACKGROUNDS];

            /*for (int i = 0; i < MAXBACKGROUNDS; i++)
            {
                back[i] = new Image("data/background.png");
            }*/

            background = new Image("data/background.png");
            x = 0;
            y= -150;
            startX = 0;
            startY= -150;
            xSpeed = 2;
            ySpeed = 2;
            height = 1024;
            width = 11264;
        }

        /// <summary>
        /// draw backgraund map
        /// </summary>
        public void Draw()
        {
            /*for (int i = 0; i < MAXBACKGROUNDS; i++)
            {
                Hardware.DrawHiddenImageBackground(back[i], x, y);
            }*/

            Hardware.DrawHiddenImageBackground(background, x, y, height, width);
            
        }

        

    }
}
