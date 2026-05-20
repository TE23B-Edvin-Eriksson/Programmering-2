using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Numerics;

class Program
{
    static void Main()
    {
        const int screenWidth = 800;
        const int screenHeight = 600;
        Raylib.InitWindow(screenWidth, screenHeight, "Asteroids");
        Raylib.SetTargetFPS(60);

        // Ship
        Vector2 shipPos = new Vector2(screenWidth / 2, screenHeight / 2);
        float shipRotation = 0;
        float shipSpeed = 0;

        // Asteroids
        List<Asteroid> asteroids = new List<Asteroid>();
        Random rand = new Random();

        for (int i = 0; i < 5; i++)
        {
            asteroids.Add(new Asteroid(rand.Next(0, screenWidth), rand.Next(0, screenHeight), rand.Next(1, 3)));
        }

        while (!Raylib.WindowShouldClose())
        {
            // Update ship
            if (Raylib.IsKeyDown(KeyboardKey.Left) || Raylib.IsKeyDown(KeyboardKey.A)) shipRotation -= 5;
            if (Raylib.IsKeyDown(KeyboardKey.Right ) || Raylib.IsKeyDown(KeyboardKey.D)) shipRotation += 5;
            if (Raylib.IsKeyDown(KeyboardKey.Up) || Raylib.IsKeyDown(KeyboardKey.W))
            {
                shipSpeed += 0.1f;
                if (shipSpeed > 5) shipSpeed = 5;
            }
            else
            {
                shipSpeed *= 0.98f;
            }

            Vector2 direction = new Vector2((float)Math.Cos(shipRotation * Math.PI / 180), (float)Math.Sin(shipRotation * Math.PI / 180));
            shipPos += direction * shipSpeed;

            // Wrap around screen
            if (shipPos.X < 0) shipPos.X = screenWidth;
            if (shipPos.X > screenWidth) shipPos.X = 0;
            if (shipPos.Y < 0) shipPos.Y = screenHeight;
            if (shipPos.Y > screenHeight) shipPos.Y = 0;

            // Update asteroids
            foreach (var asteroid in asteroids)
            {
                asteroid.Update();
            }

            // Draw
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);

            // Draw ship
            Vector2 shipTip = shipPos + direction * 20;
            Vector2 shipLeft = shipPos + new Vector2((float)Math.Cos((shipRotation - 135) * Math.PI / 180), (float)Math.Sin((shipRotation - 135) * Math.PI / 180)) * 15;
            Vector2 shipRight = shipPos + new Vector2((float)Math.Cos((shipRotation + 135) * Math.PI / 180), (float)Math.Sin((shipRotation + 135) * Math.PI / 180)) * 15;
            Raylib.DrawTriangle(shipTip, shipLeft, shipRight, Color.White);

            // Draw asteroids
            foreach (var asteroid in asteroids)
            {
                asteroid.Draw();
            }

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}

class Asteroid
{
    public Vector2 Position { get; set; }
    public Vector2 Velocity { get; set; }
    public float Size { get; set; }

    public Asteroid(float x, float y, float size)
    {
        Position = new Vector2(x, y);
        Velocity = new Vector2((float)(new Random().NextDouble() * 4 - 2), (float)(new Random().NextDouble() * 4 - 2));
        Size = size * 20;
    }

    public void Update()
    {
        Position += Velocity;
        // Wrap around screen
        Vector2 pos = Position;
        if (pos.X < 0) pos.X = 800;
        if (pos.X > 800) pos.X = 0;
        if (pos.Y < 0) pos.Y = 600;
        if (pos.Y > 600) pos.Y = 0;
        Position = pos;
    }

    public void Draw()
    {
        Raylib.DrawCircleV(Position, Size, Color.Gray);
    }
}