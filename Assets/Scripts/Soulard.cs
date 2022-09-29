
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random=UnityEngine.Random;

public class Soulard : MonoBehaviour
{
    /// etat: 
     /*EntrerMineEtCreuser
     EtancherSoif
     
     AllerMaisonEtSeReposer
   
     Beuverie
     */

    //above this value a drunk is thirsty
    const int ThirstLevel        = 5;

       //the higher the value, the thirstier the miner
    private int                   m_iThirst = 0;


    Manager manager;

    SoulardOwnedStates state_soulard = new SoulardOwnedStates();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     bool Thirsty() {
        if (m_iThirst >= ThirstLevel){
            return true;
        }

        return false;
    }

     bool Beuverie() {

        float isAbleToMeetMiner = Random.Range(0.0f, 100.0f);

        double probability = 0.50;

        bool result = isAbleToMeetMiner < probability; 

        if (result){
            return true;
        }

        return false;
    }

    
}
