using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(BoxCollider2D))]
public class InteractionHelper : MonoBehaviour
{
    [SerializeField] GameObject TextHelperObj;
    [SerializeField] TextMeshProUGUI TextHelperTxt;
    [SerializeField] KeyCode interactionKey;
    private bool isShowing;

    //If player comes within the radius a messafe will appear;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !isShowing)
        {
            StartCoroutine(ShowInteractHelper());
        }
    }

    //Function to show for a short period of time the desired interaction message
    IEnumerator ShowInteractHelper()
    {
        isShowing = true;
        TextHelperObj.SetActive(true);
        TextHelperTxt.text = $"You can use {interactionKey} to interact!";

        yield return new WaitForSeconds(2f);

        TextHelperObj.SetActive(false);
        isShowing = false;
    }
}
