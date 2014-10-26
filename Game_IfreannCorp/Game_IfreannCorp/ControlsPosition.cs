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
    public class ControlsPosition 
    {
        public ControlsPosition()
        {
            // TODO: Construct any child components here
        }

        public Vector2 Right()
        {
            return new Vector2(Main.Instance.Width - 75, 75);
        }

        public Vector2 Left()
        {
            return new Vector2(Main.Instance.Width - 75, Main.Instance.Height - 75);
        }
    }
}
