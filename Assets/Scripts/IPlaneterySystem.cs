using System.Collections.Generic;

public interface IPlaneterySystem
{
    IEnumerable<IPlaneteryObject> planeteryObjects
    {
        get;
        set;
    }

    void Update(float deltaTime);
}
