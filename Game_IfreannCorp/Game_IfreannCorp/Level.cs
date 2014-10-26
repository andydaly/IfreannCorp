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
    public class Level : Entity
    {
        public int _Score;
        Vector2 _Text1Position1;
        Vector2 _Text1Position2;
        Vector2 _Text2Position1;
        Vector2 _Text2Position2;
        Vector2 _ScoreText1;
        Vector2 _ScoreText2;
        SpriteFont _PlayerDetails;
        SpriteFont _ScoreDetails;
        public bool _StageComplete = false;
        bool _MuteActive;
        Background _LevelBackground;
        Player _Player;
        Controls _Button;
        Aim _FreeAim;
        Song _Song;
        public List<Projectile> _Projectiles = new List<Projectile>();
        List<Explosion> _Explosions = new List<Explosion>();
        float _Break = 0.0f;
        public bool _NextStage = false;
        LevelLayout _LevelRun;
        public bool _ReBuild = false;

        public Level(float _Time, int _Score, bool _LeftSide, bool _MuteActive, string _Background, int _Enemy, string _Music, int _TravelNum1)
        {
            this._Score = _Score;
            _Button = new Controls(_LeftSide);
            this._MuteActive = _MuteActive;
            _LevelBackground = new Background(_Background + "1", _Background + "2");
            _Song = Main.Instance.Content.Load<Song>(_Music);
            
            _LevelRun = new LevelLayout(_Time, _Enemy, _TravelNum1);
            if (_LeftSide)
                _Text1Position1 = new Vector2(_Width - 30, 150);
            else if (!_LeftSide)
                _Text1Position1 = new Vector2(_Width - 30, _Height - 10);
        }

        public Level(float _Time, int _Score, bool _LeftSide, bool _MuteActive, string _Background, int _Enemy, string _Music, int _TravelNum1, int _AmbushNum1)
        {
            this._Score = _Score;
            _Button = new Controls(_LeftSide);
            this._MuteActive = _MuteActive;
            _LevelBackground = new Background(_Background + "1", _Background + "2");
            _Song = Main.Instance.Content.Load<Song>(_Music);

            _LevelRun = new LevelLayout(_Time, _Enemy, _TravelNum1, _AmbushNum1);
            if (_LeftSide)
                _Text1Position1 = new Vector2(_Width - 30, 150);
            else if (!_LeftSide)
                _Text1Position1 = new Vector2(_Width - 30, _Height - 10);
        }

        public Level(float _Time, int _Score, bool _LeftSide, bool _MuteActive, string _Background, int _Enemy, string _Music, int _TravelNum1, int _AmbushNum1, int _TravelNum2)
        {
            this._Score = _Score;
            _Button = new Controls(_LeftSide);
            this._MuteActive = _MuteActive;
            _LevelBackground = new Background(_Background + "1", _Background + "2");
            _Song = Main.Instance.Content.Load<Song>(_Music);

            _LevelRun = new LevelLayout(_Time, _Enemy, _TravelNum1, _AmbushNum1, _TravelNum2);
            if (_LeftSide)
                _Text1Position1 = new Vector2(_Width - 30, 150);
            else if (!_LeftSide)
                _Text1Position1 = new Vector2(_Width - 30, _Height - 10);
        }

        public Level(float _Time, int _Score, bool _LeftSide, bool _MuteActive, string _Background, int _Enemy, string _Music, int _TravelNum1, int _AmbushNum1, int _TravelNum2, int _AmbushNum2)
        {
            this._Score = _Score;
            _Button = new Controls(_LeftSide);
            this._MuteActive = _MuteActive;
            _LevelBackground = new Background(_Background + "1", _Background + "2");
            _Song = Main.Instance.Content.Load<Song>(_Music);
            _LevelRun = new LevelLayout(_Time, _Enemy, _TravelNum1, _AmbushNum1, _TravelNum2, _AmbushNum2);
            if (_LeftSide)
                _Text1Position1 = new Vector2(_Width - 30, 150);
            else if (!_LeftSide)
                _Text1Position1 = new Vector2(_Width - 30, _Height - 10);
        }

        public Level(float _Time, int _Score, bool _LeftSide, bool _MuteActive, string _Background, int _Enemy, string _Music, int _TravelNum1, int _AmbushNum1, int _TravelNum2, int _AmbushNum2, int _TravelNum3)
        {
            this._Score = _Score;
            _Button = new Controls(_LeftSide);
            this._MuteActive = _MuteActive;
            _LevelBackground = new Background(_Background + "1", _Background + "2");
            _Song = Main.Instance.Content.Load<Song>(_Music);
            _LevelRun = new LevelLayout(_Time, _Enemy, _TravelNum1, _AmbushNum1, _TravelNum2, _AmbushNum2, _TravelNum3);
            if (_LeftSide)
                _Text1Position1 = new Vector2(_Width - 30, 150);
            else if (!_LeftSide)
                _Text1Position1 = new Vector2(_Width - 30, _Height - 10);
        }


        public Level(float _Time, int _Score, bool _LeftSide, bool _MuteActive, string _Background, int _Enemy, string _Music, int _TravelNum1, int _AmbushNum1, int _TravelNum2, int _AmbushNum2, int _TravelNum3, int _AmbushNum3)
        {
            this._Score = _Score;
            _Button = new Controls(_LeftSide);
            this._MuteActive = _MuteActive;
            _LevelBackground = new Background(_Background + "1", _Background + "2");
            _Song = Main.Instance.Content.Load<Song>(_Music);
            _LevelRun = new LevelLayout(_Time, _Enemy, _TravelNum1, _AmbushNum1, _TravelNum2, _AmbushNum2, _TravelNum3, _AmbushNum3);
            if (_LeftSide)
                _Text1Position1 = new Vector2(_Width - 30, 150);
            else if (!_LeftSide)
                _Text1Position1 = new Vector2(_Width - 30, _Height - 10);
        }

        public Level(float _Time, int _Score, bool _LeftSide, bool _MuteActive, string _Background, int _Enemy, string _Music, int _TravelNum1, int _AmbushNum1, int _TravelNum2, int _AmbushNum2, int _TravelNum3, int _AmbushNum3, int _TravelNum4)
        {
            this._Score = _Score;
            _Button = new Controls(_LeftSide);
            this._MuteActive = _MuteActive;
            _LevelBackground = new Background(_Background + "1", _Background + "2");
            _Song = Main.Instance.Content.Load<Song>(_Music);
            _LevelRun = new LevelLayout(_Time, _Enemy, _TravelNum1, _AmbushNum1, _TravelNum2, _AmbushNum2, _TravelNum3, _AmbushNum3, _TravelNum4);
            if (_LeftSide)
                _Text1Position1 = new Vector2(_Width- 30, 150);
            else if (!_LeftSide)
                _Text1Position1 = new Vector2(_Width - 30, _Height - 10);
        }

        public Level(float _Time, int _Score, bool _LeftSide, bool _MuteActive, string _Background, int _Enemy, string _Music, int _TravelNum1, int _AmbushNum1, int _TravelNum2, int _AmbushNum2, int _TravelNum3, int _AmbushNum3, int _TravelNum4, int _AmbushNum4)
        {
            this._Score = _Score;
            _Button = new Controls(_LeftSide);
            this._MuteActive = _MuteActive;
            _LevelBackground = new Background(_Background + "1", _Background + "2");
            _Song = Main.Instance.Content.Load<Song>(_Music);
            _LevelRun = new LevelLayout(_Time, _Enemy, _TravelNum1, _AmbushNum1, _TravelNum2, _AmbushNum2, _TravelNum3, _AmbushNum3, _TravelNum4, _AmbushNum4);
            if (_LeftSide)
                _Text1Position1 = new Vector2(_Width - 30, 150);
            else if (!_LeftSide)
                _Text1Position1 = new Vector2(_Width - 30, _Height - 10);
        }

        public Level(float _Time, int _Score, bool _LeftSide, bool _MuteActive, string _Background, int _Enemy, string _Music, int _TravelNum1, int _AmbushNum1, int _TravelNum2, int _AmbushNum2, int _TravelNum3, int _AmbushNum3, int _TravelNum4, int _AmbushNum4, int _TravelNum5)
        {
            this._Score = _Score;
            _Button = new Controls(_LeftSide);
            this._MuteActive = _MuteActive;
            _LevelBackground = new Background(_Background + "1", _Background + "2");
            _Song = Main.Instance.Content.Load<Song>(_Music);
            _LevelRun = new LevelLayout(_Time, _Enemy, _TravelNum1, _AmbushNum1, _TravelNum2, _AmbushNum2, _TravelNum3, _AmbushNum3, _TravelNum4, _AmbushNum4, _TravelNum5);
            if (_LeftSide)
                _Text1Position1 = new Vector2(_Width - 30, 150);
            else if (!_LeftSide)
                _Text1Position1 = new Vector2(_Width - 30, _Height - 10);
        }


        public override void LoadContent()
        {

            _Text1Position2 = new Vector2(20, _Height - 35);
            _Text2Position1 = new Vector2(5, _Height - 10);
            _Text2Position2 = new Vector2(10, 10);

            MediaPlayer.Stop();

            

            _PlayerDetails = Main.Instance.Content.Load<SpriteFont>("UI/SDetails");
            _ScoreDetails = Main.Instance.Content.Load<SpriteFont>("UI/Score");


            _Sprite = Main.Instance.Content.Load<Texture2D>("UI/complete");
            _Center = new Vector2(_Sprite.Width / 2, _Sprite.Height / 2);

            _Sprite2 = Main.Instance.Content.Load<Texture2D>("UI/gameover");
            _Center2 = new Vector2(_Sprite2.Width / 2, _Sprite2.Height / 2);

            _Position = new Vector2(_Width / 2, _Height / 2);

            _ScoreText1 = new Vector2((_Width / 2)+100, (_Height / 2)+120);
            _ScoreText2 = new Vector2((_Width / 2) - 120, (_Height / 2) + 100);

            if (!_MuteActive)
            {
                MediaPlayer.Play(_Song);
                MediaPlayer.IsRepeating = true;
            }

            _Player = new Player();
            _Player.LoadContent();

            _FreeAim = new Aim();

            

            _LevelRun.LoadContent();
            _LevelBackground.LoadContent();
            _Button.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            if ((_Button._Active) || (_FreeAim._Active))
            {
                Projectile _Bullet = new Projectile(_Player._Position, _Player._Direction);
                _Bullet.LoadContent();
                _Projectiles.Add(_Bullet);
                _Button._Active = false;
                _FreeAim._Active = false;
            }

           



            if (!_LevelRun._Ambush)
                if (_Player._Active)
                    _Button.Update(gameTime);
            
            if (_LevelRun._Ambush)
                if (_Player._Active)
                    _FreeAim.GameUpdate(gameTime, _Player._Position);
            



            _LevelRun.GameUpdate(gameTime, _Player._Position);
            

            

            _LevelBackground.GameUpdate(gameTime, _LevelRun._Ambush);
            
            

            if (_FreeAim._Active)
                _Player._Rotation = _FreeAim._PlayerRotate;

            if (_Player._Active)
                _Player.GameUpdate(gameTime, _LevelRun._Ambush);
            

            

            for (int i = 0; i < _Projectiles.Count; i++)
            {
                _Projectiles[i].Update(gameTime);
                _Score += _Projectiles[i]._Score;
                if (!_Projectiles[i]._Active)
                    _Projectiles.Remove(_Projectiles[i]);
            }

            for (int i = 0; i < _Explosions.Count; i++)
            {
                if (!_LevelRun._Ambush)
                    _Explosions[i]._Position.X += 2;
                _Explosions[i].Update(gameTime);

                if (!_Explosions[i]._Active)
                    _Explosions.Remove(_Explosions[i]);
            }


            for (int i = 0; i < Main.Instance._EnProjectiles.Count; i++)
            {
                Main.Instance._EnProjectiles[i].Update(gameTime);
                if (((_Player._Position.X - (_Player._Sprite.Width / 2)) < (Main.Instance._EnProjectiles[i]._Position.X))
                    && ((_Player._Position.Y + (_Player._Sprite.Height / 2)) > (Main.Instance._EnProjectiles[i]._Position.Y))
                    && ((_Player._Position.Y - (_Player._Sprite.Height / 2)) < (Main.Instance._EnProjectiles[i]._Position.Y))
                    && ((_Player._Position.X + (_Player._Sprite.Width / 2)) > (Main.Instance._EnProjectiles[i]._Position.X)))
                {
                    _Player._Health -= 5;
                    Main.Instance._EnProjectiles[i]._Active= false;
                }


                if (!Main.Instance._EnProjectiles[i]._Active)
                    Main.Instance._EnProjectiles.Remove(Main.Instance._EnProjectiles[i]);
            }


            for (int i = 0; i < Main.Instance._Enemies.Count; i++)
            {
                Main.Instance._Enemies[i].Update(gameTime);

                if (((_Player._Position.X - (_Player._Sprite.Width / 2)) < (Main.Instance._Enemies[i]._Position.X + (Main.Instance._Enemies[i]._Sprite.Width / 2)))
                    && ((_Player._Position.Y + (_Player._Sprite.Height / 2)) > (Main.Instance._Enemies[i]._Position.Y - (Main.Instance._Enemies[i]._Sprite.Height / 2)))
                    && ((_Player._Position.Y - (_Player._Sprite.Height / 2)) < (Main.Instance._Enemies[i]._Position.Y + (Main.Instance._Enemies[i]._Sprite.Height / 2)))
                    && ((_Player._Position.X + (_Player._Sprite.Width / 2)) > (Main.Instance._Enemies[i]._Position.X - (Main.Instance._Enemies[i]._Sprite.Width / 2))))
                {
                    _Player._Health -= 20;
                    Main.Instance._Enemies[i]._Active = false;
                }

               
                if (!Main.Instance._Enemies[i]._Active)
                {
                    if (Main.Instance._Enemies[i]._Comet)
                    {
                        Explosion _Dead = new Explosion(Main.Instance._Enemies[i]._Position, 100, 100, 1, 3, "Explosion/cometCrumble", 1.0f, 0.1f); 
                        _Dead.LoadContent();
                        _Explosions.Add(_Dead);
                    }
                    else
                    {
                        Explosion _Dead = new Explosion(Main.Instance._Enemies[i]._Position, 64, 64, 5, 5, "Explosion/ExplosionSheet", 1.5f, 0.001f);
                        _Dead.LoadContent();
                        _Explosions.Add(_Dead);
                    }
                    Main.Instance._Enemies.Remove(Main.Instance._Enemies[i]);
                    _LevelRun._Killed = true;
                }
                

            }

            

            if (_LevelRun._StageComplete)
                if (_Player._Active)
                    _StageComplete = true;

            if (!_Player._Active)
            {
                Explosion _Dead = new Explosion(_Player._Position, 64, 64, 5, 5, "Explosion/ExplosionSheet", 2.5f, 0.001f);
                _Dead.LoadContent();
                _Explosions.Add(_Dead);
                float _TimeDelta = (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (_Break > 4.0f)
                {
                    _ReBuild = true;
                }

                _Break += _TimeDelta;
            }




            if (_StageComplete)
            {
                float _TimeDelta = (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (_Break > 4.0f)
                {
                    _NextStage = true;
                }

                _Break += _TimeDelta;
            }
        }

        public override void Draw(GameTime gameTime)
        {

            _LevelBackground.Draw(gameTime);
            if (_Player._Active)
                _Player.Draw(gameTime);

            for (int i = 0; i < Main.Instance._EnProjectiles.Count; i++)
            {
                Main.Instance._EnProjectiles[i].Draw(gameTime);
                

            }

            for (int i = 0; i < _Explosions.Count; i++)
            {
                _Explosions[i].Draw(gameTime);        
            }

            for (int i = 0; i < _Projectiles.Count; i++)
            {
                _Projectiles[i].Draw(gameTime);
            }

            for (int i = 0; i < Main.Instance._Enemies.Count; i++)
            {
                Main.Instance._Enemies[i].Draw(gameTime);
            }

            if (!_LevelRun._Ambush)
                Main.Instance.Spritebatch.DrawString(_PlayerDetails, "HP: " + _Player._Health.ToString() + "%", _Text1Position1, Color.AntiqueWhite, 0 - MathHelper.PiOver2, new Vector2(0, 0), 1.3f, SpriteEffects.None, 1);
            else
                Main.Instance.Spritebatch.DrawString(_PlayerDetails, "HP: " + _Player._Health.ToString() + "%", _Text1Position2, Color.AntiqueWhite, 0, new Vector2(0, 0), 1.3f, SpriteEffects.None, 1);

            if (!_LevelRun._Ambush)
                Main.Instance.Spritebatch.DrawString(_PlayerDetails, _Score.ToString(), _Text2Position1, Color.AntiqueWhite, 0 - MathHelper.PiOver2, new Vector2(0, 0), 1.3f, SpriteEffects.None, 1);
            else
                Main.Instance.Spritebatch.DrawString(_PlayerDetails, _Score.ToString(), _Text2Position2, Color.AntiqueWhite, 0, new Vector2(0, 0), 1.3f, SpriteEffects.None, 1);


            //if (!_LevelRun._Ambush)
            //    _Button.Draw(gameTime);

            _LevelRun.Draw(gameTime);

            if (_StageComplete)
            {
                if (!_LevelRun._Ambush)
                {
                    Main.Instance.Spritebatch.Draw(_Sprite, _Position, null, Color.White, 0 - MathHelper.PiOver2, _Center, 1.0f, SpriteEffects.None, 0);
                    Main.Instance.Spritebatch.DrawString(_ScoreDetails, "Score: " + _Score.ToString(), _ScoreText1, Color.Red, 0 - MathHelper.PiOver2, new Vector2(0, 0), 1.3f, SpriteEffects.None, 1);
                }
                else
                {
                    Main.Instance.Spritebatch.Draw(_Sprite, _Position, null, Color.White, 0, _Center, 1.0f, SpriteEffects.None, 0);
                    Main.Instance.Spritebatch.DrawString(_ScoreDetails, "Score: " + _Score.ToString(), _ScoreText2, Color.Red, 0, new Vector2(0, 0), 1.3f, SpriteEffects.None, 1);
                }    
            }


            if (_Player._Active == false)
            {
                if (!_LevelRun._Ambush)
                    Main.Instance.Spritebatch.Draw(_Sprite2, _Position, null, Color.White, 0 - MathHelper.PiOver2, _Center2, 1.0f, SpriteEffects.None, 0);
                else
                    Main.Instance.Spritebatch.Draw(_Sprite2, _Position, null, Color.White, 0, _Center2, 1.0f, SpriteEffects.None, 0);
            }
        }
    }
}
