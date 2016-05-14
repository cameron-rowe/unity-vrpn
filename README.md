# VRPN on Unity

To enable VRPN functionality in your Unity3D application, simply add all of the assets in this repository to your application, including streaming assets and plugins. You **DO NOT** need to include any Project Settings.

Once the assets have been added, simply create an empty game object in your scene, and add the `CaVR` script to it. To configure input, the `ConfigureInputs()` function of the `VRPNInputManager` class must contain the mapped values to be used. For example:

```csharp
private void ConfigureInputs() {
    ButtonMap.Add("home", "WiiMote0[0]");
    ButtonMap.Add("a", "WiiMote0[3]");
    ButtonMap.Add("nunchuck-z", "WiiMote0[16]");
    
    AnalogMap.Add("x", "WiiMote0[21]");
    AnalogMap.Add("z", "WiiMote0[22]");
    
    SixdofMap.Add("wand", "WiiMote0[0]");
}
```
Button and analog bindings for the WiiMote controller for VRPN can be found at https://github.com/vrpn/vrpn/blob/master/vrpn_WiiMote.h

To access SixDOF information and button values, see the `ExampleInputScript`. The code for this class is pasted below.

```csharp
using UnityEngine;

public class ExampleInputScript : MonoBehaviour {
    private VRPNInputManager inputManager;

    // Use this for initialization
    void Start () {
        var cavr = FindObjectOfType<CaVR>();
        inputManager = cavr.InputManger;
    }
    
    // Update is called once per frame
    void Update () {
        var wand = inputManager.GetSixdofValue("wand");
        
        // do something with wand SixDOF
        transform.localPosition = wand.Position;
        
        var homeButtonPressed = inputManager.GetButtonValue("home");
        
        // do something on button press
        if(homeButtonPressed) {
            Debug.Log("Pressed Home Button!");
        }
        
        var xAxis = inputManager.GetAnalogValue("x");
        
        // do something with axis information
        transform.Rotate(Vector3.up, xAxis);
    }
}

```

The script `example.lua` located in the `StreamingAssets` folder is necessary for configuring VRPN. The buttons, analogs, and sixdofs configuration URLS must be added to use the appropriate VRPN device. The ability to configure several machines is provided, however currently only the master machine is supported.