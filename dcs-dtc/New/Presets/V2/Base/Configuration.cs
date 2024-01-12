﻿using DTC.Utilities;
using Newtonsoft.Json;

namespace DTC.New.Presets.V2.Base;

public class ConfigurationSystem
{
    public string PropertyName { get; set; }
    public string SystemName { get; set; }
    public bool IgnoreForLoadSave { get; set; }
}

public abstract class Configuration : IConfiguration
{
    public int Version { get; } = 2;

    public static Configuration FromJson(string s, Type type)
    {
        return ConfigLoader.FromJson(s, type);
    }

    public static Configuration FromCompressedString(string s, Type type)
    {
        try
        {
            var json = StringCompressor.DecompressString(s);
            var cfg = FromJson(json, type);
            return cfg;
        }
        catch
        {
            return null;
        }
    }

    protected abstract Type GetConfigurationType();

    public string ToJson()
    {
        var json = JsonConvert.SerializeObject(this);
        return json;
    }

    public string ToCompressedString()
    {
        var json = ToJson();
        return StringCompressor.CompressString(json);
    }

    public Configuration Clone()
    {
        var json = ToJson();
        var cfg = FromJson(json, GetConfigurationType());
        return cfg;
    }

    public void CopyConfiguration<T>(T cfg) where T : Configuration
    {
        var systems = GetSystems();

        foreach (var system in systems)
        {
            var prop = GetType().GetProperty(system.PropertyName);
            var value = prop.GetValue(cfg);
            if (value != null)
            {
                prop.SetValue(this, value);
            }
        }
    }

    public virtual void AfterLoadFromJson()
    {
    }

    public List<ConfigurationSystem> GetSystems()
    {
        var props = new List<ConfigurationSystem>();

        var properties = from property in GetType().GetProperties()
                         where Attribute.IsDefined(property, typeof(SystemAttribute))
                         orderby ((SystemAttribute)property.GetCustomAttributes(typeof(SystemAttribute), false).Single()).Order
                         select property;

        foreach (var prop in properties)
        {
            var attrs = prop.GetCustomAttributes(typeof(SystemAttribute), false);
            if (attrs.Length > 0)
            {
                var attr = (SystemAttribute)attrs[0];
                props.Add(new ConfigurationSystem() { PropertyName = prop.Name, SystemName = attr.Name, IgnoreForLoadSave = attr.IgnoreForLoadSave });
            }
        }

        return props;
    }

    public bool IsSystemNull(ConfigurationSystem system)
    {
        var prop = GetType().GetProperty(system.PropertyName);
        if (prop != null)
        {
            var value = prop.GetValue(this);
            return value == null;
        }
        return true;
    }

    public void CopySystemFrom(ConfigurationSystem system, Configuration configToLoad)
    {
        var prop = GetType().GetProperty(system.PropertyName);
        var value = prop.GetValue(configToLoad);
        if (value != null)
        {
            prop.SetValue(this, value);
        }
    }

    public void ClearSystem(ConfigurationSystem system)
    {
        var prop = GetType().GetProperty(system.PropertyName);
        prop.SetValue(this, null);
    }

    IConfiguration IConfiguration.Clone()
    {
        return Clone();
    }
}
