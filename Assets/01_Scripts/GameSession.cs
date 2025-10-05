using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    public static int LeftScore;
    public static int RightScore;
    public static string Winner;

    public static void Reset()
    {
        LeftScore = 0;
        RightScore = 0;
        Winner = string.Empty;
    }
}
