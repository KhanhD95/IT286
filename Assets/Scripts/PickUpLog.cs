using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpLog : MonoBehaviour
{
    private bool mouseOver = false;
    public int lengthBar = 150;
    public int widthBar = 25;
    private InvetoryManager ManageScript;

    public void OnMouseOver()
    {
        mouseOver = true;
    }

    public void OnMouseExit()
    {
        mouseOver = false;
    }

    public void OnGUI()
    {
        if (mouseOver == true)
            GUI.Box(new Rect(200, 20, lengthBar, widthBar), "Pick Up Wood");
    }

    public void OnMouseDown()
    {
        Destroy(gameObject);

        ManageScript = GameObject.Find("Player").GetComponent<InvetoryManager>();

        ManageScript.logCollected = true;
    }

}
