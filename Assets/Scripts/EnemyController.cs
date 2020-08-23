using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    NavMeshAgent agent;
    public NavMeshAim aim;
    bool isGrounded;
    public AnimationManager animMan;
    public void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(aim.GetNavMeshAim());
    }
    private void Update()
    {
        animMan.SetGrounded(isGrounded);
        animMan.SetSpeed(Mathf.Abs(agent.velocity.magnitude));
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("CanBeGrounded") || collision.gameObject.tag.Equals("Enemy") || collision.gameObject.tag.Equals("Player"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag.Equals("CanBeGrounded") || collision.gameObject.tag.Equals("Enemy") || collision.gameObject.tag.Equals("Player"))
        {
            isGrounded = false;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag.Equals("CanBeGrounded") || collision.gameObject.tag.Equals("Enemy") || collision.gameObject.tag.Equals("Player"))
        {
            isGrounded = true;
        }
    }
}
