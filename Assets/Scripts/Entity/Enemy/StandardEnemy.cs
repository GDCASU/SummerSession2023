using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardEnemy : IEnemy
{
    // Values
    [SerializeField] float minReloadTime = 1f;
    [SerializeField] float maxReloadTime = 2f;

    float reloadTime;

    // Controls
    bool moveLeft = true;

    protected override void Start()
    {
        base.Start();

        ResetReload();
    }

    private void Update()
    {
        if (moveDown) return;

        Move();  // move
        TurnAround();   // Check turn around and do so

        // Gun gun shoot shoot. Reload go brrt. Then fire and reload.
        reloadTime -= Time.deltaTime;
        if(reloadTime <= 0f)
        {
            Fire();
            ResetReload();
        }
    }

    // Moves enemy
    protected override void Move()
    {
        if (moveLeft)
        {
            //transform.Translate(Vector3.left * Time.deltaTime * speed);
            transform.position = transform.position + new Vector3(-speed * Time.deltaTime, 0f, 0f);
            moveLeft = Camera.main.WorldToViewportPoint(transform.position).x > 0f;
        }
        else
        {   // Move right
            //transform.Translate(Vector3.right * Time.deltaTime * speed);
            transform.position = transform.position + new Vector3(speed * Time.deltaTime, 0f, 0f);
            moveLeft = Camera.main.WorldToViewportPoint(transform.position).x > 1f;
        }
    }

    void TurnAround()
    {
        if (playerTransform == null)
        {
            Destroy(gameObject);
            return;
        }

        if (playerTransform.position.y < transform.position.y && transform.rotation.eulerAngles.z == 180) transform.Rotate(Vector3.forward, -180);
        else if (playerTransform.position.y > transform.position.y && transform.rotation.eulerAngles.z == 0) transform.Rotate(Vector3.forward, 180);
        else return;

        moveLeft = !moveLeft;
    }

    // Sets reloadTime between minReloadTime and maxReloadTime
    void ResetReload()
    {
        reloadTime = Random.Range(minReloadTime, maxReloadTime);
        reloadTime += fireDelay;
    }
}
