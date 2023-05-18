using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour, IEnemy
{

    [SerializeField]
    int level;

    [SerializeField]
    GameObject labelText;

    public abstract void Attack();

    public abstract void Die();

    public abstract void DeSpawn();

    public int GetLevel()
    {
        return level;
    }

    public GameObject GetLabelText()
    {
        return labelText;
    }

    public void SetLevelLabel()
    {
        labelText.GetComponent<TextMeshProUGUI>().text = "Lv. " + level.ToString();
    }
}
