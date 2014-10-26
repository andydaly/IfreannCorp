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
using Microsoft.Xna.Framework.Input.Touch;


namespace Game_IfreannCorp
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Intro : Entity
    {
        Texture2D _Background;
        Rectangle _ScreenRectangle;
        float _Break = 0.0f;
        Texture2D _Sprite3;
        bool _Mode = false;
        string _Display2, _Display3;
        bool _Next1, _Next2;

        public Intro(string _Display)
        {
            _Sprite = Main.Instance.Content.Load<Texture2D>(_Display);
            _Active = true;
        }

        public Intro(string _Display1, string _Display2, string _Display3)
        {
            _Sprite = Main.Instance.Content.Load<Texture2D>(_Display1);
            this._Display2 = _Display2;
            this._Display3 = _Display3;
            _Active = true;
            _Mode = true;
            _Next1 = false;
            _Next2 = false;
        }

        public override void LoadContent()
        {
            _Background = Main.Instance.Content.Load<Texture2D>("Introduction/planetart");
            _ScreenRectangle = new Rectangle(0, 0, _Width, _Height);

            
            
            _Center = new Vector2(_Sprite.Width / 2, _Sprite.Height / 2);
            _Position = new Vector2(_Width/2, _Height/2);
        }

        public override void Update(GameTime gameTime)
        {
            float _TimeDelta = (float)gameTime.ElapsedGameTime.TotalSeconds;
            TouchCollection _Touches = TouchPanel.GetState();
            if (!_Mode)
            {
                foreach (TouchLocation _Touch in _Touches)
                {

                    if ((_Touch.State == TouchLocationState.Pressed) && (_Break > 3.0f))
                    {
                        _Active = false;
                        _Break = 0.0f;
                    }
                }

                _Break += _TimeDelta;
            }
            else
            {
                foreach (TouchLocation _Touch in _Touches)
                {

                    if ((_Touch.State == TouchLocationState.Pressed) && (_Break > 1.0f))
                    {
                        if (_Next2)
                        {
                            _Active = false;
                        }
                        if ((!_Next2) && (_Next1))
                        {
                            _Sprite = Main.Instance.Content.Load<Texture2D>(_Display3);
                            _Next2 = true;
                        }
                        if (!_Next1)
                        {
                            _Sprite = Main.Instance.Content.Load<Texture2D>(_Display2);
                            _Next1 = true;
                        }
                        
                        
                        _Break = 0.0f;
                    }
                }

                _Break += _TimeDelta;
            }
        }

        public override void Draw(GameTime gameTime)
        {
            Main.Instance.Spritebatch.Draw(_Background, _ScreenRectangle, Color.White);
            Main.Instance.Spritebatch.Draw(_Sprite, _Position, null, Color.White, 0 - MathHelper.PiOver2, _Center, 1.0f, SpriteEffects.None, 0);

        }
    }
}
