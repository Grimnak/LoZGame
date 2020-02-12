namespace LoZClone
{
    public class AttackState : IPlayerState
    {
        private LoZGame game;
        private Link player;
        private ISprite sprite;
        private bool isAttacking = false;
        private int lockoutTimer = 0;

        public AttackState(LoZGame game, IPlayer playerInstance)
        {
            this.game = game;
            this.player = (Link)playerInstance;
            isAttacking = true;
            lockoutTimer = 15; //attack frames * frame delay
            sprite = createCorrectSprite();
        }
        private ISprite createCorrectSprite()
        {
            if (player.CurrentDirection.Equals("Up"))
            {
                return LinkSpriteFactory.Instance.createSpriteLinkAttackUp(player.CurrentColor);
            }
            else if (player.CurrentDirection.Equals("Down"))
            {
                return LinkSpriteFactory.Instance.createSpriteLinkAttackDown(player.CurrentColor);
            }
            else if (player.CurrentDirection.Equals("Left"))
            {
                return LinkSpriteFactory.Instance.createSpriteLinkAttackLeft(player.CurrentColor);
            }
            else
            {
                return LinkSpriteFactory.Instance.createSpriteLinkAttackRight(player.CurrentColor);
            }
        }
        public void idle()
        {
            if (isAttacking)
            {
                lockoutTimer--;
            }
            else
            {
                player.State = new IdleState(game, player);
            }

            if (lockoutTimer <= 0)
            {
                isAttacking = false;
            }
        }
        public void moveUp()
        {
            if (isAttacking)
            {
                lockoutTimer--;
            }
            else
            {
                player.State = new MoveUpState(game, player);
            }

            if (lockoutTimer <= 0)
            {
                isAttacking = false;
            }
        }
        public void moveDown()
        {
            if (isAttacking)
            {
                lockoutTimer--;
            }
            else
            {
                player.State = new MoveDownState(game, player);
            }

            if (lockoutTimer <= 0)
            {
                isAttacking = false;
            }
        }
        public void moveLeft()
        {
            if (isAttacking)
            {
                lockoutTimer--;
            }
            else
            {
                player.State = new MoveLeftState(game, player);
            }

            if (lockoutTimer <= 0)
            {
                isAttacking = false;
            }
        }
        public void moveRight()
        {
            if (isAttacking)
            {
                lockoutTimer--;
            }
            else
            {
                player.State = new MoveRightState(game, player);
            }

            if (lockoutTimer <= 0)
            {
                isAttacking = false;
            }
        }
        public void attack()
        {
            if (isAttacking)
            {
                lockoutTimer--;
            }
            

            if (lockoutTimer <= 0)
            {
                isAttacking = false;
            }
        }
        public void Update()
        {
            sprite.Update();
        }
        public void Draw()
        {
            sprite.Draw(game.SpriteBatch, player.CurrentLocation, player.CurrentTint);
        }
    }
}
