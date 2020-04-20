using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;
using UnityEngine.UI;

public class NetworkServerUI : MonoBehaviour {
	public Text ip;
	void Start () {
		string ipaddress = Network.player.ipAddress;
		ip.text = "ip : " + ipaddress.ToString();
		NetworkServer.Listen(25000);
		NetworkServer.RegisterHandler(888, ServerRecieveMessage);
	}
	void Update () {
		
	}
	void ServerRecieveMessage(NetworkMessage message)
	{
		StringMessage msg = new StringMessage();
		msg.value = message.ReadMessage<StringMessage>().value;
		string[] val = msg.value.Split('|');
		Debug.Log(val[0]+","+val[1] + ","+val[2]);
		Calibrator.transform.eulerAngles = new Vector3((float.Parse(val[2])), (float.Parse(val[1]))+180, float.Parse(val[0])*0);
		}
}
