using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Photon.Pun;
using Photon.Chat;
// using Photon.Realtime;
public class chat : MonoBehaviour, IChatClientListener
{
	public ChatClient chatClient;

    public string activeChannel;
    public string sendUser;

    public bool isSend2User;
    public InputField inputField;

    public ScrollRect ScrollView;
    public GameObject textPrefab;

    public string user;

    private GameObject chatObject;
    private Transform Content;
    private Scrollbar Scrollbar;
    public GameObject hideShowButton;
    public FontSizer fontSizer;

    public Dropdown ChannelSelector;
    public Transform ChannelForm;
    

    // Start is called before the first frame update
    void Start(){
        chatObject = transform.Find("Chat").gameObject;
        Content = ScrollView.content;
        Scrollbar=ScrollView.verticalScrollbar;
    }

    void Awake()
    {
        chatClient = new ChatClient( this );
        this.chatClient.ConnectUsingSettings(PhotonNetwork.PhotonServerSettings.AppSettings.GetChatSettings());
        user = PhotonNetwork.NickName;
        if( user.CompareTo("")==0){
            user="noName"+System.Environment.TickCount%1000;
        }
        this.chatClient.AuthValues = new AuthenticationValues(this.user);

    }

    // Update is called once per frame
    void Update()
    {
        if (this.chatClient != null)
		{
			this.chatClient.Service(); 
		}
    }

    public void DebugReturn(ExitGames.Client.Photon.DebugLevel level, string message)
	{
		// if (level == ExitGames.Client.Photon.DebugLevel.ERROR)
		// {
		// 	Debug.LogError(message);
		// }
		// else if (level == ExitGames.Client.Photon.DebugLevel.WARNING)
		// {
		// 	Debug.LogWarning(message);
		// }
		// else
		// {
		// 	Debug.Log(message);
		// }
	}
    
    // メッセージを送信する
    public void SendChat(){
        if(!inputField.text.Equals("")){
            if(isSend2User){
                SendChatMessageUser();
            }else{
                SendChatMessageChannel();
            }
            inputField.text="";
        }
    }
    public void SendChatInReturn(){
        if(Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter)){
            SendChat();
        }
    }

    void SendChatMessageChannel(){
        chatClient.PublishMessage( activeChannel, inputField.text );
    }
    void SendChatMessageUser(){
        chatClient.SendPrivateMessage( sendUser, inputField.text );
    }

    //チャット切断時
	public void OnDisconnected()
	{
	}
    //チャット接続時
    public void OnConnected()
	{
        // Debug.Log("connected");
        // chatClient.Subscribe( new string[] { "メイン", "channelB" } );
        chatClient.Subscribe("メイン");
        user=PhotonNetwork.NickName;
    }

    public void OnChatStateChange(ChatState state){
    }

    //メッセージ受信時の処理
    public void OnGetMessages(string channelName, string[] senders, object[] messages)
	{
        bool isActive=channelName.Equals(activeChannel);
        for(int i=0;i<messages.Length;i++)
        {
            GameObject obj = (GameObject)Instantiate(textPrefab, transform.position, Quaternion.identity);
            obj.GetComponent<Text>().text=senders[i]+": "+messages[i];
            obj.GetComponent<Text>().fontSize=(int)fontSizer.fontSize;
            obj.GetComponent<Message>().channel=channelName;
            obj.GetComponent<Message>().sender=senders[i];
            obj.SetActive(isActive);
            obj.transform.SetParent(Content);
            Scrollbar.value=0;
        }

		// if (channelName.Equals(this.selectedChannelName))
		// {
		// 	// update text
		//     this.ShowChannel(this.selectedChannelName);
		// }
	}

    public void OnPrivateMessage(string sender, object message, string channelName)
	{
        
    }



    //チャットチャンネル --------------------------------
    
	public void OnSubscribed(string[] channels, bool[] results)
	{
        // Debug.Log("channels:"+channels[0]+"\nresults:"+results[0]);
    }
    public void OnUnsubscribed(string[] channels)
	{

    }
    //ユーザーのステータス --------------------------------
	public void OnStatusUpdate(string user, int status, bool gotMessage, object message)
	{
    }

    //ユーザーとのチャットチャンネル --------------------------------
    public void OnUserSubscribed(string channel, string user)
    {
        Debug.LogFormat("OnUserSubscribed: channel=\"{0}\" userId=\"{1}\"", channel, user);
    }

    public void OnUserUnsubscribed(string channel, string user)
    {
        Debug.LogFormat("OnUserUnsubscribed: channel=\"{0}\" userId=\"{1}\"", channel, user);
    }


    // チャットの表示
    public void HideShowChat(){
        chatObject.SetActive(chatObject.activeSelf^true);
        hideShowButton.SetActive(chatObject.activeSelf^true);
    }
    // チャンネル切り替え
    public void ChangeChannel(){
        // Debug.Log(ChannelSelector.captionText.text);
        if(ChannelSelector.value==0){
            ChannelSelector.value=1;
            ChannelForm.gameObject.SetActive(true);
        }else{
            activeChannel=ChannelSelector.captionText.text;
            // chatClient.Subscribe(ChannelSelector.captionText.text);
            foreach (Message item in Content.GetComponentsInChildren<Message>())
            {
                // item.gameObject.SetActive(true);
                // Debug.Log(item.channel.Equals(activeChannel));
                item.GetComponent<Text>().enabled=item.channel.Equals(activeChannel);
            }
        }
        
    }
    public void addChannel(){
        string channel = ChannelForm.GetComponentInChildren<InputField>().text;
        ChannelForm.GetComponentInChildren<InputField>().text="";
        chatClient.Subscribe(channel);
        Dropdown.OptionData option=new Dropdown.OptionData();
        option.text=channel;
        ChannelSelector.options.Add(option);
        ChannelForm.gameObject.SetActive(false);
    }
    public void addChannelInReturn(){
        if(Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter)){
            addChannel();
        }
    }
}
