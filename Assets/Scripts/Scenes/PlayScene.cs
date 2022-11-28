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
    [SerializeField]
    private GameObject m_stageObject;
    [SerializeField]
    private GameObject m_blockManagerObject;

    void Awake()
    {
        m_playerController = Instantiate(m_playerControllerObject, null).GetComponent<PlayerController>();
        Instantiate(m_playUIObject, GameObject.FindWithTag("Canvas").transform);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        m_stageObject = Instantiate(m_stageObject, transform);
        m_blockManagerObject = Instantiate(m_blockManagerObject, null);

    }

    // Update is called once per frame
    void Update()
    {
        if(IsGameOver())
        {
            m_playerController.Disable();
            SceneManager.LoadSceneAsync("Result");
        }
    }

    private bool IsGameOver()
    {
        return true;
    }


}
