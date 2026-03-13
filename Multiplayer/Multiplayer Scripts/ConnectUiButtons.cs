using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
using Newtonsoft.Json.Bson;
using Unity.VisualScripting;

public class ConnectUiButtons : MonoBehaviour
{

    [SerializeField] private Button Host;
    [SerializeField] private Button Client;
    [SerializeField] private Button Server;
    [SerializeField] private GameObject ConnectionButtonPanel;
    public string ipAddress = "127.0.0.1";

    
    void Start()
    {
        Host.onClick.AddListener(HostButtonOnClick);
        Client.onClick.AddListener(ClientButtonOnClick);
        Server.onClick.AddListener(ServerButtonOnClick);
    }

    private void HostButtonOnClick()
    {
        NetworkManager.Singleton.StartHost();
    }

    private void ClientButtonOnClick()
    {
        NetworkManager.Singleton.StartClient();
    }

    private void ServerButtonOnClick()
    {
        NetworkManager.Singleton.StartServer();
    }

    public void Join()
    {
        ConnectionButtonPanel.SetActive(false);
        NetworkManager.Singleton.NetworkConfig.ConnectionData = System.Text.Encoding.ASCII.GetBytes("Password1234");
        NetworkManager.Singleton.StartClient(); 
    }

    public void IPAddressChanged(string newAddress)
    {
        this.ipAddress = newAddress;
    }

    

}
