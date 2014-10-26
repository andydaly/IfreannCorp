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
    public class Projectile : Entity
    {
        public int _Score;
        public Vector2 _Direction, _PlayerPos, _PlayerDir;
        float _Rotation = 0.0f;
        int _Type = 1;


        public Projectile(Vector2 _PlayerPos, Vector2 _PlayerDir)
        {
            _Active = true;
            this._PlayerPos = _PlayerPos;
            this._PlayerDir = _PlayerDir;
        }

        public Projectile(Vector2 _PlayerPos, Vector2 _PlayerDir, int _Type)
        {
            _Active = true;
            this._PlayerPos = _PlayerPos;
            this._PlayerDir = _PlayerDir;
            this._Type = _Type;
        }

        public override void LoadContent()
        {
            _Score = 0;

            if (_Type == 2)
            {
                _Sprite = Main.Instance.Content.Load<Texture2D>("Projectile/bullet2");
            }
            else if (_Type == 3)
            {
                _Sprite = Main.Instance.Content.Load<Texture2D>("Projectile/bullet3");
            }
            else
            {
                _Sprite = Main.Instance.Content.Load<Texture2D>("Projectile/bullet");
            }
            _Center = new Vector2(_Sprite.Width / 2, _Sprite.Height / 2);
            _Position = _PlayerPos + _PlayerDir * 20.0f;
            _Direction = _PlayerDir;
        }

        public override void Update(GameTime gameTime)
        {
            float _TimeDelta = (float)gameTime.ElapsedGameTime.TotalSeconds;
            float _Speed = 500.0f;
            _Position += _Direction * _Speed * _TimeDelta;

            _Rotation = (float)Math.Atan2(_Direction.X, -_Direction.Y);




            if ((_Type != 2) && (_Type != 3))
            {
                for (int i = 0; i < Main.Instance._Enemies.Count; i++)
                {
                    if ((_Position.X > (Main.Instance._Enemies[i]._Position.X - (Main.Instance._Enemies[i]._Sprite.Width / 2)))
                        && (_Position.X < (Main.Instance._Enemies[i]._Position.X + (Main.Instance._Enemies[i]._Sprite.Width / 2)))
                        && (_Position.Y < (Main.Instance._Enemies[i]._Position.Y + (Main.Instance._Enemies[i]._Sprite.Height / 2)))
                        && (_Position.Y > (Main.Instance._Enemies[i]._Position.Y - (Main.Instance._Enemies[i]._Sprite.Height / 2))))
                    {
                        _Active = false;
                        Main.Instance._Enemies[i]._Health -= 60;
                        if (Main.Instance._Enemies[i]._Health < 0)
                            _Score = 10;
                    }
                    
                }
            }



            if ((_Position.X > _Width) || (_Position.X < 0 - 30) || (_Position.Y < 0) || (_Position.Y > _Height))
            {
                _Active = false;
            }

        }

        public override void Draw(GameTime gameTime)
        {
            Main.Instance.Spritebatch.Draw(_Sprite, _Position, null, Color.White, _Rotation, _Center, 1.0f, SpriteEffects.None, 0);
        }
    }
}
