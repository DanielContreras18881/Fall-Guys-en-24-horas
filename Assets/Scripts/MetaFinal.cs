using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaFinal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag.Equals("Enemy"))
        {
            FindObjectOfType<WinOrLose>().Lose();
        }
        else if (other.transform.tag.Equals("Player"))
        {
            FindObjectOfType<WinOrLose>().Win();
        }
    }
}
