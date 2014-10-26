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
    public class Type5 : Entity
    {
        int _Num1;
        int _Num2;
        float _Break = 0.0f;
        Vector2 _VDirection;
        float _Rotation = 0.0f;
        bool _Ambush;
        Vector2 _PlayerCo;
        int _Mode = 0;
        float _Target = 0.0f;
        bool _Direction;
        int _StayArea;
        int _Counter = 1;

        public Type5(bool _Ambush, Vector2 _PlayerCo)
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
            _Num1 = _Random.Next(1, 4);
            _Sprite = Main.Instance.Content.Load<Texture2D>("IfreannAlt/spacetank" + _Num1.ToString() + "p1");//"Ifreann/betrayers1p1");
            _Center = new Vector2(_Sprite.Width / 2, _Sprite.Height / 2);




            if (!_Ambush)
            {
                _Mode = _Random.Next(1, 4);
                _Target = _PlayerCo.Y;


                int _DirStart = _Random.Next(1, 3);
                if (_DirStart == 1)
                    _Direction = true;
                else
                    _Direction = false;


                _StayArea = _Random.Next(50, 300);

                _Position.X = (0 - (_Sprite.Width / 2));
                _Position.Y = _Random.Next(0, _Height);
            }
            if (_Ambush)
            {
                _Mode = _Random.Next(1, 3);
                _Num2 = _Random.Next(1, 6);
                if (_Num2 == 1)
                {
                    _StayArea = _Random.Next(20, 70);


                    _Position.X = (0 - (_Sprite.Width / 2));
                    _Position.Y = _Random.Next(0, _Height - 50);
                    _Rotation = 0 - MathHelper.PiOver2;
                }
                else if (_Num2 == 2)
                {
                    _StayArea = _Random.Next(_Width - 70, _Width - 20);

                    _Position.X = (_Width + (_Sprite.Width / 2));
                    _Position.Y = _Random.Next(0, _Height - 50);
                    _Rotation = 0 + MathHelper.PiOver2;
                }
                else
                {
                    _StayArea = _Random.Next(20, 60);
                    _Position.X = _Random.Next(0, _Width);
                    _Position.Y = (0 - (_Sprite.Height / 2));
                }

            }
        }

        public override void Update(GameTime gameTime)
        {
            float _TimeDelta = (float)gameTime.ElapsedGameTime.TotalSeconds;
            float _Speed = 100.0f;

            if (_Num1 == 3)
            {
                if (_Counter < 5)
                    _Counter++;
                else
                    _Counter = 1;
            }
            else
            {
                if (_Counter < 6)
                    _Counter++;
                else
                    _Counter = 1;
            }

            _Sprite = Main.Instance.Content.Load<Texture2D>("IfreannAlt/spacetank" + _Num1.ToString() + "p" + _Counter.ToString());

            if (!_Ambush)
            {
                _VDirection = new Vector2(-(float)Math.Sin(_Rotation), (float)Math.Cos(_Rotation));
                _Rotation = 0 - MathHelper.PiOver2;
                if (_Mode == 1)
                {
                    _Position.X += (_Speed / 2) * _TimeDelta;
                    if (_Direction == true)
                        _Position.Y += (_Speed / 2) * _TimeDelta;
                    else if (_Direction == false)
                        _Position.Y -= (_Speed / 2) * _TimeDelta;

                    if (_Position.Y >= _Height - (_Sprite.Height / 2))
                        _Direction = false;
                    else if (_Position.Y <= 0 + (_Sprite.Height / 2))
                        _Direction = true;


                    if ((_Position.Y > _Target-5) && (_Position.Y < _Target+5) && (_Break > 0.6f))
                    {
                        Projectile _Bullet = new Projectile(_Position, _VDirection, 3);
                        _Bullet.LoadContent();
                        Main.Instance._EnProjectiles.Add(_Bullet);
                        _Break = 0.0f;
                    }
                    _Break += _TimeDelta;

                }
                else if (_Mode == 2)
                {
                    if (_Position.X < _StayArea)
                        _Position.X += _Speed * _TimeDelta;
                    if (_Position.Y > _Target)
                        _Position.Y -= (_Speed / 2) * _TimeDelta;

                    if (_Position.Y < _Target)
                        _Position.Y += (_Speed / 2) * _TimeDelta;


                    if ((_Position.Y > _Target - 5) && (_Position.Y < _Target + 5) && (_Break > 0.8f))
                    {
                        Projectile _Bullet = new Projectile(_Position, _VDirection, 3);
                        _Bullet.LoadContent();
                        Main.Instance._EnProjectiles.Add(_Bullet);
                        _Break = 0.0f;
                    }
                    else if (_Break > 1.5f)
                    {
                        Projectile _Bullet = new Projectile(_Position, _VDirection, 3);
                        _Bullet.LoadContent();
                        Main.Instance._EnProjectiles.Add(_Bullet);
                        _Break = 0.0f;
                    }
                    _Break += _TimeDelta;
                }
                else if (_Mode == 3)
                {
                    if (_Position.X < _StayArea)
                        _Position.X += _Speed * _TimeDelta;

                    if ((_Position.Y > _Target - 5) && (_Position.Y < _Target + 5) && (_Break > 0.6f))
                    {
                        Projectile _Bullet = new Projectile(_Position, _VDirection, 3);
                        _Bullet.LoadContent();
                        Main.Instance._EnProjectiles.Add(_Bullet);
                        _Break = 0.0f;
                    }
                    else if (_Break > 1.5f)
                    {
                        Projectile _Bullet = new Projectile(_Position, _VDirection, 3);
                        _Bullet.LoadContent();
                        Main.Instance._EnProjectiles.Add(_Bullet);
                        _Break = 0.0f;
                    }
                    _Break += _TimeDelta;
                }


                if (_Position.X > (Main.Instance.Width + _Sprite.Width))
                {
                    _Active = false;
                }
            }

            if (_Ambush)
            {
                if (_Mode == 1)
                {
                    if (_Position.X > _PlayerCo.X)
                        _Position.X -= _Speed * _TimeDelta;

                    if (_Position.X < _PlayerCo.X)
                        _Position.X += _Speed * _TimeDelta;

                    if (_Position.Y > _PlayerCo.Y)
                        _Position.Y -= _Speed * _TimeDelta;

                    if (_Position.Y < _PlayerCo.Y)
                        _Position.Y += _Speed * _TimeDelta;

                    _Break = 0.0f;

                }
                else if (_Mode == 2)
                {
                    if (_Num2 == 1)
                    {
                        if (_Position.X < _StayArea)
                        {
                            if (_Position.X > _PlayerCo.X)
                                _Position.X -= _Speed * _TimeDelta;

                            if (_Position.X < _PlayerCo.X)
                                _Position.X += _Speed * _TimeDelta;

                            if (_Position.Y > _PlayerCo.Y)
                                _Position.Y -= _Speed * _TimeDelta;

                            if (_Position.Y < _PlayerCo.Y)
                                _Position.Y += _Speed * _TimeDelta;

                            _Break = 0.0f;
                        }
                        else
                        {
                            if (_Break > 1.5f)
                            {
                                _Rotation = ((float)Math.Atan2(_PlayerCo.Y - _Position.Y, _PlayerCo.X - _Position.X) - MathHelper.PiOver2);
                                _VDirection = new Vector2(-(float)Math.Sin(_Rotation), (float)Math.Cos(_Rotation));
                                Projectile _Bullet = new Projectile(_Position, _VDirection, 3);
                                _Bullet.LoadContent();
                                Main.Instance._EnProjectiles.Add(_Bullet);
                                _Break = 0.0f;
                            }
                        }
                        _Break += _TimeDelta;
                    }
                    else if (_Num2 == 2)
                    {
                        if (_Position.X > _StayArea)
                        {
                            if (_Position.X > _PlayerCo.X)
                                _Position.X -= _Speed * _TimeDelta;

                            if (_Position.X < _PlayerCo.X)
                                _Position.X += _Speed * _TimeDelta;

                            if (_Position.Y > _PlayerCo.Y)
                                _Position.Y -= _Speed * _TimeDelta;

                            if (_Position.Y < _PlayerCo.Y)
                                _Position.Y += _Speed * _TimeDelta;

                            _Break = 0.0f;
                        }
                        else
                        {
                            if (_Break > 1.5f)
                            {
                                _Rotation = ((float)Math.Atan2(_PlayerCo.Y - _Position.Y, _PlayerCo.X - _Position.X) - MathHelper.PiOver2);
                                _VDirection = new Vector2(-(float)Math.Sin(_Rotation), (float)Math.Cos(_Rotation));
                                Projectile _Bullet = new Projectile(_Position, _VDirection, 3);
                                _Bullet.LoadContent();
                                Main.Instance._EnProjectiles.Add(_Bullet);
                                _Break = 0.0f;
                            }
                        }
                        _Break += _TimeDelta;
                    }
                    else
                    {
                        if (_Position.Y < _StayArea)
                        {
                            if (_Position.X > _PlayerCo.X)
                                _Position.X -= _Speed * _TimeDelta;

                            if (_Position.X < _PlayerCo.X)
                                _Position.X += _Speed * _TimeDelta;

                            if (_Position.Y > _PlayerCo.Y)
                                _Position.Y -= _Speed * _TimeDelta;

                            if (_Position.Y < _PlayerCo.Y)
                                _Position.Y += _Speed * _TimeDelta;
                            _Break = 0.0f;
                        }
                        else
                        {
                            if (_Break > 1.5f)
                            {
                                _Rotation = ((float)Math.Atan2(_PlayerCo.Y - _Position.Y, _PlayerCo.X - _Position.X) - MathHelper.PiOver2);
                                _VDirection = new Vector2(-(float)Math.Sin(_Rotation), (float)Math.Cos(_Rotation));
                                Projectile _Bullet = new Projectile(_Position, _VDirection, 3);
                                _Bullet.LoadContent();
                                Main.Instance._EnProjectiles.Add(_Bullet);
                                _Break = 0.0f;
                            }
                        }
                        _Break += _TimeDelta;
                    }
                }
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
