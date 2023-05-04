using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected int level;

    [SerializeField] protected int[] DamageList;
    [SerializeField] protected float[] CooldownList;

    protected int damage;
    protected float cooldown;

    public void LevelUp() 
    {
        level++;
        damage = DamageList[level];
        cooldown = CooldownList[level];
        OtherValues();
    }

    protected IEnumerator AttackTimer() 
    {
        while (true) 
        {
            Attack();
            yield return new WaitForSeconds(cooldown);
        }
    }

    protected void Start()
    {
        StartCoroutine(AttackTimer());
    }

    protected virtual void Attack()
    {
        // Attack script
    }
    protected virtual void OtherValues()
    {
        // Attack script
    }
}
