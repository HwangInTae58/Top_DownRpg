using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public GameObject dialog;
    public Text nameText;
    public Text description;

    public void SetActiveDialog(bool active)
    {
        dialog.SetActive(active);
    }

    public void SetDialogContent(string name, string descriptionText)
    {
        nameText.text = name  ;
        description.text = descriptionText;
    }
}
