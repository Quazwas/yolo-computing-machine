using UnityEngine;
using System.Collections;

public class networkManager : MonoBehaviour {
	//Starts Server
	public void startServer(int maxConnect, int port, bool bLAN) {
		Network.InitializeServer(maxConnect, port, bLAN);
	}
	//Joins Server
	public void joinServer(string ip, int port, string pass) {
		Network.Connect(ip, port, pass);
	}
	void OnServerInitialized(){
		Debug.Log("Server Initialized.");
	}
	void OnConnectedToServer(){
		Debug.Log("Connected to Server");
	}
	void OnPlayerDisconnected(NetworkPlayer player) {
		if(Network.isServer){
			Network.RemoveRPCs(player);
			Network.DestroyPlayerObjects(player);
		}
		Debug.Log ("Player has left");
	}
}

