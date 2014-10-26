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
    public class Controls : Entity
    {
        bool _LeftSide;
        ControlsPosition _Layout;
        float _Break = 0.0f;
        bool _Pressed = false;

        public Controls(bool _LeftSide)
        {
            this._LeftSide = _LeftSide;
            _Layout = new ControlsPosition();
        }

        

        public override void LoadContent()
        {
            //_Sprite = Main.Instance.Content.Load<Texture2D>("UI/circle");
            //_Center = new Vector2(_Sprite.Width / 2, _Sprite.Height / 2);
            //if (_LeftSide)
            //    _Position = _Layout.Left();
            //else if (!_LeftSide)
            //    _Position = _Layout.Right();
        }

        public override void Update(GameTime gameTime)
        {
            float _TimeDelta = (float)gameTime.ElapsedGameTime.TotalSeconds;
            MouseState _MousePos = Mouse.GetState();


            if (_MousePos.LeftButton != ButtonState.Pressed)
                _Pressed = false;

            if ((_MousePos.LeftButton == ButtonState.Pressed) && (_Break > 0.3f) && (!_Pressed))
            {
                _Active = true;
                _Pressed = true;
                _Break = 0.0f;
            }
            _Break += _TimeDelta;
            //if (((_MousePos.LeftButton == ButtonState.Pressed) &&
            //    ((_MousePos.X > (_Position.X - (((_Sprite.Width / 2) * _Scale) - 25))) && (_MousePos.X < (_Position.X + (((_Sprite.Width / 2) * _Scale) - 25))) &&
            //    (_MousePos.Y > (_Position.Y - (((_Sprite.Height / 2) * _Scale) - 25))) && (_MousePos.Y < (_Position.Y + (((_Sprite.Height / 2) * _Scale) - 25)))))
            //    && (_Break > 0.3f) && (!_Pressed))
            //{
            //    _Active = true;
            //    _Pressed = true;
            //    _Break = 0.0f;
            //}
            //_Break += _TimeDelta;

            
            
        }

        public override void Draw(GameTime gameTime)
        {
            //Main.Instance.Spritebatch.Draw(_Sprite, _Position, null, Color.White, 0, _Center, 1, SpriteEffects.None, 0);
        }
    }
}
