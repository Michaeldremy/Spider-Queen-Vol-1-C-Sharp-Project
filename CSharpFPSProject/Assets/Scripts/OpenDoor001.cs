using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenDoor001 : MonoBehaviour 
{
public GameObject TextDisplay;
public GameObject TheDoor;
public float TheDistance = PlayerCasting.DistanceFromTarget;

    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;

    }

    void OnMouseOver()
    {
        if (TheDistance <= 4)
        {
            TextDisplay.GetComponent<Text>().text = "Press Button";
        }
        if (Input.GetButtonDown("Action"))
        {
            if (TheDistance <= 4)
            {
                StartCoroutine(OpenTheDoor());
            }
        }
    }

    void OnMouseExit()
    {
        TextDisplay.GetComponent<Text>().text = "";
    }

    IEnumerator OpenTheDoor()
    {
        TheDoor.GetComponent<Animator>().enabled=true;
        yield return new WaitForSeconds(1);
        TheDoor.GetComponent<Animator>().enabled=false;
        yield return new WaitForSeconds(5);
        TheDoor.GetComponent<Animator>().enabled=true;
        yield return new WaitForSeconds(1);
        TheDoor.GetComponent<Animator>().enabled=false;
    }

}