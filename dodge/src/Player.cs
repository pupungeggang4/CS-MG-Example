using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace dodge;

public class Player {
    public float Speed {get; set;} = 320.0f;
    public Rect2F Rect {get; set;} = new Rect2F(400.0f, 300.0f, 80.0f, 80.0f);
    public Rectangle RenderRect = new Rectangle(0, 0, 0, 0);
    public Vector2 Velocity = new Vector2(0.0f, 0.0f);

    public void Update(Game1 game, GameTime dt)
    {
        KeyboardState keyboardState = Keyboard.GetState();
        if (keyboardState.IsKeyDown(Keys.Left))
        {
            Rect.Pos.X -= new Vector2(Speed * dt, 0.0f);
        }
    }

    public void Render(Game1 game, GameTime dt)
    {
        RenderRect = new Rectangle((int)(Rect.Pos.X - Rect.Size.X / 2.0f), (int)(Rect.Pos.Y - Rect.Size.Y / 2.0f), (int)Rect.Size.X, (int)Rect.Size.Y);
        game.SpriteBatch.Draw(game.Pixel, RenderRect, Color.Cyan);
    }
}
