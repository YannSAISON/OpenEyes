using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class KeyControlPanel : MonoBehaviour {
    public Text legendText;
    public InputField inputToChangeKeyControl;
    public Text inputPlaceHolder;
    public KeyControlEnum whichControl;

    private void Awake() {
        string control = PlayerPrefs.GetString(whichControl.ToString());
        Debug.Log("Control : " + control);
        if (string.IsNullOrEmpty(control)) {
            control = SetupKeyControl();
        }

        Debug.Log("Control : " + control);
        legendText.name = "Label_" + whichControl.ToString();
        inputToChangeKeyControl.characterLimit = 1;
        inputToChangeKeyControl.name = "InputField_" + whichControl.ToString();
        inputToChangeKeyControl.placeholder.name = "Placeholder_" + whichControl.ToString();
        inputPlaceHolder.text = control;
        legendText.text = whichControl.ToString();
        inputToChangeKeyControl.onEndEdit.AddListener(delegate { ChangeControlKey(inputToChangeKeyControl); });
    }

    private void ChangeControlKey(InputField inputField) {
        if (inputField.text.Length > 0) {
            Debug.Log("Text has been entered");
        }

        IsChangeabled(inputField.text);
    }

    private string SetupKeyControl() {
        string control;

        switch (whichControl) {
            case KeyControlEnum.Forward:
                control = "z";
                Debug.Log(Input.GetButton("Horizontal"));
                PlayerPrefs.SetString(KeyControlEnum.Forward.ToString(), control);
                break;
            case KeyControlEnum.Backward:
                control = "s";
                PlayerPrefs.SetString(KeyControlEnum.Backward.ToString(), control);
                break;
            case KeyControlEnum.Right:
                control = "d";
                PlayerPrefs.SetString(KeyControlEnum.Right.ToString(), control);
                break;
            case KeyControlEnum.Left:
                control = "q";
                PlayerPrefs.SetString(KeyControlEnum.Left.ToString(), control);
                break;
            case KeyControlEnum.Inventory:
                control = "i";
                PlayerPrefs.SetString(KeyControlEnum.Inventory.ToString(), control);
                break;
            case KeyControlEnum.Interact:
                control = "e";
                PlayerPrefs.SetString(KeyControlEnum.Interact.ToString(), control);
                break;
            default:
                throw new ApplicationException();
        }

        return control;
    }

    private bool IsChangeabled(string newInputControl) {
        return newInputControl != PlayerPrefs.GetString(KeyControlEnum.Forward.ToString()) &&
               newInputControl != PlayerPrefs.GetString(KeyControlEnum.Backward.ToString()) &&
               newInputControl != PlayerPrefs.GetString(KeyControlEnum.Right.ToString()) &&
               newInputControl != PlayerPrefs.GetString(KeyControlEnum.Left.ToString()) &&
               newInputControl != PlayerPrefs.GetString(KeyControlEnum.Inventory.ToString()) &&
               newInputControl != PlayerPrefs.GetString(KeyControlEnum.Interact.ToString());
    }
}
