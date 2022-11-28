using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*============================================
 * �T�v�F�Q�[�����ɉe������萔�𒲐��ł���悤�ɂ��邽�߂̃N���X
 =============================================*/
public static class Parameter
{
    // �{�[���̏������x
    public static Vector2 BALL_INIT_VELOCITY = new Vector2(-5.0f, -5.0f);
    // �u���b�N�̃T�C�Y
    public static Vector3 BLOCK_SIZE = Vector3.zero;
    // �p�h���̃T�C�Y
    public static Vector3 PADDLE_SIZE = Vector3.zero;
    // �{�[���̃T�C�Y
    public static Vector3 BALL_SIZE = Vector3.zero;
    // �W���X�g����̃T�C�Y
    public static Vector3 JUST_RELEASE_SIZE = Vector3.zero;
    // ��������
    public static float LIMIT_TIME = 60.0f;
    // ���݂̎���
    public static float CURRENT_TIME = LIMIT_TIME;
    // �u���b�N����ꂽ�ۂ̉��Z�X�R�A
    public static int BREAK_BLOCK_SCORE = 200;
    // �p�h�����u���b�N�ɐG�ꂽ�ۂ̃X�R�A������(���t���[��)
    public static int DECREASE_SCORE_AMOUNT = 1;
    // �{�[���̍Œᑬ�x
    public static Vector2 BALL_MIN_VELOCITY = new Vector2(1.0f, 1.0f);
    // �{�[�������˂���ۂ̑��x�{��
    public static float BALL_BOUND_VELOCITY_MULTIPLY = 0.9f;
    // �p�h�����p���[�`���[�W���s���ۂ̃��x���㏸�Ԋu
    public static float PADDLE_LEVEL_UP_INTERVAL = 0.5f;
    // �p�h�����p���[�`���[�W�����Ă���Œ��̑��x�{��
    public static float PADDLE_CHARGE_VELOCITY_MULTIPLY = 1.0f;
    // �{�[���̍ő僌�x��
    public static int BALL_MAX_LEVEL = 10;
    // ���݂̃X�R�A
    public static int CURRENT_SCORE = 0;
    // ���݂̃n�C�X�R�A
    public static int CURRENT_HIGH_SCORE = 0;
    // �X�e�[�W�̊J�n�ʒu(��ԍ���̃u���b�N�̈ʒu)
    public static Vector2 START_STAGE_POSITION = new Vector2(-4.0f, -2.0f);
    // �u���b�N�̔z�u�Ԋu
    public static Vector2 BLOCK_POSITION_INTERVAL = new Vector2(0.5f, 0.5f);
}
