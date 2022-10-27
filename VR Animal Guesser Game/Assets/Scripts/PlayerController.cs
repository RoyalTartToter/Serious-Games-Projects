using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform defaultPosition;

    public void MoveBackToDefaultPosition()
    {
        this.gameObject.transform.position = defaultPosition.position;
    }
}
