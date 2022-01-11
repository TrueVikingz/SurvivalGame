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
        SceneManager.sceneLoad += LoadState;
        DontDestroyOnLoad(gameObject);
    }

    // Ressources
    Public list<Sprite> playerSprites;
    Public list<Sprite> weeaponSprites;
    Public list<int> weaponPrice;
    Public list<int> xpTable;

    // References
    public Player player;

    //public weapon weapon...

    // Logic
    public int pesos;
    public int experience;

    // Save state
    /*
     * INT preferedSkin
     * INT pesos
     * INT experience
     * INT weaponLevel
     */

    public void SaveState()
    {
        string s = "";

        s += "0" + "|";
        s += pesos.ToString() + "|";
        s += experience.ToString() + "|";
        s += "0";

        Playerprefs.SetString("SaveState", s);
    }
    public void LoadState(Scene s, LoadSceneMode mode)
    {
        if (!PlayerPrefs.HasKey("SaveState"))
            return;

        string[] data = Playerprefs.GetString("SaveState").Split('|');

        // Change player skin
        pesos = int.Parse(data[1]);
        experience = int.Parse(data[2]);
        // Change the weapon level

        Debug.Log("LoadState");
    }
}
