using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField]float rateOfFire;
    [SerializeField]Projectile projectile;
    [SerializeField] AudioController audioFire;
    [SerializeField] AudioController audioReload;
    [SerializeField] Transform hand;
  
  
    public WeaponReloader Reloader;

   Transform muzzle;

    float nextFireAllowed;
   public  bool canFire;

  
    void Awake()
    {
        muzzle = transform.Find("Muzzle");

        Reloader = GetComponent<WeaponReloader>();

    }

    void Start()
    {
        transform.SetParent(hand);
    }


    public void  Reload()
    {
        if (Reloader == null)
            return;
        Reloader.Reload();
        audioReload.Play();
    }

    public virtual void Fire()
    {
        
        canFire = false;
        if (Time.time < nextFireAllowed)
            return;

        if(Reloader != null)
        {
            if (Reloader.IsReloading)
                return;
            if (Reloader.RoundsRemainingInClip == 0)
                return;

            Reloader.TakeFromClip(1);
        }

        nextFireAllowed = Time.time + rateOfFire;

        Instantiate(projectile, muzzle.position, muzzle.rotation);
        print("Firing" + Time.time);
        audioFire.Play();
        canFire = true;
    }
	
}
