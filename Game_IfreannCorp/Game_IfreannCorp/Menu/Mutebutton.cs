
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


namespace Game_IfreannCorp.Menu
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Mutebutton : Entity
    {

        bool _Pressed;
        bool _Altered;
        
        public Mutebutton(int _X, int _Y)
        {
            this._X = _X;
            this._Y = _Y;
            //_Scale = 1.0f;
            _Active = false;
            _Altered = false;
        }

        public override void LoadContent()
        {
            if (!_Active)
                _Sprite = Main.Instance.Content.Load<Texture2D>("Menus/Mute");
            _Center = new Vector2(_Sprite.Width / 2, _Sprite.Height / 2);
            _Position = new Vector2((float)_X, (float)_Y);
        }

        public override void Update(GameTime gameTime)
        {

            if ((_Active) && (_Altered))
            {

                MediaPlayer.IsMuted = true;
                _Altered = false;
            }
            else if ((!_Active) && (_Altered))
            {
                MediaPlayer.IsMuted = false;

               

                _Altered = false;
            }



            MouseState _MousePos = Mouse.GetState();
            if (_MousePos.LeftButton != ButtonState.Pressed)
                _Pressed = false;
            
            if ((!_Pressed) && (_MousePos.LeftButton == ButtonState.Pressed) &&
                ((_MousePos.X > (_Position.X - (((_Sprite.Width / 2) * _Scale) - 25))) && (_MousePos.X < (_Position.X + (((_Sprite.Width / 2) * _Scale) - 25))) &&
                (_MousePos.Y > (_Position.Y - (((_Sprite.Height / 2) * _Scale) - 25))) && (_MousePos.Y < (_Position.Y + (((_Sprite.Height / 2) * _Scale) - 25)))))
            {
                _Active = !_Active;
                if (_Active)
                    _Sprite = Main.Instance.Content.Load<Texture2D>("Menus/UnMute");
                else
                    _Sprite = Main.Instance.Content.Load<Texture2D>("Menus/Mute");
                _Pressed = true;
                _Altered = true;
            }

        }

        public override void Draw(GameTime gameTime)
        {
            Main.Instance.Spritebatch.Draw(_Sprite, _Position, null, Color.White, 0, _Center, 1, SpriteEffects.None, 0);
        }
    }
}
