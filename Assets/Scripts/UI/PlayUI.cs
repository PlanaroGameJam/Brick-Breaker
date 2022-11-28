using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI m_scoreText;
    [SerializeField]
    private TextMeshProUGUI m_timeText;
    [SerializeField]
    private TextMeshProUGUI m_highScoreText;

    // Start is called before the first frame update
    void Awake()
    {
        m_scoreText.text = $"スコア：{Parameter.CURRENT_SCORE.ToString()}点";
        m_timeText.text = $"時間：{Parameter.LIMIT_TIME.ToString()}秒";
        m_highScoreText.text = $"ハイスコア：{Parameter.CURRENT_HIGH_SCORE.ToString()}点";
    }

    // Update is called once per frame
    void Update()
    {
        m_timeText.text = $"時間：{(Parameter.CURRENT_TIME -= Time.deltaTime).ToString("#.#")}秒";
    }
}
