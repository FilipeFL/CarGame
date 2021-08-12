using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mega_Fone : MonoBehaviour
{
    private Global Controlador;

    private Player PlayerScript;
    
    // Start is called before the first frame update
    void Start()
    {
        Controlador = GameObject.Find("Controlador").GetComponent<Global>();

        PlayerScript = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider objeto)
    {
        if (objeto.tag == "Player")
        {
            Controlador.Highscore = Controlador.Highscore + 5000;
            PlayerScript.ataque_especial = true;
            Controlador.ataque = true;

            //Permite o clip da coleta desse item ser iniciado.
            PlayerScript.AudioPlayer.clip = PlayerScript.AudioMegaFone;
            PlayerScript.AudioPlayer.Play();
        }
    }
}
