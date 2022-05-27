using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary: MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Bullet")
        {
            GameObject bullet = collider.gameObject;
            Destroy(bullet, 0.1f);
        }
    }
}
