using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace dodge;

public class Field {
    public float SpawnInterval {get; set;} = 1.5f;
    public float SpawnLeft {get; set;} = 1.5f;
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

    public void Update(Game1 game, GameTime dt) {
        
    }

    public void Render(Game1 game, GameTime dt) {
    }
}
