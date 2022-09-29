using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineurOwnedStates : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EnterMineAndDigForNugget(Mineur pMiner){
    //if the miner is not already located at the goldmine, he must
    //change location to the gold mine
        if (pMiner.Location() != currentLocation.goldmine){
            Debug.Log("Walkin' to the goldmine");

            pMiner.ChangeLocation(goldmine);
        }
    }
}
