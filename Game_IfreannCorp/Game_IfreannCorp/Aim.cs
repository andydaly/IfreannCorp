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
    public class Aim : Entity
    {
        public float _PlayerRotate = 0.0f;
        float _Break = 0.0f;

        public Aim()
        {
            // TODO: Construct any child components here
        }

        public override void LoadContent()
        {

        }

        public void GameUpdate(GameTime gameTime, Vector2 _PlayerCo)
        {
            float _TimeDelta = (float)gameTime.ElapsedGameTime.TotalSeconds;
            MouseState _MousePos = Mouse.GetState();


            TouchCollection _Touches = TouchPanel.GetState();
            foreach (TouchLocation _Touch in _Touches)
            {

                if ((_Touch.State == TouchLocationState.Pressed) && (_Break > 0.3f))
                {
                    _Active = true;
                    _PlayerRotate = ((float)Math.Atan2(_Touch.Position.Y - _PlayerCo.Y, _Touch.Position.X - _PlayerCo.X) + MathHelper.PiOver2);
                    _Break = 0.0f;
                }
            }
            _Break += _TimeDelta;
        }

        public override void Update(GameTime gameTime)
        {
        }

        public override void Draw(GameTime gameTime)
        {

        }
    }
}
