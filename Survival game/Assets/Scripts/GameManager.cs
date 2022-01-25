using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        if (GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
    }

    // Ressources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    // References
    public Player player;
    public Weapon weapon;
    public FloatingTextManager floatingTextManager;

    // Logic
    public int pesos;
    public int wood;
    public int stone;
    public int experience;

    // Floating text
    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }

    // Upgrade weapon
    public bool TryUpgradeWeapon()
    {
        // Is weapon max level?
        if (weaponPrices.Count <= weapon.weaponLevel)
            return false;

        if(pesos >= weaponPrices[weapon.weaponLevel])
        {
            pesos -= weaponPrices[weapon.weaponLevel];
            weapon.UpgradeWeapon();
            return true;
        }
        return false;
    }

    // Save state
    /*
     * INT preferedSkin
     * INT pesos
     * INT wood
     * INT stone
     * INT experience
     * INT weaponLevel
     */

    public void SaveState()
    {
        string s = "";

        s += "0" + "|";
        s += pesos.ToString() + "|";
        s += wood.ToString() + "|";
        s += stone.ToString() + "|";
        s += experience.ToString() + "|";
        s += "0";

        PlayerPrefs.SetString("SaveState", s);
    }
    public void LoadState(Scene s, LoadSceneMode mode)
    {
        if (!PlayerPrefs.HasKey("SaveState"))
            return;

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        // Change player skin
        pesos = int.Parse(data[1]);
        wood = int.Parse(data[2]);
        stone = int.Parse(data[3]);
        experience = int.Parse(data[4]);
        // Change the weapon level

        Debug.Log("LoadState");
    }

    /*internal void ShowText(string v1, int v2, Color magenta, Vector3 position, Vector3 vector3, float v3)
    {
        throw new NotImplementedException();
    }*/
}
