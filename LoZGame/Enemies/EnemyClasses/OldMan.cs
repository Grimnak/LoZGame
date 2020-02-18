namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class OldMan : IEnemy
    {
        public Vector2 CurrentLocation;
        private readonly OldManSprite sprite;

        public OldMan()
        {
            this.CurrentLocation = new Vector2(650, 200);
            this.sprite = EnemySpriteFactory.Instance.CreateOldManSprite();
        }

        public void TakeDamage()
        {
            //
        }

        public void Die()
        {
            //
        }

        public void Update()
        {
            this.sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            this.sprite.Draw(sb, this.CurrentLocation, Color.White);
        }
    }
}