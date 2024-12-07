using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;
using UnityEngine.Android;

public class NotificationController : MonoBehaviour
{

    [SerializeField] AndroidNotificationScript androidNotifications;

    private void Start()
    {
        androidNotifications.RequestAutorization();
        androidNotifications.RegisterNotificationChannel();
    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus == false)
        {
            AndroidNotificationCenter.CancelAllNotifications();
            androidNotifications.SendTwoRandomNotifications(2);
        }
    }
}
