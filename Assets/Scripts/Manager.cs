using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    public Mineur mineur;
    public Femme femme;
    Soulard soulard = new Soulard();
    public Manager m;


    // Start is called before the first frame update
    void Start()
    {
        mineur.setmanager(this);
        femme.SetManager(m);

        mineur.SetState(MineurOwnedStates.currentState.EnterMineAndDigForNugget);


        //femme.SetState(MineurOwnedStates.currentState.EnterMineAndDigForNugget);



        
    }


    // Update is called once per frame
    void Update()
    { 
        
    }

    void MessageFemmeOwnedStates(int Type_of_message){
        switch(Type_of_message){
      case 0:

        Debug.Log("envoi au mnieur que repas est près");
        mineur.SetState(MineurOwnedStates.currentState.GoHomeAndSleepTilRested);

                break;

      case 1:

        Debug.Log("Fini de manger");
                mineur.SetState(MineurOwnedStates.currentState.EatStew);

        break;

      }

    }

    void MessageMineurOwnedStates(int Type_of_message){
        switch(Type_of_message){
      case 0:

        Debug.Log("Mineur a faim");
        femme.SendMessage("Mineur_Faim");

        break;

      case 1:

        Debug.Log("Mineur à la maison");
        femme.SendMessage("Mineur_Maison");

        break;

      }

    }

}
