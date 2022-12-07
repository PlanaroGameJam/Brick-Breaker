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
        {4, Color.magenta},
        {5, Color.red},
    };

    List<Block> m_blocks;

    // Start is called before the first frame update
    void Awake()
    {
        m_blocks = FindObjectsOfType<Block>().ToList();
        m_blocks.ForEach(block => block.transform.SetParent(transform, true));
        foreach (var block in m_blocks)
        {
            if (block.GetLevel() <= 0) continue;
            block.SetColor(m_levelColor[block.GetLevel()]);
        }
    }

    // Update is called once per frame
    public void Execute()
    {
        m_blocks.RemoveAll(block => block == null);

        foreach (var block in m_blocks)
        {
            block.Execute();
            if (block.GetLevel() <= 0) continue;
            block.SetColor(m_levelColor[block.GetLevel()]);
        }
    }

    /*============================================
     * 概要：全てのブロックが壊れているか
     * 条件：ブロックの個数が0か
     =============================================*/
    public bool IsAllBreak()
    {
        return m_blocks.Count == 0;
    }

    public List<Block> GetList()
    {
        return m_blocks;
    }
}