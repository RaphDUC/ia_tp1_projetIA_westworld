using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    Mineur mineur = new Mineur();
    Femme femme = new Femme();
    Soulard soulard = new Soulard();


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("hey");
        mineur.setmanager(this);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
