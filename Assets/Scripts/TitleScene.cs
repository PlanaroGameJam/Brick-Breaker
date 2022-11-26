using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScene : MonoBehaviour
{
    [SerializeField]
    private GameObject m_playerControllerObject;
    private PlayerController m_playerController;
    [SerializeField]
    private GameObject m_titleUI;
    private Button m_startButton;
    private Button m_howToPlayButton;
    // Start is called before the first frame update
    void Awake()
    {
        m_playerController = Instantiate(m_playerControllerObject, null).GetComponent<PlayerController>();
        m_titleUI = Instantiate(m_titleUI, GameObject.FindWithTag("Canvas").transform);
        m_startButton = m_titleUI.GetComponentsInChildren<Button>().First();
        m_howToPlayButton = m_titleUI.GetComponentsInChildren<Button>().Last();

        m_startButton.onClick.AddListener(Start_Click);
        m_howToPlayButton.onClick.AddListener(HowToPlay_Click);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Enter(InputAction.CallbackContext context)
    {
        m_playerController.Disable();
        SceneManager.LoadSceneAsync("Tutorial");
    }

    private void Start_Click()
    {
        m_playerController.Disable();
        SceneManager.LoadSceneAsync("Play");
    }

    private void HowToPlay_Click()
    {
        m_playerController.Disable();
        SceneManager.LoadSceneAsync("Tutorial");
    }

}
