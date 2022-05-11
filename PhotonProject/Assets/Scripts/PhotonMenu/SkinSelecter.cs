using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinSelecter : MonoBehaviour
{
    public Text skinSelected;
    public List<string> posibleSkins;
    public int actualSkin = 0;

    private void Start()
    {
        skinSelected.text = posibleSkins[actualSkin];
    }

    public void BTN_NextSkin()
    {
        if (actualSkin < 3)
        {
            actualSkin++;
            skinSelected.text = posibleSkins[actualSkin];
        }
        else
        {
            actualSkin = 0;
            skinSelected.text = posibleSkins[actualSkin];
        }
        VarDontDestroy.instance.skinSelected = actualSkin;
    }

    public void BTN_PreviousSkin()
    {
        if (actualSkin > 0)
        {
            actualSkin--;
            skinSelected.text = posibleSkins[actualSkin];
        }
        else
        {
            actualSkin = 3;
            skinSelected.text = posibleSkins[actualSkin];
        }
        VarDontDestroy.instance.skinSelected = actualSkin;
    }

}
