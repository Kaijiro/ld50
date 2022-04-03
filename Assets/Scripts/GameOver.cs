using UnityEngine;
using TMPro;
using System.Collections;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI final_text;

    // Use this for initialization
    void Start()
    {
        final_text.SetText("You delayed cat "+ StaticScore.CrossSceneTimer.ToString("#.000") + " s but inevitably "+ StaticScore.CrossSceneInformation + " has been broken.");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
