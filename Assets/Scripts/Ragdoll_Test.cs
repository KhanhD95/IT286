using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll_Test : Destructable
{
    public Animator animator;
    private Rigidbody[] bodyParts;
    private MoveController moveController;
    public GameObject ammoDrop;

    void Start()
    {
        bodyParts = transform.GetComponentsInChildren<Rigidbody>();
        EnableRagdoll(false);
        moveController = GetComponent<MoveController>();
    }

    public override void Die()
    {
        base.Die();
        EnableRagdoll(true);
        animator.enabled = false;
        Instantiate(ammoDrop, transform.position, Quaternion.identity); //your dropped ammo item
    }

    void Update()
    {
        if (!IsAlive)
            return;

        animator.SetFloat("Vertical", 1);
        moveController.Move(new Vector2(1, 0));
    }


    void EnableRagdoll(bool value)
    {
        for (int i = 0; i < bodyParts.Length; i++)
        {
            bodyParts[i].isKinematic = !value;
        }
    }

    
  /* void OnDestroy() //called, when enemy will be destroyed
    {
        Instantiate(ammoDrop,transform.position,Quaternion.identity); //your dropped item

    }*/


}
