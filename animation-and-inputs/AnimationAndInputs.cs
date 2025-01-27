﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace animation_and_inputs;

public class AnimationAndInputs : Game
{
    private const int _WindowWidth = 1280;
    private const int _WindowHeight = 720;
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D _background;
    private Texture2D  _logo;
     private Texture2D _coin1;
    private Texture2D _coin2;
    private CelAnimationSequence _coin1Anim;
    private CelAnimationSequence _coin2Anim;
    private CelAnimationPlayer _coin1Player;
    private CelAnimationPlayer _coin2Player;



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
        _coin2 = Content.Load<Texture2D>("coin2");
         _coin1Anim = new CelAnimationSequence(_coin1, 16, 0.1f); 
        _coin2Anim = new CelAnimationSequence(_coin2, 16, 0.1f);
        _coin1Player = new CelAnimationPlayer();
        _coin2Player = new CelAnimationPlayer();
        _coin1Player.Play(_coin1Anim);
        _coin2Player.Play(_coin2Anim);
    }



    protected override void Update(GameTime gameTime)
    {

        _coin1Player.Update(gameTime);
        _coin2Player.Update(gameTime);
  
        

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {

        _spriteBatch.Begin();
        _spriteBatch.Draw(_background, Vector2.Zero, Color.White);
_spriteBatch.Draw(_logo, new Vector2(120, 40), null, Color.White, 0f, Vector2.Zero, 0.2f, SpriteEffects.None, 0f);
// resized my image to be
// way less than its original size
// because otherwise it would be huge;

         _coin1Player.Draw(_spriteBatch, new Vector2(100, 100),  SpriteEffects.None);
        _coin2Player.Draw(_spriteBatch, new Vector2(200, 100),  SpriteEffects.None);
         _spriteBatch.End();

        base.Draw(gameTime);
    }
}
