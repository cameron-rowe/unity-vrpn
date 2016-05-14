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
