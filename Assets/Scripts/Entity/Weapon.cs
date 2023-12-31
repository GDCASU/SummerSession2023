using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Basic Properties")]
    [SerializeField] protected GameObject ProjectilePrefab;
    [SerializeField] protected float projectileSpeed = 100f;
    [SerializeField] protected float baseFireRate = 0.5f;
    [SerializeField] protected float projectileLifetime = 5f;

    [Header("Sounds")]
    [SerializeField] private AudioClip fireSound;

    protected bool isFiring;
    // Components
    protected Shooter shooter;

    private void Start()
    {
        shooter = GetComponentInParent<Shooter>();
    }

    public virtual void Fire() 
    {
        if (fireSound != null)
            AudioManager.instance?.PlaySFX(fireSound);
    }
}
