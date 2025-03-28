using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Mirror;
namespace MirrorTest.Chat
{
    public class LoginUI : MonoBehaviour
    {
        [Header("UI Elements")]
        [SerializeField] private TMP_InputField networkAddressInput;
        [SerializeField] private TMP_InputField usernameInput;
        [SerializeField] private Button hostButton;
        [SerializeField] private Button clientButton;
        [SerializeField] private TextMeshProUGUI errorText;

        [SerializeField] private ChatNetworkManager networkManager;
        string originalNetworkAddress;
        // Start is called before the first frame update
        void Start()
        {
            hostButton.onClick.AddListener(StartHostButtonClick);
            clientButton.onClick.AddListener(StartClientButtonClick);
            if (string.IsNullOrWhiteSpace(NetworkManager.singleton.networkAddress))
                NetworkManager.singleton.networkAddress = "localhost";

            originalNetworkAddress = NetworkManager.singleton.networkAddress;
        }


        private void StartHostButtonClick()
        {
            string networkAddress = string.IsNullOrWhiteSpace(networkAddressInput.text)? "localhost": networkAddressInput.text.Trim();
            NetworkManager.singleton.networkAddress = networkAddress;
            LoginUISetActive(false);
            networkManager.StartHost();
        }
        private void StartClientButtonClick()
        {
            string networkAddress = string.IsNullOrWhiteSpace(networkAddressInput.text) ? "localhost" : networkAddressInput.text.Trim();
            NetworkManager.singleton.networkAddress = networkAddress;
            LoginUISetActive(false);
            networkManager.StartClient();
        }
        private void LoginUISetActive(bool setActive)
        {
            gameObject.SetActive(setActive);
        }

        public void ClearErrorMessageLabel()
        {
            errorText.SetText(string.Empty);
        }
        public void SetErrorMessageContent(string errorMessage)
        {
            errorText.SetText(errorMessage);
        }
        public void SetActiveErrorMessageLabelObj(bool setActive)
        {
            errorText.gameObject.SetActive(setActive);
        }
    }
}