using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random=UnityEngine.Random;

public class FemmeOwnedStates : MonoBehaviour
{

    int stat = 0; // DoHouseWork, VisitBathroom, CookStew
    string name = "Elza";
    int last_stat;
    public Femme wife;
    Manager manager;
    bool cook = false;
    bool cooking = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            Debug.Log("oula " + stat);

        switch(stat){
          case 0:
                DoHouseWork();
                DoHouseWork_Message();

            break;

          case 1:

            VisitBathroom_going();
            VisitBathroom();
            VisitBathroom_exit();

            break;

          case 2:
            CookStew_four();
            CookStew();

            break;
        }
    }

    void WifesGlobalState (){
          //1 in 10 chance of needing the bathroom (provided she is not already in the bathroom)
          if ( (Random.Range(0.0f, 100.0f) < 10) && stat != 1){
            last_stat=stat;
            stat=1;
          }
    }

    /*bool WifesGlobalState (){

      switch(msg.Msg)
      {
      case Msg_HiHoneyImHome:
       {
           cout << "\nMessage handled by " << GetNameOfEntity(wife->ID()) << " at time: " 
           << Clock->GetCurrentTime();

         SetTextColor(FOREGROUND_GREEN|FOREGROUND_INTENSITY);

         cout << "\n" << GetNameOfEntity(wife->ID()) << 
              ": Hi honey. Let me make you some of mah fine country stew";

         wife->GetFSM()->ChangeState(CookStew::Instance());
       }

       return true;

      }//end switch

      return false;
    }*/

    //-------------------------------------------------------------------------DoHouseWork

    /*DoHouseWork DoHouseWork(){
      static DoHouseWork instance;

      return &instance;
    }*/


    void DoHouseWork(){
        Debug.Log(name+" :Time to do some more housework!");
    }


    void DoHouseWork_Message(){
      switch(Random.Range(0,3)){

      case 0:

        Debug.Log(name+" : Moppin' the floor");

        break;

      case 1:

        Debug.Log(name+" : Washin' the dishes");

        break;

      case 2:
        last_stat=stat;
        stat=1;

        break;

    case 3:
        Debug.Log(name+" : Makin' the bed");
    break;
      }
    }


//------------------------------------------------------------------------VisitBathroom


void VisitBathroom_going(){  

    Debug.Log(name+" : Walkin' to the can. Need to powda mah pretty li'lle nose");

}


void VisitBathroom(){

    Debug.Log(name+" : Ahhhhhh! Sweet relief!");
    last_stat=stat;
    stat=last_stat;
}

void VisitBathroom_exit(){

    Debug.Log(name+" : Leavin' the Jon");
}



//------------------------------------------------------------------------CookStew



void CookStew_four(){
  //if not already cooking put the stew in the oven
  
  if (!cook && !cooking){

    Debug.Log(name+" : Putting the stew in the oven");
  
    //send a delayed message myself so that I know when to take the stew
    //out of the oven
    cooking = true;
    Debug.Log("ezsbvzebdjusbloezsdlovnhsndsv");
    StartCoroutine(cookstew_four_delay());
    last_stat=stat;
    stat=3; 

  }
}


void CookStew(){
     Debug.Log(name+" : Fussin' over food");
}

public void CookStew_serve(){

    Debug.Log(name+" : Puttin' the stew on the table");

}


public void CookStew_food_ready(){ // message 
        manager.SendMessage("MessageFemmeOwnedStates", 1);
        Debug.Log(name+" : at time : "+Time.time);

    Debug.Log(name+" : StewReady! Lets eat ");


    //a ajouter envoye message au mineur la bouffe est prete

    wife.SetCooking(false);
    cook = false;
   

    last_stat=stat;
    stat=0;               
}

    IEnumerator cookstew_four_delay()
    {
        yield return new WaitForSeconds(1.5f);
        int i = 0;
        manager.SendMessage("MessageFemmeOwnedStates",i);
        wife.SetCooking(true);
        cook = true;
        cooking = false;
    }

    public void SetManager(Manager manager){
        this.manager = manager;
    }

    public void setstat(int stat){
        this.stat = stat;
        Debug.Log("oula " + stat);
        CookStew_four();
        CookStew();

    }
}
