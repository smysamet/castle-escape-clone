using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySlider : KeyBase
{
    [SerializeField]
    Renderer buttonRenderer;

    // Start is called before the first frame update
    void Start()
    {
        buttonRenderer.material.SetColor("_Color", GetColor());
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // open the door
            StartCoroutine(GetDoor().GetComponent<DoorSlider>().UnlockDoor());
            
        }
    }

    public override void Vanish()
    {
        buttonRenderer.material.SetColor("_Color", Color.black);
        GetComponent<BoxCollider>().enabled = false;
    }

    
}
