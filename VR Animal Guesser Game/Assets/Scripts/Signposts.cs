using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signposts : MonoBehaviour
{
    public GameObject sign, mushroom;
    public bool isMushroom = false;

    public void TransformSign()
    {
        if (isMushroom)
        {
            mushroom.SetActive(false);
            sign.SetActive(true);
        }
        else if (!isMushroom)
        {
            sign.SetActive(false);
            mushroom.SetActive(true);
        }
    }
}
