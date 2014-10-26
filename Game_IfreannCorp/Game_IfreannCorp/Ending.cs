using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace Game_IfreannCorp
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Ending : Entity
    {
        Song _Song;
        int _Score;
        float _Break = 0.0f;
        Rectangle _ScreenRectangle;
        int _Image = 0;
        SpriteFont _ScoreDetails;

        public Ending(int _Score)
        {
            this._Score = _Score;

        }

        public override void LoadContent()
        {

            _Song = Main.Instance.Content.Load<Song>("creditsm");
            MediaPlayer.Play(_Song);
            MediaPlayer.IsRepeating = true;

            _ScoreDetails = Main.Instance.Content.Load<SpriteFont>("ArtWork/CreditsScore");
            _Sprite =  Main.Instance.Content.Load<Texture2D>("ArtWork/planetart");
            _ScreenRectangle = new Rectangle(0, 0, _Width, _Height);
            _Sprite2 = Main.Instance.Content.Load<Texture2D>("ArtWork/credits");
            _Position = new Vector2((_Width /2)+215, _Height / 2);
            _Center = new Vector2(_Sprite2.Width / 2, _Sprite2.Height / 2);
            _Position2 = new Vector2(20, _Height - 20); 
        }

        public override void Update(GameTime gameTime)
        {

            float _TimeDelta = (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (_Break > 10.0f)
            {
                if (_Image < 2)
                    _Image++;
                else
                    _Image = 0;

                if (_Image == 0)
                    _Sprite = Main.Instance.Content.Load<Texture2D>("ArtWork/planetart");
                else if (_Image == 1)
                    _Sprite = Main.Instance.Content.Load<Texture2D>("ArtWork/space1art");
                else if (_Image == 2)
                    _Sprite = Main.Instance.Content.Load<Texture2D>("ArtWork/space2art");
                
                _Break = 0.0f;
            }

            _Break += _TimeDelta;

        }

        public override void Draw(GameTime gameTime)
        {
            Main.Instance.Spritebatch.Draw(_Sprite, _ScreenRectangle, Color.White);
            Main.Instance.Spritebatch.Draw(_Sprite2, _Position, null, Color.White, 0, _Center, 1.0f, SpriteEffects.None, 0);
            Main.Instance.Spritebatch.DrawString(_ScoreDetails, "Total Score: " + _Score.ToString(), _Position2, Color.Red, 0 - MathHelper.PiOver2, new Vector2(0, 0), 1.0f, SpriteEffects.None, 1);
        }
    }
}
