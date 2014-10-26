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
    public class TankGame : Entity
    {
        Menu.MenuBody _Menu;
        bool _MuteActive, _GameCommence, _LeftSide, _StageComplete;
        Level _CurrentStage;
        bool[] _Build;
        int _StagePosition;
        int _TotalScore;
        bool _GameComplete;
        Ending _Credits;
        Intro _StageOpen;
        bool _Introduction = true;
        bool _Prepare = false;

        public TankGame()
        {
            _GameComplete = false;
            _TotalScore = 0;
            _StagePosition = 0;
            _Build = new bool[6];
            
            _GameCommence = false;
            _StageComplete = false;
        }

        public override void LoadContent()
        {

            _Menu = new Menu.MenuBody();
            _Menu.LoadContent();

            for (int i = 0; i < 5; i++)
            {
                _Build[i] = false;
            }

            
        }

        public override void Update(GameTime gameTime)
        {
            if (_Menu._MuteActive)
                _MuteActive = true;
            else if (!_Menu._MuteActive)
                _MuteActive = false;

            if (_Menu._GameCommence)
            {
                _GameCommence = true;
                _LeftSide = _Menu._LeftSide;
                if (_Menu._Build)
                {
                    _Build[0] = true;
                    _Menu._Build = false;
                    
                } 
            }


            if (_StageComplete)
            {
                if (_StagePosition < 5)
                {
                    _StagePosition++;
                    _Build[_StagePosition] = true;
                    _Introduction = true;
                }
                _StageComplete = false;
            }

            


            if (!_GameCommence)
                _Menu.Update(gameTime);
            else if (_GameCommence)
            {
                
                if (_Build[0])
                {
                    
                    _StageOpen = new Intro("Introduction/intro1", "Introduction/intro2", "Introduction/intro3");
                    _StageOpen.LoadContent();
                    _CurrentStage = new Level(0.9f, _TotalScore, _LeftSide, _MuteActive, "Space/Space", 1, "Stage1", 5, 5, 5);//10, 5, 10, 5, 15);
                    _CurrentStage.LoadContent();
                    
                    _Build[0] = false;
                }
                if (_Build[1])
                {
                    
                    _StageOpen = new Intro("Introduction/intro4");
                    _StageOpen.LoadContent();  
                    if (!_CurrentStage._ReBuild)
                        _TotalScore = _CurrentStage._Score;
                    _CurrentStage = new Level(0.7f, _TotalScore, _LeftSide, _MuteActive, "Landscape/planetTerrain", 2, "Stage2", 7, 5, 7, 5);//15, 5, 15, 7, 20, 10);
                    _CurrentStage.LoadContent();
                    _Build[1] = false;
                }
                if (_Build[2])
                {
                    
                    _StageOpen = new Intro("Introduction/intro5");
                    _StageOpen.LoadContent(); 
                    if (!_CurrentStage._ReBuild)
                        _TotalScore = _CurrentStage._Score;
                    _CurrentStage = new Level(0.7f, _TotalScore, _LeftSide, _MuteActive, "Cave/CaveL", 3, "Stage3", 5, 5, 5, 5, 5);//20, 6, 20, 5, 25, 8, 30);
                    _CurrentStage.LoadContent();
                    _Build[2] = false;
                }
                if (_Build[3])
                {
                    
                    _StageOpen = new Intro("Introduction/intro6");
                    _StageOpen.LoadContent(); 
                    if (!_CurrentStage._ReBuild)
                        _TotalScore = _CurrentStage._Score;
                    _CurrentStage = new Level(1.0f, _TotalScore, _LeftSide, _MuteActive, "Rough/Rough", 4, "Stage4", 5, 5, 5, 5, 5, 5);//15, 5, 20, 5, 20, 5, 20, 5);
                    _CurrentStage.LoadContent();
                    _Build[3] = false;
                }
                if (_Build[4])
                {
                    
                    _StageOpen = new Intro("Introduction/intro7");
                    _StageOpen.LoadContent(); 
                    if (!_CurrentStage._ReBuild)
                        _TotalScore = _CurrentStage._Score;
                    _CurrentStage = new Level(1.0f, _TotalScore, _LeftSide, _MuteActive, "Industry/industry", 5, "Stage5", 5, 5, 5, 5, 5, 5, 5, 5, 5);//15, 5, 20, 5, 20, 5, 20, 8, 25);
                    _CurrentStage.LoadContent();
                    _Build[4] = false;
                }
                if (_Build[5])
                {
                    if (!_CurrentStage._ReBuild)
                        _TotalScore = _CurrentStage._Score;
                    _Credits = new Ending(_TotalScore);
                    _Credits.LoadContent();
                    _GameComplete = true;
                    _Build[5] = false;
                }
                
                if (!_GameComplete)
                {
                    if (_Introduction)
                        _StageOpen.Update(gameTime);
                    else if (!_Introduction)
                        _CurrentStage.Update(gameTime);
                }

                if (!_StageOpen._Active)
                {
                    _Introduction = false;
                    _Build[_StagePosition] = true;
                    _Prepare = true;
                }


                if (_GameComplete)
                    _Credits.Update(gameTime);

                if (_CurrentStage._ReBuild)
                {
                    Main.Instance._EnProjectiles.Clear();
                    Main.Instance._Enemies.Clear();
                    _Build[_StagePosition] = true;
                }

                if (_CurrentStage._NextStage)
                {
                    _StageComplete = true;
                    _Introduction = true;
                }
            }

            
            
        }

        public override void Draw(GameTime gameTime)
        {
            if (!_GameCommence)
                _Menu.Draw(gameTime);
            else if (_GameCommence)
            {
                if (!_GameComplete)
                {
                    if (_Introduction)
                        _StageOpen.Draw(gameTime);
                    else if (!_Introduction)
                        _CurrentStage.Draw(gameTime);
                }
            }



            if (_GameComplete)
                _Credits.Draw(gameTime);

        }
    }
}
