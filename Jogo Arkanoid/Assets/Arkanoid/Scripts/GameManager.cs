using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

public static GameManager instance;
public int Vidas = 3;
public int TijolosRestantes;

public GameObject PlayerPrefab;
public GameObject BallPrefab;
public Transform PlayerSpawnPoint;
public Transform BallSpawnPoint;

public PlayerB PlayerAtual;
public BallB BallAtual;

public TextMeshProUGUI Contador;
public TextMeshProUGUI MensagemFinal;

public bool Segurando;
private Vector3 offset;

private void Awake()
{
    instance = this; 
}

void Start()
{
    SpawnarJogador();
    AtualizarContador();
}

public void AtualizarContador()
{
    Contador.text = $"Vidas:{Vidas}";
}

public void SpawnarJogador()
{
    GameObject PlayerOBJ = Instantiate(PlayerPrefab, PlayerSpawnPoint.position, Quaternion.identity);
    GameObject BallOBJ = Instantiate(BallPrefab, BallSpawnPoint.position, Quaternion.identity);

    PlayerAtual = PlayerOBJ.GetComponent<PlayerB>();
    BallAtual = BallOBJ.GetComponent<BallB>();

    Segurando = true;
    offset = PlayerAtual.transform.position - BallAtual.transform.position;

}

    void Update()
    {
        if (Segurando)
        {
            BallAtual.transform.position = PlayerAtual.transform.position - offset;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                BallAtual.DispararBolinha(PlayerAtual.inputX);
                Segurando = false;
            }
        }
    }
}
