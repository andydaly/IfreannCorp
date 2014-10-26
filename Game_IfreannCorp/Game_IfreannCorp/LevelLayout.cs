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
    public class LevelLayout : Entity
    {
        Wave _Attack;
        int _Enemy;
       
        public bool _StageComplete = false;
        float _Time = 0.0f;
        int[] _EnemyWaves = new int[20];
        public bool _Ambush = false;
        int _Point = 0;
        public int _CurrentEnemies;
        public bool _Killed = false;
        float _TimeCount;
        public bool _WaveComplete = false;


        public LevelLayout(float _Time, int _Enemy, int _TravelNum1)
        {
            this._Time = _Time;
            for (int i = 0; i < 20; i++)
                _EnemyWaves[i] = 0;

            _EnemyWaves[0] = _TravelNum1;
            this._Enemy = _Enemy;
            

        }

        public LevelLayout(float _Time, int _Enemy, int _TravelNum1, int _AmbushNum1)
        {
            this._Time = _Time;
            for (int i = 0; i < 8; i++)
                _EnemyWaves[i] = 0;
            _EnemyWaves[0] = _TravelNum1;
            _EnemyWaves[1] = _AmbushNum1;
            this._Enemy = _Enemy;
            
        }

        public LevelLayout(float _Time, int _Enemy,  int _TravelNum1, int _AmbushNum1, int _TravelNum2)
        {
            this._Time = _Time;
            for (int i = 0; i < 20; i++)
                _EnemyWaves[i] = 0;
            _EnemyWaves[0] = _TravelNum1;
            _EnemyWaves[1] = _AmbushNum1; 
            _EnemyWaves[2] = _TravelNum2;
            this._Enemy = _Enemy;
           
        }

        public LevelLayout(float _Time, int _Enemy,  int _TravelNum1, int _AmbushNum1, int _TravelNum2, int _AmbushNum2)
        {
            this._Time = _Time;
            for (int i = 0; i < 20; i++)
                _EnemyWaves[i] = 0;
            _EnemyWaves[0] = _TravelNum1;
            _EnemyWaves[1] = _AmbushNum1;
            _EnemyWaves[2] = _TravelNum2;
            _EnemyWaves[3] = _AmbushNum2;
            this._Enemy = _Enemy;
            
        }

        public LevelLayout(float _Time, int _Enemy,  int _TravelNum1, int _AmbushNum1, int _TravelNum2, int _AmbushNum2, int _TravelNum3)
        {
            this._Time = _Time;
            for (int i = 0; i < 20; i++)
                _EnemyWaves[i] = 0;
            _EnemyWaves[0] = _TravelNum1;
            _EnemyWaves[1] = _AmbushNum1;
            _EnemyWaves[2] = _TravelNum2;
            _EnemyWaves[3] = _AmbushNum2;
            _EnemyWaves[4] = _TravelNum3;
            this._Enemy = _Enemy;
           

        }

        public LevelLayout(float _Time, int _Enemy, int _TravelNum1, int _AmbushNum1, int _TravelNum2, int _AmbushNum2, int _TravelNum3, int _AmbushNum3)
        {
            this._Time = _Time;
            for (int i = 0; i < 20; i++)
                _EnemyWaves[i] = 0;
            _EnemyWaves[0] = _TravelNum1;
            _EnemyWaves[1] = _AmbushNum1;
            _EnemyWaves[2] = _TravelNum2;
            _EnemyWaves[3] = _AmbushNum2;
            _EnemyWaves[4] = _TravelNum3;
            _EnemyWaves[5] = _AmbushNum3;
            this._Enemy = _Enemy;
            
        }

        public LevelLayout(float _Time, int _Enemy, int _TravelNum1, int _AmbushNum1, int _TravelNum2, int _AmbushNum2, int _TravelNum3, int _AmbushNum3, int _TravelNum4)
        {
            this._Time = _Time;
            for (int i = 0; i < 20; i++)
                _EnemyWaves[i] = 0;
            _EnemyWaves[0] = _TravelNum1;
            _EnemyWaves[1] = _AmbushNum1;
            _EnemyWaves[2] = _TravelNum2;
            _EnemyWaves[3] = _AmbushNum2;
            _EnemyWaves[4] = _TravelNum3;
            _EnemyWaves[5] = _AmbushNum3;
            _EnemyWaves[6] = _TravelNum4;
            this._Enemy = _Enemy;
            
        }

        public LevelLayout(float _Time, int _Enemy, int _TravelNum1, int _AmbushNum1, int _TravelNum2, int _AmbushNum2, int _TravelNum3, int _AmbushNum3, int _TravelNum4, int _AmbushNum4)
        {
            this._Time = _Time;
            for (int i = 0; i < 20; i++)
                _EnemyWaves[i] = 0;
            _EnemyWaves[0] = _TravelNum1;
            _EnemyWaves[1] = _AmbushNum1;
            _EnemyWaves[2] = _TravelNum2;
            _EnemyWaves[3] = _AmbushNum2;
            _EnemyWaves[4] = _TravelNum3;
            _EnemyWaves[5] = _AmbushNum3;
            _EnemyWaves[6] = _TravelNum4;
            _EnemyWaves[7] = _AmbushNum4;
            this._Enemy = _Enemy;
            
        }
        
        public LevelLayout(float _Time, int _Enemy, int _TravelNum1, int _AmbushNum1, int _TravelNum2, int _AmbushNum2, int _TravelNum3, int _AmbushNum3, int _TravelNum4, int _AmbushNum4, int _TravelNum5)
        {
            this._Time = _Time;
            for (int i = 0; i < 20; i++)
                _EnemyWaves[i] = 0;
            _EnemyWaves[0] = _TravelNum1;
            _EnemyWaves[1] = _AmbushNum1;
            _EnemyWaves[2] = _TravelNum2;
            _EnemyWaves[3] = _AmbushNum2;
            _EnemyWaves[4] = _TravelNum3;
            _EnemyWaves[5] = _AmbushNum3;
            _EnemyWaves[6] = _TravelNum4;
            _EnemyWaves[7] = _AmbushNum4;
            _EnemyWaves[8] = _TravelNum5;
            this._Enemy = _Enemy;

        }

        public override void LoadContent()
        {
            _Sprite = Main.Instance.Content.Load<Texture2D>("UI/ambush");
            _Center = new Vector2(_Sprite.Width / 2, _Sprite.Height / 2);

            _Sprite2 = Main.Instance.Content.Load<Texture2D>("UI/travel");
            _Center2 = new Vector2(_Sprite.Width / 2, _Sprite.Height / 2);
            
            _Position = new Vector2(_Width / 2, _Height / 2);
            

            _Attack = new Wave(_Enemy, _EnemyWaves[_Point], _Ambush, _Time);
            _Attack.LoadContent();
        }

        public void GameUpdate(GameTime gameTime, Vector2 _PlayerCo)
        {
            float _TimeDelta = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_Attack._WaveComplete)
            {
              
                _TimeCount += _TimeDelta;
                if ((_Point != 19) && (!_Active))
                    _Point++;

                if (_EnemyWaves[_Point] != 0)
                {

                    if (_TimeCount < 2.0f)
                    {
                        _Active = true;
                    }
                    
                    if (_TimeCount > 2.0f)
                    {
                        if (_Attack._Ambush)
                            _Ambush = false;
                        else if (!_Attack._Ambush)
                            _Ambush = true;
                        _Attack = new Wave(_Enemy, _EnemyWaves[_Point], _Ambush, _Time);
                        _Attack.LoadContent();
                        _Active = false;
                    }
                }
                else if (_EnemyWaves[_Point] == 0)
                {
                    _StageComplete = true;
                }
            }

            if (!_Active)
            {
                _Attack.GameUpdate(gameTime, _PlayerCo, _Killed);
                _Killed = false;
            }

            if (!_Active)
                _TimeCount = 0.0f;

        }

        public override void Update(GameTime gameTime)
        {
        }

        public override void Draw(GameTime gameTime)
        {
            if (_Active)
            {
                if (!_Ambush)
                    Main.Instance.Spritebatch.Draw(_Sprite, _Position, null, Color.White, 0 - MathHelper.PiOver2, _Center, 1.0f, SpriteEffects.None, 0);
                if (_Ambush)
                    Main.Instance.Spritebatch.Draw(_Sprite2, _Position, null, Color.White, 0, _Center2, 1.0f, SpriteEffects.None, 0);
            }
        }
    }
}
