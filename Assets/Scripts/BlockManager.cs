using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    Dictionary<int, Color> m_levelColor = new Dictionary<int, Color>
    {
        {1, Color.blue },
        {2, Color.yellow},
        {3, Color.green},
        {4, new Color(1.0f,0.0f,1.0f)},
        {5, Color.red},
    };
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
