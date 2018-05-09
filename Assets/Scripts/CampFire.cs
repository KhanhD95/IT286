using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampFire : MonoBehaviour
{
    public HealthBar healthBar;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            healthBar.health += 10f;
    }

}
