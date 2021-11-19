/**
 * HelpScreen.cs 
 * 
 * Luis Miguel Rubio Toledo, 2015
 * 
 * Changes:
 * 0.05  28-05-2015: create class HelpScreen 
 * 0.25  28-06-2015: create menu and method HowPlaying
 * 0.26  28-06-2015: create animation
 */

namespace Tails
{
    /// <summary>
    /// Class HelpScreen
    /// Show how play with animations
    /// </summary>
    class HelpScreen
    {
        private Font font20;
        private Font explain;
        private Image left;
        private Image right;
        
        Player Left;
        Player Right;
        Player Jump;


        public HelpScreen()
        {
            font20 = new Font("data/Joystix.TTF", 20);
            explain = new Font("data/Joystix.ttf", 15);
            left = new Image("data/arrow_left.png");
            right = new Image("data/arrow_right.png");
            Left = new Player();
            Right = new Player();
            Jump = new Player();

        }


        /// <summary>
        /// Loop to show help to play when press ESC return
        /// </summary>
        public void Run()
        {

            do
            {
                //HEADER
                Hardware.ClearScreen();
                Hardware.WriteHiddenText("HELP - TAILS",
                    350, 100,
                    0x08, 0x6D, 0x08,
                    font20);

                Hardware.WriteHiddenText("Hit option number",
                    330, 150,
                    0x99, 0x99, 0x99,
                    font20);

                //Option 1
                Hardware.WriteHiddenText("1: Move arround map ",
                    320, 300,
                    0, 144, 250,
                    font20);

                //Option 2
                Hardware.WriteHiddenText("2: How Playing? ",
                    350, 350,
                    0, 144, 250,
                    font20);

                Hardware.WriteHiddenText("Hit Q to return",
                    370, 640,
                    0x99, 0x99, 0x99,
                    font20);
                Hardware.ShowHiddenScreen();
                Hardware.Pause(50);

                if (Hardware.KeyPressed(Hardware.KEY_1))
                    Animatios();
                if (Hardware.KeyPressed(Hardware.KEY_2))
                    HowPlaying();
            }
            while (!Hardware.KeyPressed(Hardware.KEY_Q));
        }


        /// <summary>
        /// Move Arround the map
        /// </summary>
        public void Animatios()
        {

            Right.MoveTo(350, 185);
            Jump.MoveTo(650, 500);
            Left.MoveTo(500, 250);

            do
            {
                //HEADER
                Hardware.ClearScreen();
                Hardware.WriteHiddenText("HELP - TAILS - Move arround map",
                    250, 100,
                    0x08, 0x6D, 0x08,
                    font20);

                //Arrow right
                Hardware.WriteHiddenText("Press key ",
                    150, 190,
                    0, 144, 250,
                    font20);
                Hardware.DrawHiddenImage(right, 290, 170);

                Right.DrawOnHiddenScreen();
                Right.AnimateRight();

                //Arrow Left
                Hardware.WriteHiddenText("Press key ",
                    150, 260,
                    0, 144, 250,
                    font20);
                Hardware.DrawHiddenImage(left, 290, 240);

                Left.DrawOnHiddenScreen();
                Left.AnimateLeft();

                //Arrow Jump
                Hardware.WriteHiddenText("When Press key SPACE ",
                    500, 330,
                    0, 144, 250,
                    font20);


                Jump.DrawOnHiddenScreen();
                Jump.AnimateJump();

                Hardware.WriteHiddenText("Hit ESC to return",
                    370, 640,
                    0x99, 0x99, 0x99,
                    font20);
                Hardware.ShowHiddenScreen();
                Hardware.Pause(50);

                
            } while (!Hardware.KeyPressed(Hardware.KEY_ESC));
        }


        /// <summary>
        /// Explain about playing game
        /// </summary>
        public void HowPlaying()
        {
            do
            {
                //HEADER
                Hardware.ClearScreen();
                Hardware.WriteHiddenText("HELP - TAILS - How Playing?",
                    250, 100,
                    0x08, 0x6D, 0x08,
                    font20);

                // Text of information
                Hardware.WriteHiddenText("The player will use to Tails for the purpose of complete this level.",
                    130, 220,
                    255, 0, 0,
                    explain);
                Hardware.WriteHiddenText("Tails can move to left, to right, jump, he can do a curl to kill ",
                    130, 250,
                    255, 0, 0,
                    explain);
                Hardware.WriteHiddenText("the enemies or can to slide. He can run and take items (rings). ",
                    130, 280,
                    255, 0, 0,
                    explain);
                Hardware.WriteHiddenText("If Tails has any ring and hit him then he lost all rings.",
                    130, 310,
                    255, 0, 0,
                    explain);
                Hardware.WriteHiddenText("If take 100 ring before hit him then, he will create a life, ",
                    130, 340,
                    255, 0, 0,
                    explain);
                Hardware.WriteHiddenText("if he has not any ring then he lost a life, and he will start",
                    130, 370,
                    255, 0, 0,
                    explain);

                Hardware.WriteHiddenText("a new this level. Tails start the game with 3 lifes.",
                    130, 400,
                    255, 0, 0,
                    explain);
                Hardware.WriteHiddenText("If lives of Tails are 0 then finish the party. ",
                    130, 430,
                    255, 0, 0,
                    explain);

                Hardware.WriteHiddenText("Hit ESC to return",
                    370, 640,
                    0x99, 0x99, 0x99,
                    font20);
                Hardware.ShowHiddenScreen();
                Hardware.Pause(50);

            } while (!Hardware.KeyPressed(Hardware.KEY_ESC));
        }
    }

}
