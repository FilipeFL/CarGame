using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo_Movel_Grande : MonoBehaviour
{
    private Global Controlador;

    private GameObject Player;

    private Player PlayerScript;

    public GameObject ProjetilPrefab;

    private float[] TemposDisparo = { 0.5f, 1.1f, 0.2f, 0.6f, 2.2f, 3.1f, 0.3f, 1.2f };

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        Controlador = GameObject.Find("Controlador").GetComponent<Global>();
        PlayerScript = GameObject.Find("Player").GetComponent<Player>();

        this.GetComponent<Rigidbody>().AddForce(-transform.up * 2, ForceMode.Impulse);

        StartCoroutine(Disparo_Inimigo_Movel());
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.transform.GetChild(0).transform.position.z - transform.position.z > 5)
        {
            Destroy(gameObject);
        }

        if (PlayerScript.ataque_especial == true)
        {
            if (Input.GetKeyDown("space"))
            {
                if (Player.transform.GetChild(0).transform.position.z - transform.position.z > -20)
                {
                    Destroy(gameObject);
                }

                PlayerScript.ataque_especial = false;
                Controlador.ataque = false;
            }
        }
    }

    public IEnumerator Disparo_Inimigo_Movel()
    {
        yield return new WaitForSeconds(TemposDisparo[Random.Range(0, TemposDisparo.Length)]);

        GameObject projetil = Instantiate(ProjetilPrefab, transform.position - (transform.up * 2.8f), transform.rotation);
        projetil.GetComponent<Rigidbody>().AddForce(-transform.up * 10, ForceMode.Impulse);

        Destroy(projetil, 2);

        StartCoroutine(Disparo_Inimigo_Movel());
    }

    private void OnTriggerEnter(Collider objeto)
    {
        if (objeto.tag == "Player")
        {
            //Permite o clip diante dessa circunstância de gameplay.
            PlayerScript.AudioPlayer.clip = PlayerScript.AudioCrash;
            PlayerScript.AudioPlayer.Play();

            Destroy(gameObject);
            Controlador.Vida--;
        }
        if (objeto.tag == "InimigoFixo")
        {
            Destroy(objeto);
        }
        if(objeto.tag == "Ato1")
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
        if(objeto.tag == "Coletavel")
        {
            Destroy(objeto);
        }
        if(objeto.tag == "InimigoFixo")
        {
            Destroy(objeto);
        }
        if(objeto.tag == "InimigoMovel")
        {
            Destroy(objeto);
        }
        if (objeto.tag == "Projetil")
        {
            Destroy(gameObject);
        }
        if (objeto.tag == "Boss")
        {
            Destroy(gameObject);
        }
    }
}
