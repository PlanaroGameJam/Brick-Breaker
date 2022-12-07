using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Countdown : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI m_countDownText;
    private float m_second = Parameter.COUNT_DOWN_SECOND;
    // Start is called before the first frame update
    void Awake()
    {
        m_countDownText.text = $"{((int)m_second + 1)}";
    }

    // Update is called once per frame
    public void Execute()
    {
        if(IsFinish())
        {
            m_countDownText.text = string.Empty;
            return;
        }
        m_second -= Time.deltaTime;
        m_countDownText.text = $"{((int)m_second + 1)}";
    }

    public bool IsFinish()
    {
        return m_second <= 0.0f;
    }
}
