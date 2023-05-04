using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveWeapon : Weapon
{

    [SerializeField] private float[] RangeList;
    [SerializeField] private LayerMask TargetLayer;

    private float range;

    [SerializeField] GameObject damageWave;

    protected override void OtherValues() 
    {
        range = RangeList[level];
    }
    protected override void Attack() 
    {
        Instantiate(damageWave, transform.position, Quaternion.identity).GetComponent<DamageWave>().Attack(range, TargetLayer, damage);
    }

}
