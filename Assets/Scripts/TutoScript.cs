using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutoScript : MonoBehaviour
{
    public KeyCode nextStepKey;

    public GameObject texts;

    private int step = 1;
    private GameObject catSprite;
    private GameObject reticle;

    // Start is called before the first frame update
    void Start()
    {
        this.catSprite = GameObject.Find("CatSprite");
        this.reticle = Camera.main.transform.Find("reticle").gameObject;

        this.catSprite.SetActive(false);
        this.reticle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && Input.GetKeyDown(this.nextStepKey))
        {
            this.texts.transform.Find("Step" + this.step).gameObject.SetActive(false);

            int nextStepNumber = this.step + 1;
            Transform nextText = this.texts.transform.Find("Step" + nextStepNumber);
            if (nextText != null)
            {
                nextText.gameObject.SetActive(true);

                if (nextStepNumber == 3)
                {
                    this.catSprite.SetActive(true);
                }
                else if (nextStepNumber == 4)
                {
                    this.reticle.SetActive(true);
                }
                else if (nextStepNumber == 7)
                {
                    this.catSprite.SetActive(false);
                    this.reticle.SetActive(false);
                }

                this.step++;
            } else {
                SceneManager.LoadScene(0);
            }
        }
    }
}
