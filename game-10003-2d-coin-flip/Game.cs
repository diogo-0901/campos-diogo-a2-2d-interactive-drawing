// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;
using System.Security.Principal;

// The namespace your code is in.
namespace MohawkGame2D
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Place your variables here:
        public void credits()
        {
            Draw.FillColor = Color.Black;
            Draw.LineSize = 0;
            Draw.Rectangle(0, 200, 400, 200);
        }
        public void background()
        {
            Window.ClearBackground(Color.Black);
        }
        public void skyboxOrange()
        {
            Color startSBOrange = new Color(255, 129, 60); // #FF813C | The orange half
            Color endSBOrange = new Color(255, 60, 0); // #FF3C00 | The red half

            for (int i = 0; i < 200; i++) // Self-note for future me: "i = 0" is where loop starts, "200" is how many times it'll loop, and i++ is just adding 1 every time
            {

                float alpha = 255.0f - ((Input.GetMouseY() - 180.0f) / (230.0f - 180.0f)) * 255.0f;

                int r = startSBOrange.R + (endSBOrange.R - startSBOrange.R) * i / 200;
                int g = startSBOrange.G + (endSBOrange.G - startSBOrange.G) * i / 200;
                int b = startSBOrange.B + (endSBOrange.B - startSBOrange.B) * i / 200;

                Draw.LineColor = new Color(r, g, b, (int)alpha); // Have to convert alpha to int or it won't work
                Draw.LineSize = 1;

                float x = i * 1.0f;

                Draw.PolyLine(new Vector2(0, x), new Vector2(Window.Height, x));
            }
        }
        public void sun()
        {
            // Draw a circle at mouse position
            Draw.FillColor = Color.Green;
            Draw.LineColor = Color.Black;
            Draw.Circle(Input.GetMouseX(), Input.GetMouseY(), 25);
        }
        public void moon()
        {
            // Draw a circle at mouse position
            Draw.FillColor = Color.Green;
            Draw.LineColor = Color.Black;
            Draw.Circle(Window.Width - Input.GetMouseX(), Window.Height - Input.GetMouseY(), 25);
        }

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetTitle("Sunset Beach");
            Window.SetSize(400, 400);
            Window.TargetFPS = 60;
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            background();
            skyboxOrange();
            sun();
            moon();
            credits();
            Vector2 sunPos = Input.GetMousePosition();
            // To do: Find a way to create a new colour and set said colour based on mouse position between 2 colours
            // Idea: Can I affect alpha of colour? (Yes you can) If so, I can make 3 layers of background and 

        }
    }

}
