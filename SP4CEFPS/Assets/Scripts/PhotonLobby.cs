using Photon.Realtime;
using Photon.Pun;
using UnityEngine;

public class PhotonLobby : MonoBehaviourPunCallbacks
{
    public static PhotonLobby lobby;

    public GameObject battleButton;
    public GameObject cancelButton;

    private void Awake()
    {
        lobby = this;
    }
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();  
    }

   public override void OnConnectedToMaster()
    {
        Debug.Log("Player has connected to the Photon master server");
        PhotonNetwork.AutomaticallySyncScene = true;
        battleButton.SetActive(true);
    }

    public void OnBattleButtonClicked()
    {
     
        battleButton.SetActive(false);
        cancelButton.SetActive(true);
        PhotonNetwork.JoinRandomRoom();
        
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Tried to join a random game but failed. There must be no open games available");
        CreateRoom();
    }

    void CreateRoom()
    { 

        Debug.Log("Tried To create a new room");
        int randomRoomName = Random.Range(0, 1000);
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = (byte)MultiplayerSetting.multiplayerSetting.maxPlayers };
        PhotonNetwork.CreateRoom("Room" + randomRoomName, roomOps);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("We are now in a room");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Tried to create a new room but failed");
        CreateRoom();
            
     }
  public void OnCancelButtonClicked()
    {
        cancelButton.SetActive(false);
        battleButton.SetActive(true);
        PhotonNetwork.LeaveRoom();
    }
}
