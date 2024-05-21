using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChangeColor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<Image>().color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
