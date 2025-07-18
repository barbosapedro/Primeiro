using UnityEngine;
using TMPro;

[System.Serializable]
public class Upgrade
{
    public string name;
    public double baseCost = 10;
    public double gps = 1;
    public int level = 0;

    public double CurrentCost() => baseCost * Mathf.Pow(1.15f, level);
}


public class UpdateManager : MonoBehaviour
{
    public Upgrade upgrade;
    public TextMeshProUGUI costTxt;
    public TextMeshProUGUI levelTxt;


    void Start()
    {
        RefreshUI();
    }

    public void Buy()
    {
        double cost = upgrade.CurrentCost();

        if (GameManager.instance.gold < cost)
            return;

        GameManager.instance.gold -= cost;
        upgrade.level++;

        GameManager.instance.UpdateGoldPerSec();
        RefreshUI();
    }

    public double TotalGPS()
    {
        return upgrade.level * upgrade.gps;
    }

    void RefreshUI()
    {
        costTxt.text = "Custo: " + upgrade.CurrentCost().ToString("0");
        levelTxt.text = "Lvl " + upgrade.level;
    }
}
