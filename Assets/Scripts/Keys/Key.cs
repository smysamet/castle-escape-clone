using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : KeyBase
{

    Animator animator;

    void Start()
    {
        // set the color of the key
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.SetColor("_Color", GetColor());


        this.animator = GetComponent<Animator>();    
    }


    public override void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Vanish();
            GetDoor().GetComponent<Door>().UnlockDoor();
        }
    }

    public override void Vanish()
    {
        animator.SetTrigger("IsVanishing");
    }
}
