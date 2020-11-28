using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachPassengers : MonoBehaviour
{

    public GameObject station;
    public GameObject train;
    public GameObject lokomotive;
    public GameObject door1;
    public GameObject door2;

    public GameObject[] characters;

    private void OnTriggerEnter(Collider other)
    {
        door1.gameObject.GetComponent<DoorMotion>().activation = true;
        door2.gameObject.GetComponent<DoorMotion>().activation = true;

        if (other.gameObject.tag == "Wagon")
        {
            foreach (var character in characters)
            {
                character.gameObject.GetComponent<CharacterAgent>().shouldMove = true;
                if (character.gameObject.GetComponent<CharacterAgent>().isOnTrain)
                {
                    character.gameObject.GetComponent<CharacterAgent>().target = station;
                    character.gameObject.GetComponent<CharacterAgent>().isOnTrain = false;

                    lokomotive.gameObject.GetComponent<SplineWalker>().passengersCounter--;
                }
                else
                {
                    character.gameObject.GetComponent<CharacterAgent>().target = train;
                    character.gameObject.GetComponent<CharacterAgent>().isOnTrain = true;

                    lokomotive.gameObject.GetComponent<SplineWalker>().passengersCounter++;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        door1.gameObject.GetComponent<DoorMotion>().activation = false;
        door2.gameObject.GetComponent<DoorMotion>().activation = false;
    }
}
