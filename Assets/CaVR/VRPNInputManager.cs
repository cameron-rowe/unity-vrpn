using System;
using System.Collections.Generic;

public class VRPNInputManager
{
    private Dictionary<string, string> ButtonMap = new Dictionary<string, string>();
    private Dictionary<string, string> AnalogMap = new Dictionary<string, string>();
    private Dictionary<string, string> SixdofMap = new Dictionary<string, string>();

    private Dictionary<string, bool> ButtonValues = new Dictionary<string, bool>();
    private Dictionary<string, float> AnalogValues = new Dictionary<string, float>();
    private Dictionary<string, Sixdof> SixdofValues = new Dictionary<string, Sixdof>();

    private Config config;

    private void ConfigureInputs() {
        //SixdofMap.Add("wheel", "WiiMote0[0]");
    }

    // Use this for initialization
    public void Start(Config c) {
        ConfigureInputs();

        foreach(var button in ButtonMap.Values) {
            ButtonValues.Add(button, false);
        }

        foreach(var analog in AnalogMap.Values) {
            AnalogValues.Add(analog, 0.0f);
        }

        foreach(var sixdof in SixdofMap.Values) {
            SixdofValues.Add(sixdof, new Sixdof());
        }

		config = c;
    }

    public void Update() {
        string device;
        int channel;

		if(config.IsMaster) {
			foreach(var button in ButtonMap.Values) {
				GetDeviceAndChannel(button, out device, out channel);
				ButtonValues[button] = config.GetButtonValue(device, channel);
			}

			foreach(var analog in AnalogMap.Values) {
				GetDeviceAndChannel(analog, out device, out channel);
				AnalogValues[analog] = config.GetAnalogValue(device, channel);
			}

			foreach(var sixdof in SixdofMap.Values) {
				GetDeviceAndChannel(sixdof, out device, out channel);
				SixdofValues[sixdof] = config.GetSixdofValue(device, channel);
			}
		}
    }

    public bool GetButtonValue(string name) {
        return ButtonValues[ButtonMap[name]];
    }

    public float GetAnalogValue(string name) {
        return AnalogValues[AnalogMap[name]];
    }

    public Sixdof GetSixdofValue(string name) {
        return SixdofValues[SixdofMap[name]];
    }

    private static void GetDeviceAndChannel(string addr, out string device, out int channel) {
        var split = addr.Split('[');
        device = split[0].Replace("]", string.Empty);
        var channelStr = split[1].Replace("]", string.Empty);
        channel = int.Parse(channelStr);
    }
}
