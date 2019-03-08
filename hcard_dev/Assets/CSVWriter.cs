using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class CSVWriter : MonoBehaviour
{

    // initiate the path the data will be written into
    private string path;
    private TestSocketIO angleReceiver;

    public float timePassed;

    // Start is called before the first frame update
    void Start()
    {
        angleReceiver = GetComponent<TestSocketIO>();

        // assign the file path the data will be written into
        path = "Data/user_data.txt";

        // Clear the content of text file before loading data into it
        File.WriteAllText(path, String.Empty);

        InvokeRepeating("WriteString", 0.5f, 0.5f);

        timePassed = 0;
    }

    private void Update()
    {
        timePassed += Time.deltaTime;
    }

    private void WriteString()
    {
        // create the writer object instance
        StreamWriter writer = new StreamWriter(path, true);

        writer.WriteLine(
            Convert.ToSingle(timePassed).ToString("F3") + "," +
            Convert.ToSingle(angleReceiver.beta).ToString("F3") + "," +
            Convert.ToSingle(angleReceiver.gamma).ToString("F3"));

        writer.Close();
    }
}
