using UnityEngine;

public class CaVR : MonoBehaviour {

	public static bool Terminated { get; private set; }
	public VRPNInputManager InputManger { get; private set; }

    private Config config;

    // Use this for initialization
    void Start() {
		Terminated = false;
		config = new Config();
		config.Init();
		InputManger = new VRPNInputManager();
		InputManger.Start(config);
	}

	// Update is called once per frame
	void Update() {
        InputManger.Update();
	}

	void Destroy() {
		Terminated = true;
	}
}
