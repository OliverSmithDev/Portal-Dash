using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowText : MonoBehaviour
{
    public string message;
    public bool ShowGui;
    public Font MyFont;
    GUIStyle CustomFont;
    public bool CostToActivate;
    public bool EndState;
    
    // Start is called before the first frame update

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            ShowGui = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            ShowGui = false;
        }
    }

    private void OnGUI()
    {
        GUI.backgroundColor = Color.black;
        // GUI.backgroundColor = new Color(1.0f, 1.0f, 1.0f, 1.0f); //0.5 is half opacity 
        if (CustomFont == null)
        {
            CustomFont = new GUIStyle(GUI.skin.button);
            CustomFont.font = MyFont;
            CustomFont.fontSize = 25;
            
        }
        if (ShowGui && CostToActivate) GUI.Box(new Rect(800, 400, 400, 50), "Cost to activate" + message, CustomFont);
        else if (ShowGui && EndState) GUI.Box(new Rect(800, 400, 400, 50), message, CustomFont);
    }
}
