using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScoreRank", menuName = "MyScriptable/CreateScoreRank")]
public class ScoreRank : ScriptableObject
{
    [SerializeField]
    private string m_rank;
    [SerializeField]
    private int m_conditionScore;
    [SerializeField]
    private string m_rankComment;

    public string Rank => m_rank;
    public int ConditionScore => m_conditionScore;
    public string RankComment => m_rankComment;

}
