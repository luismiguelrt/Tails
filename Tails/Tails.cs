/**
 * Tails.cs - Partial sonic clone
 * 
 * Luis Miguel Rubio Toledo, 2015
 * 
 * Changes:
 * 0.01, 06-03-2015: Initial version, based on SdlMuncher 0.14
 * 0.02, 06-03-2015: Show Intro... 
 * 0.03, 27-03-2015:  create class Sprite and Player
 * 0.04, 22-05-2015: change class name "program" for "Tails"
 *                   reestruct the class Tails, only Main
 *                   

 */
using System;


namespace Tails
{
    class Tails
    {
        
        /// <summary>
        /// Execute game
        /// </summary>
        public static void Main()
        {
            bool onMusic = true;
            bool fullScreen = false;
            Hardware.Init(1024, 768, 24, fullScreen);

            Intro myIntro = new Intro();
            

            bool gameStatus = false;
            // Game Loop
            do
            {
                myIntro.Run(onMusic);

                if (myIntro.GameChosen)
                {
                    Game g = new Game();
                    g.Run(onMusic);
                }

                if (Hardware.KeyPressed(Hardware.KEY_ESC))
                    gameStatus = true;


            }
            while (!gameStatus);
        }
    }
}
