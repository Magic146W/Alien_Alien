using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Bullet")
        {
            GameObject bullet = collider.gameObject;
            Color color = bullet.GetComponent<Renderer>().material.color;
            Material enemyMaterial = gameObject.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Renderer>().material;
            if (enemyMaterial.color == color)
            {
                Destroy(bullet);
                Destroy(gameObject);
            }
            else
            {
                Destroy(bullet);
            }
        }
    }
}
