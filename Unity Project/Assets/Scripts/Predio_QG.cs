using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Predio_QG : MonoBehaviour
{
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
        if (objeto.tag == "Boss")
        {
            //Encerra o áudio do Boss
            BossScript.AudioEngineBoss.Stop();
            BossScript.AudioSiren.Stop();

            gameObject.SetActive(false);

            Controlador.GameAccomplished();
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
