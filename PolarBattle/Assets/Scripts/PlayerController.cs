using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
    #region Properties
    private int score;
    public int Score
    {
        get { return score; }
        set { score += value; }
    }

    private bool isDead;
    public bool IsDead
    {
        get { return isDead; }
        set { isDead = value; }
    }

    private int level;
    public int Level
    {
        get { return level; }
        set { level += value; }
    }
    #endregion

	void Start () 
	{
	
	}

	void Update () 
	{
	
	}
}
