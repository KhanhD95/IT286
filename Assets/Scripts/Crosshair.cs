using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    [SerializeField]Texture2D image;
    [SerializeField]int size;
    
    //drawing on GUI
     void OnGUI()
    {
        //draw crosshair only when player is aiming
        if (GameManager.Instance.LocalPlayer.PlayerState.WeaponState == PlayerState.EWEAPONSTATE.AIMING || GameManager.Instance.LocalPlayer.PlayerState.WeaponState == PlayerState.EWEAPONSTATE.AIMEDFIRING)
        {
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
            screenPosition.y = Screen.height - screenPosition.y;
            GUI.DrawTexture(new Rect(screenPosition.x, screenPosition.y, size, size), image);
        }

    }



	
}
