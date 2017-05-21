using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    public Transform target;
    private float posicaoInicialY;

    private void Start()
    {
        posicaoInicialY = target.position.y;
    }

    // Update is called once per frame
    void Update () {
        float posicaoY = target.position.y - posicaoInicialY;

        transform.position = new Vector3(target.position.x, posicaoY, transform.position.z);
	}
}
