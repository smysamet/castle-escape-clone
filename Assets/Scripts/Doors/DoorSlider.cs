using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSlider : DoorBase
{
    [SerializeField]
    Renderer cubeRenderer;


    // Start is called before the first frame update
    void Start()
    {
        cubeRenderer.material.SetColor("_Color", this.GetColor());
    }

    public IEnumerator UnlockDoor()
    {
        while (transform.localScale.x > 0.1)
        {
            transform.localScale -= new Vector3(0.01f, 0, 0);
            yield return new WaitForSeconds(0.01f);
        }
        GetKey().GetComponent<KeySlider>().Vanish();
    }

    public IEnumerator LockDoor()
    {
        while(transform.localScale.x < 1.0)
        {
            transform.localScale += new Vector3(0.01f, 0, 0);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
