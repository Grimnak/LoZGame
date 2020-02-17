namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class Link : IPlayer
    {
        private readonly LoZGame game;
        private IPlayerState playerState;

        public IPlayerState State
        {
            set { this.playerState = value; }
        }

        private string currentWeapon;

        public string CurrentWeapon
        {
            get { return this.currentWeapon; }
            set { this.currentWeapon = value; }
        }

        private string currentColor;

        public string CurrentColor
        {
            get { return this.currentColor; }
            set { this.currentColor = value; }
        }

        private string currentDirection;

        public string CurrentDirection
        {
            get { return this.currentDirection; }
            set { this.currentDirection = value; }
        }

        private Vector2 currentLocation;

        public Vector2 CurrentLocation
        {
            get { return this.currentLocation; }
            set { this.currentLocation = value; }
        }

        private Color currentTint;

        public Color CurrentTint
        {
            get { return this.currentTint; }
            set { this.currentTint = value; }
        }

        private int currentSpeed;

        public int CurrentSpeed
        {
            get { return this.currentSpeed; }
            set { this.currentSpeed = value; }
        }

        private int damageCounter;

        public int DamageCounter
        {
            get { return this.damageCounter; }
            set { this.damageCounter = value; }
        }

        private int damageTimer;

        public int DamageTimer
        {
            get { return this.damageTimer; }
            set { this.damageTimer = value; }
        }

        private bool isDead;

        public bool IsDead
        {
            get { return this.isDead; }
            set { this.isDead = value; }
        }

        public Link(LoZGame game)
        {
            this.game = game;
            this.currentColor = "Green";
            this.currentDirection = "Down";
            this.currentWeapon = "Wood";
            this.currentLocation = new Vector2(150, 200);
            this.currentTint = Color.White;
            this.currentSpeed = 2;
            this.damageTimer = 0;
            this.damageCounter = 0;
            this.isDead = false;

            this.playerState = new NullState(game, this);
        }

        private void handleDamage()
        {
            if (this.damageTimer > 0 && this.damageCounter < 3)
            {
                this.damageTimer--;
                if (this.damageTimer % 10 > 5)
                {
                    this.currentTint = Color.DarkSlateGray;
                }
                else
                {
                    this.currentTint = Color.White;
                }
            }
        }

        //This handleBounds method will not remain here past Sprint 2.  This is a form of "collision handling" just so Link will stay in bounds.
        private void handleBounds()
        {
            if (this.currentLocation.X + 30 > this.game.GraphicsDevice.Viewport.Width)
            {
                this.currentLocation.X = this.game.GraphicsDevice.Viewport.Width - 30;
            }
            else if (this.currentLocation.X < 0)
            {
                this.currentLocation.X = 0;
            }

            if (this.currentLocation.Y + 30 > this.game.GraphicsDevice.Viewport.Height)
            {
                this.currentLocation.Y = this.game.GraphicsDevice.Viewport.Height - 30;
            }
            else if (this.currentLocation.Y < 0)
            {
                this.currentLocation.Y = 0;
            }
        }

        public void idle()
        {
            this.playerState.idle();
        }

        public void moveUp()
        {
            this.playerState.moveUp();
        }

        public void moveDown()
        {
            this.playerState.moveDown();
        }

        public void moveLeft()
        {
            this.playerState.moveLeft();
        }

        public void moveRight()
        {
            this.playerState.moveRight();
        }

        public void takeDamage()
        {
            if (this.damageCounter >= 3)
            {
                this.playerState.die();
            }

            if (this.damageTimer <= 0)
            {
                this.damageCounter++;
                this.damageTimer = 100;
            }
        }

        public void attack()
        {
            this.playerState.attack();
        }

        public void pickupItem(int itemTime)
        {
            this.playerState.pickupItem(itemTime);
        }

        public void useItem(int waitTime)
        {
            this.playerState.useItem(waitTime);
        }

        public void Update()
        {
            this.handleDamage();
            this.handleBounds();

            this.playerState.Update();
        }

        public void Draw()
        {
            this.playerState.Draw();
        }
    }
}