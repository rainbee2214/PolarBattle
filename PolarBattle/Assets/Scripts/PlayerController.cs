using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

    List<GameObject> bullets;
    int currentBullet;

    void Start () 
	{
        target = GameController.controller.gameObject;

        target.transform.position = new Vector3(0f, 0f, 0f);
        position = origin;

        //Convert theta and phi to radians
        theta = theta * (Mathf.PI / 180);
        phi = phi * (Mathf.PI / 180);
        //MakeBullets();
	}

    void Update()
    {
        transform.LookAt(target.transform.position);
    }

	void FixedUpdate () 
	{
        if (Mathf.Abs(Input.GetAxis("Vertical")) > 0 || Mathf.Abs(Input.GetAxis("Horizontal")) > 0) Move();
        //if (Input.GetButtonDown("Fire")) Fire();
    }

    void Move()
    {
        if (rho != GameController.controller.SphereSize) rho = GameController.controller.SphereSize;
        phi += Input.GetAxis("Vertical") * (speed/6);
        theta -= Input.GetAxis("Horizontal") * (speed/8);

        position.x = rho * Mathf.Sin(phi) * Mathf.Cos(theta);
        position.y = rho * Mathf.Sin(phi) * Mathf.Sin(theta);
        position.z = rho * Mathf.Cos(phi);

        transform.position = position;
    }
    void Fire()
    {
        bullets[currentBullet].transform.position = transform.position;
        bullets[currentBullet].SetActive(true);
        bullets[currentBullet].transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        bullets[currentBullet].rigidbody.AddForce(Vector3.zero); // Not really working at all
        currentBullet++; if (currentBullet >= bullets.Count) currentBullet = 0;
    }

    void MakeBullets()
    {
        bullets = new List<GameObject>();
        for (int i = 0; i < 10; i++)
        {
            bullets.Add(Instantiate(Resources.Load("Bullet", typeof(GameObject))) as GameObject);
            bullets[i].gameObject.SetActive(false);
        }
    }
}
