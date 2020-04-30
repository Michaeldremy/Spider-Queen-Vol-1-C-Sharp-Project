using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScriptSpider : MonoBehaviour
{
    public int EnemyHealth = 15;
    public GameObject TheSpider;

    void  DeductPoints ( int DamageAmount  )
    {
        EnemyHealth -= DamageAmount;
    }

    void  Update ()
    {
        if (EnemyHealth <= 0) {
            // Destroy(gameObject);
            this.GetComponent<SpiderFollow2>().enabled = false;
            TheSpider.GetComponent<Animation>().Play("die");
            EnemyHealth =1;
            StartCoroutine(EndSpider());
        }
    }
    IEnumerator EndSpider()
    {
        yield return new WaitForSeconds(15);
        Destroy(gameObject);
    }
}
