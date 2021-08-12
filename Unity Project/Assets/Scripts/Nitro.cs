using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nitro : MonoBehaviour
{
    private Player PlayerScript;

    private Global Controlador;

    private void Start()
    {
        PlayerScript = GameObject.Find("Player").GetComponent<Player>();

        Controlador = GameObject.Find("Controlador").GetComponent<Global>();  
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider objeto)
    {
        if (objeto.tag == "Player")
        {
            //Permite o clip da coleta desse item ser iniciado.
            PlayerScript.AudioPlayer.clip = PlayerScript.AudioNitro;
            PlayerScript.AudioPlayer.Play();

            Controlador.Highscore = Controlador.Highscore + 500;
            Controlador.contador_nitro++;
            //Player.Boost();
        }
    }
}
