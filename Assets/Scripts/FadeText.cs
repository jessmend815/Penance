using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeText : MonoBehaviour {
    Text Information;
    public float val = 5;
	public bool fade = false;

    private void OnEnable()
    {
        Information = GetComponent<Text>();
        Information.color = new Color(Information.color.r, Information.color.g, Information.color.b, 1);
    }

    void Update () {
        if (!Application.isEditor)
        {
            if (fade)
            {
                Information.color = new Color(Information.color.r, Information.color.g, Information.color.b, Information.color.a - val);
            }
            if (Information.color.a <= 0)
            {
                PlayerController.player.Information.SetActive(false);
            }
        }
        else
        {
            Information.color = new Color(Information.color.r, Information.color.g, Information.color.b, 0f);
        }
    }
}
