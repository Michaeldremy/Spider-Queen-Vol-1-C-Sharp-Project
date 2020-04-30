using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PickupSMG : MonoBehaviour
{
    public float TheDistance = PlayerCasting.DistanceFromTarget;
    public GameObject TextDisplay;

    public GameObject FakeGun;
    public GameObject RealGun;
    public GameObject OldRealGun;
    public GameObject AmmoDisplay;
    public GameObject OldAmmoDisplay;
    public AudioSource PickUpAudio;

    public GameObject ObjectiveComplete;
    public GameObject Mechanics;

    public void Update () 
    {
        TheDistance = PlayerCasting.DistanceFromTarget;

    }

    public void OnMouseOver () 
    {
        if (TheDistance <= 2 ) 
        {
            TextDisplay.GetComponent<Text>().text = "Take SMG";
        }
        if (Input.GetButtonDown("Action")) 
        {
            if (TheDistance <= 2 ) 
            {
                StartCoroutine(TakeNineMil());
                Mechanics.SetActive(true);
                ObjectiveComplete.SetActive(true);
            }
        }
    }

    public void OnMouseExit () 
    {
        TextDisplay.GetComponent<Text>().text = "";
    }

    public IEnumerator TakeNineMil() 
    {
        PickUpAudio.Play();
        transform.position = new Vector3(0, -1000, 0);
        FakeGun.SetActive(false);
        RealGun.SetActive(true);
        OldRealGun.SetActive(false);
        AmmoDisplay.SetActive(true);
        OldAmmoDisplay.SetActive(false);
        yield return new WaitForSeconds(0.1f);
    }
}
