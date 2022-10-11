using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Femme : MonoBehaviour
{

    public int nbr_apelle=0;

    public FemmeOwnedStates femmeownedstates; 

      //is she presently cooking?
    bool            m_bCooking = false;
    Location.currentLocation  m_Location;

    // Start is called before the first frame update
    void Start()
    {
//commentaire
        m_bCooking = false;
        StartCoroutine(New_Update());
    }

    // Update is called once per frame
    IEnumerator New_Update()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("etat bouffe " + m_bCooking);
        StartCoroutine(New_Update());
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
        nbr_apelle++;

    }

    void Mineur_Faim2(){
        femmeownedstates.setstat(2);
        nbr_apelle++;

    }

    void Mineur_Maison()
    {
        if (m_bCooking)
        {
            Debug.Log("azseldfnoeqdlonfbl" + m_bCooking);
            femmeownedstates.CookStew_serve();
            femmeownedstates.CookStew_food_ready();
        }
    }

}
