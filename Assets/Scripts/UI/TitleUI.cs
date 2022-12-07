using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class TitleUI : MonoBehaviour
{
    [SerializeField]
    private Button m_startButton;
    [SerializeField]
    private Button m_howToPlayButton;

    private TitleScene m_titleScene;

    void Awake()
    {
        m_titleScene = GameObject.FindWithTag("Scene").GetComponent<TitleScene>();
        m_startButton.onClick.AddListener(Start_Click);
        m_howToPlayButton.onClick.AddListener(HowToPlay_Click);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Start_Click()
    {
        SoundPlayer.PlaySFX_With_Scene(eSFX.CLICK, "Play");
        m_titleScene.PlayerController.Disable();
    }

    private void HowToPlay_Click()
    {
        SoundPlayer.PlaySFX_With_Scene(eSFX.CLICK, "Tutorial");
        m_titleScene.PlayerController.Disable();
    }

}
