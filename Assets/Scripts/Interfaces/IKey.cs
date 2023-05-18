using UnityEngine;

public interface IKey
{
    public void OnTriggerEnter(Collider other);
    public void Vanish();
}
