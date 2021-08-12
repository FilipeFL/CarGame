using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour
{
    private Global Controlador;
    
    // Start is called before the first frame update
    void Start()
    {
        Controlador = GameObject.Find("Controlador").GetComponent<Global>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider objeto)
    {
        if(objeto.tag == "Player")
        {
            Destroy(gameObject);
            Controlador.Vida--;
        }
        if(objeto.tag == "InimigoMovel")
        {
            Destroy(objeto);
        }
        if (objeto.tag == "InimigoFixo")
        {
            Destroy(objeto);
        }
        if (objeto.tag == "Ato1")
        {
            Destroy(gameObject);
        }
        if (objeto.tag == "Ato2")
        {
            Destroy(gameObject);
        }
        if (objeto.tag == "Ato3")
        {
            Destroy(gameObject);
        }
    }
}
