using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;
using UnityEngine.UI;
public class NetworkClientUI : MonoBehaviour {
	NetworkClient client;
	public Text status;
	public InputField ip;
	public Button connection;
	
	void Start () {
		client = new NetworkClient();
		Input.gyro.enabled = true;
		
	}
	public void connect()
	{

		client.Connect(ip.text, 25000);
	}
	
	void Update () {
		var temp1 = DeviceRotation.Get();
		var temp = temp1.eulerAngles;
		if (client.isConnected)
			{
				connection.interactable = false;
				status.text = "Connected";
				StringMessage msg = new StringMessage();
				msg.value = temp.x + "|" + temp.y + "|" + temp.z ;
				client.Send(888, msg);
			}
	}
}
