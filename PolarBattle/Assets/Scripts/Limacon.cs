using UnityEngine;
using System.Collections;

public class Limacon : MonoBehaviour 
{
    public float rho;
    public float phi;
    public float theta;
    public float piStep;

    Vector3 origin = Vector3.zero;
    Vector3 position;
    Vector3 nextPosition;
    
    public float speed = 0.00001f;

    public bool move;
    void Start()
    {
        position = origin;
        theta = Random.Range(1, 360);
        phi = Random.Range(1, 360);
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
            if (transform.position == nextPosition) Debug.Log("Arrived at next position.");
            else nextPosition = Move();
            transform.position = Vector3.Slerp(transform.position, nextPosition, step);
        }

    }

    Vector3 Move()
    {
        if (rho != GameController.controller.SphereSize) rho = GameController.controller.SphereSize;
        theta -= piStep * (speed);
        phi -= piStep/4f * (speed);

        position.x = rho * Mathf.Sin(phi) * Mathf.Cos(theta);
        position.y = rho * Mathf.Sin(phi) * Mathf.Sin(theta);
        position.z = rho * Mathf.Cos(phi);

        piStep += 0.0001f;
        return position;
    }
}
