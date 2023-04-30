using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    private Vector3 TargetPosition = Vector3.zero;
    private float Speed = 0f;

    public void SetTarget(float distance, float speed)
    {
        TargetPosition = transform.position + new Vector3(distance, 0, 0);
        Speed = speed;
    }

    private void Update()
    {
        if(transform.position.Equals(TargetPosition))
        {
            gameObject.SetActive(false);
        }

        transform.position = Vector3.MoveTowards(transform.position, TargetPosition, Speed * Time.deltaTime);
    }
}
