using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulardOwnedStates : MonoBehaviour
{
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


    void GoHomeAndSleepTilThirsty(Soulard pDrunken)
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
            pDrunken->DecreaseThirst();

            cout << "\n" << GetNameOfEntity(pDrunken->ID()) << ": " << "ZZZZ...hips !... ";
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



    void DrinkWhiskeyAtWill(Soulard pDrunken)
    {
        if (pDrunken->Location() != saloon)
        {
            pDrunken->ChangeLocation(saloon);

            cout << "\n" << GetNameOfEntity(pDrunken->ID()) << ": " << "Le'z go to the saloon...hips !...";
        }

        pDrunken->DrinkLotOfWhiskey();

        cout << "\n" << GetNameOfEntity(pDrunken->ID()) << ": " << "Hips !...Raaah..enough drinkin'...";

        pDrunken->GetFSM()->ChangeState(GoHomeAndSleepTilThirsty::Instance());

        cout << "\n" << GetNameOfEntity(pDrunken->ID()) << ": " << "Leavin'..hips !...the saloon..";

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




    void BenderWithMiner(Soulard drunken)
    {
        //if miner is here, invite him to drink and tchat

        cout << "\n" << GetNameOfEntity(drunken->ID()) << ":Arrrh... let's drin' a bit, shall we ?";

        cout << "\n" << GetNameOfEntity(drunken->ID()) << ": Hey, ya need to drink a bit more like this, mattey' !";

        drunken->GetFSM()->ChangeState(DrinkWhiskeyAtWill::Instance());

        SetTextColor(FOREGROUND_GREEN | FOREGROUND_INTENSITY);

        cout << "\n" << GetNameOfEntity(drunken->ID()) << ": Burp...that was fine...hips !..";

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
