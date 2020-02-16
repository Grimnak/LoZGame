using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public interface IEnemy
{
    void moveLeft();
    void moveRight();
    void moveUp();
    void moveDown();
    void attack();
    void takeDamage();
    void die();
    void Update();
    void Draw(SpriteBatch spriteBatch);
}
