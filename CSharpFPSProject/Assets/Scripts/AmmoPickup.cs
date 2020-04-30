using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AmmoPickup : MonoBehaviour 
{
    public AudioSource AmmoSound;

    void OnTriggerEnter(Collider other)
    {
        AmmoSound.Play();
        if (GlobalAmmo.LoadedAmmo == 0)
        {
            GlobalAmmo.LoadedAmmo += 10;
            this.gameObject.SetActive(false);
        }
        else
        {
            GlobalAmmo.CurrentAmmo += 10;
            this.gameObject.SetActive(false);
        }
    }
}

