using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Entity
{
    public int startWeaponID;
    [SerializeField] private Weapon[] WeaponsList;
    private int PlayerXP = 0;
    private int XPtoNextLVL = 75;
    [SerializeField] Image xpBar;

    private void Start()
    {
        WeaponsList[startWeaponID].LevelUp();
        foreach (Weapon weapon in WeaponsList)
            weapon.gameObject.SetActive((weapon.GetLevel() > 0));
                
        health = maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.GetComponent<Crystal>()){
           addXP(other.gameObject.GetComponent<Crystal>().xp);
           Destroy(other.gameObject);
        }
    }

    private void addXP(int xp){
        PlayerXP += xp;
        if (PlayerXP >= XPtoNextLVL)
            levelUP();
        xpBar.fillAmount = PlayerXP / (float)XPtoNextLVL;
    }

    private void levelUP(){
        PlayerXP -= XPtoNextLVL;
        XPtoNextLVL = (int)(XPtoNextLVL * 1.3f);
        maxHealth = (int)(maxHealth * 1.2f);
        health += (int)(maxHealth * 0.15f);

        
    }
}
