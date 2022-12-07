using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultScene : MonoBehaviour
{
    [SerializeField]
    private GameObject m_resultUIObject;
    private ResultUI m_resultUI;

    // Start is called before the first frame update
    void Awake()
    {
        Cursor.visible = true;
        m_resultUI = Instantiate(m_resultUIObject, GameObject.FindWithTag("Canvas").transform).GetComponent<ResultUI>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
