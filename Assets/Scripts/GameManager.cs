using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float maxPlayerHp, currentPlayerHp;

    public static GameManager instance; // Singleton yapısı oluşturma
    public GameObject upgradeMenu;

    Camera cam;
    TowerType selectedTower;
    public LayerMask mask;
    public float gold = 100;
    public Text goldText;
    public Image hpBar;
    bool isPaused, isDead;
    public GameObject pausePanel, deathPanel;
    Filler[] fills;

    void Start()
    {
        if (instance == null)
        {
            instance = this; // Singleton boş ise bu game manageri kullansın
        }
        else
        {
            Destroy(gameObject); // Singleton dolu ise yeni oluşturmasın kendini yok etsin
        }
        fills = FindObjectsOfType<Filler>();
        cam = Camera.main;
        currentPlayerHp = maxPlayerHp;
    }
    void UpdateGold()
    {
        goldText.text = "" + gold;
        foreach(var item in fills)
        {
            item.UpdateAmount(gold);
        }
    }
    void Update()
    {
        if (!isDead)
        {
            if (!EventSystem.current.IsPointerOverGameObject()) // ui üzerinde iken raycast atmaması için
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                    //Ray ray = cam.ScreenPointToRay(new Vector2(Screen.width/2, Screen.height/2));
                    //Fps oyununda ekran oranını ikiye bölüp her çözünürlükte tam orta noktaya ışın yollamasını sağlar.
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit, 3000, mask))
                    {
                        if (selectedTower != null)
                        {
                            if (CheckGold(25))
                            {
                                if (hit.transform.TryGetComponent(out TowerSlot TS))
                                {
                                    if (TS.PlaceTower(selectedTower))
                                    {
                                        SpendGold(25);
                                    }
                                }
                            }
                        }
                    }
                }
                if (Input.GetMouseButtonDown(1))
                {
                    Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit, 3000, mask))
                    {
                        if (hit.transform.TryGetComponent(out TowerSlot TS))
                        {
                            TS.SellTower();
                        }
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Pause();
            }
        }
    }
    public void SelectedTower(TowerType tower)
    {
        selectedTower = tower;
    }
    TowerSlot activeTS;
    public void ActivateUpgradeMenu(TowerSlot TS)
    {
        activeTS = TS;
        upgradeMenu.SetActive(true);
    }
    public void UpgradeTower()
    {
        if (activeTS != null)
        {
            activeTS.UpgradeTower();
        }
    }
    public void AddGold(float amount)
    {
        gold += amount;
        UpdateGold();
    }
    public bool SpendGold(float amount)
    {
        if (gold >= amount)
        {
            gold -= amount;
            UpdateGold();
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool CheckGold(float amount)
    {
        if (gold >= amount)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void TakeDamage(float amount)
    {
        currentPlayerHp -= amount;
        if (currentPlayerHp <= 0)
        {
            currentPlayerHp = 0;
            Die();
        }
        hpBar.fillAmount = currentPlayerHp / maxPlayerHp;
    }
    public void Pause()
    {
        if (!isPaused)
        {
            isPaused = true;
            Time.timeScale = 0;
            pausePanel.SetActive(true);
        }
        else
        {
            isPaused = false;
            Time.timeScale = 1;
            pausePanel.SetActive(false);
        }
    }
    public void Die()
    {
        isDead = true;
        deathPanel.SetActive(true);
    }
}
