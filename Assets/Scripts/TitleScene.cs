using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{
    [SerializeField]
    private GameObject m_playerControllerObject;
    private PlayerController m_playerController;
    [SerializeField]
    private GameObject m_titleUI;
    // Start is called before the first frame update
    void Awake()
    {
        m_playerController = Instantiate(m_playerControllerObject, null).GetComponent<PlayerController>();
        m_titleUI = Instantiate(m_titleUI, GameObject.FindWithTag("Canvas").transform);
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
}
