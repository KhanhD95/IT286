using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    Shooter[] weapons;
    public Shooter activeWeapon;

    public Shooter ActiveWeapon
    {
        get
        {
            return activeWeapon;
        }
    }

    void Awake()
    {
        
        weapons = transform.Find("Weapons").GetComponentsInChildren<Shooter>();
        if (weapons.Length > 0)
            Equip(0);
    }

    void Equip(int index)
    {
        activeWeapon = weapons[index];
    }

    void Update()
    {
        if(GameManager.Instance.InputController.Fire1)
        {
            activeWeapon.Fire();
        }
    }
}
