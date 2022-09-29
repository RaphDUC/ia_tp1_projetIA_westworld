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
    const int ComfortLevel       = 5;
    //the amount of nuggets a miner can carry
    const int MaxNuggets         = 3;
    //above this value a miner is thirsty
    const int ThirstLevel        = 5;
    //above this value a miner is sleepy
    const int TirednessThreshold = 5;

    //how many nuggets the miner has in his pockets
    private int                   m_iGoldCarried = 0;
    private int                   m_iMoneyInBank = 0;
    //the higher the value, the thirstier the miner
    private int                   m_iThirst = 0;
    //the higher the value, the more tired the miner
    private int                   m_iFatigue = 0;



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

    void AddToGoldCarried(int val){
        m_iGoldCarried += val;

    if (m_iGoldCarried < 0){
        m_iGoldCarried = 0;
    }

    void AddToWealth(int val){
        m_iMoneyInBank += val;

        if (m_iMoneyInBank < 0) 
            m_iMoneyInBank = 0;
    }

    bool Thirsty() {
        if (m_iThirst >= ThirstLevel){
            return true;
        }

        return false;
    }

    bool Fatigued(){
        if (m_iFatigue > TirednessThreshold)
        {
            return true;
        }
        return false;
    }

    void DecreaseFatigue(){
        m_iFatigue -= 1;
    
    }

    void IncreaseFatigue(){
        m_iFatigue += 1;
    }

    int Wealth(){
        return m_iMoneyInBank;
    }

    void SetWealth(int val){
        m_iMoneyInBank = val;
    }
    
    void AddToWealth(int val);

    void BuyAndDrinkAWhiskey(){
        m_iThirst = 0; 
        m_iMoneyInBank-=2;
    }


}

}
