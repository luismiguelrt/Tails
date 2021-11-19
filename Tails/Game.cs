/**
 * Game.cs - Partial sonic clone
 * 
 * Luis Miguel Rubio Toledo, 2015
 * 
 * Game class: game logic
 *
 * Changes:
 * 
 * 0.04, 22-05-2015: create class "Game"
 * 0.05  28-05-2015: show player and enemies
 * 0.06  02-05-2015: move with using the arrow keys left and right 
 * 0.07  03-05-2015: show 20 rings consecutives
 * 0.08  02-06-2015: check colision with rings
 * 0.09  02-06-2015: check colision with enemies
 * 0.11  04-06-2015: move rings with map
 * 0.15  05-06-2015: the rings have movement in game
 * 0.20  05-06-2015: the enemies have movement in game
 * 0.21  05-06-2015: Restart game correctly
 * 0.23  06-06-2015: check colision with sprites
 * 0.24  06-06-2015: create struct for CurrentScore and modify
 * 0.28  06-06-2015: implement sound
 * 0.29  06-06-2015: add life when take 10 rings correctly
 * 0.30  06-06-2015: clean and debug in collisions
 * 0.32  07-06-2015: display all screen background
 * 0.33  07-06-2015: show animals when enemy death
 */
using System;


namespace Tails
{
    struct CurrentScore
    {
        public string name;
        public int score;
        public int currenRings;
        
    }
    class Game
    {
        // --------------------------------------------
        // Attributes
        Sound startGame, extraLive, takeRing;
        
        const int MAXITEMS = 20;
        const int MAXANIMALS = 2;
        DateTime waitSecons;
        CurrentScore myScore;

        // int score;
        // int life;

        Font font18;
        Map myMap;

        Player player;
        CrabMeat crabMeat;
        MotorBug motorBug;
        Item[] ring;
        Animals[] animal;
        bool finished;

        int startRingX;
        int startRingY;
        bool getLife;


        // --------------------------------------------
        // Methods
        public Game()
        {
            
            startGame = new Sound("sound/green_hill_zone.mp3");
            extraLive = new Sound("sound/extra_life.mp3");
            takeRing = new Sound("sound/Ring_Sound_Effect.mp3");

            font18 = new Font("data/Joystix.ttf", 18);
            myMap = new Map();
            player = new Player();
            crabMeat = new CrabMeat();
            motorBug = new MotorBug();
            
            ring = new Item[MAXITEMS];
            startRingX = 150;
            startRingY = 400;

            myScore.currenRings = 0;
            myScore.score = 0;

            //score = 0;
            // life = 3;
            for (int i = 0; i < MAXITEMS; i++)
            {
                ring[i] = new Item();
                ring[i].MoveTo(startRingX, startRingY);

                startRingX += 40;
            }

            getLife = false;

            animal = new Animals[MAXANIMALS];
            animal[0] = new Animals();
            animal[1] = new Animals();
            animal[0].Hide();
            animal[1].Hide();
        }

        /// <summary>
        /// Display alls movements
        /// </summary>
        public void MoveElements()
        {

            for (int i = 0; i < MAXITEMS; i++)
            {
                ring[i].Animate();
                
            }
            crabMeat.Animate();
            motorBug.MoveAnimation();
            animal[0].Animate();
            animal[1].Animate();
            
        }

        public void RestartAll()
        {
            startRingX = 150;
            startRingY = 400;
            for (int i = 0; i < MAXITEMS; i++)
            {
                ring[i] = new Item();
                ring[i].MoveTo(startRingX, startRingY);

                startRingX += 40;
            }

            motorBug.Show();
            crabMeat.Show();
            motorBug.Restart();
            crabMeat.Restart();
            myMap.Restart();
            player.Restart();
        }

        /*
        public void StartEnemies()
        {
            
            crabMeat.MoveTo(200, 480);
            
            //crabMeat.LoadImage("data/CrabMeat.png");
            motorBug.LoadImage("data/MotorBug.png");
            
            motorBug.MoveTo(500, 400);

            //crabMeat.DrawOnHiddenScreen();
            motorBug.DrawOnHiddenScreen();
            
        }
         * */

        /// <summary>
        /// check input
        /// </summary>

