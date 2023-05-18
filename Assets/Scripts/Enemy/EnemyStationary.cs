using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStationary : EnemyBase
{

    Animator animator;

    void Start()
    {
        this.animator = GetComponent<Animator>();

        // set level text
        base.SetLevelLabel();
    }


    public override void Attack()
    {
        animator.SetTrigger("IsAttacking");
    }

    public override void Die()
    {
        animator.SetTrigger("IsDying");
        Invoke("DeSpawn", 1.58f);
    }

    public override void DeSpawn()
    {
        Destroy(this.gameObject);
    }
}
