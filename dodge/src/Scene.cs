using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace dodge;

public class Scene {
    public Scene()
    {
    }

    public void Update(Game1 game)
    {
        game.Field.Update(game);
    }

    public void Render(Game1 game)
    {
        game.Field.Render(game);
    }
}
