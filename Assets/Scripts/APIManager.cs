using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
public class APIManager : MonoBehaviour
{
    [SerializeField] private string URL;
    [SerializeField] private TMP_Text tempText;

    public void GetData()
    {
        StartCoroutine(FetchData());
    }

    public IEnumerator FetchData()
    {
        using (var request = UnityWebRequest.Get(URL))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log(request.error);
            }
            else if (request.result == UnityWebRequest.Result.Success)
            {
                var resultat = request.downloadHandler.text;
              //Debug.Log(resultat);

                var Weather = JsonUtility.FromJson<CurrentWeather>(request.downloadHandler.text).current_weather;
                
               // Debug.Log(Weather.temperature);
               tempText.text = "Temp : " + Weather.temperature + " °";

            }
        }
    }
}
