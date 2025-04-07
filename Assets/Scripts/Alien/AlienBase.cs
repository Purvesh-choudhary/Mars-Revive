using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AlienBase : MonoBehaviour
{
    public float moveSpeed;
    public float chaseRange;
    public float attackRange;
    public float attackCooldown;
    public int attackDamage;
    public float health = 100f;

    protected float cooldownTimer;
    protected float currentHealth;

    protected Transform player;

    protected virtual void Start()
    {
        currentHealth = health;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    protected virtual void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= attackRange)

        {

            if (cooldownTimer <= 0)

            {

                Attack();

                cooldownTimer = attackCooldown;

            }

        }

        else if (distance <= chaseRange)

        {

            ChasePlayer();

        }

        cooldownTimer -= Time.deltaTime;
    }

    protected void ChasePlayer()
    {
        transform.LookAt(player);
        transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
    }

     public virtual void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }

    protected abstract void Attack(); // override in child
}

