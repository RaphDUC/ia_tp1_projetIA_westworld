using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Femme : MonoBehaviour
{

    public FemmeOwnedStates femmeownedstates; 

      //is she presently cooking?
    bool            m_bCooking = false;
    Location.currentLocation  m_Location;

    // Start is called before the first frame update
    void Start()
    {
//commentaire
        m_bCooking = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("lol");
    }

    void ChangeLocation(Location.currentLocation loc){
        m_Location=loc;
    }

    public bool Cooking(){
        return m_bCooking;
    }

    public void SetCooking(bool val){
        m_bCooking = val;
    }

    public bool GetCooking(){
        return m_bCooking;
    }

    public FemmeOwnedStates GetFemmeOwnedStates(){
        return femmeownedstates;
    }

    public void SetManager(Manager manager){
        femmeownedstates.SetManager(manager);
    }

    void Mineur_Faim(){
        femmeownedstates.setstat(2);

    }

    void Mineur_Maison()
    {
        Debug.Log("azedsuhveikdlfnvedr" + m_bCooking);
        if (m_bCooking)
        {

            
            femmeownedstates.CookStew_serve();
            femmeownedstates.CookStew_food_ready();
        }
    }
}
