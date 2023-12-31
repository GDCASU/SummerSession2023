using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyForward : MonoBehaviour
{
    [SerializeField] float speed = 1f;

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
}
