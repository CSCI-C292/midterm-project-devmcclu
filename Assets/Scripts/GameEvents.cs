using System;

public static class GameEvents
{
    public static event EventHandler LevelFinished;
    public static event EventHandler PlayerDied;

    public static void InvokeLevelFinished()
    {
       LevelFinished(null, EventArgs.Empty);
    }
    
    public static void InvokePlayerDied()
    {
       PlayerDied(null, EventArgs.Empty);
    }
}
