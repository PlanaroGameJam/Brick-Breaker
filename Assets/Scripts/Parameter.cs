using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Parameter
{
    public static Vector2 BALL_INIT_VELOCITY = new Vector2(-5.0f, -5.0f);
    public static Vector3 BLOCK_SIZE = Vector3.zero;
    public static Vector3 PADDLE_SIZE = Vector3.zero;
    public static Vector3 BALL_SIZE = Vector3.zero;
    public static Vector3 JUST_RELEASE_SIZE = Vector3.zero;
    public static float LIMIT_TIME = 60.0f;
    public static int BREAK_BLOCK_SCORE = 200;
    public static int DECREASE_SCORE_AMOUNT = 1;
    public static Vector2 BALL_MIN_VELOCITY = new Vector2(1.0f, 1.0f);
    public static float BALL_BOUND_VELOCITY_MULTIPLY = 0.9f;
    public static float PADDLE_LEVEL_UP_INTERVAL = 0.5f;
    public static float PADDLE_CHARGE_VELOCITY_MULTIPLY = 1.0f;
    public static int BALL_MAX_LEVEL = 10;

}
