using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public enum EMoveState
    {
        WALKING,
        RUNNING,
        SPRINTING,
        JUMPING,
    }

    public enum EWEAPONSTATE
    {
        IDLE,
        FIRING,
        AIMING,
        AIMEDFIRING,
    }

    public EMoveState MoveState;
    public EWEAPONSTATE WeaponState;

    private InputController m_InputController;
    public InputController InputController
    {
        get
        {
            if (m_InputController == null)
                m_InputController = GameManager.Instance.InputController;
            return m_InputController;
        }
    }

    void Update()
    {
        SetWeaponState();
        SetMoveState();
    }

    void SetWeaponState()
    {
        WeaponState = EWEAPONSTATE.IDLE;

        if (InputController.Fire1)
            WeaponState = EWEAPONSTATE.FIRING;

        if (InputController.Fire2)
            WeaponState = EWEAPONSTATE.AIMING;

        if (InputController.Fire1 && InputController.Fire2)
            WeaponState = EWEAPONSTATE.AIMEDFIRING;
    }


    void SetMoveState()
    {
        MoveState = EMoveState.RUNNING;

        if (InputController.IsSprinting)
            MoveState = EMoveState.SPRINTING;

        if (InputController.IsWalking)
            MoveState = EMoveState.WALKING;

        if (InputController.isJumping)
            MoveState = EMoveState.JUMPING;

    }


}
