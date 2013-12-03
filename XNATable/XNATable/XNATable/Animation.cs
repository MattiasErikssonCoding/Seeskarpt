using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace XNATable
{
    public class Animation
    {
        #region Protected inits
        
        protected Color color;
        protected Texture2D image;
        protected SpriteFont font;
        protected Rectangle sourceRect;
        protected Vector2 origin, position;
        protected ContentManager content;

        protected string text;
        protected bool isActive;

        protected float axis;
        protected float alpha;
        protected float scale;
        protected float rotation; 
        
        public virtual float Alpha
        {
            get { return alpha; }
            set { alpha = value; }
        }

        public bool IsActive
        {
            set { isActive = value; }
            get { return isActive; }
        }

        public float Scale
        {
            set { scale = value; }
        }
        public SpriteFont Font
        {
            get { return font; }
            set { font = value; }
        }


        #endregion

        public virtual void LoadContent(
            ContentManager Content,
            Texture2D image,
            string text,
            Vector2 position)
        {
            
            this.image = image;
            this.text = text;
            this.position = position;
            
            if (text != String.Empty)
            {
                font = content.Load<SpriteFont>("SpriteFont1");
                color = new Color(100, 110, 31);
            }
            
            if (image != null) 
                sourceRect = new Rectangle(0, 0, image.Width, image.Height); 
            
            rotation = 0.0f;
            axis = 0.0f;
            scale = 1.0f;
            alpha = 1.0f;
        }

        public virtual void UnloadContent()
        {
            content.Unload();
            text = String.Empty;
            position = Vector2.Zero;
            sourceRect = Rectangle.Empty;
            image = null;
        }

        public virtual void Update(GameTime gameTime) 
        {
 
        }
        public virtual void Draw(SpriteBatch spriteBatch) 
        {
            if (image != null)
            {
                origin = new Vector2(sourceRect.Width / 2,
                    sourceRect.Height / 2);
                
                spriteBatch.Draw(
                    image,
                    position + origin,
                    sourceRect,
                    Color.White * alpha,
                    rotation,
                    origin,
                    scale,
                    SpriteEffects.None,
                    0.0f);   
            }
            
            if (text != String.Empty)
            {
                origin = new Vector2(font.MeasureString(text).X / 2,
                    font.MeasureString(text).Y / 2);

                spriteBatch.DrawString(
                    font,
                    text,
                    position + origin,
                    color * alpha,
                    rotation,
                    origin,
                    scale,
                    SpriteEffects.None,
                    0.0f);
            }
        }
    }
}
