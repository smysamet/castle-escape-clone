using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    int level;
    [SerializeField]
    float speed;

    [SerializeField]
    FloatingJoystick joystick;

    [SerializeField]
    GameObject levelLabel;

    Animator animator;

    Vector3 movementVector;

    bool alive;

    void Start()
    {
        animator = GetComponent<Animator>();
        movementVector = new Vector3(0,0,0);

        UpdateLabelText();

        alive = true;
    }


    private void FixedUpdate()
    {
        if (alive)
        {
            Move();
        }

    }


    void Move()
    {
        movementVector.x = -joystick.Horizontal;
        movementVector.z = -joystick.Vertical;

        if (movementVector.magnitude > 0)
        {
            animator.SetBool("IsRunning", true);
            transform.Translate(movementVector * Time.deltaTime * speed, Space.World);
            if (movementVector != Vector3.zero)
            {
                transform.forward = movementVector;
            }

        }
        else
        {
            animator.SetBool("IsRunning", false);
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            int enemyLevel = collision.gameObject.GetComponent<EnemyBase>().GetLevel();

            if (this.level > enemyLevel)
            {
                Attack();
                collision.gameObject.GetComponent<EnemyBase>().Die();
            }
            else
            {
                // play enemy attack animation
                collision.gameObject.GetComponent<EnemyBase>().Attack();

                // play player die animation
                Die();
            }
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "WinArea")
        {
            StartCoroutine(ChangeLevelToFeaturesScene());
        }

        else if(other.gameObject.tag == "EnemyFov")
        {
            int enemyLevel = other.gameObject.GetComponentInParent<EnemyBase>().GetLevel();
            if (this.level > enemyLevel)
            {
                Attack();
                other.gameObject.GetComponentInParent<EnemyBase>().Die();
            }
            else
            {
                other.gameObject.GetComponentInParent<EnemyBase>().Attack();
                Die();
            }
        }
    }

    public void IncreaseLevel(int amount)
    {
        if(amount <= 0)
        {
            return;
        }

        this.level += amount;
        UpdateLabelText();
    }

    void Attack()
    {
        animator.SetTrigger("IsAttacking");
    }

    void Die()
    {
        animator.SetTrigger("IsDying");
        alive = false;

        // restart the current level
        StartCoroutine(RestartCurrentLevel());
    }


    public int GetLevel()
    {
        return this.level;
    }

    void UpdateLabelText() 
    {
        levelLabel.gameObject.GetComponent<TextMeshProUGUI>().text = "Lv. " + level.ToString();
    }


    IEnumerator RestartCurrentLevel()
    {
        yield return new WaitForSeconds(1.6f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator ChangeLevelToFeaturesScene()
    {
        yield return new WaitForSeconds(1.6f);
        SceneManager.LoadScene("Features");
    }

}
