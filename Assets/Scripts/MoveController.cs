using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    //public Rigidbody rb;

    public void Move(Vector3 direction)
    {

        //rb.AddForce((transform.forward * direction.x + transform.right * direction.z) *5);
        transform.position += transform.forward * direction.x * Time.deltaTime + transform.right * direction.y * Time.deltaTime;
    }

	
}
