using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pickables : MonoBehaviour
{
    public int mapNumber = 4, numHintsUsed = 0;

    public MapPoint defaultPosition;
    public MapPoint currentlyInMapPoint;

    [TextArea (15, 20)]
    public string hintOne, hintTwo, hintThree;

    void Start()
    {

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

    public void BeHeld()
    {
        GameManager.instance.currentlyHeld = this;
        switch (numHintsUsed)
        {
            case 0:
                GameManager.instance.hintOneText.text = "Hint 1 Locked";
                GameManager.instance.hintTwoText.text = "Hint 2 Locked";
                GameManager.instance.hintThreeText.text = "Hint 3 Locked";
                break;
            case 1:
                GameManager.instance.hintOneText.text = hintOne;
                GameManager.instance.hintTwoText.text = "Hint 2 Locked";
                GameManager.instance.hintThreeText.text = "Hint 3 Locked";
                break;
            case 2:
                GameManager.instance.hintOneText.text = hintOne;
                GameManager.instance.hintTwoText.text = hintTwo;
                GameManager.instance.hintThreeText.text = "Hint 3 Locked";
                break;
            case 3:
                GameManager.instance.hintOneText.text = hintOne;
                GameManager.instance.hintTwoText.text = hintTwo;
                GameManager.instance.hintThreeText.text = hintThree;
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // if the user brings an animal model in range of the map point
        if (other.tag == "Map Point")
        {
            currentlyInMapPoint = other.GetComponent<MapPoint>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // if the user brings an animal model back out of range of the map point
        if (other.tag == "Map Point")
        {
            currentlyInMapPoint = defaultPosition;
        }
    }

    public void OnAnimalDrop()
    {
        if (currentlyInMapPoint != defaultPosition)
        {
            // if the dropped animal matches the animal currently entered the trigger, then snap the animal to the map point
            if (currentlyInMapPoint.animalNumber == mapNumber)
            {
                // add this animal to the list of animals currently belonging to this point
                GameManager.instance.CalculateScore();

                // snap the animal to this point
                Debug.Log(currentlyInMapPoint.gameObject.name + "has been snapped to correct position");
                this.transform.position = currentlyInMapPoint.gameObject.transform.Find("Snapping Point").position;
                this.transform.SetParent(currentlyInMapPoint.gameObject.transform);
            }

            if (currentlyInMapPoint.animalNumber != mapNumber)
            {
                Debug.Log(currentlyInMapPoint.gameObject.name + "has been snapped to wrong position");
                this.transform.position = currentlyInMapPoint.gameObject.transform.Find("Snapping Point").position;
                this.transform.SetParent(currentlyInMapPoint.gameObject.transform);
            }
        }
        else if (currentlyInMapPoint == defaultPosition)
        {
            this.transform.position = defaultPosition.gameObject.transform.position;
        }
    }
    
}
