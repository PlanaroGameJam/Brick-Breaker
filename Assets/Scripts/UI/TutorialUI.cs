using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialUI : MonoBehaviour
{
    private int m_pageIndex = 0;
    [SerializeField]
    List<Sprite> m_pageSprites;
    [SerializeField]
    private Image m_pageObject;
    [SerializeField]
    private Button m_leftButton;
    [SerializeField]
    private Button m_rightButton;
    [SerializeField]
    private Button m_closeButton;
    [SerializeField]
    private TextMeshProUGUI m_pageText;

    // Start is called before the first frame update
    void Awake()
    {
        m_leftButton.onClick.AddListener(Left_Click);
        m_rightButton.onClick.AddListener(Right_Click);
        m_closeButton.onClick.AddListener(Close_Click);
        SetSprite();
        SetButtonState();
        SetNowPage();
    }

    private void Left_Click()
    {
        m_pageIndex = System.Math.Clamp(--m_pageIndex, 0, m_pageSprites.Count - 1);
        SetSprite();
        SetButtonState();
        SetNowPage();
    }

    private void Right_Click()
    {
        m_pageIndex = System.Math.Clamp(++m_pageIndex, 0, m_pageSprites.Count - 1);
        SetSprite();
        SetButtonState();
        SetNowPage();
    }

    private void Close_Click()
    {
        //m_playerController.Disable();
        SceneManager.LoadSceneAsync("Title");
    }

    private void SetSprite()
    {
        m_pageObject.sprite = m_pageSprites[m_pageIndex];
    }

    private void SetButtonState()
    {
        m_leftButton.interactable = m_pageIndex == 0 ? false : true;
        m_rightButton.interactable = m_pageIndex == m_pageSprites.Count - 1 ? false : true;
    }

    private void SetNowPage()
    {
        m_pageText.text = $"{m_pageIndex + 1} / {m_pageSprites.Count}";
    }

}
