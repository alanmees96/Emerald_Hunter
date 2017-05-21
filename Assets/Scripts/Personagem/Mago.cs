using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mago : MonoBehaviour {

    //Componentes
    public Rigidbody2D rgbd;
    public Material mtrl;

    //Prefabs
    public GameObject Projetil;

    //Parametros do player
    private int VidaPlayer;
    [RangeAttribute(2, 30)] public int _velocidadePlayer = 10;
    public float _tempoEntreDisparos = 0.5F;//intervalo de tempo entre disparos
    private int _distIniDispPlayX = 1;//Distancia incial de onde o projetil vai ser criado em relacao ao player no eicho X
    private float _distIniDispPlayY = 0.5f;//Distancia incial de onde o projetil vai ser criado em relacao ao player no eicho X

    //Controles de liberacao
    private bool _bloqueaDisparo; // bloqueia o disparo para nao atirar toda hora
    public bool playerDireita; //Verifica para qual lado o player está virado, é acessada em Projetil
    public bool podePular;

    // Use this for initialization
    void Start () {
        rgbd = this.GetComponent<Rigidbody2D>();
        mtrl = this.GetComponent<Material>();

        inicializaVariaveisDefualt();

        InicializaInformacoesGlobais();
    }

    private void OnDestroy()
    {
        
    }

    // Update is called once per frame
    void Update () {
        Movimentacao();
        Disparo();
    }

    void FixedUpdate()
    {
        SalvaInformacoesGlobais();
    }

    private void InicializaInformacoesGlobais()
    {
        VidaPlayer = GameMaster
    }

    private void SalvaInformacoesGlobais()
    {

    }

    private void inicializaVariaveisDefualt()
    {
        _bloqueaDisparo = false;
        playerDireita = true;
        podePular = true;
    }

    private void Movimentacao()
    {
        float move = Input.GetAxis("Horizontal");
        rgbd.velocity = new Vector2(move * _velocidadePlayer, rgbd.velocity.y);

        if (move > 0)
            playerDireita = true;
        else if(move < 0)
            playerDireita = false;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (podePular)
            {
                rgbd.velocity = Vector2.up * 7;
                podePular = false;
            }
        }
    }

    private void Disparo()
    {
        if (Input.GetKey(KeyCode.Space) && !_bloqueaDisparo)
        {
            StartCoroutine(SpawnDisparos());
        }
    }

    IEnumerator SpawnDisparos()
    {
        _bloqueaDisparo = true;

        if(playerDireita)
            Instantiate(Projetil, new Vector3(this.transform.position.x + _distIniDispPlayX, this.transform.position.y + _distIniDispPlayY), Quaternion.identity);
        else
            Instantiate(Projetil, new Vector3(this.transform.position.x - _distIniDispPlayX, this.transform.position.y + _distIniDispPlayY), Quaternion.identity);

        //antes do intervalo de tempo
        yield return new WaitForSeconds(_tempoEntreDisparos);

        //após o intervalo de tempo
        _bloqueaDisparo = false;
    }
}
