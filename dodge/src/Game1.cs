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
    public SpriteFont Font => _font;
    private SpriteFont _font;
    private Scene _scene;

    public int VirtualWidth = 800;
    public int VirtualHeight = 600;

    public float Dt;
    public float DtRender;

    public Field Field;
    public bool GameOver = false;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        int monitorWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        int monitorHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
        int width, height;
        if (monitorWidth * 3 / 4 > monitorHeight)
        {
            height = (int)(monitorHeight * 0.8f);
            width = (int)(height * 4 / 3);
        }
        else
        {
            width = (int)(monitorWidth * 0.8f);
            height = (int)(width * 3 / 4);
        }
        _graphics.PreferredBackBufferWidth = width;
        _graphics.PreferredBackBufferHeight = height;
        _graphics.SynchronizeWithVerticalRetrace = true;
        _graphics.ApplyChanges();
    }

    protected override void Initialize()
    {
        base.Initialize();
        _pixel = new Texture2D(GraphicsDevice, 1, 1);
        _pixel.SetData(new[] { Color.White });
        _scene = new Scene();

        Field = new Field();
        Field.Reset();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _font = Content.Load<SpriteFont>("Font/Neodgm");
        _renderTarget = new RenderTarget2D(
            GraphicsDevice, VirtualWidth, VirtualHeight 
        );
    }

    protected override void Update(GameTime gameTime)
    {
        Dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        _scene.Update(this);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        DtRender = (float)gameTime.ElapsedGameTime.TotalSeconds;

        // Screen rendering
        GraphicsDevice.SetRenderTarget(_renderTarget);
        GraphicsDevice.Clear(Color.Black);

        //_spriteBatch.Begin();
        _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp);
        _scene.Render(this);
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
