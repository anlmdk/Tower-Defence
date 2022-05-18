using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSlot : MonoBehaviour
{
    GameObject placedTower;

    TowerType myTowerType;
    int upgradeLevel = 0;

    public bool PlaceTower(TowerType towerType)
    {
        if (placedTower == null)
        {
            myTowerType = towerType;
            GameObject instedTower = Instantiate(towerType.towerLevel1, transform);
            placedTower = instedTower;
            return true;
        }
        else
        {
            GameManager.instance.ActivateUpgradeMenu(this);
            return false;
        }
    }
    public void UpgradeTower()
    {
        if (upgradeLevel == 1)
        {
            Destroy(placedTower);
            GameObject instedTower = Instantiate(myTowerType.towerLevel2, transform);
            placedTower = instedTower;
        }
        else if (upgradeLevel == 2)
        {
            Destroy(placedTower);
            GameObject instedTower = Instantiate(myTowerType.towerLevel3, transform);
            placedTower = instedTower;
        }
        upgradeLevel++;
    }
    public void SellTower()
    {
        upgradeLevel = 0;
        if (placedTower != null)
        {
            Destroy(placedTower);
            GameManager.instance.AddGold(10);
            placedTower = null;
        }
    }
}
