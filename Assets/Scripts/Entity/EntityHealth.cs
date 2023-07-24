using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHealth : MonoBehaviour
{
    [SerializeField] public int health = 5;
    [SerializeField] private float hitInvulnerabilityTime = 0f;

    private bool invulnerable = false;      // Used anytime the Entity is invunerable to attacks (hits, shield, evade, etc.)

    private void OnTriggerEnter(Collider hitCollider)
    {
        DamageDealer damageDealer = hitCollider.GetComponent<DamageDealer>();

        if (!invulnerable)
        {
            if (damageDealer != null)       // If a damage dealer hit the Entity
            {
                if (damageDealer.tag != gameObject.tag)     // If projectiles are of same faction of Entity
                {
                    TakeDamage(damageDealer.damage);
                    damageDealer.Hit();
                }
            }
        }
    }

    private void TakeDamage(int damage)         // Change health value with damage passed in; wait for invTime
    {
        MakeInvulnerable(hitInvulnerabilityTime);
        health -= damage;
        if (health <= 0)
        {
            Death();
        }
    }

    public void MakeInvulnerable(float invTime)         // Called ANY time the Entity becomes invulnerable
    {
        if (!invulnerable) {
            StartCoroutine(InvulnerableCo(invTime));
        }
    }

    private IEnumerator InvulnerableCo(float invTime)
    {
        invulnerable = true;
        yield return new WaitForSeconds(invTime);
        invulnerable = false;
    }

    protected virtual void Death()
    {
        Destroy(gameObject);
    }
}