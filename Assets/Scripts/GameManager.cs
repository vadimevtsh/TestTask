using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    private PlaneterySystemFactory _planeterySystemFactory;
    private List<IPlaneterySystem> _planeterySystems = new List<IPlaneterySystem>();

    public event Action<float> OnUpdate; 

    void Start()
    {
        _planeterySystemFactory = new PlaneterySystemFactory(this);
        
        _planeterySystems.Add(_planeterySystemFactory.Create(5));
    }

    void Update()
    {
        OnUpdate?.Invoke(Time.time);

        foreach (PlaneterySystem planeterySystem in _planeterySystems)
        {
            planeterySystem.Update(Time.time);
        }
    }
}