using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScriptQueen : MonoBehaviour
{
    public int EnemyHealth = 100;
    public GameObject TheQueen;
    public float EnemySpeed;
    public GameObject ObjectiveComplete;

    void  DeductPoints ( int DamageAmount  )
    {
        EnemyHealth -= DamageAmount;
        // EnemySpeed = 0;
        // TheQueen.GetComponent<Animation>().Play("GetHit");
    }

    void  Update ()
    {
        if (EnemyHealth <= 0) {
            // Destroy(gameObject);
            this.GetComponent<QueenSpiderFollow>().enabled = false;
            TheQueen.GetComponent<Animation>().Play("Die");
            ObjectiveComplete.SetActive(true);
            EnemyHealth =1;
            StartCoroutine(EndQueen());
        }
    }
    IEnumerator EndQueen()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }
}
