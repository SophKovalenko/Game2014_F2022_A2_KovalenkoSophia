using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsPanelChanger : MonoBehaviour
{
    public GameObject instructionsPanel1;
    public GameObject instructionsPanel2;
    public GameObject instructionsPanel3;
    public GameObject instructionsPanel4;

    // Start is called before the first frame update
    void Start()
    {
        instructionsPanel1.SetActive(true);
        instructionsPanel2.SetActive(false);
        instructionsPanel3.SetActive(false);
        instructionsPanel4.SetActive(false);
    }

    public void OnFirstOkButtonClicked()
    {
        instructionsPanel1.SetActive(false);
        instructionsPanel2.SetActive(true);
    }

    public void OnSecondOkButtonClicked()
    {
        instructionsPanel2.SetActive(false);
        instructionsPanel3.SetActive(true);
    }

    public void OnThirdOkButtonClicked()
    {
        instructionsPanel3.SetActive(false);
        instructionsPanel4.SetActive(true);
    }
}
