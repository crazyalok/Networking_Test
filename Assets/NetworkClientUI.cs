using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;
using UnityEngine.UI;
public class NetworkClientUI : MonoBehaviour {
	NetworkClient client;
	public Text text,text1;
	void OnGUI()
	{
		string ipaddress = Network.player.ipAddress;
		GUI.Box(new Rect(10, Screen.height - 50, 100, 50), ipaddress);
		GUI.Label(new Rect(20, Screen.height - 30, 100, 20), "Status : " + client.isConnected);
		if (!client.isConnected)
		{
			if(GUI.Button(new Rect(10, 10, 60, 50), "Connect"))
			{
				connect();
			}
		}
	}
	void Start () {
		client = new NetworkClient();
		Input.gyro.enabled = true;
	}
	void connect()
	{
		client.Connect("192.168.43.139", 25000);
	}
	
	void Update () {

		var temp1 = DeviceRotation.Get();
		//var temp1 = Input.gyro.attitude;
		var temp = temp1.eulerAngles;
		text.text = temp.normalized.ToString();
		text1.text = temp.ToString();
		var pos = Input.acceleration;
		if (client.isConnected)
		{
			StringMessage msg = new StringMessage();
			msg.value = temp.x + "|" + temp.y + "|" + temp.z + "|" + pos.x + "|" + pos.y + "|" + pos.z; ;
			//msg.value = temp.x + "|" + temp.y + "|" + temp.z + "|"+temp.w + "|" + pos.x + "|" + pos.y + "|" + pos.z;
			client.Send(888, msg);
		}
	}
}
