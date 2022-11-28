using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*============================================
 * 概要：ゲーム内に影響する定数を調整できるようにするためのクラス
 =============================================*/
public static class Parameter
{
    // ボールの初期速度
    public static Vector2 BALL_INIT_VELOCITY = new Vector2(-5.0f, -5.0f);
    // ブロックのサイズ
    public static Vector3 BLOCK_SIZE = Vector3.zero;
    // パドルのサイズ
    public static Vector3 PADDLE_SIZE = Vector3.zero;
    // ボールのサイズ
    public static Vector3 BALL_SIZE = Vector3.zero;
    // ジャスト判定のサイズ
    public static Vector3 JUST_RELEASE_SIZE = Vector3.zero;
    // 制限時間
    public static float LIMIT_TIME = 60.0f;
    // 現在の時間
    public static float CURRENT_TIME = LIMIT_TIME;
    // ブロックが壊れた際の加算スコア
    public static int BREAK_BLOCK_SCORE = 200;
    // パドルがブロックに触れた際のスコア減少量(毎フレーム)
    public static int DECREASE_SCORE_AMOUNT = 1;
    // ボールの最低速度
    public static Vector2 BALL_MIN_VELOCITY = new Vector2(1.0f, 1.0f);
    // ボールが反射する際の速度倍率
    public static float BALL_BOUND_VELOCITY_MULTIPLY = 0.9f;
    // パドルがパワーチャージを行う際のレベル上昇間隔
    public static float PADDLE_LEVEL_UP_INTERVAL = 0.5f;
    // パドルがパワーチャージをしている最中の速度倍率
    public static float PADDLE_CHARGE_VELOCITY_MULTIPLY = 1.0f;
    // ボールの最大レベル
    public static int BALL_MAX_LEVEL = 10;
    // 現在のスコア
    public static int CURRENT_SCORE = 0;
    // 現在のハイスコア
    public static int CURRENT_HIGH_SCORE = 0;
    // ステージの開始位置(一番左上のブロックの位置)
    public static Vector2 START_STAGE_POSITION = new Vector2(-4.0f, -2.0f);
    // ブロックの配置間隔
    public static Vector2 BLOCK_POSITION_INTERVAL = new Vector2(0.5f, 0.5f);
}
