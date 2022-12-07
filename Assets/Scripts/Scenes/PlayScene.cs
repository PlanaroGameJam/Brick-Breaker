using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayScene : MonoBehaviour
{
    [SerializeField]
    private GameObject m_playerControllerObject;
    private PlayerController m_playerController;
    [SerializeField]
    private GameObject m_playUIObject;
    private PlayUI m_playUI;
    [SerializeField]
    private GameObject m_stageObject;
    [SerializeField]
    private GameObject m_blockManagerObject;
    private BlockManager m_blockManager;
    [SerializeField]
    private GameObject m_outOfDisplay;
    [SerializeField]
    private GameObject m_paddleObject;
    private Paddle m_paddle;
    [SerializeField]
    private GameObject m_ballObject;
    private Ball m_ball;
    [SerializeField]
    private GameObject m_soundManagerObject;
    [SerializeField]
    private GameObject m_countDownObject;
    private Countdown m_countDown;
    void Awake()
    {
        m_soundManagerObject = Instantiate(m_soundManagerObject, null);
        SoundPlayer.SetUp(m_soundManagerObject);
        m_stageObject = Instantiate(m_stageObject, transform);
        m_outOfDisplay = Instantiate(m_outOfDisplay, new Vector3(0.0f, -0.7f, 0.0f), Quaternion.identity, null);
        Instantiate(m_paddleObject, new Vector3(0.0f, -2.0f, 0.0f), Quaternion.identity, null).TryGetComponent(out m_paddle);
        Instantiate(m_ballObject, null).TryGetComponent(out m_ball);
        Instantiate(m_blockManagerObject, null).TryGetComponent(out m_blockManager);
        Instantiate(m_playerControllerObject, null).TryGetComponent(out m_playerController);
        Instantiate(m_countDownObject, GameObject.FindWithTag("Canvas").transform).TryGetComponent(out m_countDown);
        Instantiate(m_playUIObject, GameObject.FindWithTag("Canvas").transform).TryGetComponent(out m_playUI);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;

        Parameter.CURRENT_SCORE = 0;
        Parameter.CURRENT_TIME = Parameter.LIMIT_TIME;

        SoundPlayer.PlayBGM(eBGM.TITLE);
    }

    // Update is called once per frame
    void Update()
    {
        m_countDown.Execute();
        if (!m_countDown.IsFinish()) return;
        m_ball.Execute();
        m_blockManager.Execute();

        m_playUI.Execute();
        if(IsGameOver() || IsClear())
        {
            m_playerController.Disable();
            SceneManager.LoadSceneAsync("Result");
        };
    }

    private void FixedUpdate()
    {
        if (!m_countDown.IsFinish()) return;
        m_paddle.Execute();
    }

    private bool IsGameOver()
    {
        return m_ball.IsOutOfRange() || Parameter.CURRENT_TIME <= 0.0f;
    }

    private bool IsClear()
    {
        return m_blockManager.IsAllBreak();
    }
}
