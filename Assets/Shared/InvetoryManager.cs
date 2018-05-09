using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvetoryManager : MonoBehaviour
{
    public bool logCollected = false;
    private bool showGUI = false;

    public Transform campFire;
    public Transform player;

    void Update()
    {
        if (logCollected == true)
            showGUI = true;

        if (logCollected == true && Input.GetKey(KeyCode.E))
        MakeCampFire();
        
    }

    void OnGUI()
    {
        if (showGUI == true)
            GUI.Box(new Rect(200, 200, 200, 25), "Press E to Craft CampFire");
    }

    void MakeCampFire()
    {
        Instantiate(campFire, player.transform.position, Quaternion.identity);
        logCollected = false;
        showGUI = false;
    }


}
