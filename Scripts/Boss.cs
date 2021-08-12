  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private Global Controlador;

    public GameObject ProjetilPrefab;

    private float[] TemposDisparo = { 0.5f, 0.6f, 0.2f, 0.3f, 1.2f, 1.3f, 0.8f };

    Player Player;

    public AudioSource AudioEngineBoss, AudioSiren;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player").GetComponent<Player>();

        Controlador = GameObject.Find("Controlador").GetComponent<Global>();

        StartCoroutine(Disparo_Boss());
    }

    // Update is called once per frame
    void Update()
    {
        if (Controlador.pause == false)
        {
            Actions();
        }
    }

    public IEnumerator Disparo_Boss()
    {
        yield return new WaitForSeconds(TemposDisparo[Random.Range(0, TemposDisparo.Length)]);

        GameObject projetil = Instantiate(ProjetilPrefab, transform.position - (transform.forward * 2.8f), ProjetilPrefab.transform.rotation);
        projetil.GetComponent<Rigidbody>().AddForce(-transform.forward * 10, ForceMode.Impulse);
        
        Destroy(projetil, 2);

        StartCoroutine(Disparo_Boss());
    }

    private void Actions()
    {
        if (Player.ato_3 == true)
        {
            //Frente
            transform.Translate(Vector3.forward * Time.deltaTime * Player.AutomaticSpeed);
        }
    }

    private void OnTriggerEnter(Collider objeto)
    {
        if (objeto.tag == "InimigoMovel")
        {
            Destroy(objeto);
        }
        if (objeto.tag == "InimigoFixo")
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
    }
}
