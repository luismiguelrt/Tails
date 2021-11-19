/**
 * MotorBug.cs - Partial sonic clone
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
    class MotorBug : Enemy
    {
        private bool moveLeft = false;

        public MotorBug()
        {
            x = 360;
            y = 460;
            startX = 360;
            startY = 460;
            width = 32;
            height = 26;
            xSpeed = 2;
            ySpeed = 2;
            LoadSequence(RIGHT, new string[] {"data/MotorBugRight_01.png", 
                "data/MotorBugRight_02.png"});
            LoadSequence(LEFT, new string[] {"data/MotorBugLeft_01.png", 
                "data/MotorBugLeft_02.png"});
        }

        /// <summary>
        /// change direction to Right
        /// </summary>
        public void MoveRight()
        {
            ChangeDirection(RIGHT);
            x += xSpeed;
            Animate();
        }


        /// <summary>
        /// Change direction to Left
        /// </summary>
        public void MoveLeft()
        {
            ChangeDirection(LEFT);
            x -= xSpeed;
            Animate();
        }

        /// <summary>
        /// use for move the enemy a section of map
        /// </summary>
        public void MoveAnimation()
        {

            if (!moveLeft)
            {
                MoveRight();
                if (x >= 610)
                    moveLeft = true;
            }
            if (moveLeft)
            {
                MoveLeft();
                if (x <= 360)
                    moveLeft = false;
            }

        }
    }
}
