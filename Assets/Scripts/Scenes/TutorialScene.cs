using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScene : MonoBehaviour
{
    [SerializeField]
    private GameObject m_tutorialUIObject;
    private TutorialUI m_tutorialUI;

    void Awake()
    {
        m_tutorialUI = Instantiate(m_tutorialUIObject, GameObject.FindWithTag("Canvas").transform).GetComponent<TutorialUI>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
