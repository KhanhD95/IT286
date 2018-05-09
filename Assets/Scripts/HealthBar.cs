using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
   Image healthBar;
    float maxHealth = 100f;
    public float health;

    //GameObject go = GetComponent<Image>();

    //GameObject go = new GameObject();
    // Use this for initialization
    void Start()
    {
        
        healthBar = GetComponent<Image>();
        
        health = maxHealth;

        /*GameObject imageObject = GameObject.FindGameObjectWithTag("hp");
        if (imageObject != null)
        {
            healthBar = imageObject.GetComponent<Image>();
        }

        health = maxHealth;*/
    }

    // Update is called once per frame
    void Update ()
    {
        //Debug.Log("health value ");
        healthBar.fillAmount = health / maxHealth;

        /*if (health < 0)
        {
            Destroy(gameObject);
        }*/
    }
}
