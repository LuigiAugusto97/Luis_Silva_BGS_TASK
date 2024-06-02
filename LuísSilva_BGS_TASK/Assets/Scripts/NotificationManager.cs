using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NotificationManager : MonoBehaviour
{
    [Header("References to UI elements of the notification")]
    [SerializeField] GameObject NotificationBox;
    [SerializeField] Button ConfirmChoiceButton;
    [SerializeField] Button DeclineChoiceButton;
    [SerializeField] TextMeshProUGUI NotificationText;

    //Static refence of self
    public static NotificationManager Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }

    //Function to start/restart the coroutine that shows the notification appering
    public void ShowNotification(string text, bool waitForInput = false, float timeToShow = 2f, bool hasChoices = false, Action onConfirmChoice = null)
    {
        StopCoroutine(nameof(Notification));
        CloseNotificationBox();
        StartCoroutine(Notification(text, waitForInput, timeToShow, hasChoices, onConfirmChoice));
    }
   
    //Function to make appear the notification box and handle possible interactions
    private IEnumerator Notification(string text, bool waitForInput, float timeToShow, bool hasChoices, Action onConfirmChoice)
    {
        //Activate the notification box and set the text
        NotificationBox.SetActive(true);
        NotificationText.text = text;

        //Remove all listeners of the button
        ConfirmChoiceButton.onClick.RemoveAllListeners();
        DeclineChoiceButton.onClick.RemoveAllListeners();

        //If it has possible interaction activate the buttons and handle the on click events
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

        //If it should wait to clear the notification; wait for player input or else wait certain amount
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

    //Function to close the notification box
    private void CloseNotificationBox()
    {
        NotificationBox.SetActive(false);
    }
}
