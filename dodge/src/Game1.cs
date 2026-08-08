using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace dodge;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    public SpriteBatch SpriteBatch => _spriteBatch;
    private SpriteBatch _spriteBatch;
    public RenderTarget2D RenderTarget => _renderTarget;
    private RenderTarget2D _renderTarget;
    public Texture2D Pixel => _pixel;
    private Texture2D _pixel;
    private Scene _scene;

    public int VirtualWidth {get; set;} = 800;
    public int VirtualHeight {get; set;} = 600;

    public Field Field {get; set;}

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        _graphics.PreferredBackBufferWidth = 1600;
        _graphics.PreferredBackBufferHeight = 1200;
        _graphics.ApplyChanges();
    }

    protected override void Initialize()
    {
        base.Initialize();
        _pixel = new Texture2D(GraphicsDevice, 1, 1);
        _pixel.SetData(new[] { Color.White });
        _scene = new Scene();

        Field = new Field();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _renderTarget = new RenderTarget2D(
            GraphicsDevice, VirtualWidth, VirtualHeight 
        );
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);
        GraphicsDevice.SetRenderTarget(_renderTarget);
        GraphicsDevice.Clear(Color.Black);

        Rectangle rect = new Rectangle(400, 300, 80, 80);

        _spriteBatch.Begin();
        _scene.Render(this, gameTime);
        _spriteBatch.End();

        // Main render part.
        GraphicsDevice.SetRenderTarget(null);
        GraphicsDevice.Clear(Color.Black);

        _spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Opaque, SamplerState.PointClamp);
        _spriteBatch.Draw(_renderTarget, GraphicsDevice.Viewport.Bounds, Color.White);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
