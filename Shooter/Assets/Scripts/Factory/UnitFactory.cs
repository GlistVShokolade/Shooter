using System;
using System.Collections.Generic;

public class UnitFactory : Factory<Unit, Unit>
{
    public override Unit Create(Unit obj)
    {
        if (obj == null)
        {
            throw new NullReferenceException(nameof(obj));
        }

        Unit unit = Instantiate(obj);

        Buffer.Add(unit);

        return unit;
    }

    public override void Remove(Unit obj)
    {
        if (obj == null)
        {
            throw new NullReferenceException(nameof(obj));
        }
        if (Buffer.Contains(obj) == false)
        {
            throw new KeyNotFoundException(nameof(obj));
        }

        Buffer.Remove(obj);
    }
}