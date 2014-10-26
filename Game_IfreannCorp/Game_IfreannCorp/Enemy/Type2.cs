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


namespace Game_IfreannCorp.Enemy
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Type2 : Entity
    {
        float _Rotation = 0.0f;
        bool _Ambush;
        Vector2 _PlayerCo;
        int _Mode = 0;
        float _Target = 0.0f;
        int _Num;
        int _Counter = 1;


        public Type2(bool _Ambush, Vector2 _PlayerCo)
        {
            _Health = 100;
            _Active = true;
            this._Ambush = _Ambush;
            this._PlayerCo = _PlayerCo;
            _Comet = false;
        }

        public override void LoadContent()
        {
            _Random = new Random();
            _Num = _Random.Next(1, 5);
            _Sprite = Main.Instance.Content.Load<Texture2D>("Generic/alien" + _Num.ToString() + "p1");
            _Center = new Vector2(_Sprite.Width / 2, _Sprite.Height / 2);

            _Mode = _Random.Next(1, 3);
            _Target = _PlayerCo.Y;

            if (!_Ambush)
            {
                _Position.X = (0 - (_Sprite.Width / 2));
                _Position.Y = _Random.Next(0, _Height);
            }
            if (_Ambush)
            {
                int _Num2 = _Random.Next(1, 6);
                if (_Num2 == 1)
                {
                    _Position.X = (0 - (_Sprite.Width / 2));
                    _Position.Y = _Random.Next(0, _Height - 50);
                    _Rotation = 0 - MathHelper.PiOver2;
                }
                else if (_Num2 == 2)
                {
                    _Position.X = (_Width + (_Sprite.Width / 2));
                    _Position.Y = _Random.Next(0, _Height - 50);
                    _Rotation = 0 + MathHelper.PiOver2;
                }
                else
                {
                    _Position.X = _Random.Next(0, _Width);
                    _Position.Y = (0 - (_Sprite.Height / 2));
                }

            }
        }

        public override void Update(GameTime gameTime)
        {
            float _TimeDelta = (float)gameTime.ElapsedGameTime.TotalSeconds;
            float _Speed = 100.0f;

            if ((_Num == 2) || (_Num == 4))
            {
                if (_Counter < 4)
                    _Counter++;
                else
                    _Counter = 1;
            }
            else
            {
                if (_Counter < 2)
                    _Counter++;
                else
                    _Counter = 1;
            }
            _Sprite = Main.Instance.Content.Load<Texture2D>("Generic/alien" + _Num.ToString() + "p" + _Counter.ToString());


            if (!_Ambush)
            {
                _Rotation = 0 - MathHelper.PiOver2;

                if (_Mode == 1)
                {
                    _Position.X += _Speed * _TimeDelta;
                }
                else if (_Mode == 2)
                {
                    _Position.X += _Speed * _TimeDelta;
                    if (_Position.Y > _Target)
                        _Position.Y -= (_Speed/2) * _TimeDelta;

                    if (_Position.Y < _Target)
                        _Position.Y += (_Speed/2) * _TimeDelta;
                }

                if (_Position.X > (Main.Instance.Width + _Sprite.Width))
                {
                    _Active = false;
                }
            }

            if (_Ambush)
            {
                if (_Position.X > _PlayerCo.X)
                    _Position.X -= _Speed * _TimeDelta;

                if (_Position.X < _PlayerCo.X)
                    _Position.X += _Speed * _TimeDelta;

                if (_Position.Y > _PlayerCo.Y)
                    _Position.Y -= _Speed * _TimeDelta;

                if (_Position.Y < _PlayerCo.Y)
                    _Position.Y += _Speed * _TimeDelta;
            }




            if (_Health < 0)
            {
                _Active = false;
            }

        }

        public override void Draw(GameTime gameTime)
        {
            Main.Instance.Spritebatch.Draw(_Sprite, _Position, null, Color.White, _Rotation, _Center, 1, SpriteEffects.None, 1);
        }
    }
}
