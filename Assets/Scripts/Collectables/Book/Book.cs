using UnityEngine;

public class Book : CollectableBase
{

    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
    }


    public override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerController>().IncreaseLevel(GetLevelAmount());
            Vanish();
            GetComponent<BoxCollider>().enabled = false;
        }
    }

    public override void Vanish()
    {
        this.animator.SetTrigger("IsVanishing");
    }
}
