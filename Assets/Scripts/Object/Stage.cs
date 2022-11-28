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

        for(int i = 0; i < m_stage.Count; i++)
        {
            for (int j = 0; j < m_stage[i].Length; j++)
            {
                if (m_stage[i][j] <= 0) continue;
                var block = Instantiate(
                    m_blockObject,
                    new Vector3(Parameter.START_STAGE_POSITION.x + j * m_blockObject.transform.localScale.x + Parameter.BLOCK_POSITION_INTERVAL.x * j , -(Parameter.START_STAGE_POSITION.y + i * m_blockObject.transform.localScale.y + Parameter.BLOCK_POSITION_INTERVAL.y * i), 0.0f),
                    Quaternion.identity,
                    null).GetComponent<Block>();
                block.SetLevel(m_stage[i][j]);

            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
