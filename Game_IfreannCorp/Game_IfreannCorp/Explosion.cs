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
    public class Explosion : Entity
    {
        struct Animation
        {
            public int Width, Height, Rows, Columns;
            public Texture2D Image;
            public Rectangle Frame;
        }
        int _FrameWidth = 0;
        int _FrameHeight = 0;
        Animation _Animate;
        int _CurrentFrameX = 0;
        int _CurrentFrameY = 0;
        float _Break = 0.0f;
        float _SpriteScale = 0.0f;
        float _Time = 0.0f;


        public Explosion(Vector2 _Pos, int _FWidth, int _FHeight, int _FRows, int _FColumns, string _SpriteSheet, float _SpriteScale, float _Time)
        {
            _Position = _Pos;
            _Animate.Width = _FWidth;
            _Animate.Height = _FHeight;
            _Animate.Rows = _FRows;
            _Animate.Columns = _FColumns;
            _Animate.Image = Main.Instance.Content.Load<Texture2D>(_SpriteSheet);
            this._SpriteScale = _SpriteScale;
            this._Time = _Time;
            _Active = true;
        }

        public override void LoadContent()
        {
            

            
            
            _Center = new Vector2(_Animate.Width / 2, _Animate.Height / 2);

            _Break = _Time;
        }

        public override void Update(GameTime gameTime)
        {
            float _TimeDelta = (float)gameTime.ElapsedGameTime.TotalSeconds;
            
            

            if (_Break > _Time)
            {
                if (_CurrentFrameY < _Animate.Rows)
                {
                    if (_CurrentFrameX < _Animate.Columns)
                    {
                        _Animate.Frame = new Rectangle(_FrameWidth, _FrameHeight, _Animate.Width, _Animate.Height);
                        _FrameWidth += _Animate.Width;
                        _CurrentFrameX++;
                    }
                    else
                    {
                        _CurrentFrameX = 0;
                        _FrameWidth = 0;
                        _FrameHeight += _Animate.Height;
                        _CurrentFrameY++;
                    }
                }
                else
                {
                    _Active = false;
                }
                _Break = 0.0f;
            }


            _Break += _TimeDelta;

        }

        public override void Draw(GameTime gameTime)
        {
            Main.Instance.Spritebatch.Draw(_Animate.Image, _Position, _Animate.Frame, Color.White, 0f, _Center, _SpriteScale, SpriteEffects.None, 0);
        }
    }
}
