using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateControl : MonoBehaviour {
    Vector2 currentLocation;
    Vector2 lastLocation;

    private void Start()
    {
        currentLocation = new Vector2();
        lastLocation = new Vector2();      
    }

    private void Update()
    {
        lastLocation = currentLocation;
        currentLocation = transform.position;
    }

    public void SetCurrentLocation(Vector2 initCurrentLocation)
    {
        currentLocation = initCurrentLocation;
    }

    public Vector2 GetCurrentLocation()
    {
        return currentLocation;
    }

    public void SetLastLocation(Vector2 initLastLocation)
    {
        lastLocation = initLastLocation;
    }

    public Vector2 GetLastLocation()
    {
        return lastLocation;
    }
}
