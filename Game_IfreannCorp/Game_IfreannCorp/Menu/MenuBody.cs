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
    public class MenuBody : Entity
    {
        public bool _MuteActive, _GameCommence, _LeftSide, _Build;
        MainMenu _Start;
        OptionsMenu _Selection;
        LoadMenu _Load;
        bool _Starter, _Options, _LoadGame;
        Song _Song;

        public MenuBody()
        {
            _Starter = true;
            _Options = false;
            _LoadGame = false;
            _MuteActive = false;
            _GameCommence = false;
            _Build = false;
        }

        public override void LoadContent()
        {
            _Song = Main.Instance.Content.Load<Song>("Menu");
            MediaPlayer.Play(_Song);
            MediaPlayer.IsRepeating = true;




            _Start = new MainMenu();
            _Start.LoadContent();
            _Selection = new OptionsMenu();
            _Selection.LoadContent();
            _Load = new LoadMenu();
            _Load.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            if (_Start._MuteActive)
                _MuteActive = true;
            else if (!_Start._MuteActive)
                _MuteActive = false;


            


            if (_Start._Active)
            {
                _Starter = false;
                //_Options = true;
                _Build = true;
                _GameCommence = true;
                _LeftSide = true;
            }

            //if (_Selection._GameCommence)
            //{
            //    _Build = true;
            //    _GameCommence = true;
            //    _LeftSide = _Selection._LeftSide;
            //}


            if (_Starter)
                _Start.Update(gameTime);
            //else if (_Options)
            //    _Selection.Update(gameTime);
            //else if (_LoadGame)
            //    _Load.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            if (_Starter)
                _Start.Draw(gameTime);
            else if (_Options)
                _Selection.Draw(gameTime);
            else if (_LoadGame)
                _Load.Draw(gameTime);
        }
    }
}
