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
using Microsoft.Devices.Sensors;


namespace Game_IfreannCorp
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Player : Entity
    {
        float _Accel = 0.0f;
        float _Speed = 0.0f;
        public float _Rotation = 0 - MathHelper.PiOver2;
        int _Counter = 1;
        
        public Vector2 _Direction;

        public Player()
        {
            _Health = 100;
            _Active = true;
        }

        public override void LoadContent()
        {
            Main.Instance._Motion.ReadingChanged += new EventHandler<AccelerometerReadingEventArgs>(AccelerometerReadingChanged);
            
            _Sprite = Main.Instance.Content.Load<Texture2D>("Player/spaceTankAnim1");
            _Position = new Vector2(_Width - 45, _Height / 2);
            _Center = new Vector2(_Sprite.Width / 2, _Sprite.Height / 2);
        }

        public void GameUpdate(GameTime gameTime, bool _Ambush)
        {
            _Direction = new Vector2((float)Math.Sin(_Rotation), -(float)Math.Cos(_Rotation));

            float _TimeDelta = (float)gameTime.ElapsedGameTime.TotalSeconds;
            _Speed = 700.0f * _TimeDelta;

            if (_Counter < 6)
                _Counter++;
            else
                _Counter = 1;

            _Sprite = Main.Instance.Content.Load<Texture2D>("Player/spaceTankAnim" + _Counter.ToString());


            if (!_Ambush)
            {
                _Rotation = 0 - MathHelper.PiOver2;
                _Position.X = _Width - 45;
                if (Main.Instance._Working == true)
                {
                    _Position.Y -= (_Accel * _Speed);

                    if (_Position.Y < 0)
                    {
                        _Position.Y = 0;
                        _Accel = 0;
                    }
                    else if (_Position.Y > _Height)
                    {
                        _Position.Y = _Height;
                        _Accel = 0;
                    }
                }
            }
            if (_Ambush)
            {
                _Sprite = Main.Instance.Content.Load<Texture2D>("Player/spaceTank");
                _Position = new Vector2(_Width / 2, _Height - 40);
            }



            if (_Health <= 0)
            {
                _Active = false;
                _Health = 0;
            }
        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw(GameTime gameTime)
        {
            Main.Instance.Spritebatch.Draw(_Sprite, _Position, null, Color.White, _Rotation, _Center, 1.0f, SpriteEffects.None, 0);
        }

        public void AccelerometerReadingChanged(object sender, AccelerometerReadingEventArgs e)
        {
            _Accel = (float)e.X;
            //_Accel.X = (float)e.X;
            //_Accel.Y = (float)e.Y;
            //_Accel.Z = (float)e.Z;
        }
    }
}
