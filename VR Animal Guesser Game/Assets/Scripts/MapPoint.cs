using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPoint : MonoBehaviour
{
    // maintain a reference to the material
    Material m_material;

    //GameObject m_animal_entered = null;
    string m_animal_entered;

    // different colours for the point
    Color m_red = new Color(1.0f, 0.2f, 0.2f, 1.0f);
    Color m_green = new Color(0.2f, 1.0f, 0.2f, 1.0f);

    public int animalNumber = 4;

    // Start is called before the first frame update
    void Start()
    {
        // initialize the material
        m_material = GetComponent<Renderer>().material;
        m_material.color = m_red;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // if the user brings an animal model in range of the map point
        if (other.tag == "Animal")
        {
            // change the colour of the map point
            m_material.color = m_green;
            Debug.Log(other.name);

            // track whether the animal stays inside the trigger
            m_animal_entered = other.name;

            Debug.Log(m_animal_entered);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // if the user brings an animal model back out of range of the map point
        if (other.tag == "Animal")
        {
            // change the colour of the map point
            m_material.color = m_red;
            //Debug.Log(other.name);

            m_animal_entered = null;
        }
    }

    
    public void OnAnimalDrop(GameObject dropped_animal)
    {
        Debug.Log(dropped_animal.name + "HHHHH");
        Debug.Log(m_animal_entered + "DDDDD");

        GameObject animal = GameObject.Find(m_animal_entered);
        // if the dropped animal matches the animal currently entered the trigger, then snap the animal to the map point
        if (animal != null && GameObject.ReferenceEquals(animal, dropped_animal))
        {
            // add this animal to the list of animals currently belonging to this point

            // remove the animal's rigid body
            Destroy(dropped_animal.GetComponent<Rigidbody>());

            // snap the animal to this point
            Debug.Log(gameObject.name + "<----THISSSSSSSSSSSSSSSSSSSSSS");
            dropped_animal.transform.position = gameObject.transform.position;
            dropped_animal.transform.SetParent(gameObject.transform);
        }
    }

}
