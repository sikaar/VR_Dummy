using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] public class WeatherInfo
{
    public float temperature;
    public float windspeed;
    public float winddirection;
    public int weathercode;
}

[System.Serializable] public class CurrentWeather
{
    public WeatherInfo current_weather;
}