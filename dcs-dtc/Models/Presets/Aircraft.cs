using DTC.Utilities;
using DTC.Models.F16;
using DTC.Models.FA18;
using DTC.Models.AH64;
using DTC.Models.F15E;

namespace DTC.Models.Presets
{
    public class Aircraft : IAircraft
    {
        public string Name
        {
            get
            {
                return Model switch
                {
                    AircraftModel.F16C => "F-16C",
                    AircraftModel.FA18C => "F/A-18C",
                    AircraftModel.AH64D => "AH-64D",
                    AircraftModel.F15E => "F-15E",
                    _ => throw new Exception()
                };
            }
        }

        public List<IPreset> Presets { get; set; }
        public AircraftModel Model { get; set; }

        public Aircraft(AircraftModel model)
        {
            Presets = new List<IPreset>();
            Model = model;
        }

        public string GetAircraftModelName()
        {
            return Enum.GetName(typeof(AircraftModel), Model);
        }

        public Type GetAircraftConfigurationType()
        {
            return Model switch
            {
                AircraftModel.F16C => typeof(F16Configuration),
                AircraftModel.FA18C => typeof(FA18Configuration),
                AircraftModel.AH64D => typeof(AH64Configuration),
                AircraftModel.F15E => typeof(F15EConfiguration),
                _ => throw new Exception()
            };
        }

        public Preset CreatePreset(string name, IConfiguration cfg = null)
        {
            if (Model == AircraftModel.F16C)
            {
                if (cfg == null)
                {
                    cfg = new F16Configuration();
                }
                var p = new Preset(name, cfg);
                Presets.Add(p);
                return p;
            }
            else if (Model == AircraftModel.FA18C)
            {
                if (cfg == null)
                {
                    cfg = new FA18Configuration();
                }
                var p = new Preset(name, cfg);
                Presets.Add(p);
                return p;
            }
            else if (Model == AircraftModel.AH64D)
            {
                if (cfg == null)
                {
                    cfg = new AH64Configuration();
                }
                var p = new Preset(name, cfg);
                Presets.Add(p);
                return p;
            }
            else if (Model == AircraftModel.F15E)
            {
                if (cfg == null)
                {
                    cfg = new F15EConfiguration();
                }
                var p = new Preset(name, cfg);
                Presets.Add(p);
                return p;
            }
            else
            {
                throw new Exception();
            }
        }

        internal IPreset ClonePreset(IPreset preset)
        {
            var p = preset.Clone();
            Presets.Add(p);
            PresetsStore.PresetChanged(this, p);
            return p;
        }

        internal void DeletePreset(IPreset preset)
        {
            Presets.Remove(preset);
            FileStorage.DeletePreset(this, preset);
        }
    }
}
