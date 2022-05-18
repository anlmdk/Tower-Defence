using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Create Enemy Type")]
public class EnemyType : ScriptableObject
{
    public string enemyName;
    public float enemySpeed;
    public float enemyMaxHP;
    public Color enemyColor;
}
