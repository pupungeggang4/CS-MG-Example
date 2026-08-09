using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace dodge;

public class Scene
{
    public Scene()
    {
    }

    public void Update(Game1 game)
    {
        if (game.GameOver)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                game.GameOver = false;
                game.Field.Reset();
            }
        }
        else
        {
            game.Field.Update(game);
        }
    }

    public void Render(Game1 game)
    {
        game.Field.Render(game);
        if (game.GameOver)
        {
            game.SpriteBatch.DrawString(game.Font, "Press Space to Restart.", new Vector2(20, 20), Color.White);
        }
    }
}
