using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace XNATable
{
    public class FadeAnimation : Animation
    {
        float fadeSpeed;
        float activateValue;

        bool increase;
        bool stopUpdating;

        TimeSpan defaultTime, timer;
        
        public TimeSpan Timer
        {
            get { return timer; }
            set { defaultTime = value; timer = defaultTime; }
        }

        public float FadeSpeed
        {
            get { return fadeSpeed; }
            set { fadeSpeed = value; }
        }

        public override float Alpha
        {
            get { return alpha; }
            set { alpha = value;
                if (alpha == 1.0f)
                    increase = false;
                else if (alpha == 0.0f)
                    increase = true;
            }
        }

        public float ActivateValue
        {
            get { return activateValue; }
            set { activateValue = value; }
        }

        public override void LoadContent(ContentManager Content,
            Texture2D image,
            string text,
            Vector2 position)
        {
            base.LoadContent(Content, image, text, position);
            increase = false;
            fadeSpeed = 1.9f;
            defaultTime = new TimeSpan(0, 0, 1);
            timer = defaultTime;
            activateValue = 0.0f;
            stopUpdating = false;
        }

        public override void Update(GameTime gameTime)
        {
            if (isActive)
            {
                if (!stopUpdating)
                {
                    //Increasing or decreasing the fade of graphics
                    if (!increase)
                        alpha -= fadeSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    else
                        alpha += fadeSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    //Start increasing when 0
                    if (alpha <= 0.0f)
                    {
                        alpha = 0.0f;
                        increase = true;
                    }
                    //Stop increasing when 1.0
                    else if (alpha >= 1.0f)
                    {
                        alpha = 1.0f;
                        increase = false;
                    }
                }

                if (alpha == activateValue)
                {
                    stopUpdating = true;
                    timer -= gameTime.ElapsedGameTime;
                    if (timer.TotalSeconds <= 0)
                    {
                        timer = defaultTime;
                        stopUpdating = false;
                    }
                }
            }
            else
            {
               // alpha = defaultAlpha;
                stopUpdating = false;
            }
        }
    }
}
