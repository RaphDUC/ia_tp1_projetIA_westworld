using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulardOwnedStates : MonoBehaviour
{

     public Soulard pDrunken;
    public Manager manager;

    public enum currentState
    {

        GoHomeAndSleepTilThirsty,
        DrinkWhiskeyAtWill,
        BenderWithMiner,


    };
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    //ADD FUNCTIONS STATE BETWEEN HERE

    //------------------------------------------------------------------------methods for GoHomeAndSleepTilRested


    void GoHomeAndSleepTilThirsty()
    {
        if (pDrunken.GetCurrentLocation() != Location.currentLocation.drunken_house)
        {

            Debug.Log(pDrunken.getName() + ": " + "Hips !!..Gonna go' home");
            pDrunken.SetLocation(Location.currentLocation.drunken_house);




        }

        //if miner is not fatigued start to dig for nuggets again.
        if (!pDrunken.Thirsty())
        {

            Debug.Log(pDrunken.getName() + ": " + "Ah man... 'm thirsty again... need more whiskey, fella' !");
            pDrunken.SetState(currentState.DrinkWhiskeyAtWill);



        }

        else
        {
            //sleep
            pDrunken.DecreaseThirst();
            Debug.Log(pDrunken.getName() + ": " + "ZZZZ...hips!... ");

        }


        //switch (msg.Msg)
        //{
        //    case Msg_HeyDrunkManImHere:

        //        //send a delayed message myself so that I know I'll need to call the miner to have a bender
        //        Dispatch->DispatchMessage(SEND_MSG_IMMEDIATELY,                  //time delay
        //            pDrunken->ID(),           //sender ID
        //            ent_Miner_Bob,           //receiver ID
        //            Msg_NopeFellaImNothere,        //msg
        //            NO_ADDITIONAL_INFO);

        //}



    }

    //------------------------------------------------------------------------DrinkWhiskeyAtWill



    void DrinkWhiskeyAtWill()
    {
        if (pDrunken.GetCurrentLocation() != Location.currentLocation.saloon)
        {
            pDrunken.SetLocation(Location.currentLocation.saloon);
            Debug.Log(pDrunken.getName() + ": " + "Le'z go to the saloon...hips !...");

        }

        pDrunken.DrinkLotOfWhiskey();

        Debug.Log(pDrunken.getName() + ": " + "Hips !...Raaah..enough drinkin'...");

        pDrunken.SetState(currentState.GoHomeAndSleepTilThirsty);

        Debug.Log(pDrunken.getName() + ": " + "Leavin'..hips !...the saloon..");



        //switch (msg.Msg)
        //{
        //    case Msg_HeyDrunkManImHere:

        //        //send a delayed message myself so that I know I'll need to call the miner to have a bender
        //        Dispatch->DispatchMessage(0,                  //time delay
        //            pDrunken->ID(),           //sender ID
        //            ent_Miner_Bob,           //receiver ID
        //            Msg_HoiFellaLetsHaveABender,        //msg
        //            NO_ADDITIONAL_INFO);

        //        pDrunken->GetFSM()->ChangeState(BenderWithMiner::Instance());

        //        return true;
        //}


    }



    //------------------------------------------------------------------------Bender




    void BenderWithMiner()
    {
        //if miner is here, invite him to drink and tchat


        Debug.Log(pDrunken.getName() + ": " + ":Arrrh... let's drin' a bit, shall we ?");


        Debug.Log(pDrunken.getName() + ": " + ": Hey, ya need to drink a bit more like this, mattey' !");



        pDrunken.SetState(currentState.DrinkWhiskeyAtWill);



        Debug.Log(pDrunken.getName() + ": " + " Burp...that was fine...hips!..");


        //switch (msg.Msg)
        //{
        //    case Msg_HeyDrunkManImHere:

        //        //send a delayed message myself so that I know I'll need to call the miner to have a bender
        //        Dispatch->DispatchMessage(0,                  //time delay
        //            pDrunken->ID(),           //sender ID
        //            ent_Miner_Bob,           //receiver ID
        //            Msg_NopeFellaImNothere,        //msg
        //            NO_ADDITIONAL_INFO);



        //        return true;
        //}


    }




    //AND HERE

}
