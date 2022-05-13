using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class State 
{
    // Класс для хранения основных параметров о состоянии игры
    public static bool finishing;
    public static bool falling;
    public static string totalTime;
    public enum GameState
    {
        none, victory, defeat
    }
    public static GameState state;
}
