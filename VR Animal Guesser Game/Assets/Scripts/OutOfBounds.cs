using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        other.GetComponent<Pickables>().MoveToDefaultPosition();
    }
}
