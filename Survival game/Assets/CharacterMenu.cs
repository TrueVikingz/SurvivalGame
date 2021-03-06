using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterMenu : MonoBehaviour
{
    // Text fields
    public Text levelText, hitpointText, goldText, woodText, stoneText, upgradeCostText, xpText;

    // Logic
    private int currentCharacterSelection = 0;
    public Image characterSelectionSprite;
    public Image weaponSprite;
    public RectTransform xpBar;

    // Character Selection
    public void OnArrowClick(bool right)
    {
        if (right)
        {
            currentCharacterSelection++;

            // If we went too far away
            if (currentCharacterSelection == GameManager.instance.playerSprites.Count)
                currentCharacterSelection = 0;

            OnSelectionChanged();
        }
        else
        {
            currentCharacterSelection--;

            // If we went too far away
            if (currentCharacterSelection < 0)
                currentCharacterSelection = GameManager.instance.playerSprites.Count - 1;

            OnSelectionChanged();
        }
    }
    private void OnSelectionChanged()
    {
        characterSelectionSprite.sprite = GameManager.instance.playerSprites[currentCharacterSelection];
    }

    // Weapon Upgrade
    public void OnUpgradeClick()
    {
        if (GameManager.instance.TryUpgradeWeapon())
            UpdateMenu();
    }

    // Update the character Information
    public void UpdateMenu()
    {
        // Weapon
        weaponSprite.sprite = GameManager.instance.weaponSprites[GameManager.instance.weapon.weaponLevel];
        upgradeCostText.text = "NOT IMPLEMENTED";


        // Meta
        levelText.text = "NOT IMPLEMENTED";
        hitpointText.text = GameManager.instance.player.hitpoint.ToString();
        goldText.text = GameManager.instance.gold.ToString();
        woodText.text = GameManager.instance.wood.ToString();
        stoneText.text = GameManager.instance.stone.ToString();

        // xp Bar
        xpText.text = "NOT IMPLEMENTED";
        xpBar.localScale = new Vector3(0.5f, 0, 0);
    }
    public void ExitGame()
    {
        SceneManager.LoadScene("Main_Start");
    }
}
