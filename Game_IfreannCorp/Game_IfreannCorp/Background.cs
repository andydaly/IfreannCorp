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
    public class Background : Entity
    {
        Rectangle _ScreenRectangle;
        Rectangle _ScreenRectangle2;
        

        public Background(string _Image1, string _Image2)
        {
            _Sprite = Main.Instance.Content.Load<Texture2D>(_Image1);
            _Sprite2 = Main.Instance.Content.Load<Texture2D>(_Image2);
        }

        public override void LoadContent()
        {
            _ScreenRectangle = new Rectangle(0, 0, _Width, _Height);
            _ScreenRectangle2 = new Rectangle(0 - _Width, 0, _Width, _Height);
        }

        public void GameUpdate(GameTime gameTime, bool _Ambush)
        {
            if (!_Ambush)
            {
                _ScreenRectangle.X += 1;
                _ScreenRectangle2.X += 1;

                if (_ScreenRectangle.X >= _Width)
                    _ScreenRectangle.X = 0 - _Width;
                if (_ScreenRectangle2.X >= _Width)
                    _ScreenRectangle2.X = 0 - _Width;
            }

        }

        public override void Update(GameTime gameTime)
        {
        }

        public override void Draw(GameTime gameTime)
        {
            Main.Instance.Spritebatch.Draw(_Sprite, _ScreenRectangle, Color.White);
            Main.Instance.Spritebatch.Draw(_Sprite2, _ScreenRectangle2, Color.White);
        }
    }
}
