using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScene : MonoBehaviour
{
    [SerializeField]
    private GameObject m_tutorialUIObject;
    private TutorialUI m_tutorialUI;
    [SerializeField]
    private GameObject m_soundManagerObject;

    void Awake()
    {
        m_tutorialUI = Instantiate(m_tutorialUIObject, GameObject.FindWithTag("Canvas").transform).GetComponent<TutorialUI>();
        m_soundManagerObject = Instantiate(m_soundManagerObject, null);
        SoundPlayer.SetUp(m_soundManagerObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
