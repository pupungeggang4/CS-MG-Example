using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace dodge;

public class Bullet
{
    public Rectangle RenderRect = new Rectangle(0, 0, 0, 0);
    public Rect2F Rect;
    public float Speed = 200.0f;
    public Vector2 Velocity = new Vector2(0.0f, 0.0f);

    public Bullet(float x, float y, float w, float h, float vx, float vy)
    {
        Rect = new Rect2F(x, y, w, h);
        Velocity = new Vector2(vx * Speed, vy * Speed);        
    }

    public void Update(Game1 game)
    {
        Rect.Pos = new Vector2(Rect.Pos.X + Velocity.X * game.Dt, Rect.Pos.Y + Velocity.Y * game.Dt);
    }

    public void Render(Game1 game)
    {
        RenderRect = new Rectangle((int)(Rect.Pos.X - Rect.Size.X / 2.0f), (int)(Rect.Pos.Y - Rect.Size.Y / 2.0f), (int)Rect.Size.X, (int)Rect.Size.Y);
        game.SpriteBatch.Draw(game.Pixel, RenderRect, Color.White);
    }
}
