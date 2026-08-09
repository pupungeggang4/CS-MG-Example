using System;

using var game = new dodge.Game1();
try
{
    game.Run();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    Console.WriteLine(ex.StackTrace);
}
System.Environment.Exit(0);
