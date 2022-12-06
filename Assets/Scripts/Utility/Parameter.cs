using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*============================================
 * 概要：ゲーム内に影響する定数を調整できるようにするためのクラス
 =============================================*/
public static class Parameter
{
    // ボールの初期速度
    public static Vector2 BALL_INIT_VELOCITY = new Vector2(-2.0f, -2.0f);
    // ブロックのサイズ
    public static Vector3 BLOCK_SIZE = Vector3.one;
    // パドルのサイズ
    public static readonly Vector3 PADDLE_SIZE = new Vector3(1.5f, 1.5f, 1.0f);
    // ボールのサイズ
    public static Vector3 BALL_SIZE = Vector3.one;
    // ジャスト判定のサイズ
    public static Vector3 JUST_RELEASE_SIZE = Vector3.zero;
    // 制限時間
    public static float LIMIT_TIME = 60.0f;
    // 現在の時間
    public static float CURRENT_TIME = LIMIT_TIME;
    // ブロックにヒットした際の加算スコア
    public static int HIT_BLOCK_SCORE = 200;
    // パドルがブロックに触れた際のスコア減少量(毎フレーム)
    public static int DECREASE_SCORE_AMOUNT = 1;
    // ボールの最低速度
    public static Vector2 BALL_MIN_VELOCITY = new Vector2(-1.0f, -1.0f);
    // ボールが反射する際の速度倍率
    public static float BALL_BOUND_VELOCITY_MULTIPLY = 0.9f;
    // パドルがパワーチャージを行う際のレベル上昇間隔
    public static float PADDLE_LEVEL_UP_INTERVAL = 0.5f;
    // パドルがパワーチャージをしている最中の速度倍率
    public static float PADDLE_CHARGE_VELOCITY_MULTIPLY = 1.0f;
    // ボールの最大レベル
    public static int BALL_MAX_LEVEL = 10;
    // ボールの反射に成功した場合の速度倍率
    public static float SUCCESS_TO_REFLECT_BALL_VELOCITY_MULTIPLY = 1.5f;

    // 現在のスコア
    public static int CURRENT_SCORE = 0;
    // 現在のハイスコア
    public static int CURRENT_HIGH_SCORE = 0;
    // ステージの中央(中心のブロックの位置)
    public static readonly Vector2 STAGE_CENTER = Vector2.zero;
    // ブロックの配置間隔
    public static readonly Vector2 BLOCK_POSITION_INTERVAL = new Vector2(0.2f, 0.2f);
    // カウントダウン秒数
    public static float COUNT_DOWN_SECOND = 3.0f;
}