        void CheckInput()
        {
            if ((Hardware.KeyPressed(Hardware.KEY_LEFT)))
            {
                if (player.GetX() > 0)
                    player.MoveLeft();
                if (myMap.GetX() < 0 && player.GetX() >= 0)
                {
                    //motorBug.MoveAllRight();
                    crabMeat.MoveAllRight();
                    myMap.MoveAllRight();
                    for (int i = 0; i < MAXITEMS; i++)
                    {
                        ring[i].MoveAllRight();
                    }
                }
                waitSecons = DateTime.Now; 
            }

            if ((Hardware.KeyPressed(Hardware.KEY_RIGHT)))
            {
                if (player.GetX() < 600 - player.GetHeight())
                    player.MoveRight();
                //motorBug.MoveAllLeft();
                crabMeat.MoveAllLeft();
                myMap.MoveAllLeft();
                for (int i = 0; i < MAXITEMS; i++)
                {
                    ring[i].MoveAllLeft();
                }
                waitSecons = DateTime.Now;

            }

            if (Hardware.KeyPressed(Hardware.KEY_SPC))
            {
                player.Jump();
                waitSecons = DateTime.Now;
            }

            // ESC to return to Intro
            if (Hardware.KeyPressed(Hardware.KEY_ESC))
                finished = true;

            if (DateTime.Now > waitSecons.AddSeconds(6))
            {
                waitSecons = DateTime.Now;
                player.Animate();
            }
            player.gravity();
            
        }

        /// <summary>
        /// show all Elements
        /// </summary>
        void DrawElements()
        {
            Hardware.ClearScreen();
            myMap.Draw();
            
            
            for (int i = 0; i < MAXITEMS; i++)
            {
                ring[i].DrawOnHiddenScreen();
            }

            motorBug.DrawOnHiddenScreen();
            crabMeat.DrawOnHiddenScreen();
            Hardware.WriteHiddenText("Score: " + myScore.score,
                60, 30,
                0xCC, 0xCC, 0xCC,
                font18);

            Hardware.WriteHiddenText("Rings: " + myScore.currenRings,
                300, 30,
                0xCC, 0xCC, 0xCC,
                font18);

            Hardware.WriteHiddenText("Lives: " + player.GetLives(),
                600, 30,
                0xCC, 0xCC, 0xCC,
                font18);

            animal[0].DrawOnHiddenScreen();
            animal[1].DrawOnHiddenScreen();
            player.DrawOnHiddenScreen();
            
            Hardware.ShowHiddenScreen();
            Hardware.Pause(10);
        }


        // collisions 
        void CheckCollisions(bool onMusic)
        {
            
            // collision for enemies
            if (player.CollisionsWith(motorBug) || player.CollisionsWith(crabMeat))
            {
                // direccions sprite 0 = RIGHT, 1 = LEFT, 2 = WAIT 
                for (int i = 0; i <= 2; i++)
                {
                    if (myScore.currenRings > 0)
                    {
                        myScore.currenRings = 0;
                        player.MoveTo(player.GetX() - player.GetWidth(), player.GetY());
                        player.Die();
                    }
                    else if (player.GetCurrentDirection() == i && myScore.currenRings == 0)
                    {
                        // life--;
                        player.Die();
                        player.LoseLive();
                        RestartAll();
                        if (player.GetLives() == 0)
                            finished = true;
                    }
                }
                // direccions sprite 3 = JUMP, 4 = CURLRIGTH, 5 = CURLLEFT 
                for (int i = 3; i <= 5; i++)
                {
                    if (player.GetCurrentDirection() == i && player.CollisionsWith(motorBug))
                    {
                        myScore.score += 1000;
                        animal[0].MoveTo(motorBug.GetX(), motorBug.GetY());
                        motorBug.Hide();
                        animal[0].Show();
                        
                    }
                    if (player.GetCurrentDirection() == i && player.CollisionsWith(crabMeat))
                    {
                        
                        myScore.score += 1000;
                        animal[1].MoveTo(crabMeat.GetX(), crabMeat.GetY());
                        crabMeat.Hide();
                        animal[1].Show();
                        
                    }
                    
                }
            }


            // when take 10 ring lvl up
            if (myScore.currenRings != 0)
            {

                if (myScore.currenRings % 10 == 0 && !getLife)
                {
                    if (onMusic)
                        extraLive.PlayOnce();
                    getLife = true;
                    player.WinLive();
                }
                if (myScore.currenRings % 2 == 1)
                    getLife = false;
            }

            //collision for items
            for (int i = 0; i < MAXITEMS; i++)
            {
                if (player.CollisionsWith(ring[i]))
                {
                    if (onMusic)
                        takeRing.PlayOnce();
                    myScore.score += 100;
                    myScore.currenRings++;
                    ring[i].Hide();
                    
                }
            }

        }

        /// <summary>
        /// Execute game
        /// </summary>
        public void Run(bool onMusic)
        {
            player.Restart();
            if (onMusic)
                startGame.PlayIntro();
            // Game Loop
            
            do
            {
                // Update screen
                //StartEnemies();
                MoveElements();
                DrawElements();
                
                CheckInput();
                CheckCollisions(onMusic);
                
            }
            while (!finished);

            // Wait for ESC to be released
            while (Hardware.KeyPressed(Hardware.KEY_ESC)) { }
        }
    }
}
