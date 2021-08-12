using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorUI : MonoBehaviour
{
    public GameObject TelaStart, TelaCreditos, TelaPausa, TelaOptions, TelaAudio, TelaControls;

    //As trilhas de Menus são declaradas no script próprio de Menu.
    public AudioSource TrilhaMenu, TrilhaCreditos;

    private Global Controlador;

    private Player PlayerScript;

    private Boss BossScript;

    private bool able_SFX = true, able_Music = true;

    public bool jogo_ativo = false;

    // Start is called before the first frame update
    void Start()
    {
        TelaCreditos.SetActive(false);
        TelaStart.SetActive(true);
        TelaPausa.SetActive(false);
        TelaOptions.SetActive(false);
        TelaAudio.SetActive(false);

        TrilhaMenu.Play();

        Controlador = GameObject.Find("Controlador").GetComponent<Global>();

        PlayerScript = GameObject.Find("Player").GetComponent<Player>();

        BossScript = GameObject.Find("Boss").GetComponent<Boss>();
    }

    // Update is called once per frame
    void Update()
    {
        //Se o jogo for pausado, será providenciado o devido comportamento dos áudios em cada tela que surgir.
        if (TelaCreditos.activeSelf == false && TelaPausa.activeSelf == false && TelaStart.activeSelf == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                TelaPausa.SetActive(true);
                Controlador.pause = true;
                Controlador.PausarTrilhaAto1();
                Controlador.PausarTrilhaAto2();
                Controlador.PausarTrilhaAto3();
                Controlador.PausarTraffic();
                BossScript.AudioEngineBoss.Stop();
                BossScript.AudioSiren.Stop();
                TrilhaMenu.Play();
                PlayerScript.ativo = false;
            }
        }
    }

    //Para cada botão ou navegação de menus, foi implementado um comportamento diferente dos áudios implementados.

    public void bt_Start()
    {
        TelaStart.SetActive(false);
        TrilhaMenu.Stop();
        jogo_ativo = true;
        Controlador.pause = false;
        Controlador.TocarTrilhaAto1();
        Controlador.TocarTraffic();
    }

    public void bt_Options()
    {
        if (jogo_ativo == false)
        {
            TelaStart.SetActive(false);
            TelaOptions.SetActive(true);
        }
        if (jogo_ativo == true)
        {
            TelaOptions.SetActive(true);
            TelaPausa.SetActive(false);
        }
    }

    public void bt_Credits()
    {
        TelaStart.SetActive(false);
        TelaCreditos.SetActive(true);
        TrilhaCreditos.Play();
        TrilhaMenu.Stop();
    }

    public void bt_Skip_Credits()
    {
        TelaStart.SetActive(true);
        TelaCreditos.SetActive(false);
        TrilhaCreditos.Stop();
        TrilhaMenu.Play();
    }

    public void bt_Exit()
    {
        Debug.Log("Saiu do jogo");
        Application.Quit();
    }

    public void bt_BackToGame()
    {
        TelaPausa.SetActive(false);
        Controlador.pause = false;
        TrilhaMenu.Pause();
        PlayerScript.ativo = true;

        if(PlayerScript.ato_1 == true)
        {
            Controlador.TocarTrilhaAto1();
            Controlador.TocarTraffic();
        }
        if (PlayerScript.ato_2 == true)
        {
            Controlador.TocarTrilhaAto2();
            Controlador.TocarTraffic();
        }
        if (PlayerScript.ato_3 == true)
        {
            Controlador.TocarTrilhaAto3();
            Controlador.TocarTraffic();
            BossScript.AudioEngineBoss.Play();
            BossScript.AudioSiren.Play();
        }
    }

    public void btn_Audio()
    {
        TelaOptions.SetActive(false);
        TelaAudio.SetActive(true);
    }

    public void btn_Controls()
    {
        TelaOptions.SetActive(false);
        TelaControls.SetActive(true);
    }

    public void btn_Back_Controls()
    {
        TelaOptions.SetActive(true);
        TelaControls.SetActive(false);
    }

    public void btn_Back_Options()
    {
        if (jogo_ativo == false)
        {
            TelaStart.SetActive(true);
            TelaOptions.SetActive(false);
        }

        if (jogo_ativo == true)
        {
            TelaPausa.SetActive(true);
            TelaOptions.SetActive(false);
        }
    }

    public void btn_SFX()
    { 
        if (able_SFX == true)
        {
            Debug.Log("Sound Effects Disabled");
            able_SFX = false;
        }
        else
        {
            Debug.Log("Sound Effects Enabled");
            able_SFX = true;
        }
    }

    public void btn_Music()
    {
        if (able_Music == true)
        {
            Debug.Log("Music Disabled");
            able_Music = false;
        }
        else
        {
            Debug.Log("Music Enabled");
            able_Music = true;
        }
    }

    public void btn_Back_Audio()
    {
        TelaOptions.SetActive(true);
        TelaAudio.SetActive(false);
    }
}
