using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DoorBase : MonoBehaviour, IDoor
{

    [SerializeField]
    GameObject key;

    [SerializeField]
    Color color;


    public Color GetColor()
    {
        return color;
    }

    public GameObject GetKey()
    {
        return key;
    }

}
