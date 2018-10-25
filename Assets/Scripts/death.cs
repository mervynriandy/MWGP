using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Death")
        {
            Destroy(this.gameObject);

        }
    }
}
