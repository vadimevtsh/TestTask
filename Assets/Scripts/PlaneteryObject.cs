using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlaneteryObject : MonoBehaviour, IPlaneteryObject
{
    [SerializeField]
    private MassClassEnum _massClass;
    private double _mass;
    private double _planetRadius;
    private float _amplitude;
    private float _frequence;

    private void Awake()
    {
        _frequence = Random.Range(0.001f, 5f);
        _amplitude = Random.Range(0.001f, 30f);
        _massClass = (MassClassEnum)Random.Range(0, Enum.GetValues(typeof(MassClassEnum)).Length);

        switch (_massClass)
        {
            case MassClassEnum.Asteroidan:
                _mass = Random.Range(0.0000001f, 0.00001f);
                _planetRadius = Random.Range(0.01f, 0.03f);
                _mass *= 100;
                break;
            case MassClassEnum.Mercurian:
                _mass = Random.Range(0.00001f, 0.1f);
                _planetRadius = Random.Range(0.03f, 0.7f);
                _mass *= 10;
                break;
            case MassClassEnum.Subterran:
                _mass = Random.Range(0.1f, 0.5f);
                _planetRadius = Random.Range(0.5f, 1.2f);
                _mass *= 5;
                break;
            case MassClassEnum.Terran:
                _mass = Random.Range(0.5f, 2);
                _planetRadius = Random.Range(0.8f, 1.9f);
                break;
            case MassClassEnum.Superterran:
                _mass = Random.Range(2f, 10f);
                _planetRadius = Random.Range(1.3f, 3.3f);
                _mass = Mathf.Sqrt((float)_mass) / 5;
                break;
            case MassClassEnum.Neptunian:
                _mass = Random.Range(10, 50f);
                _planetRadius = Random.Range(2.1f, 5.7f);
                _mass = Mathf.Sqrt((float)_mass) / 10;
                break;
            case MassClassEnum.Jovian:
                _mass = Random.Range(50, 5000f);
                _planetRadius = Random.Range(3.5f, 27f);
                _mass = Mathf.Sqrt((float)_mass) / 100;
                break;
        }
        transform.localScale = new Vector3(
            (float)(_planetRadius * _mass), 
            (float)(_planetRadius * _mass),
            (float)(_planetRadius * _mass));
    }

    public void OrbitalMovement(float deltaTime)
    {
        float x = Mathf.Cos(deltaTime * _frequence) * _amplitude;
        float y = Mathf.Sin(deltaTime * _frequence) * _amplitude;
        float z = 0;

        transform.position = new Vector3(x, y, z);
    }

    public MassClassEnum massClass
    {
        get => _massClass;
        set => _massClass = value;
    }
    
    public double mass
    {
        get => _mass;
        set => _mass = value;
    }
}
