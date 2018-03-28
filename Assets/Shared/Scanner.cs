using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Scanner : MonoBehaviour
{
    [SerializeField] float scanSpeed;
    [SerializeField][Range(0, 360)] float fieldOfView;
    [SerializeField] LayerMask mask;

    SphereCollider rangeTrigger;
    List<Player> targets;
    Player selectedTarget;

    void Start()
    {
        rangeTrigger = GetComponent<SphereCollider>();
        targets = new List<Player>();
        PrepareScan();

    }

    void PrepareScan()
    {
        if (selectedTarget != null)
            return;

        GameManager.Instance.Timer.Add(ScanForTargets, scanSpeed);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;

        if (selectedTarget != null)
            Gizmos.DrawLine(transform.position, selectedTarget.transform.position);

        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + GetViewAngle(fieldOfView / 2) * GetComponent<SphereCollider>().radius);
        Gizmos.DrawLine(transform.position, transform.position + GetViewAngle(-fieldOfView / 2) * GetComponent<SphereCollider>().radius);

    }

    Vector3 GetViewAngle(float angle)
    {
        float radian = (angle + transform.eulerAngles.y) * Mathf.Deg2Rad;
        return new Vector3(Mathf.Sin(radian), 0, Mathf.Cos(radian));
        
    }

    void ScanForTargets()
    {
        print("Scanning For Targets");
        Collider[] result = Physics.OverlapSphere(transform.position, rangeTrigger.radius);

        for (int i = 0; i < result.Length; i++)
        {
            var player = result[i].transform.GetComponent<Player>();
            if (player == null)
                return;

            if (!IsInLineOfSight(Vector3.up, player.transform.position))
                continue;

            targets.Add(player);
        }

        if(targets.Count == 1)
        {
            selectedTarget = targets[0];
        }else
        {
            //checking for closest target
            float closestTarget = rangeTrigger.radius;
            foreach(var possibleTarget in targets)
            {
                if (Vector3.Distance(transform.position, possibleTarget.transform.position) < closestTarget)
                    selectedTarget = possibleTarget;
            }
        }

        PrepareScan();


    }

     bool IsInLineOfSight(Vector3 eyeHeight, Vector3 targetPosition)
     {
            Vector3 direction = targetPosition - transform.position;

            if (Vector3.Angle(transform.forward, direction.normalized)<fieldOfView/2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, targetPosition);
            
            //check if something is block our view
            if (Physics.Raycast(transform.position + eyeHeight, direction.normalized, distanceToTarget, mask))
                    return false;

                return true;
            }
            return false;
     }
       

}
