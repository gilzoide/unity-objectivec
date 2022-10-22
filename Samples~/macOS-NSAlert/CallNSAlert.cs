using UnityEngine;

public class CallNSAlert : MonoBehaviour
{
    public string Message;

    public void SetMessage(string message)
    {
        Message = message;
    }

    public void Alert()
    {
#if UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX  // || UNITY_IOS (NSAlert is not support in iOS)
        NSAlertMessage.Alert(Message);
#else
        Debug.Log("Unsupported platform");
#endif
    }
}
