using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickables : MonoBehaviour
{
    //public GameObject objectText;
    public EditScore scoreScript;
    public int mapNumber = 4;

    void Start()
    {
            scoreScript = GameObject.FindGameObjectWithTag("Score").GetComponent<EditScore>();
    }

    public void SetTextActive(GameObject objectText){
        if(objectText.activeSelf)
        {
            Debug.Log("Selected");
            objectText.SetActive(false);
        }
        else
        {
            Debug.Log("Unselected");
            objectText.SetActive(true);
        }
    }

    public void OnAnimalDrop(MapPoint mapPoint)
    {
       // Debug.Log(dropped_animal.name + "HHHHH");
        //Debug.Log(m_animal_entered + "DDDDD");

        // if the dropped animal matches the animal currently entered the trigger, then snap the animal to the map point
        if (mapPoint.animalNumber == this.mapNumber)
        {
            // add this animal to the list of animals currently belonging to this point

            // remove the animal's rigid body
            //this.GetComponent<Rigidbody>().
            scoreScript.noHintsUsed();
            //update points
            // snap the animal to this point
            Debug.Log(mapPoint.gameObject.name + "<----THISSSSSSSSSSSSSSSSSSSSSS");
            this.transform.position = mapPoint.gameObject.transform.position;
            this.transform.SetParent(mapPoint.gameObject.transform);
        }
    }
    
}
