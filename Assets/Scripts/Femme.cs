using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Femme : MonoBehaviour
{

      //is she presently cooking?
    bool            m_bCooking = false;
    Location.currentLocation  m_Location;

    // Start is called before the first frame update
    void Start()
    {
//commentaire
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
