using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoUm : MonoBehaviour {

    private Rigidbody2D rgbd;

    private int vidaInimigo = 100;
    private bool movDireito;

	// Use this for initialization
	void Start () {
        rgbd = this.GetComponent<Rigidbody2D>();
        movDireito = true;
        StartCoroutine(TrocaLado());
    }
	
	// Update is called once per frame
	void Update () {
        if(movDireito)
            rgbd.velocity = Vector2.right;
        else
            rgbd.velocity = Vector2.left;
    }


    IEnumerator TrocaLado()
    {
        yield return new WaitForSeconds(2f);
        movDireito = !movDireito;
        StartCoroutine(TrocaLado());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
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
