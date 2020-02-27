namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class SpikeCross : IEnemy
    {
        private EnemyCollisionHandler enemyCollisionHandler;
        private Rectangle bounds;

        public Rectangle Bounds
        {
            get { return this.bounds; }
            set { this.bounds = value; }
        }

        public LoZGame Game
        {
            get; set;
        }

        public Vector2 CurrentLocation
        {
            get; set;
        }
        public int VelocityX
        {
            get; set;
        }

        public int VelocityY
        {
            get; set;
        }

        public int AttackFactor
        {
            get; set;
        }

        public Boolean Attacking
        {
            get; set;
        }

        public Boolean Retreating
        {
            get; set;
        }

        private IEnemyState currentState;
        private int health = 10;
        private int lifeTime = 0;
        private Vector2 initialPos;
        private readonly int directionChange = 40;

        private enum direction
        {
            Up,
            Down,
            Left,
            Right,
            Idle
        };

        private direction currentDirection;


        public SpikeCross(Vector2 location)
        {
            this.Game = LoZGame.Instance;
            this.currentState = new IdleSpikeCrossState(this);
            this.CurrentLocation = new Vector2(location.X, location.Y);
            this.Bounds = new Rectangle((int)this.CurrentLocation.X, (int)this.CurrentLocation.Y, 25, 25);
            this.enemyCollisionHandler = new EnemyCollisionHandler(this);
            Attacking = false;
            Retreating = false;
            initialPos = location;
        }

        private void getNewDirection()
        {
            Random randomselect = new Random();
            this.currentDirection = (direction)randomselect.Next(0, 4);
        }

        private void updateLoc()
        {
            int spikeX = (int)CurrentLocation.X;
            int spikeY = (int)CurrentLocation.Y;
            int linkX = (int)Game.Link.CurrentLocation.X;
            int linkY = (int)Game.Link.CurrentLocation.Y;

            if (Attacking)
            {
                Console.WriteLine("made it 1");
                if (!Retreating)
                {
                    if (Math.Abs(CurrentLocation.X) + Math.Abs(CurrentLocation.Y) <= Math.Abs(initialPos.X) + Math.Abs(initialPos.Y) - 50)
                    {
                        Console.WriteLine("made it 2");
                        AttackFactor = -1;
                        Retreating = true;
                    }
                }
                else
                {
                    if (Math.Abs(CurrentLocation.X) + Math.Abs(CurrentLocation.Y) == Math.Abs(initialPos.X) + Math.Abs(initialPos.Y))
                    {
                        Attacking = false;
                        currentState.Stop();
                    }
                }
            }
            else
            {
                Console.WriteLine("made it 3");
                if (spikeX == linkX)
                {
                    Attacking = true;
                    AttackFactor = 3 * (linkY - spikeY) / Math.Abs(linkY - spikeY);
                    currentState.MoveDown();
                   /* if (spikeY < linkY)
                    {

                        currentState.MoveDown();
                    }
                    else
                    {
                        currentState.MoveUp();
                    } */
                }
                else if (spikeY == linkY)
                {
                    Attacking = true;
                    AttackFactor = 3 * (linkX - spikeX) / Math.Abs(linkX - spikeX);
                    currentState.MoveRight();
                  /*  if (spikeX < linkX)
                    {

                        currentState.MoveRight();
                    }
                    else
                    {
                        currentState.MoveLeft();
                    } */
                }
            }
            this.currentState.Update();
        }

        public void TakeDamage()
        {
        }

        public void Die()
        {
        }

        public void Update()
        {
            this.updateLoc();
            this.bounds.X = (int)this.CurrentLocation.X;
            this.bounds.Y = (int)this.CurrentLocation.Y;
        }

        public void Draw(SpriteBatch sb)
        {
            this.currentState.Draw(sb);
        }

        public void OnCollisionResponse(ICollider otherCollider)
        {
            if (otherCollider is IProjectile)
            {
                this.enemyCollisionHandler.OnCollisionResponse((IProjectile)otherCollider);
            }
        }

        public IEnemyState CurrentState
        {
            get { return this.currentState; }
            set { this.currentState = value; }
        }

        public int Health
        {
            get { return this.health; }
            set { this.health = value; }
        }
    }
}
