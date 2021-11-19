/**
 * Sprite.cs - A basic graphic element to inherit from
 * 
 * Luis Miguel Rubio Toledo, 2015
 * 
 * Changes:
 * 0.03  27-03-2015: create class Sprite
 * 0.05  28-05-2015: draw sprite
 * 0.08  02-05-2015: create methods of colision with other sprite
 * 0.14  04-06-2015: create methods for sequence Sprites
 */

namespace Tails
{
    class Sprite 
    {
        // --------------------------------------------
        // Attributes

        protected int x, y;
        protected int startX, startY;
        protected int width, height;
        protected int xSpeed, ySpeed;
        protected Image image;
        protected bool visible;
        protected Image[][] sequence;
        protected bool containsSequence;
        protected int currentFrame;

        protected byte numDirections = 10;
        protected byte currentDirection;
        public const byte RIGHT = 0;
        public const byte LEFT = 1;
        public const byte WAIT = 2;
        public const byte JUMP = 3;
        public const byte CURLRIGTH = 4;
        public const byte CURLLEFT = 5;
        public const byte DIE = 6;
        

        // --------------------------------------------
        // Methods

        /// <summary>
        /// constructor
        /// </summary>
        public Sprite()
        {

            visible = true;
            sequence = new Image[numDirections][];
            currentDirection = RIGHT;
        }

        /// <summary>
        /// add name image
        /// </summary>
        /// <param name="imageNames">images</param>
        public Sprite(string imageName, int newX, int newY)
        : this()
        {
            LoadImage(imageName);
            x = newX;
            y = newY;
        }

        

        /// <summary>
        /// Load images
        /// </summary>
        /// <param name="name">Image Name</param>
        public void LoadImage(string name)
        {
            image = new Image(name);
            containsSequence = false;
        }

        /// <summary>
        /// Load Sequence for change image when move
        /// </summary>
        /// <param name="direction">Direction acually</param>
        /// <param name="names">Image names</param>
        public void LoadSequence(byte direction, string[] names)
        {
            int amountOfFrames = names.Length;
            sequence[direction] = new Image[amountOfFrames];
            for (int i = 0; i < amountOfFrames; i++)
                sequence[direction][i] = new Image(names[i]);
            containsSequence = true;
            currentFrame = 0;
        }

        /// <summary>
        /// Load Sequence to change
        /// </summary>
        /// <param name="names">Image Name</param>
        public void LoadSequence(string[] names)
        {
            LoadSequence(RIGHT, names);
        }

        public int GetX()
        {
            return x;
        }

        public int GetY()
        {
            return y;
        }

        public int GetWidth()
        {
            return width;
        }

        public int GetHeight()
        {
            return height;
        }

        public int GetSpeedX()
        {
            return xSpeed;
        }

        public int GetSpeedY()
        {
            return ySpeed;
        }

        public bool IsVisible()
        {
            return visible;
        }

        /// <summary>
        /// Check if can move or no
        /// </summary>
        /// <param name="newX">New position X to draw</param>
        /// <param name="newY">New position Y to draw</param>
        public void MoveTo(int newX, int newY)
        {
            x = newX;
            y = newY;
            if (startX == -1)
            {
                startX = x;
                startY = y;
            }
        }

        /// <summary>
        /// modify Speed x and y
        /// </summary>
        /// <param name="newXSpeed">new speed X</param>
        /// <param name="newYSpeed">new speed Y</param>
        public void SetSpeed(int newXSpeed, int newYSpeed)
        {
            xSpeed = newXSpeed;
            ySpeed = newYSpeed;
        }

        /*
        public void SetStart(int startX, int startY)
        {
            this.startX = startX;
            this.startY = startY;
        }
        */

        /// <summary>
        /// Show elements
        /// </summary>
        public void Show()
        {
            visible = true;
        }

        /// <summary>
        /// Hide elements
        /// </summary>
        public void Hide()
        {
            visible = false;
        }

        /// <summary>
        /// Check colision
        /// </summary>
        /// <param name="otherSprite">The image to colision</param>
        /// <returns>return if have colision or no</returns>
        public bool CollisionsWith(Sprite otherSprite)
        {
            return (visible && otherSprite.IsVisible() &&
                CollisionsWith(otherSprite.GetX(),
                    otherSprite.GetY(),
                    otherSprite.GetX() + otherSprite.GetWidth(),
                    otherSprite.GetY() + otherSprite.GetHeight()));
        }

        /// <summary>
        /// Check colision
        /// </summary>
        /// <param name="xStart">Point to start X</param>
        /// <param name="yStart">Point to start Y</param>
        /// <param name="xEnd">Point to go X</param>
        /// <param name="yEnd">Point to go Y</param>
        /// <returns>return if have colision</returns>
        public bool CollisionsWith(int xStart, int yStart, int xEnd, int yEnd)
        {
            if (visible &&
                    (x < xEnd) &&
                    (x + width > xStart) &&
                    (y < yEnd) &&
                    (y + height > yStart)
                    )
                return true;
            return false;
        }

        /// <summary>
        /// Draw alls images in the screen
        /// </summary>
        public void DrawOnHiddenScreen()
        {
            if (!visible)
                return;

            if (containsSequence)
                Hardware.DrawHiddenImage(
                    sequence[currentDirection][currentFrame], x, y);
            else
                Hardware.DrawHiddenImage(image, x, y);
        }

        /// <summary>
        /// restart x and y
        /// </summary>
        public void Restart()
        {
            x = startX;
            y = startY;
        }


        /// <summary>
        /// move all in background
        /// </summary>
        public void MoveAllRight()
        {

            x += xSpeed;
        }

        public void MoveAllLeft()
        {

            x -= xSpeed;
        }
        public void MoveAllUp()
        {

            y += ySpeed;
        }

        public void MoveAlldown()
        {

            y -= ySpeed;
        }

        /// <summary>
        /// Change frames to draw
        /// </summary>
        public void NextFrame()
        {
            currentFrame++;
            if (currentFrame >= sequence[currentDirection].Length)
                currentFrame = 0;
        }

        /// <summary>
        /// Change direction
        /// </summary>
        /// <param name="newDirection">Neww direction to change</param>
        public void ChangeDirection(byte newDirection)
        {
            if (!containsSequence) return;
            if (currentDirection != newDirection)
            {
                currentDirection = newDirection;
                currentFrame = 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns> current Direction</returns>
        public byte GetCurrentDirection()
        {
            return currentDirection;
        }
        
        /// <summary>
        /// is virtual void for  
        /// </summary>
        public virtual void Animate()
        {

        }

    }
}
