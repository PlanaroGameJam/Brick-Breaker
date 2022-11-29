using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    List<GameObject> m_blocks = new List<GameObject>();

    // Start is called before the first frame update
    void Awake()
    {
        m_blocks = GameObject.FindGameObjectsWithTag("Block").ToList();
        foreach (var blockObject in m_blocks)
        {
            var block = blockObject.GetComponent<Block>();
            block.SetColor(m_levelColor[block.GetLevel()]);
        }

        m_blocks.ForEach(blockObject => blockObject.transform.SetParent(transform, true));
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var blockObject in m_blocks)
        {
            var block = blockObject.GetComponent<Block>();
            if (block.GetLevel() <= 0)
            {
                continue;
            }
            block.SetColor(m_levelColor[block.GetLevel()]);
        }
        var remove = m_blocks.FindAll(blockObject => blockObject.GetComponent<Block>().GetLevel() <= 0);
        m_blocks.RemoveAll(blockObject => blockObject.GetComponent<Block>().GetLevel() <= 0);
        remove.ForEach(obj => Destroy(obj));
    }


    /*============================================
     * 概要：全てのブロックが壊れているか
     * 条件：ブロックの個数が0か
     =============================================*/
    public bool IsAllBreak()
    {
        return m_blocks.Count == 0;
    }
}
