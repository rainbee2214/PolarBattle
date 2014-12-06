using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
    public static GameController controller;

    #region Properties
    private int sphereSize = 20;
    public int SphereSize
    {
        get { return sphereSize; }
        set { sphereSize += value; }
    }
    #endregion

    void Awake()
    {
        //if control is not set, set it to this one and allow it to persist
        if (controller == null)
        {
            DontDestroyOnLoad(gameObject);
            controller = this;
        }
        //else if control exists and it isn't this instance, destroy this instance
        else if (controller != this)
        {
            //Debug.Log("Game control already exists, deleting this new one");
            Destroy(gameObject);
        }
    }

	void Start () 
	{
	}

	void Update () 
	{
	
	}
}
