using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour 
{
    #region Properties
    private int health;
    public int Health
    {
        get { return health; }
        set { health += value; }
    }
    #endregion

    public float rho;
    public float phi;
    public float theta;

    Vector3 origin = Vector3.zero;
    Vector3 position;
    Vector3 nextPosition;


    public float speed = 0.1f;

    float nextMoveTime;
    float moveRange = 3f;

    public bool move;
    void Start()
    {
        position = origin;

        //Convert theta and phi to radians
        theta = theta * (Mathf.PI / 180);
        phi = phi * (Mathf.PI / 180);

        rho = GameController.controller.SphereSize;
    }

    void FixedUpdate()
    {
        if (move)
        {
            float step = Time.time / 1000f;
            Vector3 startingPosition = transform.position;
            if (transform.position == nextPosition) ;
            else nextPosition = Move(Random.Range(-moveRange, moveRange), Random.Range(-moveRange, moveRange));
            transform.position = Vector3.Slerp(transform.position, nextPosition, step);
        }

    }

    Vector3 Move(float hMoveAmount, float vMoveAmount)
    {
        if (rho != GameController.controller.SphereSize) rho = GameController.controller.SphereSize;
        theta -= hMoveAmount * (speed);
        phi -= vMoveAmount * (speed);

        position.x = rho * Mathf.Sin(phi) * Mathf.Cos(theta);
        position.y = rho * Mathf.Sin(phi) * Mathf.Sin(theta);
        position.z = rho * Mathf.Cos(phi);

        return position;
    }
}
