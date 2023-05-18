using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Entity
{
    public int startWeaponID;
    [SerializeField] public Weapon[] WeaponsList;
    private int PlayerXP = 0;
    [SerializeField] private int XPtoNextLVL = 75;
    [SerializeField] Image xpBar;
    [SerializeField] private UpgradeSystem upgradeSystem;

    StageEventManager sEm;

    private void Start()
    {
        sEm = FindObjectOfType<StageEventManager>();
        WeaponsList[startWeaponID].LevelUp();
        foreach (Weapon weapon in WeaponsList)
            weapon.gameObject.SetActive((weapon.GetLevel() > 0));
                
        health = maxHealth;
    }

    public new void Die() 
    {
        Destroy(gameObject);
        drop();
        sEm.WinStage();
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

        upgradeSystem.TogglePanel();
        upgradeSystem.RandomizeButtons();
    }

    public void healByFood(int FoodHeal){
        health = health + FoodHeal < maxHealth ? health + FoodHeal : maxHealth;
    }
}
