using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monumento_Arco_Iris : MonoBehaviour
{
    private Global Controlador;

    private Player Player;

    // Start is called before the first frame update
    void Start()
    {
        Controlador = GameObject.Find("Controlador").GetComponent<Global>();
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
            Player.ato_1 = false;
            Player.ato_2 = true;

            //Permite a troca de trilha sonora respectiva ao ato.
            Controlador.PausarTrilhaAto1();
            Controlador.TocarTrilhaAto2();

            Controlador.Ato++;

            gameObject.SetActive(false);
        }
        if(objeto.tag == "NPC")
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
