
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
    const int ThirstLevel = 5;

    //the higher the value, the thirstier the miner
    private int m_iThirst = 0;

    string m_name = "Phil";
    Location.currentLocation m_Location;
    SoulardOwnedStates.currentState m_State;


    Manager manager;

    SoulardOwnedStates state_soulard = new SoulardOwnedStates();

    public Location.currentLocation GetCurrentLocation()
    {
        return m_Location;
    }
    public void SetLocation(Location.currentLocation location)
    {
        this.m_Location = location;
    }

    public SoulardOwnedStates.currentState GetCurrentState()
    {
        return m_State;
    }
    public void SetState(SoulardOwnedStates.currentState state)
    {
        this.m_State = state;
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool Thirsty()
    {
        if (m_iThirst >= ThirstLevel)
        {
            return true;
        }

        return false;
    }

    public void DecreaseThirst() { m_iThirst -= 1; }
    public void IncreaseThirst() { m_iThirst += 1; }
    public void DrinkLotOfWhiskey() { m_iThirst = 0; }

 

    public string getName()
    {
        return m_name;
    }

     void TimeForBender(){
        this.SetState(SoulardOwnedStates.currentState.BenderWithMiner);
     }


}
