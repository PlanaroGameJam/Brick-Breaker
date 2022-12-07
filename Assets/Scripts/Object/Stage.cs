using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    private List<int[]> m_stage;
    [SerializeField]
    private GameObject m_blockObject;
    void Awake()
    {
        m_stage = LoadStage.Load("Stage");
        foreach (int[] m_line in m_stage){
            Debug.Log( String.Join(", ", m_line) );
        }

        for(int i = 0; i < m_stage.Count; i++)
        {
            for (int j = 0; j < m_stage[i].Length; j++)
            {
                Vector3 block_position = Vector3.zero;
                float px = (float) j - m_stage[i].Length / 2;
                float py = (float) -i + m_stage.Count / 2;

                block_position.x = Parameter.STAGE_CENTER.x + px * (m_blockObject.transform.localScale.x + Parameter.BLOCK_POSITION_INTERVAL.x);
                block_position.y = Parameter.STAGE_CENTER.y + py * (m_blockObject.transform.localScale.y + Parameter.BLOCK_POSITION_INTERVAL.y);

                if (m_stage[i][j] <= 0) continue;
                var block = Instantiate(m_blockObject, block_position, Quaternion.identity, null).GetComponent<Block>();
                block.SetLevel(m_stage[i][j]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
