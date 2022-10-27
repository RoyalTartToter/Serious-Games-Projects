using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Animal")
        {
            other.GetComponent<Pickables>().MoveToDefaultPosition();
        }
        else if(other.tag == "Player")
        {
            other.GetComponent<PlayerController>().MoveBackToDefaultPosition();
        }
    }
}
