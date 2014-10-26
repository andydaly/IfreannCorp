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
    public class OptionsMenu : Entity
    {
        Rectangle _ScreenRectangle;
        ControlsPosition _Layout;
        SpriteFont _SelectionText;
        Vector2 _Text1, _Text2, _Text3;
        public bool _LeftSide;
        public bool _GameCommence;

        public OptionsMenu()
        {
            _Layout = new ControlsPosition();
            _GameCommence = false;
        }

        public override void LoadContent()
        {
            _Sprite = Main.Instance.Content.Load<Texture2D>("Menus/Options");
            _ScreenRectangle = new Rectangle(0, 0, _Width, _Height);

            _Sprite2 = Main.Instance.Content.Load<Texture2D>("UI/Circle");

            _Position = _Layout.Left(); 
            _Position2 = _Layout.Right();
            _Center = new Vector2(_Sprite2.Width / 2, _Sprite2.Height / 2);

            _SelectionText = Main.Instance.Content.Load<SpriteFont>("Menus/StartText");
            _Text1 = new Vector2((Main.Instance.Width / 2) + 30, (Main.Instance.Height / 2) + 190);
            _Text2 = new Vector2(_Position.X - (_Sprite2.Width / 2) - 25, _Position.Y + 25);
            _Text3 = new Vector2(_Position2.X - (_Sprite2.Width / 2) - 25, _Position2.Y + 25);
        }

        public override void Update(GameTime gameTime)
        {
            MouseState _MousePos = Mouse.GetState();

            if ((_MousePos.LeftButton == ButtonState.Pressed) &&
                ((_MousePos.X > (_Position.X - (((_Sprite2.Width / 2) * _Scale) - 25))) && (_MousePos.X < (_Position.X + (((_Sprite2.Width / 2) * _Scale) - 25))) &&
                (_MousePos.Y > (_Position.Y - (((_Sprite2.Height / 2) * _Scale) - 25))) && (_MousePos.Y < (_Position.Y + (((_Sprite2.Height / 2) * _Scale) - 25)))))
            {
                _LeftSide = true;
                _GameCommence = true;
            }

            if ((_MousePos.LeftButton == ButtonState.Pressed) &&
                ((_MousePos.X > (_Position2.X - (((_Sprite2.Width / 2) * _Scale) - 25))) && (_MousePos.X < (_Position2.X + (((_Sprite2.Width / 2) * _Scale) - 25))) &&
                (_MousePos.Y > (_Position2.Y - (((_Sprite2.Height / 2) * _Scale) - 25))) && (_MousePos.Y < (_Position2.Y + (((_Sprite2.Height / 2) * _Scale) - 25)))))
            {
                _LeftSide = false;
                _GameCommence = true;
            }
        }

        public override void Draw(GameTime gameTime)
        {
            Main.Instance.Spritebatch.Draw(_Sprite, _ScreenRectangle, Color.White);

            Main.Instance.Spritebatch.Draw(_Sprite2, _Position, null, Color.White, 0, _Center, 1, SpriteEffects.None, 0);
            Main.Instance.Spritebatch.Draw(_Sprite2, _Position2, null, Color.White, 0, _Center, 1, SpriteEffects.None, 0);
            
            Main.Instance.Spritebatch.DrawString(_SelectionText, "Choose Button Layout", _Text1, Color.White, 0 - MathHelper.PiOver2, new Vector2(0, 0), 1.3f, SpriteEffects.None, 1);
            Main.Instance.Spritebatch.DrawString(_SelectionText, "Left", _Text2, Color.White, 0 - MathHelper.PiOver2, new Vector2(0, 0), 1, SpriteEffects.None, 1);
            Main.Instance.Spritebatch.DrawString(_SelectionText, "Right", _Text3, Color.White, 0 - MathHelper.PiOver2, new Vector2(0, 0), 1, SpriteEffects.None, 1);
           
        }
    }
}
