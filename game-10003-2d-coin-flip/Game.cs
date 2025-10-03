// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;

// The namespace your code is in.
namespace MohawkGame2D
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Place your variables here:
        public void background()
        {
            Window.ClearBackground(Color.Black);
        }
        public void skybox()
        {
            Draw.FillColor = new Color(255, 0, 0, 155);
            Draw.Square(0, 0, 400);
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
            skybox();
            Vector2 sunPos = Input.GetMousePosition();
            // To do: Find a way to create a new colour and set said colour based on mouse position between 2 colours
            // Idea: Can I affect alpha of colour? (Yes you can) If so, I can make 3 layers of background and 

        }
    }

}
