using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    [SerializeField]
    private List<ScoreRank> m_scoreRankList;

    private ScoreRank m_currentScoreRank;
    private ScoreRank m_nextScoreRank;

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
        int currentCount = m_scoreRankList.Count(scoreRank => Parameter.CURRENT_SCORE >= scoreRank.ConditionScore);
        int nextCount = m_scoreRankList.Count(scoreRank => Parameter.CURRENT_SCORE < scoreRank.ConditionScore);

        m_currentScoreText.text = $"スコア：{Parameter.CURRENT_SCORE.ToString()}点";

        // 現在のスコアを示すものがない場合
        if (currentCount == 0)
        {
            m_nextScoreRank = m_scoreRankList.FindAll(scoreRank => Parameter.CURRENT_SCORE < scoreRank.ConditionScore).First();
            m_currentRankText.text = $"";
            m_currentRankCommentText.text =
                $"手を抜いたね？\n" +
                $"{m_nextScoreRank.Rank}ランクまであと{(m_nextScoreRank.ConditionScore - Parameter.CURRENT_SCORE).ToString()}点！";
        }
        // 次のスコアを示すものがない場合
        else if (nextCount == 0)
        {
            m_currentScoreRank = m_scoreRankList.FindAll(scoreRank => Parameter.CURRENT_SCORE >= scoreRank.ConditionScore).Last();
            m_currentRankText.text = $"{m_currentScoreRank.Rank}";
            m_currentRankCommentText.text = $"{m_currentScoreRank.RankComment}";
        }
        // それ以外(通常時)
        else
        {
            m_currentScoreRank = m_scoreRankList.FindAll(scoreRank => Parameter.CURRENT_SCORE >= scoreRank.ConditionScore).Last();
            m_nextScoreRank = m_scoreRankList.FindAll(scoreRank => Parameter.CURRENT_SCORE < scoreRank.ConditionScore).First();

            m_currentRankText.text = $"{m_currentScoreRank.Rank}";
            m_currentRankCommentText.text =
                $"{m_currentScoreRank.RankComment}\n" +
                $"{m_nextScoreRank.Rank}ランクまであと{(m_nextScoreRank.ConditionScore - Parameter.CURRENT_SCORE).ToString()}点！";
        }
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
