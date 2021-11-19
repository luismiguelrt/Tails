/**
 * CreditsScreen.cs 
 * 
 * Luis Miguel Rubio Toledo, 2015
 * 
 * Changes:
 * 0.05  28-05-2015: create class CreditScreen 
 * 0.12  04-06-2015: show CreditScreen
 * 0.18  05-06-2015: create swich with 4 effects
 */
using System;
namespace Tails
{
    /// <summary>
    /// Class CreditsScreen
    /// Show screen of credits
    /// </summary>
    class CreditsScreen
    {
        private Font font18;
        Random rnd;
        private string programmer;
        short y;
        float redColour;     //float to
        float greenColour;   //increment
        float blueColour;    //colour by 0,5
        byte redColourEsc;
        byte greenColourEsc;

        public CreditsScreen()
        {
            rnd = new Random();
            font18 = new Font("data/Joystix.TTF", 25);
            programmer = "Luis Miguel Rubio Toledo";
            redColourEsc  = 255;
            greenColourEsc = 0;
            redColour = 0;
            greenColour = 0;
            blueColour = 0;
            y = 550;
        }


        /// <summary>
        /// Loop that show the name to programers
        /// </summary>
        public void Run()
        {
            
            int effect;
            effect = rnd.Next(0, 4);
            switch (effect)
            {
                case 0: Effect0(); break;
                case 1: Effect1(); break;
                case 2: Effect2(); break;
                case 3: Effect3(); break;
                case 4: Effect4(); break;
                //case 5: Effect5(); break;
            } 
            
            
        }

        /// <summary>
        /// first version
        /// </summary>
        public void Effect0()
        {
            do
            {

                //HEADER
                Hardware.ClearScreen();
                Hardware.WriteHiddenText("Credits - TAILS",
                    350, 100,
                    0x08, 0x6D, 0x08,
                    font18);

                //Name
                Hardware.WriteHiddenText(programmer,
                    150, 190,
                    0, 0, 250,
                    font18);

                //Draw "Hit Q Return" changing colour 
                Hardware.WriteHiddenText("Hit Q to return",
                    Convert.ToInt16(512 - "Hit Q to return".Length * 14 / 2), 600, //Center text(x,y)
                    redColourEsc, greenColourEsc, 0,
                    font18);
                Hardware.ShowHiddenScreen();
                Hardware.Pause(10);
                greenColourEsc += 5;
                redColourEsc -= 5;
            }
            while (!Hardware.KeyPressed(Hardware.KEY_Q));
        }

        //Effect1: moving up
        public void Effect1()
        {

            while ((y > 100) && (!Hardware.KeyPressed(Hardware.KEY_Q)))
            {

                Hardware.ClearScreen();
                //Draw moving up programmers
                Hardware.WriteHiddenText(programmer,
                    Convert.ToInt16(512 - programmer.Length * 14 / 2), y, //Center text(x,y)          
                    255, 255, 255,
                    font18);

                //Draw "Hit Q Return" changing colour 
                Hardware.WriteHiddenText("Hit Q to return",
                    Convert.ToInt16(512 - "Hit Q to return".Length * 14 / 2), 600, //Center text(x,y)
                    redColourEsc, greenColourEsc, 0,
                    font18);
                Hardware.ShowHiddenScreen();
                Hardware.Pause(10);
                greenColourEsc += 5;
                redColourEsc -= 5;
                y--; ;
            }
            
        }

        //Effect2: moving up + black&white
        public void Effect2()
        {
            
            while ((y > 100) && (!Hardware.KeyPressed(Hardware.KEY_Q)))
            {
                Hardware.ClearScreen();

                //Draw moving up programmers black&white
                Hardware.WriteHiddenText(programmer,
                    Convert.ToInt16(512 - programmer.Length * 14 / 2), y, //Center text(x,y)
                    (byte)redColour, (byte)greenColour, (byte)blueColour,
                    font18);
                redColour += 0.5F;
                greenColour += 0.5F;
                blueColour += 0.5F;

                //Draw "Hit Q Return" changing colour 
                Hardware.WriteHiddenText("Hit Q to return",
                    Convert.ToInt16(512 - "Hit Q to return".Length * 14 / 2), 600, //Center text(x,y)
                    redColourEsc, greenColourEsc, 0,
                    font18);
                Hardware.ShowHiddenScreen();
                Hardware.Pause(10);
                greenColourEsc += 5;
                redColourEsc -= 5;
                y--;
            }
            
        }

        //Effect3: moving down
        public void Effect3()
        {
            y = 100;

            do
            {
               
                Hardware.ClearScreen();
                //Draw moving up programmers blur
                Hardware.WriteHiddenText(programmer,
                    Convert.ToInt16(512 - programmer.Length * 20 / 2), y, //Center text(x,y)
                    255, 255, 255,
                    font18);

                //Draw "Hit Q Return" changing colour 
                Hardware.WriteHiddenText("Hit Q to return",
                    Convert.ToInt16(512 - "Hit Q to return".Length * 14 / 2), 600, //Center text(x,y)
                    redColourEsc, greenColourEsc, 0,
                    font18);
                Hardware.ShowHiddenScreen();
                Hardware.Pause(10);
                greenColourEsc += 5;
                redColourEsc -= 5;
                if(y < 550)
                    y++;
            } while (!Hardware.KeyPressed(Hardware.KEY_Q));
            
        }


        //Effect4: moving up + blue
        public void Effect4()
        {
            
            while ((y > 100) && (!Hardware.KeyPressed(Hardware.KEY_Q)))
            {
                Hardware.ClearScreen();
                //Draw moving up programmers blur black&white
                Hardware.WriteHiddenText(programmer,
                    Convert.ToInt16(512 - programmer.Length * 20 / 2), y, //Center text(x,y)
                    (byte)redColour, (byte)greenColour, (byte)blueColour,
                    font18);

                blueColour += 0.5F;

                //Draw "Hit Q Return" changing colour 
                Hardware.WriteHiddenText("Hit Q to return",
                    Convert.ToInt16(512 - "Hit Q to return".Length * 14 / 2), 600, //Center text(x,y)
                    redColourEsc, greenColourEsc, 0,
                    font18);
                Hardware.ShowHiddenScreen();
                Hardware.Pause(10);
                greenColourEsc += 5;
                redColourEsc -= 5;
                y--;
            }
            
        }
    }
}
