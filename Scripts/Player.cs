using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int AutomaticSpeed, ManualSpeed;
    
    private Global Controlador;

    public bool ativo = true;

    public bool ato_1 = true, ato_2 = false, ato_3 = false;

    public bool ataque_especial = false;

    //Declara os áudios que serão usados como clips ou Audio Sources ao decorrer do jogo.

    public AudioClip AudioBuzina, AudioPneu, AudioCrash, AudioCaixaSom, AudioFerramentaConserto, AudioMegaFone, AudioNitro;

    public AudioSource AudioPlayer;

    public AudioSource AudioMotor;
    
    // Start is called before the first frame update
    void Start()
    {
        Controlador = GameObject.Find("Controlador").GetComponent<Global>();
        AudioPlayer = transform.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Controlador.pause == false)
        {
            Actions();
        }
    }

    void Actions()
    {
        if (ativo == true)
        {
            AudioMotor.Play();

            //Movimento automático
            transform.Translate(Vector3.forward * Time.deltaTime * AutomaticSpeed);
            Controlador.Highscore++;

            //Movimentação testes, posteriormente será utilizada para fazer um boost no veículo
            /*if (Input.GetKey("w"))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * AutomaticSpeed);
                //Controlador.Highscore++;
            }*/

            //Movimentação lateral
            if (Input.GetKey("a"))
            {
                if (transform.GetChild(0).transform.position.x > -9)
                {
                    transform.GetChild(0).transform.Translate(-Vector3.right * Time.deltaTime * ManualSpeed);
                }
            }
            
            //Permite o áudio da movimentação lateral do Player.
            if (Input.GetKeyDown("a"))
            {
                AudioPlayer.clip = AudioPneu;
                AudioPlayer.Play();
            }

            if (Input.GetKey("d"))
            {
                if (transform.GetChild(0).transform.position.x < 9)
                {
                    transform.GetChild(0).transform.Translate(Vector3.right * Time.deltaTime * ManualSpeed);
                }
            }

            //Permite o áudio da movimentação lateral do Player.
            if (Input.GetKeyDown("d"))
            {
                AudioPlayer.clip = AudioPneu;
                AudioPlayer.Play();
            }

            //Permite o clip do áudio de buzina.
            if (Input.GetKeyDown("space"))
            {
                AudioPlayer.clip = AudioBuzina;
                AudioPlayer.Play();
            }
        }
        else
        {
            //Se o Player não estiver ativo então o motor não pode ser ouvido.
            AudioMotor.Stop();
        }
    }

    public void Boost()
    {
        transform.Translate(Vector3.forward * 10);
    }

    private void OnTriggerEnter(Collider objeto)
    {
        if(objeto.tag == "Ato1")
        {
            ato_1 = false;
            ato_2 = true;
        }
        if(objeto.tag == "Ato2")
        {
            ato_2 = false;
            ato_3 = true;
        }
    }
}
