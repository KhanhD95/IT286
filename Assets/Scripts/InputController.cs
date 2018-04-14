using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputController : MonoBehaviour
{
    public float Horizontal;
    public float Vertical;
    public Vector2 MouseInput;
    public bool Fire1;
    public bool Fire2;
    public bool Reload;
    public bool IsWalking;
    public bool IsSprinting;
    public bool isCrouched;
    public bool isJumping;

    void Update()
    {
        Vertical = Input.GetAxis("Vertical");
        Horizontal = Input.GetAxis("Horizontal");
        MouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        Fire1 = Input.GetButton("Fire1");
        Fire2 = Input.GetButton("Fire2");
        Reload = Input.GetKey(KeyCode.R);
        IsWalking = Input.GetKey(KeyCode.V);
        IsSprinting = Input.GetKey(KeyCode.LeftShift);
        isCrouched = Input.GetKey(KeyCode.C);
        isJumping = Input.GetKey(KeyCode.Space);
    }

   

}
