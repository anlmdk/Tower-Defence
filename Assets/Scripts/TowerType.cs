using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "UpgradeTower")]
public class TowerType : ScriptableObject
{
    public string towerName;

    public GameObject towerLevel1;
    public GameObject towerLevel2;
    public GameObject towerLevel3;

    public float towerConstractionPrice;
    public float towerUpgrade1Price;
    public float towerUpgrade2Price;

    public float tower1SellPrice;
    public float tower2SellPrice;
    public float tower3SellPrice;
}
