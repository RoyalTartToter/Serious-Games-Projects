using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class Pickables : MonoBehaviour
{
    public int mapNumber = 4, numHintsUsed = 0;
    public Rigidbody pickableRigidbody;
    public MapPoint defaultPosition;
    public MapPoint currentlyInMapPoint;
    public bool hasBeenPlaced = false, isFrozen = true;

    [TextArea (15, 20)]
    public string hintOne, hintTwo, hintThree;

    void Start()
    {
        pickableRigidbody = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        BeFrozen();
    }

    public void BeFrozen()
    {
        if (isFrozen)
        {
            pickableRigidbody.constraints = RigidbodyConstraints.FreezeAll;
        }
        else if (!isFrozen)
        {
            pickableRigidbody.constraints = RigidbodyConstraints.None;
        }
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
        isFrozen = false;
        GameManager.instance.currentlyHeld = this;
        GameManager.instance.isHoldingSomething = true;
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

    private void OnTriggerStay(Collider other)
    {
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

    public void MoveToDefaultPosition()
    {
        this.transform.position = defaultPosition.gameObject.transform.position;
        this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
    }

    public void OnAnimalDrop()
    {
        if (currentlyInMapPoint != defaultPosition && !hasBeenPlaced && !currentlyInMapPoint.hasBeenUsed)
        {
            // if the dropped animal matches the animal currently entered the trigger, then snap the animal to the map point
            if (currentlyInMapPoint.animalNumber == mapNumber)
            {
                //Gives feedback in the UI that the animal was placed properly
                GameManager.instance.justPerformedText.text = gameObject.name + " has been snapped to correct position!\n";

                //Calculates the score based on hints used
                GameManager.instance.CalculateScore();

                transform.rotation = Quaternion.identity;

                //Stops the pickable from being interactable
                Destroy(gameObject.GetComponent<XRGrabInteractable>());
                isFrozen = true;
                //Finds the snapping point child of the MapPoint and moves the pickable into that position
                this.transform.position = currentlyInMapPoint.gameObject.transform.Find("Snapping Point").position;


                //A failsafe boolean to prevent multiple points from the same object
                hasBeenPlaced = true;
                GameManager.instance.CheckForGameOver();

                currentlyInMapPoint.hasBeenUsed = true;
                currentlyInMapPoint.m_material.color = Color.green;
            }
            else if (currentlyInMapPoint.animalNumber != mapNumber)
            {
                GameManager.instance.justPerformedText.text = gameObject.name + " was placed in the wrong position!\n No points were awarded.";
                transform.rotation = Quaternion.identity;
                Destroy(gameObject.GetComponent<XRGrabInteractable>());
                isFrozen = true;
                this.transform.position = GameManager.instance.allMapPoints[this.mapNumber - 1].gameObject.transform.Find("Snapping Point").position;

                GameManager.instance.CheckForGameOver();
                hasBeenPlaced = true;
                currentlyInMapPoint.hasBeenUsed = true;
                currentlyInMapPoint.m_material.color = Color.red;
            }
        }
        else
        {
            isFrozen = true;
        }
    }
    
}
