using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachPassengers : MonoBehaviour
{

    public GameObject station;
    public GameObject train;
    public GameObject lokomotive;
    public GameObject[] characters;

    private void OnTriggerEnter(Collider other)
    {
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
}
