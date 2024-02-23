using DTC.New.Presets.V2.Aircrafts.AH64D;
using DTC.New.Presets.V2.Aircrafts.F15E;
using DTC.New.Presets.V2.Aircrafts.F16;
using DTC.New.Presets.V2.Aircrafts.FA18;
using DTC.New.Presets.V2.Base;
using DTC.New.UI.Aircrafts.AH64D;
using DTC.New.UI.Aircrafts.F15E;
using DTC.New.UI.Aircrafts.F16;
using DTC.New.UI.Aircrafts.FA18;

namespace DTC.New.UI.Base.Pages
{
    internal class AircraftPageFactory
    {
        public static AircraftPage Make(Aircraft aircraft, Preset preset)
        {
            return aircraft switch
            {
                F16Aircraft => new F16Page(aircraft, preset),
                FA18Aircraft => new FA18Page(aircraft, preset),
                F15EAircraft => new F15EPage(aircraft, preset),
                AH64DAircraft => new AH64DPage(aircraft, preset),
                _ => throw new NotImplementedException()
            };
        }
    }
}
