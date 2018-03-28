using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : Destructable
{
    [SerializeField] float inSeconds;
    public override void Die()
    {
        base.Die();
        GameManager.Instance.Respawner.Despawn(gameObject, inSeconds);
        print("REKT!");
    }

    void OnEnable()
    {
        Reset();
    }


    public override void TakenDamage(float amount)
    {
        
        base.TakenDamage(amount);
        print("Remaining:" + HitPointRemaining);

    }

}
