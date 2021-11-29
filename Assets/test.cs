using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    string hit = "........";
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {

        hit = "HITHIT";
 

    }
    IEnumerator ChangeString() {
        hit = "........";
        yield return new WaitForSeconds(0.5f);
    }

    private void OnGUI() {
        GUIStyle myRectStyle = new GUIStyle(GUI.skin.textField);
        myRectStyle.fontSize = 50;
        myRectStyle.normal.textColor = Color.red;
        GUI.Box(new Rect(new Vector2(100, 100), new Vector2(400, 100)), hit , myRectStyle);
    }
}
