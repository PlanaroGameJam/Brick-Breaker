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
        m_scoreText.text = $"�X�R�A�F{Parameter.CURRENT_SCORE.ToString()}�_";
        m_timeText.text = $"���ԁF{Parameter.LIMIT_TIME.ToString()}�b";
        m_highScoreText.text = $"�n�C�X�R�A�F{Parameter.CURRENT_HIGH_SCORE.ToString()}�_";
    }

    // Update is called once per frame
    void Update()
    {
        m_timeText.text = $"���ԁF{(Parameter.CURRENT_TIME -= Time.deltaTime).ToString("#.#")}�b";
    }
}
