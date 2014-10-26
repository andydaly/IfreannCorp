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
    public class Wave : Entity
    {
        float _TimeCount = 0.0f;
        float _CountAdded = 0.0f;
        float _Time;
        int _Enemy;
        int _TimeStart;
        public bool _WaveComplete;
        public bool _Ambush;
        public bool _EnemyShow;
        public int _CurrentEnemies;
        bool _WaveStart;
        int _EnemyNumber;
        int _EnemyCounter;

        public Wave(int _Enemy, int _EnemyNumber, bool _Ambush, float _Time)
        {
            this._Enemy = _Enemy;
            
            this._Time = _Time;
            
            this._EnemyNumber = _EnemyNumber;
            
            _CurrentEnemies = 0;
            this._Ambush = _Ambush;
        }

        public override void LoadContent()
        {
            if (_Ambush)
                _TimeStart = 1;
            else if (!_Ambush)
                _TimeStart = 5;

            _EnemyShow = false;
            _WaveComplete = false;
            _WaveStart = false;
        }

        public void GameUpdate(GameTime gameTime, Vector2 _PlayerCo, bool _Killed)
        {
            float _TimeDelta = (float)gameTime.ElapsedGameTime.TotalSeconds;
            _TimeCount += _TimeDelta;
            if ((_TimeCount > (_TimeStart + _CountAdded)) && (_EnemyCounter < _EnemyNumber))
            {
                if (_Enemy == 1)
                {
                    Enemy.Type1 _EnemyType = new Enemy.Type1(_Ambush, _PlayerCo);
                    _EnemyType.LoadContent();
                    Main.Instance._Enemies.Add(_EnemyType);
                    _EnemyCounter++;
                    
                    _EnemyShow = true;
                    _WaveStart = true;
                        
                }
                else if (_Enemy == 2)
                {
                    Enemy.Type2 _EnemyType = new Enemy.Type2(_Ambush, _PlayerCo);
                    _EnemyType.LoadContent();

                    Main.Instance._Enemies.Add(_EnemyType);
                    _EnemyCounter++;
                    
                    _EnemyShow = true;
                    _WaveStart = true;
                }
                else if (_Enemy == 3)
                {
                    Enemy.Type3 _EnemyType = new Enemy.Type3(_Ambush, _PlayerCo);
                    _EnemyType.LoadContent();

                    Main.Instance._Enemies.Add(_EnemyType);
                    _EnemyCounter++;
                    
                    _EnemyShow = true;
                    _WaveStart = true;
                }
                else if (_Enemy == 4)
                {
                    Enemy.Type4 _EnemyType = new Enemy.Type4(_Ambush, _PlayerCo);
                    _EnemyType.LoadContent();

                    Main.Instance._Enemies.Add(_EnemyType);
                    _EnemyCounter++;
                    
                    _EnemyShow = true;
                    _WaveStart = true;
                }
                else if (_Enemy == 5)
                {
                    Enemy.Type5 _EnemyType = new Enemy.Type5(_Ambush, _PlayerCo);
                    _EnemyType.LoadContent();

                    Main.Instance._Enemies.Add(_EnemyType);
                    _EnemyCounter++;
                    
                    _EnemyShow = true;
                    _WaveStart = true;
                }


                
                _CountAdded += _Time;
            }


            if ((_Killed) || (_EnemyShow))
            {
                _CurrentEnemies = 0;
                for (int i = 0; i < Main.Instance._Enemies.Count; i++)
                {
                    if (Main.Instance._Enemies[i]._Active)
                        _CurrentEnemies++;
                }
                _Killed = false;
                _EnemyShow = false;
            }



            
            if ((_CurrentEnemies == 0) && (_WaveStart) && (_EnemyCounter == _EnemyNumber))
                _WaveComplete = true;
            

        }

        public override void Update(GameTime gameTime)
        {
        }



        public override void Draw(GameTime gameTime)
        {

        }
    }
}
