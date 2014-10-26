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
    public class Startbutton : Entity
    {
        public Startbutton(int _X, int _Y)
        {
            this._X = _X;
            this._Y = _Y;
            _Scale = 1.5f;
        }

        public override void LoadContent()
        {
            _Sprite = Main.Instance.Content.Load<Texture2D>("Menus/Start");
            _Center = new Vector2(_Sprite.Width / 2, _Sprite.Height / 2);
            _Position = new Vector2((float)_X, (float)_Y);
        }

        public override void Update(GameTime gameTime)
        {
            MouseState _MousePos = Mouse.GetState();

            if ((_MousePos.LeftButton == ButtonState.Pressed) &&
                ((_MousePos.X > (_Position.X - (((_Sprite.Width / 2) * _Scale) - 25))) && (_MousePos.X < (_Position.X + (((_Sprite.Width / 2) * _Scale) - 25))) &&
                (_MousePos.Y > (_Position.Y - (((_Sprite.Height / 2) * _Scale) - 25))) && (_MousePos.Y < (_Position.Y + (((_Sprite.Height / 2) * _Scale) - 25)))))
            {
                _Active = true;
            }
        }

        public override void Draw(GameTime gameTime)
        {
            Main.Instance.Spritebatch.Draw(_Sprite, _Position, null, Color.White, 0, _Center, 1.0f, SpriteEffects.None, 0);
        }
    }
}
