using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public int startWeaponID;
    [SerializeField] private Weapon[] WeaponsList;

    private void Start()
    {
        WeaponsList[startWeaponID].LevelUp();
    }

}
