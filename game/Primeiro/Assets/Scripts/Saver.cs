using UnityEngine;

public static class Saver
{
    public static void Save()
    {
        PlayerPrefs.SetString("Gold", GameManager.instance.gold.ToString());
        PlayerPrefs.SetInt("upgradeLevel", GameManager.instance.updateManager.upgrade.level);
        PlayerPrefs.Save();
    }

    public static void Load()
    {
        if (PlayerPrefs.HasKey("Gold"))
        {
            double gold = double.Parse(PlayerPrefs.GetString("Gold"));
            GameManager.instance.gold = gold;
        }

        if (PlayerPrefs.HasKey("upgradeLevel"))
        {
            int level = PlayerPrefs.GetInt("upgradeLevel");
            GameManager.instance.updateManager.upgrade.level = level;
        }

        GameManager.instance.UpdateGoldPerSec();
    }
}


