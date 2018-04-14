using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [System.Serializable]
    public class CameraRig
    {
        public Vector3 CameraOffset;
        public float damping;
    }
    //0 0.8 -7.3
    // 5

    [SerializeField] CameraRig defaultCamera;
    [SerializeField] CameraRig aimCamera;

     Transform cameraLookTarget;
    public Player localPlayer;

	// Use this for initialization
	void Awake ()
    {
        GameManager.Instance.OnLocalPlayerJoined += HandleOnLocalPlayerJoined; ;
	}
	
    void HandleOnLocalPlayerJoined (Player player)
    {
        localPlayer = player;
        cameraLookTarget = localPlayer.transform.Find("cameraLookTarget");

        if (cameraLookTarget == null)
            cameraLookTarget = localPlayer.transform;
    }

	// Update is called once per frame
	void Update ()
    {
        if (localPlayer == null)
            return;

        CameraRig cameraRig = defaultCamera;

        if (localPlayer.PlayerState.WeaponState == PlayerState.EWEAPONSTATE.AIMING || localPlayer.PlayerState.WeaponState == PlayerState.EWEAPONSTATE.AIMEDFIRING)
            cameraRig = aimCamera;




        Vector3 targetPosition = cameraLookTarget.position + localPlayer.transform.forward * cameraRig.CameraOffset.z + localPlayer.transform.up * cameraRig.CameraOffset.y + localPlayer.transform.right * cameraRig.CameraOffset.x;
        Quaternion targetRotation = Quaternion.LookRotation(cameraLookTarget.position - targetPosition, Vector3.up);

        transform.position = Vector3.Lerp(transform.position, targetPosition, cameraRig.damping * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, cameraRig.damping * Time.deltaTime);
    }
}
