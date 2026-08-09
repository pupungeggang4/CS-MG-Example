using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace dodge;

public class Field
{
    public float SpawnInterval = 1.5f;
    public float SpawnLeft = 1.5f;
    public List<Bullet> Bullets;
    public Player Player;

    public Field()
    {
        Player = new Player();
        Bullets = new List<Bullet>();
        SpawnInterval = 1.5f;
        SpawnLeft = 1.5f;
    }

    public void Reset()
    {
        Player = new Player();
        Bullets = new List<Bullet>();
        SpawnInterval = 1.5f;
        SpawnLeft = 1.5f;
    }

    public void SpawnBullet()
    {
        int index = Random.Shared.Next(0, 4);
        int x = Random.Shared.Next(20, 780);
        int y = Random.Shared.Next(20, 580);
        float vx = 0, vy = 0;
        if (index == 0)
        {
            y = -20;
            vy = 1;
        }
        else if (index == 1)
        {
            x = -20;
            vx = 1;
        }
        else if (index == 2)
        {
            y = 620;
            vy = -1;
        }
        else if (index == 3)
        {
            x = 820;
            vx = -1;
        }
        Bullets.Add(new Bullet(x, y, 40, 40, vx, vy));
    }

    public void Update(Game1 game)
    {
        if (SpawnLeft < 0)
        {
            SpawnBullet();
            SpawnLeft = SpawnInterval;
        }
        else
        {
            SpawnLeft -= game.Dt;
        }
        for (int i = 0; i < Bullets.Count; i++)
        {
            Bullets[i].Update(game);
        }
        Player.Update(game);

        for (int i = 0; i < Bullets.Count; i++)
        {
            if (Player.Rect.Overlap(Bullets[i].Rect))
            {
                game.GameOver = true;
            }
        }
        for (int i = Bullets.Count - 1; i >= 0; i--)
        {
            if (Bullets[i].Rect.Pos.X > 840 || Bullets[i].Rect.Pos.X < -40 || Bullets[i].Rect.Pos.Y > 640 || Bullets[i].Rect.Pos.Y < -40)
            {
                Bullets.RemoveAt(i);
            }
        }
    }

    public void Render(Game1 game)
    {
        for (int i = 0; i < Bullets.Count; i++)
        {
            Bullets[i].Render(game);
        }
        Player.Render(game);
    }
}
