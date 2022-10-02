using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mineur : MonoBehaviour
{

    /// etat: 
    /*EntrerMineEtCreuser
    EtancherSoif
    VisiterBanqueEtDeposerPepite
    AllerMaisonEtRelation
    MangerRepas

    Dispute
    Beuverie
    */


    //the amount of gold a miner must have before he feels he can go home
    public int ComfortLevel = 5;
    //the amount of nuggets a miner can carry
    public int MaxNuggets = 3;
    //above this value a miner is thirsty
    public int ThirstLevel = 5;
    //above this value a miner is sleepy
    public int TirednessThreshold = 5;

    //how many nuggets the miner has in his pockets
    private int m_iGoldCarried = 0;
    private int m_iMoneyInBank = 0;
    //the higher the value, the thirstier the miner
    private int m_iThirst = 0;
    //the higher the value, the more tired the miner
    private int m_iFatigue = 0;
    Location.currentLocation m_Location;
    MineurOwnedStates.currentState m_State;

    private bool m_alcooled;

    private string m_name = "Bob";

    Manager manager;

    MineurOwnedStates state_miner = new MineurOwnedStates();


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        m_iThirst += 1;
    }

    public Location.currentLocation GetCurrentLocation()
    {
        return m_Location;
    }
    public void SetLocation(Location.currentLocation location)
    {
        this.m_Location = location;
    }

    public MineurOwnedStates.currentState GetCurrentState()
    {
        return m_State;
    }
    public void SetState(MineurOwnedStates.currentState state)
    {
        this.m_State = state;
    }


    public void AddToGoldCarried(int val)
    {
        m_iGoldCarried += val;

        if (m_iGoldCarried < 0)
        {
            m_iGoldCarried = 0;
        }

    }

    public int GoldCarried() { return m_iGoldCarried; }
    public void SetGoldCarried(int val) { m_iGoldCarried = val; }

    public bool PocketsFull() { return m_iGoldCarried >= MaxNuggets; }




    public void AddToWealth(int val)
    {
        m_iMoneyInBank += val;

        if (m_iMoneyInBank < 0)
            m_iMoneyInBank = 0;
    }

    public bool Thirsty()
    {
        if (m_iThirst >= ThirstLevel)
        {
            return true;
        }

        return false;
    }

    public bool Fatigued()
    {
        if (m_iFatigue > TirednessThreshold)
        {
            return true;
        }
        return false;
    }

    public void DecreaseFatigue()
    {
        m_iFatigue -= 1;

    }

    public void IncreaseFatigue()
    {
        m_iFatigue += 1;
    }

    public int Wealth()
    {
        return m_iMoneyInBank;
    }

    public void SetWealth(int val)
    {
        m_iMoneyInBank = val;
    }



    public void BuyAndDrinkAWhiskey()
    {
        m_iThirst = 0;
        m_iMoneyInBank -= 2;
    }

    public void SetAlcooled(bool val)
    {
        this.m_alcooled = val;
    }

    public bool Alcooled()
    {
        if (m_alcooled)
        {
            return true;
        }
        return false;
    }
    public void setmanager(Manager manager)
    {
        this.manager = manager;
    }


    public string getName()
    {
        return m_name;
    }


}


