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
    public abstract class Entity
    {
        public bool _Active;
        private Texture2D _sprite, _sprite2;
        public int _Width = Main.Instance.Width;
        public int _Height = Main.Instance.Height;
        public int _X, _Y;
        public Vector2 _Center, _Center2, _Position, _Position2;
        public float _Scale = 1.5f;
        public Random _Random;
        public int _Health;
        public int _Num = 1;
        public bool _Comet;

        public Entity()
        {
            // TODO: Construct any child components here
        }


        public Texture2D _Sprite
        {
            get { return _sprite; }
            set { _sprite = value; }
        }

        public Texture2D _Sprite2
        {
            get { return _sprite2; }
            set { _sprite2 = value; }
        }

        public abstract void LoadContent();
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime);
    }
}

