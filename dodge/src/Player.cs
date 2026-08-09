using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace dodge;

public class Player
{
    public float Speed = 320.0f;
    public Rect2F Rect = new Rect2F(400.0f, 300.0f, 80.0f, 80.0f);
    public Rectangle RenderRect = new Rectangle(0, 0, 0, 0);
    public Vector2 Velocity = new Vector2(0.0f, 0.0f);

    public void Update(Game1 game)
    {
        KeyboardState keyboardState = Keyboard.GetState();
        if (keyboardState.IsKeyDown(Keys.Left))
        {
            Rect.Pos = new Vector2(Rect.Pos.X - Speed * game.Dt, Rect.Pos.Y);
        }
        if (keyboardState.IsKeyDown(Keys.Right))
        {
            Rect.Pos = new Vector2(Rect.Pos.X + Speed * game.Dt, Rect.Pos.Y);
        }
        if (keyboardState.IsKeyDown(Keys.Up))
        {
            Rect.Pos = new Vector2(Rect.Pos.X, Rect.Pos.Y - Speed * game.Dt);
        }
        if (keyboardState.IsKeyDown(Keys.Down))
        {
            Rect.Pos = new Vector2(Rect.Pos.X, Rect.Pos.Y + Speed * game.Dt);
        }
    }

    public void Render(Game1 game)
    {
        RenderRect = new Rectangle((int)(Rect.Pos.X - Rect.Size.X / 2.0f), (int)(Rect.Pos.Y - Rect.Size.Y / 2.0f), (int)Rect.Size.X, (int)Rect.Size.Y);
        game.SpriteBatch.Draw(game.Pixel, RenderRect, Color.Cyan);
    }
}
