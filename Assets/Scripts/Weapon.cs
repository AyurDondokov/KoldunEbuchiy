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
        gameObject.SetActive(true);
        level++;
        OtherValues();
        damage = DamageList[level];
        cooldown = CooldownList[level];
        StartCoroutine(AttackTimer());
    }

    public int GetLevel() 
    {
        return level;
    }

    protected IEnumerator AttackTimer() 
    {
        while (true) 
        {
            Attack();
            yield return new WaitForSeconds(cooldown);
        }
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
