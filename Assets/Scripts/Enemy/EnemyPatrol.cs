using UnityEngine;

public class EnemyPatrol : EnemyBase
{
    [SerializeField]
    GameObject path;

    // Move the path in a loop (end->start)
    public bool followPathInLoop;
    public bool startFollow;

    // Waypoint index that enemy will go next
    int nextWaypointIndex;

    // Next waypoint
    GameObject nextWaypoint;

    // Speed for moving between waypoints
    public float moveSpeed;

    Animator animator;

    void Start()
    {
        // set level text
        base.SetLevelLabel();

        // set target waypoint
        this.nextWaypoint = this.path.transform.GetChild(this.nextWaypointIndex).gameObject;

        this.animator = GetComponent<Animator>();
    }


    void Update()
    {

        if(this.startFollow) 
        {
            if (!this.animator.GetBool("IsRunning"))
            {
                this.animator.SetBool("IsRunning", true);
            }

            FollowPath();
        }
    }

    void FollowPath()
    {
        // move enemy from its current position to the next waypoint
        this.transform.position = Vector3.MoveTowards(this.transform.position, this.nextWaypoint.transform.position, this.moveSpeed * Time.deltaTime);

        // make enemy look at the next waypoint
        UpdateRotation();

        // check if enemy is at the nextWaypoint position
        if (this.transform.position == this.nextWaypoint.transform.position)
        {
            // update the nextWaypoint
            UpdateNextWaypoint();
        }
    }

    void UpdateRotation()
    {
        this.transform.LookAt(this.nextWaypoint.transform, Vector3.up);
    }

    void UpdateNextWaypoint()
    {
        this.nextWaypointIndex++;

        // control for out of bounds and path loop travel
        if (this.nextWaypointIndex >= this.path.transform.childCount)
        {
            if (this.followPathInLoop)
            {
                this.nextWaypointIndex = 0;
            }
            else
            {
                return;
            }
        }
        this.nextWaypoint = this.path.transform.GetChild(this.nextWaypointIndex).gameObject;
    }

    public override void Attack()
    {
        this.animator.SetTrigger("IsAttacking");

        // disable colliders so when player dies it wont play the animation again
        GetComponentInChildren<MeshCollider>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
    }

    public override void Die()
    {
        animator.SetTrigger("IsDying");

        // to stop it from following the path
        this.startFollow = false;

        // disable colliders so dying animation wont play more than once
        GetComponentInChildren<MeshCollider>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;

        Invoke("DeSpawn", 1.58f);
    }

    public override void DeSpawn()
    {
        Destroy(this.gameObject);
    }
}
