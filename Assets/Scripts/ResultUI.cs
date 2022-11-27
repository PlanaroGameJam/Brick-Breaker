using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI m_currentScoreText;
    [SerializeField]
    private TextMeshProUGUI m_currentRankText;
    [SerializeField]
    private TextMeshProUGUI m_currentRankCommentText;

    [SerializeField]
    private Button m_restartButton;
    [SerializeField]
    private Button m_exitButton;

    // Start is called before the first frame update
    void Awake()
    {
        m_restartButton.onClick.AddListener(Restart_Click);
        m_exitButton.onClick.AddListener(Exit_Click);
        SetResult();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void SetResult()
    {
        m_currentScoreText.text = $"スコア：{0}点";
        m_currentRankText.text = "";
        m_currentRankCommentText.text = "";
    }

    private void Restart_Click()
    {
        SceneManager.LoadSceneAsync("Play");
    }

    private void Exit_Click()
    {
        SceneManager.LoadSceneAsync("Title");
    }
}
