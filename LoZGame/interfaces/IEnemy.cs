using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public interface IEnemy
{
    void takeDamage();
    void die();
    void Update();
    void Draw(SpriteBatch spriteBatch);
}
