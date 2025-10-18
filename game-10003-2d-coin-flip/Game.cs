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

        public void skyboxNight()
        {
            Color startSBNight = new Color(15, 24, 31); // #0F181F | The night sky
            Color endSBNight = new Color(12, 36, 66); // #0C2442 | The city glow

            for (int i = 0; i < 200; i++) // Self-note for future me: "i = 0" is where loop starts, "200" is how many times it'll loop, and i++ is just adding 1 every time
            {
                // Mouse y-axis input not required because night sky is always being rendered behind
                int r = startSBNight.R + (endSBNight.R - startSBNight.R) * i / 200;
                int g = startSBNight.G + (endSBNight.G - startSBNight.G) * i / 200;
                int b = startSBNight.B + (endSBNight.B - startSBNight.B) * i / 200;

                Draw.LineColor = new Color(r, g, b);
                Draw.LineSize = 1;

                float x = i * 1.0f;

                Draw.PolyLine(new Vector2(0, x), new Vector2(Window.Height, x));
            }
        }

        public void skyboxBlue()
        {
            Color startSBBlue = new Color(1, 94, 234); // #FF813C | The orange half
            Color endSBBlue = new Color(0, 192, 250); // #FF3C00 | The red half

            for (int i = 0; i < 200; i++) // Self-note for future me: "i = 0" is where loop starts, "200" is how many times it'll loop, and i++ is just adding 1 every time
            {

                float alpha = 255.0f - ((Input.GetMouseY() - 10.0f) / (180.0f - 10.0f)) * 255.0f; // Skybox starts fading at 10px on y-axis and goes completely invisible at 180px

                int r = startSBBlue.R + (endSBBlue.R - startSBBlue.R) * i / 200;
                int g = startSBBlue.G + (endSBBlue.G - startSBBlue.G) * i / 200;
                int b = startSBBlue.B + (endSBBlue.B - startSBBlue.B) * i / 200;

                Draw.LineColor = new Color(r, g, b, (int)alpha); // Must convert alpha to int or it won't work
                Draw.LineSize = 1;

                float x = i * 1.0f;

                Draw.PolyLine(new Vector2(0, x), new Vector2(Window.Height, x));
            }
        }
        public void skyboxOrange()
        {
            Color startSBOrange = new Color(255, 129, 60); // #FF813C | The orange half
            Color endSBOrange = new Color(255, 60, 0); // #FF3C00 | The red half

            for (int i = 0; i < 200; i++) // Self-note for future me: "i = 0" is where loop starts, "200" is how many times it'll loop, and i++ is just adding 1 every time
            {

                float alpha = 255.0f - ((Input.GetMouseY() - 180.0f) / (230.0f - 180.0f)) * 255.0f; // Skybox starts fading at 180px on y-axis and goes completely invisible at 230px

                int r = startSBOrange.R + (endSBOrange.R - startSBOrange.R) * i / 200;
                int g = startSBOrange.G + (endSBOrange.G - startSBOrange.G) * i / 200;
                int b = startSBOrange.B + (endSBOrange.B - startSBOrange.B) * i / 200;

                Draw.LineColor = new Color(r, g, b, (int)alpha); // Must convert alpha to int or it won't work
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
            skyboxNight();
            skyboxOrange();
            skyboxBlue();
            sun();
            moon();
            credits();

        }
    }

}
