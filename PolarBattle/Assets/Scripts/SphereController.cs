using UnityEngine;
using System.Collections;

public class SphereController : MonoBehaviour 
{
    float currentSize;

	void Start () 
    {
        currentSize = GameController.controller.SphereSize;
        SetScale(2 * currentSize);
	}
	

	void Update () 
    {
        if (currentSize != GameController.controller.SphereSize)
        {
            currentSize = GameController.controller.SphereSize;
            SetScale(2 * currentSize);
        }
	}

    void SetScale(float scale)
    {
        transform.localScale = new Vector3(scale, scale, scale);
    }
}
