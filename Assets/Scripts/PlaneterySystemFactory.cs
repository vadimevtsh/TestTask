public class PlaneterySystemFactory : IPlaneterySystemFactory
{
    private GameManager _gameManager;

    public PlaneterySystemFactory(GameManager gameManager)
    {
        _gameManager = gameManager;
    }

    public IPlaneterySystem Create(double mass)
    { 
        PlaneterySystem planeterySystem = new PlaneterySystem(mass);
        _gameManager.OnUpdate += planeterySystem.Update;
        return planeterySystem;
    }
}