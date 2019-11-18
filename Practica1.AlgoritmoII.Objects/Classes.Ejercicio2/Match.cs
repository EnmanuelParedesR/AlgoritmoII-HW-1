using System;

namespace Practica1.AlgoritmoII.Objects.Classes.Ejercicio2
{
    //TODO: Remove and use a KeyValuePair [Dictionary]
    public class Match
    {
        public readonly Nut Nut;
        public readonly Screw Screw;
        public readonly int Diameter;

        public Match(Nut _nut, Screw _screw)
        {
            Nut = _nut;
            Screw = _screw;

            if (_nut.Diameter != _screw.Diameter)
                throw new Exception("Error with diameter compare");
            Diameter = _nut.Diameter;
        }
    }
}
