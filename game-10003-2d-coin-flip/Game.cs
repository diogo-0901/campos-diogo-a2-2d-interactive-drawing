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
        void credits()
        {
            Draw.FillColor = Color.Black;
            Draw.LineSize = 0;
            Draw.Rectangle(0, 200, 400, 200);
        }
        void background()
        {
            Window.ClearBackground(Color.Black);
        }

        void skyboxNight()
        {
            Color startSBNight = new Color(15, 24, 31); // #0F181F | The night sky
            Color endSBNight = new Color(12, 36, 66); // #0C2442 | The city glow

            for (int i = 0; i < 200; i++) // Self-note for future me: "i = 0" is where loop starts, "200" is how many times it'll loop, and i++ is just adding 1 every time
            {
                // Int starts on start colour, then subtracts down to end colour in the span of 200 lines
                int r = startSBNight.R + (endSBNight.R - startSBNight.R) * i / 200;
                int g = startSBNight.G + (endSBNight.G - startSBNight.G) * i / 200;
                int b = startSBNight.B + (endSBNight.B - startSBNight.B) * i / 200;

                Draw.LineColor = new Color(r, g, b);
                Draw.LineSize = 1;

                float x = i * 1.0f;

                Draw.PolyLine(new Vector2(0, x), new Vector2(Window.Height, x));
            }
        }

        void skyboxBlue()
        {
            Color startSBBlue = new Color(1, 94, 234); // #015EEA | Deep blue sky
            Color endSBBlue = new Color(0, 192, 250); // #00C0FA | Horizon

            for (int i = 0; i < 200; i++)
            {
                // Skybox starts fading at 10px on y-axis and goes completely invisible at 180px
                float alpha = 255.0f - ((Input.GetMouseY() - 10.0f) / (180.0f - 10.0f)) * 255.0f;

                int r = startSBBlue.R + (endSBBlue.R - startSBBlue.R) * i / 200;
                int g = startSBBlue.G + (endSBBlue.G - startSBBlue.G) * i / 200;
                int b = startSBBlue.B + (endSBBlue.B - startSBBlue.B) * i / 200;

                Draw.LineColor = new Color(r, g, b, (int)alpha); // Must register float as int or it won't work
                Draw.LineSize = 1;

                float x = i * 1.0f;

                Draw.PolyLine(new Vector2(0, x), new Vector2(Window.Height, x));
            }
        }
        void skyboxOrange()
        {
            Color startSBOrange = new Color(255, 129, 60); // #FF813C | The orange half
            Color endSBOrange = new Color(255, 60, 0); // #FF3C00 | The red half

            for (int i = 0; i < 200; i++)
            {

                float alpha = 255.0f - ((Input.GetMouseY() - 180.0f) / (230.0f - 180.0f)) * 255.0f;

                int r = startSBOrange.R + (endSBOrange.R - startSBOrange.R) * i / 200;
                int g = startSBOrange.G + (endSBOrange.G - startSBOrange.G) * i / 200;
                int b = startSBOrange.B + (endSBOrange.B - startSBOrange.B) * i / 200;

                Draw.LineColor = new Color(r, g, b, (int)alpha);
                Draw.LineSize = 1;

                float x = i * 1.0f;

                Draw.PolyLine(new Vector2(0, x), new Vector2(Window.Height, x));
            }
        }
        void sun(float x, float y)
        {
            // Draw a circle at mouse position
            Draw.FillColor = new Color(255, 216, 0);
            Draw.LineSize = 0;
            Draw.Circle(x,y, 35);
        }
        void moon(float x, float y)
        {
            Color moon = new Color(255, 251, 232);
            Color moonOutline = new Color(180, 154, 128);

            // Draw a circle at mouse position
            Draw.FillColor = moon;
            Draw.LineColor = moonOutline;
            Draw.LineSize = 2;
            Draw.Circle(x, y, 25);
            Draw.Circle(x - 9, y + 9, 10);
            Draw.Circle(x + 10, y - 8, 5);
        }

        void beach()
        {
            Draw.LineSize = 0;
            Draw.FillColor = new Color(246, 215, 155);
            Draw.Rectangle(new Vector2(240, 160), new Vector2(400, 200));
            Draw.Quad(new Vector2(120, 200), new Vector2(130, 190), new Vector2(160, 170), new Vector2(240, 160));
            Draw.Triangle(new Vector2(120, 200), new Vector2(240, 160), new Vector2(240, 200));
        }

        void loungeChair(float x, float y)
        {
            Draw.LineSize = 5;
            Draw.Line(new Vector2(x + 20, y + 60), new Vector2(x + 30, y + 50));
            Draw.Line(new Vector2(x + 30, y + 50), new Vector2(x + 90, y + 50));
            Draw.Line(new Vector2(x + 70, y + 50), new Vector2(x + 85, y + 30));
            Draw.Line(new Vector2(x + 90, y + 50), new Vector2(x + 100, y + 60));
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
            sun(Input.GetMouseX(), Input.GetMouseY());
            moon(Window.Width - Input.GetMouseX(), Window.Height - Input.GetMouseY());
            beach();
            loungeChair(230, 100);
            credits();

        }
    }

}
