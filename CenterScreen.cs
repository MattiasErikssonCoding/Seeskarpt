using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace XNATable
{
    public class CenterScreen : GameScreen
    {
        SpriteFont font;
        //MenuManager menuManager;

        public override void LoadContent(ContentManager Content, InputManager inputManager)
        {
            base.LoadContent(Content, inputManager);
            if (font == null) { font = content.Load<SpriteFont>("SpriteFont1"); }
         //   menuManager = new MenuManager();
         //   menuManager.LoadContent(content, "Title");
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
         //   menuManager.UnloadContent();
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            inputManager.Update();
         //   menuManager.Update(gameTime);
            if (inputManager.KeyPressed(Keys.Up))
                ScreenManager.Instance.SetScreen(new NorthScreen(), inputManager);
            if (inputManager.KeyPressed(Keys.Down))
                ScreenManager.Instance.SetScreen(new SouthScreen(), inputManager);
            if (inputManager.KeyPressed(Keys.Left))
                ScreenManager.Instance.SetScreen(new WestScreen(), inputManager);
            if (inputManager.KeyPressed(Keys.Right))
                ScreenManager.Instance.SetScreen(new EastScreen(), inputManager);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
           // menuManager.Draw(spriteBatch);
            spriteBatch.DrawString(font, "This is the Center screen", new Vector2(250, 200), Color.Black);
        }
    }
}
