using Microsoft.Xna.Framework.Graphics;

public interface IEnemy
{
    void TakeDamage();

    void Die();

    void Update();

    void Draw(SpriteBatch spriteBatch);
}