using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderMago : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Plataforma")
        {
            Mago mag = this.gameObject.GetComponent<Mago>();
            mag.podePular = true;
        }
        
    }
}
