using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace dodge;

public class Rect2F
{
     public Vector2 Pos;
     public Vector2 Size;
     public Rect2F(float x, float y, float w, float h)
     {
         Pos = new Vector2(x, y);
         Size = new Vector2(w, h);
     }
     public bool Overlap(Rect2F rect)
     {
         return Vector2.Distance(Pos, rect.Pos) < ((Size.X + rect.Size.X) / 2);
     }
}
