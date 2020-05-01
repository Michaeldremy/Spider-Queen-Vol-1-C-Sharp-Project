using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGunDamage : MonoBehaviour
{
    public int DamageAmount = 5;
    public float TargetDistance;
    public float AllowedRange = 15f;
    public RaycastHit hit;
    public GameObject TheBullet;
    public GameObject TheBlood;
    public GameObject TheBloodGreen;

    void Update()
    {
        if(GlobalAmmo.LoadedAmmo >= 1)
        {
            if(Input.GetButton("Fire1")) 
            {

            RaycastHit Shot;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot)) 
                {
                    TargetDistance = Shot.distance;
                    if (TargetDistance <= AllowedRange)
                    {
                        Shot.transform.SendMessage("DeductPoints", DamageAmount);
                        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
                        {
                            if(hit.transform.tag == "Zombie" || hit.transform.tag == "Queen")
                            {
                                Instantiate(TheBlood, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
                            }
                            if(hit.transform.tag == "Spider")
                            {
                                Instantiate(TheBloodGreen, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
                            }
                            if(hit.transform.tag == "Untagged")
                            {
                            Instantiate(TheBullet, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
                            }
                        }
                    }
                }
            }
        }
    }
}