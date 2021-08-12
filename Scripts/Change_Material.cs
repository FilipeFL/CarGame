using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_Material : MonoBehaviour
{
    public Material pavimento;

    private Player Player;
    
    private bool can_change = false;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        Can_Change();
    }

    void Can_Change()
    {
        if (Player.ato_2 == true)
        {
            can_change = true;
        }
        

        if(can_change == true)
        {
            Change();
        }
    }

    void Change()
    {
        GetComponent<Renderer>().material = pavimento;
    }
}
