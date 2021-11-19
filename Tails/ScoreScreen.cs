/**
 * ScoreScreen.cs 
 * 
 * Luis Miguel Rubio Toledo, 2015
 * 
 * Changes:
 * 0.05  28-05-2015: create class ScoreScreen 
 * 0.13  04-06-2015: show ScoreScreen
 * 0.31  06-06-2015: implement arraList and load file in class ScoreScreen
 */

using System;
using System.IO;
using System.Collections;

/// <summary>
/// Class ScoreScreen
/// Show Score
/// </summary>
namespace Tails
{
    class ScoreScreen
    {

        Font font18;
        StreamReader Reader;
        ArrayList scores;
        string line;

        public ScoreScreen()
        {
            
            font18 = new Font("data/Joystix.ttf", 18);
            scores = new ArrayList();
        }





        /// <summary>
        /// Draw Scrore in the screen
        /// Draw lives
        /// </summary>
        public void Run()
        {
            try
            {

                Reader = File.OpenText("data/Scores.txt");
                do
                {
                    line = Reader.ReadLine();
                    if (line != null)
                        scores.Add(line);
                } while (line != null);
                Reader.Close();
            }
            catch (Exception)
            {
            }
            scores.Sort();
            scores.Reverse();
            
            do
            {
                Hardware.ClearScreen();
                Hardware.WriteHiddenText("Score - TAILS",
                    350, 100,
                    0x08, 0x6D, 0x08,
                    font18);

                //Names
                short posY = 190;
                foreach (string punt in scores)
                {
                    Hardware.WriteHiddenText((string)punt, 370, posY, 0xCC, 0xCC, 0xCC, font18);
                    posY += 40;
                }

                Hardware.WriteHiddenText("Hit Q to return",
                    370, 640,
                    0x99, 0x99, 0x99,
                    font18);
                Hardware.ShowHiddenScreen();
                Hardware.Pause(50);
            }
            while (!Hardware.KeyPressed(Hardware.KEY_Q));
        }

    }
}
