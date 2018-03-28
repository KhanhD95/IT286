using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponReloader : MonoBehaviour
{
    [SerializeField] int maxAmmo;
    [SerializeField] float reloadTime;
    [SerializeField] int clipSize;
    [SerializeField] Container inventory;
    [SerializeField] EWeaponType weaponType;

    public int usedAmmo;
    bool isReloading;
    System.Guid containerItemId;

    public event System.Action OnAmmoChanged;

    public int RoundsRemainingInClip
    {
        get
        {
            return clipSize - usedAmmo;
        }
    }

    public int RoundsRemainingInInventory
    {
        get
        {
            return inventory.GetAmountRemaining(containerItemId);
        }
    }


    public bool IsReloading
    {
        get
        {
            return isReloading;
        }
    }

    void Awake()
    {
        inventory.OnContainerReady += () =>
        {

            containerItemId = inventory.Add(weaponType.ToString(), maxAmmo);
        };
    }


    public void Reload()
    {
        if (isReloading)
            return;

        isReloading = true;
        GameManager.Instance.Timer.Add(() => {
            ExecuteReload(inventory.TakeFromContainer(containerItemId, clipSize - RoundsRemainingInClip));
        },reloadTime);

        
    }

    public void ExecuteReload(int amount)
    {
        print("RELOADING!");
        isReloading = false;
        usedAmmo -= amount;

        if (OnAmmoChanged != null)
        {
            OnAmmoChanged();
        }

    }


    public void TakeFromClip(int amount)
    {
        usedAmmo += amount;
        HandleOnAmmoChanged();
    }

    public void HandleOnAmmoChanged()
    {
        if (OnAmmoChanged != null)
        {
            OnAmmoChanged();
        }
    }



}
