using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AlienBase : MonoBehaviour
{
    public float moveSpeed;
    //public float chaseRange;
    public float attackRange;
    public float attackCooldown;
    public float attackDamage;
    public float health = 100f;
    public float DeathTimer= 3f;
    public int score = 50;
    
    public Animator animator;

    protected float cooldownTimer;
    protected float currentHealth;

    protected Transform player;
    protected bool isAlive=true;
    protected float distance;



    protected virtual void Start()
    {
        currentHealth = health;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    protected virtual void Update()
    {
        distance = Vector3.Distance(transform.position, player.position);

        if (distance <= attackRange)
        {

            if (cooldownTimer <= 0)

            {
                animator.SetTrigger("attack");
                Attack();

                cooldownTimer = attackCooldown;

            }

        }

        // else if (distance <= chaseRange && isAlive)
        else if (isAlive)
        {
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            if (!stateInfo.IsName("Attack")) 
            {
                ChasePlayer();
            }

        }

        cooldownTimer -= Time.deltaTime;
    }

    protected void ChasePlayer()
    {
        animator.SetBool("isWalking",true);
        // transform.LookAt(player);
        // transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

        Vector3 targetPosition = new Vector3(player.position.x, transform.position.y, player.position.z);
        transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

    }

     public virtual void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0 && isAlive)
        {   
            Die();
        }
    }

    protected virtual void Die()
    {
        LevelManager.Instance.UpdateScore(score);
        isAlive = false;
        Destroy(gameObject.GetComponent<Collider>());
        animator.SetTrigger("isDead");
        Destroy(gameObject,DeathTimer);
    }

    protected abstract void Attack();
}

