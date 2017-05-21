using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour {

    private Rigidbody2D rgbd;


    private int _dano = 40;

    private int velocidade = 20;
    

    // Use this for initialization
    void Start () {
        rgbd = this.GetComponent<Rigidbody2D>();

        Mago mago = GameObject.FindGameObjectWithTag("Mago").GetComponent<Mago>();

        if (!mago.playerDireita)
            velocidade *= -1;

        Destroy(this.gameObject, 0.5F);
	}
	
	// Update is called once per frame
	void Update () {
        rgbd.velocity = new Vector2(velocidade, rgbd.velocity.y);
	}

    public int GetDano()
    {
        return this._dano;
    }
    
}
