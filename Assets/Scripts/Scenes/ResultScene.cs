using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultScene : MonoBehaviour
{
    [SerializeField]
    private GameObject m_resultUIObject;
    private ResultUI m_resultUI;
    [SerializeField]
    private GameObject m_soundManagerObject;

    // Start is called before the first frame update
    void Awake()
    {
        Cursor.visible = true;
        m_resultUI = Instantiate(m_resultUIObject, GameObject.FindWithTag("Canvas").transform).GetComponent<ResultUI>();
        m_soundManagerObject = Instantiate(m_soundManagerObject, null);
        SoundPlayer.SetUp(m_soundManagerObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
