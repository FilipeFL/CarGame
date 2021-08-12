using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estatua_Olho : MonoBehaviour
{
    private Monumento_Arco_Iris Demarca_Ato;

    private Global Controlador;

    private Boss BossScript;

    private Player Player;

    // Start is called before the first frame update
    void Start()
    {
        Controlador = GameObject.Find("Controlador").GetComponent<Global>();

        BossScript = GameObject.Find("Boss").GetComponent<Boss>();

        Player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider objeto)
    {
        if(objeto.tag == "Player")
        {
            Player.ato_2 = false;
            Player.ato_3 = true;

            //Permite a troca de trilha sonora respectiva ao ato.
            Controlador.PausarTrilhaAto2();
            Controlador.TocarTrilhaAto3();

            BossScript.AudioEngineBoss.Play();
            BossScript.AudioSiren.Play();

            Controlador.Ato++;

            gameObject.SetActive(false);
        }
        if (objeto.tag == "NPC")
        {
            Destroy(objeto);
        }
        if (objeto.tag == "Coletavel")
        {
            Destroy(objeto);
        }
        if (objeto.tag == "InimigoMovel")
        {
            Destroy(objeto);
        }
        if (objeto.tag == "InimigoFixo")
        {
            Destroy(objeto);
        }
        if (objeto.tag == "Projetil")
        {
            Destroy(objeto);
        }
    }
}
