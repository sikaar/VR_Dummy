using System.Collections;
using System.Collections.Generic;
using Oculus.Platform;
using UnityEngine;
using Application = Oculus.Platform.Application;

public class DeepLink : MonoBehaviour
{
    private ulong theappID;

    private string thepackagename;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OpenDeepLinkGolfPlus()
    {
        theappID = 2412327085529357;
        thepackagename = "com.golfscope.proputt";
        }
    
    public void OpenDeepLinkGolf5()
    {
        theappID = 4113720305326115;
        thepackagename = "com.aaagamestudios.golf5eclub";
        }

    public void OpenDeepLink()
    {
        var options = new ApplicationOptions();
        options.SetDeeplinkMessage("abc");
        Application.LaunchOtherApp(theappID, options);
    }
    
    public void launchApp()
    {
        string packageName = thepackagename;
        bool fail = false;
        string bundleId = packageName; // your target bundle id
        AndroidJavaClass up = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject ca = up.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaObject packageManager = ca.Call<AndroidJavaObject>("getPackageManager");

        AndroidJavaObject launchIntent = null;
        try
        {
            launchIntent = packageManager.Call<AndroidJavaObject>("getLaunchIntentForPackage", bundleId);
        }
        catch (System.Exception e)
        {
            fail = true;
        }

        if (fail)
        { //open app in store
           // Application.OpenURL("https://google.com");
        }
        else //open the app
            ca.Call("startActivity", launchIntent);

        up.Dispose();
        ca.Dispose();
        packageManager.Dispose();
        launchIntent.Dispose();
    }
    
    
}
