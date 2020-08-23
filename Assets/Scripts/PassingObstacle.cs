using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PassingObstacle : MonoBehaviour
{
    NavMeshObstacle obstacle;
    public float TimeToWait;
    public int maxEntities;
    int currentEntities = 0;
    void Start()
    {
        obstacle = GetComponent<NavMeshObstacle>();
        obstacle.enabled = false;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag.Equals("Enemy"))
        {
            currentEntities++;
            if (currentEntities == maxEntities)
            {
                StartCoroutine(ActivateObstacle());
            }
        }
    }

    IEnumerator ActivateObstacle()
    {
        obstacle.enabled = true;
        yield return new WaitForSeconds(TimeToWait);
        currentEntities = 0;
        obstacle.enabled = false;
    }
}
