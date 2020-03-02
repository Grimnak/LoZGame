namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class SpikeCross : IEnemy
    {
        private EnemyCollisionHandler enemyCollisionHandler;
        private Rectangle bounds;
        private LoZGame Game;

        public Rectangle Bounds
        {
            get { return this.bounds; }
            set { this.bounds = value; }
        }

        public Physics Physics { get; set; }

        public int VelocityX
        {
            get; set;
        }

        public int VelocityY
        {
            get; set;
        }

        public int Health { get { return health; } set { health = value; } }
        
        public int AttackFactor
        {
            get; set;
        }

        public bool Attacking
        {
            get; set;
        }

        public bool Retreating
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
            this.Physics = new Physics(new Vector2(location.X, location.Y), new Vector2(0, 0), new Vector2(0, 0));
            this.currentState = new LeftMovingSpikeCrossState(this);
            this.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, 25, 25);
            this.Game = LoZGame.Instance;
            this.currentState = new IdleSpikeCrossState(this);
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
            int spikeX = (int)Physics.Location.X;
            int spikeY = (int)Physics.Location.Y;
            int linkX = (int)Game.Link.Physics.Location.X;
            int linkY = (int)Game.Link.Physics.Location.Y;

          /*  if (Attacking)
            {
                if (!Retreating)
                {
                    if (Math.Abs(Physics.Location.X) + Math.Abs(Physics.Location.Y) <= Math.Abs(initialPos.X) + Math.Abs(initialPos.Y) - 50)
                    {
                        AttackFactor = -1;
                        Retreating = true;
                    }
                }
                else
                {
                    if (Math.Abs(Physics.Location.X) + Math.Abs(Physics.Location.Y) == Math.Abs(initialPos.X) + Math.Abs(initialPos.Y))
                    {
                        Attacking = false;
                        currentState.Stop();
                    }
                } 

            }
            else
            { */
            if (!Attacking)
            {
                if (spikeX == linkX)
                {
                    Attacking = true;
                    AttackFactor = 3 * (linkY - spikeY) / Math.Abs(linkY - spikeY);
                    currentState.MoveDown();
                }
                else if (spikeY == linkY)
                {
                    Attacking = true;
                    AttackFactor = 3 * (linkX - spikeX) / Math.Abs(linkX - spikeX);
                    currentState.MoveRight();
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
            this.bounds.X = (int)this.Physics.Location.X;
            this.bounds.Y = (int)this.Physics.Location.Y;

        }

        public void Draw()
        {
            this.currentState.Draw();
        }

        public void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            if (otherCollider is IPlayer)
            {
                this.enemyCollisionHandler.OnCollisionResponse((IPlayer)otherCollider, collisionSide);
            }
            else if (otherCollider is IBlock)
            {
                this.enemyCollisionHandler.OnCollisionResponse((IBlock)otherCollider, collisionSide);
            }
            else if (otherCollider is IProjectile)
            {
                this.enemyCollisionHandler.OnCollisionResponse((IProjectile)otherCollider, collisionSide);
            }
        }

        public IEnemyState CurrentState
        {
            get { return this.currentState; }
            set { this.currentState = value; }
        }
    }
}
