using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public int startWeaponID;
    [SerializeField] private Weapon[] WeaponsList;
    private int PlayerXP = 0;

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
        Debug.Log(PlayerXP);
    }
}
