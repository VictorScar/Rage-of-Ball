using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class State 
{
    // ����� ��� �������� �������� ���������� � ��������� ����
    public static bool finishing;
    public static bool falling;
    public static string totalTime;
    public enum GameState
    {
        none, victory, defeat
    }
    public static GameState state;
}
