using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavMeshAim : MonoBehaviour
{
    public Transform point;
    public Vector3 GetNavMeshAim()
    {
        RaycastHit hit;
        if (Physics.Raycast(point.position, Vector3.up * -1, out hit))
        {
            return hit.point;
        }
        return Vector3.zero;
    }
}
