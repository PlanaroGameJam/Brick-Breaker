using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*============================================
 * �T�v�F�Q�[�����ɉe������萔�𒲐��ł���悤�ɂ��邽�߂̃N���X
 =============================================*/
public static class Parameter
{
    // �{�[���̏������x
    public static Vector2 BALL_INIT_VELOCITY = new Vector2(-2.0f, -2.0f);
    // �u���b�N�̃T�C�Y
    public static Vector3 BLOCK_SIZE = Vector3.one;
    // �p�h���̃T�C�Y
    public static readonly Vector3 PADDLE_SIZE = new Vector3(1.5f, 1.5f, 1.0f);
    // �{�[���̃T�C�Y
    public static Vector3 BALL_SIZE = Vector3.one;
    // �W���X�g����̃T�C�Y
    public static Vector3 JUST_RELEASE_SIZE = Vector3.zero;
    // ��������
    public static float LIMIT_TIME = 60.0f;
    // ���݂̎���
    public static float CURRENT_TIME = LIMIT_TIME;
    // �u���b�N�Ƀq�b�g�����ۂ̉��Z�X�R�A
    public static int HIT_BLOCK_SCORE = 200;
    // �p�h�����u���b�N�ɐG�ꂽ�ۂ̃X�R�A������(���t���[��)
    public static int DECREASE_SCORE_AMOUNT = 1;
    // �{�[���̍Œᑬ�x
    public static Vector2 BALL_MIN_VELOCITY = new Vector2(-1.0f, -1.0f);
    // �{�[�������˂���ۂ̑��x�{��
    public static float BALL_BOUND_VELOCITY_MULTIPLY = 0.9f;
    // �p�h�����p���[�`���[�W���s���ۂ̃��x���㏸�Ԋu
    public static float PADDLE_LEVEL_UP_INTERVAL = 0.5f;
    // �p�h�����p���[�`���[�W�����Ă���Œ��̑��x�{��
    public static float PADDLE_CHARGE_VELOCITY_MULTIPLY = 1.0f;
    // �{�[���̍ő僌�x��
    public static int BALL_MAX_LEVEL = 10;
    // �{�[���̔��˂ɐ��������ꍇ�̑��x�{��
    public static float SUCCESS_TO_REFLECT_BALL_VELOCITY_MULTIPLY = 1.5f;

    // ���݂̃X�R�A
    public static int CURRENT_SCORE = 0;
    // ���݂̃n�C�X�R�A
    public static int CURRENT_HIGH_SCORE = 0;
    // �X�e�[�W�̒���(���S�̃u���b�N�̈ʒu)
    public static readonly Vector2 STAGE_CENTER = Vector2.zero;
    // �u���b�N�̔z�u�Ԋu
    public static readonly Vector2 BLOCK_POSITION_INTERVAL = new Vector2(0.2f, 0.2f);
    // �J�E���g�_�E���b��
    public static float COUNT_DOWN_SECOND = 3.0f;
}
