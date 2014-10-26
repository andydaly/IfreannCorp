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
    public class MainMenu : Entity
    {
        public bool _MuteActive;

        Rectangle _ScreenRectangle;
        Startbutton _Button1;
        Loadbutton _Button2;
        Mutebutton _Button3;

        public MainMenu()
        {
            
        }

        public override void LoadContent()
        {
            _Random = new Random();
            int _Display = _Random.Next(1, 3);

            _Display = 1;
            if (_Display == 1)
                _Sprite = Main.Instance.Content.Load<Texture2D>("Menus/Main");
            else if (_Display == 2)
                _Sprite = Main.Instance.Content.Load<Texture2D>("Menus/planet2");
            
            _ScreenRectangle = new Rectangle(0, 0, _Width, _Height);

            _Button1 = new Startbutton((_Width / 2) + 120, _Height / 2);
            //_Button2 = new Loadbutton((_Width / 2) + 190, _Height/2);
            _Button3 = new Mutebutton(_Width - 50, 50);
            _Button1.LoadContent();
            //_Button2.LoadContent();
            _Button3.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            if (_Button3._Active)
                _MuteActive = true;
            else if (!_Button3._Active)
                _MuteActive = false;



            if (_Button1._Active)
                _Active = true;


            _Button1.Update(gameTime);
            _Button3.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Main.Instance.Spritebatch.Draw(_Sprite, _ScreenRectangle, Color.White);
            _Button1.Draw(gameTime);
            //_Button2.Draw(gameTime);
            _Button3.Draw(gameTime);
        }
    }
}
