using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeText : MonoBehaviour {
    Text Information;
    public float val = 5;
	public bool fade = false;
    float cools;

    private void OnEnable()
    {
        cools = 0.75f;
        Information = GetComponent<Text>();
        Information.color = new Color(Information.color.r, Information.color.g, Information.color.b, 1);
    }

    void Update () {
        /*if (!Application.isEditor)
        {*/
            if (fade && cools <= 0)
            {
                Information.color = new Color(Information.color.r, Information.color.g, Information.color.b, Information.color.a - val);
            }
            if (Information.color.a <= 0)
            {
                gameObject.SetActive(false);
            }

            if (cools > 0) cools -= Time.deltaTime;
        /*}
        else
        {
            if (Information.enabled) Information.enabled = false;
        }*/
    }
}
