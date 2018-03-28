using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoCounter : MonoBehaviour {

    // Use this for initialization
    [SerializeField] Text text;
    PlayerShoot playerShoot;
    WeaponReloader reloader;

    
	void Awake ()
    {
        GameManager.Instance.OnLocalPlayerJoined += HandleOnLocalPlayerJoined;
        
	}

    void HandleOnLocalPlayerJoined(Player player )
    {
        playerShoot = player.PlayerShoot;
        reloader = playerShoot.ActiveWeapon.Reloader;
        reloader.OnAmmoChanged += HandleOnAmmoChanged;
        //playerShoot.ActiveWeapon.reloader.OnAmmoChanged += HandleOnAmmoChanged;

    }

    void HandleOnAmmoChanged()
    {
        int amountInInvetory = reloader.RoundsRemainingInInventory;
        int amountInClip = reloader.RoundsRemainingInClip;
        text.text = string.Format("{0}/{1}", amountInClip, amountInInvetory);
    }

	
	// Update is called once per frame
	void Update () {
		
	}
}
