using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detectar_Rua : MonoBehaviour
{
    public GameObject Rua1, Rua2;
    public bool primeiro = true;

    private Monumento_Arco_Iris Demarca_Ato;

    private void OnTriggerEnter(Collider objeto)
    {
      if (objeto.name == "rua1" && primeiro == false)
      {
            Rua2.transform.Translate(Vector3.forward * 40);
      }

      if (objeto.name == "rua2")
      {
            Rua1.transform.Translate(Vector3.forward * 40);
      }

      primeiro = false;
    }

    private void Start()
    {
        Demarca_Ato = GameObject.Find("monumento_arco_iris").GetComponent<Monumento_Arco_Iris>();
    }
}
