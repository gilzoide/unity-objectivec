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
        NSAlertMessage.Alert(Message);
    }
}
