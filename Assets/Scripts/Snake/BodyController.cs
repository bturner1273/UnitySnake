using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyController : MonoBehaviour {
    private Vector2 currentLocation;
    private Vector2 lastLocation;
    private bool isBody;
    

    private void Start()
    {
        isBody = false;
        currentLocation = new Vector2();
        lastLocation = new Vector2();      
    }

   // private void Update()
    //{
        //lastLocation = currentLocation;
        //currentLocation = transform.position;
    //}

    public bool GetIsBody()
    {
        return isBody;
    }

    public void SetIsBody(bool initIsBody)
    {
        isBody = initIsBody;
    }

    public void SetCurrentLocation(Vector2 initCurrentLocation)
    {
        lastLocation = currentLocation;
        currentLocation = initCurrentLocation;
        transform.position = initCurrentLocation;
    }

    public Vector2 GetCurrentLocation()
    {
        return currentLocation;
    }

    public Vector2 GetLastLocation()
    {
        return lastLocation;
    }
}
