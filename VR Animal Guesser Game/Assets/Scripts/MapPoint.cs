using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPoint : MonoBehaviour
{
    // maintain a reference to the material
    public Material m_material;

    public int animalNumber = 4;
    public string correctAnimal = "";

    public bool hasBeenUsed = false;

    // Start is called before the first frame update
    void Start()
    {
        // initialize the material
        m_material = GetComponent<Renderer>().material;
        m_material.color = Color.blue;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateColour();
    }

    public void UpdateColour()
    {
        if (!hasBeenUsed && GameManager.instance.isHoldingSomething)
        {
            if (GameManager.instance.currentlyHeld.currentlyInMapPoint == this)
            {
                m_material.color = Color.yellow;
            }
            else if (GameManager.instance.currentlyHeld.currentlyInMapPoint != this)
            {
                m_material.color = Color.blue;
            }
        }
    }
}
