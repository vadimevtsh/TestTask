using System.Collections.Generic;
using UnityEngine;

public class PlaneterySystem : IPlaneterySystem
{
    private double _mass;
    private IEnumerable<IPlaneteryObject> _planeteryObjects;

    public PlaneterySystem(double mass)
    {
        _mass = mass;
        
        PlanetarSystemCreation();
    }

    public IEnumerable<IPlaneteryObject> planeteryObjects 
    { 
        get => _planeteryObjects;
        set => _planeteryObjects = value; 
    }

    public void Update(float deltaTime)
    {
        foreach (PlaneteryObject planeteryObject in _planeteryObjects)
            planeteryObject.OrbitalMovement(deltaTime);
    }

    private void PlanetarSystemCreation()
    {
        List<IPlaneteryObject> listOfPlaneteryObjects = new List<IPlaneteryObject>();
        
        while (_mass > 0)
        {
            GameObject planetaryObject = GameObject.Instantiate
                (Resources.Load<GameObject>("Prefabs/PlaneteryObject"), Vector3.zero, Quaternion.identity);
            listOfPlaneteryObjects.Add(planetaryObject.GetComponent<PlaneteryObject>());
            _mass -= planetaryObject.GetComponent<PlaneteryObject>().mass;
        }

        if (listOfPlaneteryObjects.Count == 1)
        {
            GameObject planetaryObject = GameObject.Instantiate
                (Resources.Load<GameObject>("Prefabs/PlaneteryObject"), Vector3.zero, Quaternion.identity);
            listOfPlaneteryObjects.Add(planetaryObject.GetComponent<PlaneteryObject>());
        }

        _planeteryObjects = listOfPlaneteryObjects;
    }
}