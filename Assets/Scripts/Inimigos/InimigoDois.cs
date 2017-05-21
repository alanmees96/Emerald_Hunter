using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoDois : MonoBehaviour {

    private Rigidbody2D rgbd;

    private int vidaInimigo = 100;

    private bool liberaPulo;
	// Use this for initialization
	void Start () {
        rgbd = this.GetComponent<Rigidbody2D>();
        liberaPulo = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (liberaPulo)
        {
            rgbd.velocity = Vector2.up * 4;
            liberaPulo = false;
        }
	}

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Plataforma")
        {
            liberaPulo = true;
        }

        if (collision.gameObject.tag == "DisparoSimples")
        {
            Projetil projetil = collision.gameObject.GetComponent<Projetil>();
            vidaInimigo -= projetil.GetDano();

            Destroy(collision.gameObject);

            if (vidaInimigo <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
