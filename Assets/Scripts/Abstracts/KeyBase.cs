using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class KeyBase : MonoBehaviour, IKey
{

    [SerializeField]
    GameObject door;

    [SerializeField]
    Color color;

    public abstract void OnTriggerEnter(Collider other);

    public abstract void Vanish();

    public GameObject GetDoor()
    {
        return door;
    }
    
    public Color GetColor()
    {
        return color;
    }
}
