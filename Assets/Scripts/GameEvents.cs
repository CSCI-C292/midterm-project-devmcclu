using System;

public static class GameEvents
{
    public static event EventHandler LevelFinished;

    public static void InvokeLevelFinished()
    {
       LevelFinished(null, EventArgs.Empty);
    }
}
