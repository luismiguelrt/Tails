/**
 * Intro.cs 
 * 
 * Luis Miguel Rubio Toledo, 2015
 * 
 * Changes:
 * 0.01, 06-03-2015: Initial version
 * 0.04, 22-05-2015: Game can be quit (ESC) or start (SPC)
 * 0.17  05-06-2015: show menu with all cases
 */
using System;
using System.Threading;

namespace Tails
{
    class Intro
    {
        private Font font18;
        private Font font74;
        private Sprite backgroundTails;
        private Player waiting;
        private Sound intro;
        
        private bool finished;

        public bool GameChosen { get; set; }
        public bool ExitChosen { get; set; }

        /// <summary>
        /// constructor
        /// </summary>
        public Intro()
        {
            finished = false;
            font18 = new Font("data/Joystix.ttf", 24);
            font74 = new Font("data/Joystix.ttf", 74);
            backgroundTails = new Sprite("data/Tails.png", 450, 100);
            waiting = new Player();
            intro = new Sound("sound/title_screen.mp3");
            
        }

        public void Run(bool onMusic)
        {
            GameChosen = false;
            ExitChosen = false;
            finished = false;
            if (onMusic)
                intro.PlayIntro();
            do
            {
                
                ShowIntro();
                
                if (Hardware.KeyPressed(Hardware.KEY_SPC))
                {
                    
                    // And prepare to enter the game
                    GameChosen = true;
                    finished = true;
                }
                if (Hardware.KeyPressed(Hardware.KEY_S))
                {
                    ScoreScreen scoreScreen = new ScoreScreen();
                    scoreScreen.Run();
                }
                if (Hardware.KeyPressed(Hardware.KEY_C))
                {
                    CreditsScreen creditsScreen = new CreditsScreen();
                    creditsScreen.Run();
                }
                if (Hardware.KeyPressed(Hardware.KEY_H))
                {
                    HelpScreen helpScreen = new HelpScreen();
                    helpScreen.Run();
                }
                if (Hardware.KeyPressed(Hardware.KEY_ESC))
                {
                    ExitChosen = true;
                    finished = true;
                }
                
            }
            while (!finished);
            
        }

        /// <summary>
        /// display intro 
        /// </summary>
        public void ShowIntro()
        {
            Hardware.ClearScreen();
            waiting.Animate();
            waiting.DrawOnHiddenScreen();
            backgroundTails.DrawOnHiddenScreen();

            Hardware.WriteHiddenText("TAILS! ",
                    70, 100,
                0xCC, 0xCC, 0xCC,
                font74);

            Hardware.WriteHiddenText("Press SPACE to Start! ",
                    50, 400,
                0xCC, 0xCC, 0xCC,
                font18);

            Hardware.WriteHiddenText("Press S to Score! ",
                    50, 450,
                20, 0xCC, 0xCC,
                font18);

            Hardware.WriteHiddenText("Press C to Credits! ",
                    50, 500,
                0xCC, 0xCC, 20,
                font18);

            Hardware.WriteHiddenText("Press H to Help! ",
                    50, 550,
                0xCC, 20, 0xCC,
                font18);
            Hardware.Pause(90); // Not to use a 100% CPU for nothing
            Hardware.ShowHiddenScreen();
            
        }
    }
}
