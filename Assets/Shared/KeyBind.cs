using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyBind : MonoBehaviour
{
    private Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();

    public Text forward, backward, left, right;

    private GameObject currentKey;

    private Color32 normal = new Color32(39,171,249,255);
    private Color32 selected = new Color32(239, 116, 36, 255);
    
    // Use this for initialization
	void Start ()
    {
        keys.Add("Forward",(KeyCode)System.Enum.Parse(typeof(KeyCode),PlayerPrefs.GetString("Forward","UpArrow")));
        keys.Add("Backward", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Backward", "DownArrow")));
        keys.Add("Left", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Left", "LeftArrow")));
        keys.Add("Right", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Right", "RightArrow")));

        forward.text = keys["Forward"].ToString();
        backward.text = keys["Backward"].ToString();
        left.text = keys["Left"].ToString();
        right.text = keys["Right"].ToString();
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(keys["Forward"]))
        {
            //Do a move action
            Debug.Log("Forward");
        }

        if (Input.GetKeyDown(keys["Backward"]))
        {
            //Do a move action
            Debug.Log("Backward");
        }

        if (Input.GetKeyDown(keys["Left"]))
        {
            //Do a move action
            Debug.Log("Left");
        }

        if (Input.GetKeyDown(keys["Right"]))
        {
            //Do a move action
            Debug.Log("Right");
        }

    }

     void OnGUI()
    {
        if (currentKey != null)
        {
            Event e = Event.current;
            if(e.isKey)
            {
                keys[currentKey.name] = e.keyCode;
                currentKey.transform.GetChild(0).GetComponent<Text>().text = e.keyCode.ToString();
                currentKey.GetComponent<Image>().color = normal;
                currentKey = null;
            }
        }



    }

    public void ChangeKey(GameObject clicked)
    {
        if(currentKey != null)
        {
            currentKey.GetComponent<Image>().color = normal;
        }

       currentKey = clicked;
        currentKey.GetComponent<Image>().color = selected;
    }

    public void SaveKeys()
    {
        foreach(var key in keys)
        {
            PlayerPrefs.SetString(key.Key, key.Value.ToString());

        }

        PlayerPrefs.Save();
    }

}
