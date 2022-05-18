using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    public float maxHP, currentHP;
    public Image hpBar;

    void Start()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(float amount)
    {
        currentHP -= amount;
        if (currentHP <= 0)
        {
            currentHP = 0;
            Die();
        }
        hpBar.fillAmount = currentHP / maxHP;
    }

    void Die()
    {
        GameManager.instance.AddGold(5);
        Destroy(gameObject);
    }
}
