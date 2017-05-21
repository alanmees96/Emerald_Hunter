using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMasterMotherFucker : MonoBehaviour {

    public static GameMasterMotherFucker GameMaster;


    public int VidaPlayer
    {
        get { return VidaPlayer; }
        set { VidaPlayer = value; }
    }


    private void Awake()
    {
        if(GameMaster == null)
        {
            DontDestroyOnLoad(gameObject);
            GameMaster = this;
        }
        else if (GameMaster != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ValoresDefaultJogador();
    }

    private void ValoresDefaultJogador()
    {
        this.VidaPlayer = 100;
    }




}
