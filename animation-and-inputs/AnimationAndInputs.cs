using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace animation_and_inputs;

public class AnimationAndInputs : Game
{
    private const int _WindowWidth = 445;
    private const int _WindowHeight = 250;
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D _background;
    private Texture2D  _logo;
     private Texture2D _coin1;

    private CelAnimationSequence _coin1Anim;

    private CelAnimationPlayer _coin1Player;

    private Texture2D _egg;
    private CelAnimationSequence _eggAnim;
    private CelAnimationPlayer _eggPlayer;

        private Texture2D _monster;
    private Vector2 _monsterPosition;
    private CelAnimationSequence _monsterAnim;
    private CelAnimationPlayer _monsterPlayer;



    public AnimationAndInputs()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        _graphics.PreferredBackBufferWidth = _WindowWidth;
        _graphics.PreferredBackBufferHeight = _WindowHeight;
        _graphics.ApplyChanges();

        base.Initialize();

    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _background = Content.Load<Texture2D>("background");
        _logo = Content.Load<Texture2D>("logo");

        _coin1 = Content.Load<Texture2D>("coin");

         _coin1Anim = new CelAnimationSequence(_coin1, 16, 0.1f); 
        _coin1Player = new CelAnimationPlayer();
        _coin1Player.Play(_coin1Anim);

        _egg = Content.Load<Texture2D>("egg");
        _eggAnim = new CelAnimationSequence(_egg, 16,0.1f);
        _eggPlayer = new CelAnimationPlayer();
        _eggPlayer.Play(_eggAnim);

        _monster = Content.Load<Texture2D>("monster");
        _monsterAnim = new CelAnimationSequence(_monster, 32, 0.1f);
        _monsterPlayer = new CelAnimationPlayer();
        _monsterPlayer.Play(_monsterAnim);


    }



    protected override void Update(GameTime gameTime)
    {

         KeyboardState kbCurrentState = Keyboard.GetState();


 if (kbCurrentState.IsKeyDown(Keys.Down) || kbCurrentState.IsKeyDown(Keys.S))
        {
            _monsterPosition.Y += 5; 
        }
        if (kbCurrentState.IsKeyDown(Keys.Right) || kbCurrentState.IsKeyDown(Keys.D))
        {
            _monsterPosition.X += 5; 
        }
        if (kbCurrentState.IsKeyDown(Keys.Left) || kbCurrentState.IsKeyDown(Keys.A))
        {
            _monsterPosition.X -= 5; 
            
        }
        if (kbCurrentState.IsKeyDown(Keys.Up) || kbCurrentState.IsKeyDown(Keys.W))
        {
            _monsterPosition.Y -= 5; 
        }
        _monsterPlayer.Update(gameTime);
        _coin1Player.Update(gameTime);
    _eggPlayer.Update(gameTime);


  
        

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {

        _spriteBatch.Begin();
        _spriteBatch.Draw(_background, Vector2.Zero, Color.White);
_spriteBatch.Draw(_logo, new Vector2(40, 40), null, Color.White, 0f, Vector2.Zero, 0.1f, SpriteEffects.None, 0f);
// resized my image to be
// way less than its original size
// because otherwise it would be huge;
// im aware some of the properties are useless but like
// it literally breaks if i remove one so dont judge me
// im crashing out


         _coin1Player.Draw(_spriteBatch, new Vector2(170, 100),  SpriteEffects.None);
          _eggPlayer.Draw(_spriteBatch, new Vector2(190, 100),  SpriteEffects.None);
           _monsterPlayer.Draw(_spriteBatch, _monsterPosition, SpriteEffects.None);

         _spriteBatch.End();

        base.Draw(gameTime);
    }
}
