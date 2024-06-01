using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NotificationManager : MonoBehaviour
{
    public static NotificationManager Instance { get; private set; }

    [SerializeField] GameObject NotificationBox;
    [SerializeField] Button ConfirmChoiceButton;
    [SerializeField] Button DeclineChoiceButton;
    [SerializeField] TextMeshProUGUI NotificationText;
    private void Awake()
    {
        Instance = this;
    }
    public void ShowNotification(string text, bool waitForInput = false, float timeToShow = 2f, bool hasChoices = false, Action onConfirmChoice = null)
    {
        StopCoroutine("Notification");
        CloseNotificationBox();
        StartCoroutine(Notification(text, waitForInput, timeToShow, hasChoices, onConfirmChoice));
    }
    private IEnumerator Notification(string text, bool waitForInput, float timeToShow, bool hasChoices, Action onConfirmChoice)
    {
        NotificationBox.SetActive(true);
        NotificationText.text = text;

        ConfirmChoiceButton.onClick.RemoveAllListeners();
        DeclineChoiceButton.onClick.RemoveAllListeners();

        if (hasChoices && onConfirmChoice != null)
        {
            ConfirmChoiceButton.gameObject.SetActive(true);
            ConfirmChoiceButton.onClick.AddListener(() => { onConfirmChoice?.Invoke(); });

            DeclineChoiceButton.gameObject.SetActive(true);
            DeclineChoiceButton.onClick.AddListener(CloseNotificationBox);
            yield break;
        }
        else
        {
            ConfirmChoiceButton.gameObject.SetActive(false);
            DeclineChoiceButton.gameObject.SetActive(false);            
        }
        if (waitForInput)
        {
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }
        else
        {
            yield return new WaitForSeconds(timeToShow);
        }
        CloseNotificationBox();
    }


    private void CloseNotificationBox()
    {
        NotificationBox.SetActive(false);
    }
}
