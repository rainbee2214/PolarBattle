using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
    GameObject target;

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

    public float rho;
    public float phi;
    public float theta;

    Vector3 origin = new Vector3(0, 0, 0);
    Vector3 position;

    public float speed = 1;

    void Start () 
	{
        target = GameController.controller.gameObject;

        target.transform.position = new Vector3(0f, 0f, 0f);
        position = origin;

        //Convert theta and phi to radians
        theta = theta * (Mathf.PI / 180);
        phi = phi * (Mathf.PI / 180);
	}

	void Update () 
	{
        transform.LookAt(target.transform.position);
        if (Mathf.Abs(Input.GetAxis("Vertical")) > 0 || Mathf.Abs(Input.GetAxis("Horizontal")) > 0) Move();
	}

    void Move()
    {
        if (rho != GameController.controller.SphereSize) rho = GameController.controller.SphereSize;
        theta -= Input.GetAxis("Vertical") * (speed);
        phi -= Input.GetAxis("Horizontal") * (speed);

        position.x = rho * Mathf.Sin(phi) * Mathf.Cos(theta);
        position.y = rho * Mathf.Sin(phi) * Mathf.Sin(theta);
        position.z = rho * Mathf.Cos(phi);

        transform.position = position;

    }
}
