using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ClearInputAndOutput : MonoBehaviour {


    public GameObject input1;
    public GameObject input2;
    public GameObject output;

	// Use this for initialization
	void Start () 
    {
        output.GetComponent<Text>().text = "Output";
        input1.GetComponentInChildren<Text>().text = "";
        input1.GetComponent<InputField>().value = "";
        input2.GetComponentInChildren<Text>().text = "";
        input2.GetComponent<InputField>().value = "";
        this.enabled = false;
	}

    void OnEnable()
    {
        this.Start();
    }
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
