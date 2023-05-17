using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeSystem : MonoBehaviour
{
    [SerializeField] private int countOfWeapons;
    [SerializeField] private int countOfUpgrades;
    [Header("UI")]
    [SerializeField] private Image[] ButtonsIcons;
    [SerializeField] private TextMeshProUGUI[] ButtonsNames;
    [Header("Values")]
    [SerializeField] private int[] weaponIds;
    [SerializeField] private Sprite[] weaponsIcons;
    [SerializeField] private string[] weaponsNames;

    private Player player { get { return FindObjectOfType<Player>(); } }

    public void TogglePanel() 
    {
        gameObject.SetActive(!gameObject.activeSelf);
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
    }

    public void RandomizeButtons() 
    {
        int max = countOfWeapons;
        int[] arr = new int[countOfWeapons];

        for (int i = 0; i < countOfWeapons; i++)
            arr[i] = i;

        for (int i = 0; i < countOfUpgrades; i++)
        {
            int index = Random.Range(0, max);
            weaponIds[i] = arr[index];
            arr[index] = arr[max-1];
            max--;
        }

        SetUI();
    }

    public void UpgradeWeapon(int buttonId) 
    {
        player.WeaponsList[weaponIds[buttonId]].LevelUp();
    }

    private void SetUI()
    {
        for (int i = 0; i < countOfUpgrades; i++)
        {
            ButtonsIcons[i].sprite = weaponsIcons[weaponIds[i]];
            ButtonsNames[i].text = weaponsNames[weaponIds[i]];
        }
    }
}
