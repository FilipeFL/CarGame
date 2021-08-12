using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coletavel : MonoBehaviour
{
    private Global Controlador;

    private GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        Controlador = GameObject.Find("Controlador").GetComponent<Global>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.transform.GetChild(0).transform.position.z - transform.position.z > 5)
        {
            Destroy(gameObject);
        }

        transform.Rotate(Vector3.forward);
    }

    private void OnTriggerEnter(Collider objeto)
    {
        if (objeto.tag == "Player")
        {
            Destroy(gameObject);
        }
        if(objeto.tag == "InimigoFixo")
        {
            Destroy(gameObject);
        }
        if(objeto.tag == "InimigoMovel")
        {
            Destroy(gameObject);
        }
        if(objeto.tag == "Coletavel")
        {
            Destroy(objeto);
            Destroy(gameObject);
        }
    }
}
