using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace dodge;

public class Bullet {
    public Rectangle Rect;
    public float speed = 200.0f;
    public Vector2 velocity = new Vector2(0.0f, 0.0f);

    public Bullet(Rectangle rect)
    {
        Rect = rect;
    }

    public void Render(Game1 game)
    {
    }

    public void Update(Game1 game)
    {

    }
}
