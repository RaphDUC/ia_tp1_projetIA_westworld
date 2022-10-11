using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random=UnityEngine.Random;


public class MineurOwnedStates : MonoBehaviour
{
    public Mineur pMiner;
    public Manager manager;
    public GameObject txt_mineur;
    public string etat;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(New_Update());
    }

    // Update is called once per frame
    

    //void EnterMineAndDigForNugget(Mineur pMiner){
    ////if the miner is not already located at the goldmine, he must
    ////change location to the gold mine
    //    if (pMiner.Location() != currentLocation.goldmine){
    //        Debug.Log("Walkin' to the goldmine");

    //        pMiner.ChangeLocation(goldmine);
    //    }
    //}




    public enum currentState
    {
        EnterMineAndDigForNugget,
        VisitBankAndDepositGold,
        GoHomeAndSleepTilRested,
        BuyAndDrinkWhiskey,
        Bender,

        EatStew
    };


    //------------------------------------------------------------------------methods for EnterMineAndDigForNugget



    void EnterMineAndDigForNugget()
    {

        //if the miner is not already located at the goldmine, he must
        //change location to the gold mine

        //Enter
        if (pMiner.GetCurrentLocation() != Location.currentLocation.goldmine)
        {
            Debug.Log(pMiner.getName() + ": " + "Walkin' to the goldmine");
            etat = pMiner.getName() + ": " + "Walkin' to the goldmine";
            pMiner.SetLocation(Location.currentLocation.goldmine);

        }

        //Execute

        pMiner.AddToGoldCarried(1);

        pMiner.IncreaseFatigue();
        pMiner.IncreaseHunger();

        if (pMiner.Hungry())
        {
            int i = 0;
            manager.SendMessage("MessageMineurOwnedStates", i);

        }

        Debug.Log(pMiner.getName() + ": " + "Pickin' up a nugget");
        etat = pMiner.getName() + ": " + "Pickin' up a nugget";


        if (pMiner.PocketsFull())
        {
            pMiner.SetState(currentState.VisitBankAndDepositGold);
        }

        if (pMiner.Thirsty())
        {
            pMiner.SetState(currentState.BuyAndDrinkWhiskey);
        }

        Debug.Log(pMiner.getName() + ": " + "Ah'm leavin' the goldmine with mah pockets full o' sweet gold");
        etat = pMiner.getName() + ": " + "Ah'm leavin' the goldmine with mah pockets full o' sweet gold";


    }

    void VisitBankAndDepositGold()
    {
        if (pMiner.GetCurrentLocation() != Location.currentLocation.bank)
            pMiner.SetLocation(Location.currentLocation.bank);

        pMiner.AddToWealth(pMiner.GoldCarried());

        pMiner.SetGoldCarried(0);

        Debug.Log(pMiner.getName() + ": " + "Depositing gold. Total savings now: " + pMiner.Wealth());
        etat = pMiner.getName() + ": " + "Depositing gold. Total savings now: " + pMiner.Wealth();

        //////



        //wealthy enough to have a well earned rest?
        if (pMiner.Wealth() >= pMiner.ComfortLevel)
        {
            Debug.Log(pMiner.getName() + ": " + "WooHoo! Rich enough for now. Back home to mah li'lle lady");
            etat = pMiner.getName() + ": " + "WooHoo! Rich enough for now. Back home to mah li'lle lady";

            pMiner.SetState(currentState.GoHomeAndSleepTilRested);

        }

        //otherwise get more gold
        else
        {
            pMiner.SetState(currentState.EnterMineAndDigForNugget);
        }

        Debug.Log(pMiner.getName() + ": " + "Leavin' the bank");
        etat = pMiner.getName() + ": " + "Leavin' the bank";

    }







    //------------------------------------------------------------------------methods for GoHomeAndSleepTilRested



    void GoHomeAndSleepTilRested()
    {
        if (pMiner.GetCurrentLocation() != Location.currentLocation.shack)
        {
            if (!pMiner.Alcooled())
            {
                Debug.Log(pMiner.getName() + ": " + "Walkin' home");
                etat = pMiner.getName() + ": " + "Walkin' home";

            }
            else
            {
                Debug.Log(pMiner.getName() + ": " + "Walkin'...hips !... home !..hips !...");
                etat = pMiner.getName() + ": " + "Walkin'...hips !... home !..hips !...";


            }

            pMiner.SetLocation(Location.currentLocation.shack);

            manager.SendMessage("MessageMineurOwnedStates", 1);

            //let the wife know I'm home
            //Dispatch->DispatchMessage(SEND_MSG_IMMEDIATELY, //time delay
            //                          pMiner->ID(),        //ID of sender
            //                          ent_Elsa,            //ID of recipient
            //                          Msg_HiHoneyImHome,   //the message
            //                          NO_ADDITIONAL_INFO);
        }

        //if miner is not fatigued start to dig for nuggets again.
        if (!pMiner.Fatigued())
        {
            //If miner was drunk before, he is not anymore, hooray !
            if (pMiner.Alcooled())
            {
                pMiner.SetAlcooled(false);

                Debug.Log(pMiner.getName() + ": " + "Pffew... more sober right now !...");
                etat = pMiner.getName() + ": " + "Pffew... more sober right now !...";


            }
            Debug.Log(pMiner.getName() + ": " + "All mah fatigue has drained away.Time to find more gold!");
            etat = pMiner.getName() + ": " + "All mah fatigue has drained away.Time to find more gold!";


            pMiner.SetState(currentState.EnterMineAndDigForNugget);
        }

        else
        {
            //sleep
            pMiner.DecreaseFatigue();
            Debug.Log(pMiner.getName() + ": " + "ZZZZ... ");
            etat = pMiner.getName() + ": " + "ZZZZ... ";


            if (pMiner.Alcooled())
            {
                Debug.Log(pMiner.getName() + ": " + "Hips !... ");
                etat = pMiner.getName() + ": " + "Hips !... ";


            }
        }

        int i = 0;
        manager.SendMessage("MessageMineurOwnedStates",i);

    }





    //   switch(msg.Msg)
    //   {
    //   case Msg_StewReady:

    //     cout << "\nMessage handled by " << GetNameOfEntity(pMiner->ID())
    //     << " at time: " << Clock->GetCurrentTime();

    //    SetTextColor(FOREGROUND_RED|FOREGROUND_INTENSITY);



    //     if (!pMiner->Alcooled()) {
    //         cout << "\n" << GetNameOfEntity(pMiner->ID())
    //             << ": Okay Hun, ahm a comin'!";
    //     }
    //     else
    //{
    //    cout << "\n" << GetNameOfEntity(pMiner->ID()) << ": " << "Hips...'hm a comin'";

    //}

    //pMiner->GetFSM()->ChangeState(EatStew::Instance());


    //PLace here 

    void BuyAndDrinkWhiskey()
    {

        if (pMiner.GetCurrentLocation() != Location.currentLocation.saloon)
        {
            pMiner.SetLocation(Location.currentLocation.saloon);

            Debug.Log(pMiner.getName() + ": " + "Boy, ah sure is thusty! Walking to the saloon");
            etat = pMiner.getName() + ": " + "Boy, ah sure is thusty! Walking to the saloon";


            //send a delayed message to the drunken man
            //Dispatch->DispatchMessage(SEND_MSG_IMMEDIATELY,                  //time delay
            //    pMiner->ID(),           //sender ID
            //    ent_Drunk_man,           //receiver ID
            //    Msg_HeyDrunkManImHere,        //msg
            //    NO_ADDITIONAL_INFO);
        }


        pMiner.BuyAndDrinkAWhiskey();

        Debug.Log(pMiner.getName() + ": " + "That's mighty fine sippin' liquer");
        etat = pMiner.getName() + ": " + "That's mighty fine sippin' liquer";

        Debug.Log(pMiner.getName() + ": " + "Leaving the saloon, feelin' good"); 
        etat = pMiner.getName() + ": " + "Leaving the saloon, feelin' good";



        pMiner.SetState(currentState.GoHomeAndSleepTilRested);



        //switch (msg.Msg)
        //{
        //    case Msg_HoiFellaLetsHaveABender:
        //        //send a delayed message myself to say I'm ready for a Bender
        //        Dispatch->DispatchMessage(SEND_MSG_IMMEDIATELY,                  //time delay
        //            pMiner->ID(),           //sender ID
        //            ent_Drunk_man,           //receiver ID
        //            Msg_OkReadyForABenderDrunkMan,        //msg
        //            NO_ADDITIONAL_INFO);

        //        pMiner->GetFSM()->ChangeState(Bender::Instance());



        //    case Msg_NopeFellaImNothere:

        //        pMiner->GetFSM()->ChangeState(EnterMineAndDigForNugget::Instance());


        //        cout << "\n" << GetNameOfEntity(pMiner->ID()) << ": " << "Leaving the saloon, feelin' good";
        //}


    }

    //------------------------------------------------------------------------EatStew


    void EatStew()
    {
        Debug.Log(pMiner.getName() + ": " + "Smells Reaaal goood Elsa!");
        etat = pMiner.getName() + ": " + "Smells Reaaal goood Elsa!";

        Debug.Log(pMiner.getName() + ": " + "Tastes real good too!");
        etat = pMiner.getName() + ": " + "Tastes real good too!";

        pMiner.ResetHunger();

        pMiner.SetState(currentState.GoHomeAndSleepTilRested);


        Debug.Log(pMiner.getName() + ": " + "Thankya li'lle lady. Ah better get back to whatever ah wuz doin'");
        etat = pMiner.getName() + ": " + "Thankya li'lle lady. Ah better get back to whatever ah wuz doin'";

    }


    //------------------------------------------------------------------------Bender



    void Bender()
    {
        Debug.Log(pMiner.getName() + ": " + "Alright, let's drink all the alcohols we can, Phil' !");
        etat = pMiner.getName() + ": " + "Alright, let's drink all the alcohols we can, Phil' !";



        Debug.Log(pMiner.getName() + ": " + "Damn... and Phil' can take like ten of that.. burp !..");
        etat = pMiner.getName() + ": " + "Damn... and Phil' can take like ten of that.. burp !..";


        //two cases : i can be sober and then work... or i can be as drunk as Phil... Randomly !

        float probability = Random.Range(0.0f, 100.0f);
        


        if (probability <=50)
        {
            pMiner.SetState(currentState.EnterMineAndDigForNugget);

        }
        else
        {
            pMiner.SetAlcooled(true);
            pMiner.SetState(currentState.GoHomeAndSleepTilRested);

        }


        //two cases : i can be sober and then work... or i can be as drunk as Phil... Randomly !



        if (pMiner.Alcooled())
        {
            Debug.Log(pMiner.getName() + ": " + "All right, thanks! Enough drinkin', back to work now !");
            etat = pMiner.getName() + ": " + "All right, thanks! Enough drinkin', back to work now !";


        }
        else
        {
            Debug.Log(pMiner.getName() + ": " + "Hips ...! eeh eheha !.. 'think it was a bit too much...hips ! Thank ya -hips !- Phil !...");
            etat = pMiner.getName() + ": " + "Hips ...! eeh eheha !.. 'think it was a bit too much...hips ! Thank ya -hips !- Phil !...";



        }
    }


    IEnumerator New_Update()
    {
        yield return new WaitForSeconds(1);
         txt_mineur.GetComponent<UnityEngine.UI.Text>().text = etat;
        if (pMiner.GetCurrentState() == currentState.VisitBankAndDepositGold)
        {
            VisitBankAndDepositGold();
        }
        else if (pMiner.GetCurrentState() == currentState.GoHomeAndSleepTilRested)
        {
            GoHomeAndSleepTilRested();

        }else if (pMiner.GetCurrentState() == currentState.GoHomeAndSleepTilRested)
        {
            GoHomeAndSleepTilRested();

        }else if (pMiner.GetCurrentState() == currentState.EnterMineAndDigForNugget)
        {
            EnterMineAndDigForNugget();

        }else if (pMiner.GetCurrentState() == currentState.BuyAndDrinkWhiskey)
        {
            BuyAndDrinkWhiskey();

        }else if (pMiner.GetCurrentState() == currentState.Bender)
        {
            Bender();
        }else if (pMiner.GetCurrentState() == currentState.EatStew)
        {
            EatStew();
        }

        StartCoroutine(New_Update());

    }

}


//------------------------------------------------------------------------QuenchThirst







