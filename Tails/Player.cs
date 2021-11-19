/**
 * player.cs 
 * 
 * Luis Miguel Rubio Toledo, 2015
 * 
 * Changes:
 * 0.03  27-03-2015: create class player 
 * 0.14  04-06-2015: implement sequence sprites
 * 0.16  05-06-2015: control of time in movements of sprites
 * 0.21  05-06-2015: add lives and method for player
 * 0.22  05-06-2015: create gravity
 * 0.24  05-06-2015: add winLives method
 * 0.26  28-06-2015: create methods animation
 */

using System;
namespace Tails
{
    
    class Player : Sprite
    {
        protected DateTime dateNow;
        protected int lives;
        bool isJumping = false;
        public Player()
        {
            x = 100;
            y = 290;
            startX = 100;
            startY = 460;
            width = 46;
            height = 32;
            xSpeed = 3;
            ySpeed = 3;
            //LoadImage("data/BlackTails.png");
            lives = 3;

            LoadSequence(RIGHT, new string[] { "tailsSprite/TailsRight_01.png", 
            "tailsSprite/TailsRight_02.png", "tailsSprite/TailsRight_03.png", 
            "tailsSprite/TailsRight_04.png",  });
            LoadSequence(LEFT, new string[] { "tailsSprite/TailsLeft_01.png", 
            "tailsSprite/TailsLeft_02.png", "tailsSprite/TailsLeft_03.png", 
            "tailsSprite/TailsLeft_04.png" });
            LoadSequence(WAIT, new string[] { "tailsSprite/TailsWait_01.png", 
            "tailsSprite/TailsWait_02.png", "tailsSprite/TailsWait_03.png", "tailsSprite/TailsWait_04.png", 
            "tailsSprite/TailsWait_05.png", "tailsSprite/TailsWait_06.png" });
            LoadSequence(CURLLEFT, new string[] { "tailsSprite/TailsCurlLeft_01.png", 
            "tailsSprite/TailsCurlLeft_02.png", "tailsSprite/TailsCurlLeft_03.png", 
            "tailsSprite/TailsCurlLeft_04.png"});
            LoadSequence(CURLRIGTH, new string[] { "tailsSprite/TailsCurlsRight_01.png", 
            "tailsSprite/TailsCurlsRight_02.png", "tailsSprite/TailsCurlsRight_03.png", 
            "tailsSprite/TailsCurlsRight_04.png"});
            LoadSequence(DIE, new string[] { "tailsSprite/TailsDie_01.png", 
            "tailsSprite/TailsDie_02.png", "tailsSprite/TailsDie_03.png"});
            LoadSequence(JUMP, new string[] { "tailsSprite/TailsJump_01.png", 
            "tailsSprite/TailsJump_02.png", "tailsSprite/TailsJump_03.png", 
            "tailsSprite/TailsJump_04.png"});
             
        }
        

        /// <summary>
        /// Change direction to Rigth
        /// </summary>
        public void MoveRight()
        {
            ChangeDirection(RIGHT);
            x += xSpeed;
            NextFrame();
                            
        }

        /// <summary>
        /// Change direction to Left
        /// </summary>
        public void MoveLeft()
        {
            ChangeDirection(LEFT);
            x -= xSpeed;
            NextFrame();
        }

        /// <summary>
        /// simule jump To do
        /// </summary>
        public void Jump()
        {
            isJumping = true;
            if (y > 380 - GetHeight())
            {
                ChangeDirection(JUMP);
                y -= ySpeed;
                NextFrame();
            }
                
        }

        /// <summary>
        /// the player go down
        /// </summary>
        public void fall()
        {
            ChangeDirection(JUMP);
            y += ySpeed;
            NextFrame();
        }

        /// <summary>
        /// simule gravity
        /// </summary>
        public void gravity()
        {

            if (y < 460 && !isJumping)
            {
                fall();
            }
            if (y < 460)
                isJumping = false;
                
        }

        /// <summary>
        /// active animate
        /// </summary>
        public override void Animate()
        {
            
            ChangeDirection(WAIT);

            if (DateTime.Now > dateNow.AddMilliseconds(50))
            {
                NextFrame();
                dateNow = DateTime.Now;
            }
            
        }

        /// <summary>
        /// get live
        /// </summary>
        /// <returns> get Live</returns>
        public int GetLives()
        {
            return lives;
        }


        /// <summary>
        /// When colision with enemies lost one live
        /// </summary>
        /// <returns>count of lives</returns>
        public int LoseLive()
        {
            return lives--;
        }

        /// <summary>
        /// When colision with ring win one live
        /// </summary>
        /// <returns>count of lives</returns>
        public int WinLive()
        {
            return lives++;
        }

        /// <summary>
        /// simule gravity
        /// </summary>
        public void Die()
        {
            ChangeDirection(DIE);
            NextFrame();
            
        }

        /// <summary>
        /// animation move solo Right
        /// </summary>
        public void AnimateRight()
        {
            MoveRight();
            if (x > 500)
                x = 350;
        }

        /// <summary>
        /// animation move solo Left
        /// </summary>
        public void AnimateLeft()
        {

            MoveLeft();
            if (x < 350)
                x = 500;
        }

        /// <summary>
        /// animation move solo up
        /// </summary>
        public void AnimateJump()
        {
            Jump();
            if (y < 400)
                y = 500;
        }

    }
}
