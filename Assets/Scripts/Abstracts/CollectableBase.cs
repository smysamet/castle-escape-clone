using UnityEngine;

public abstract class CollectableBase : MonoBehaviour, ICollectable
{

    [SerializeField]
    int levelAmount;

    public abstract void OnTriggerEnter(Collider other);


    public int GetLevelAmount()
    {
        return levelAmount;
    }

    public abstract void Vanish();
}
