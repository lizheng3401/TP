using System.Collections;
using System.Collections.Generic;
using Framework.Config;
using UnityEngine;
using UnityEngine.UI;
using Utility;

public class PlantItem
{
    public Image PlantImage;
    public Button PlantBtn;
    public Image CDImage;
    private Transform _root;

    public PlantItem()
    {
        
    }

    public PlantItem(Transform root)
    {
        this._root = root;
        PlantImage = Utils.FindComponentInChildren<Image>(_root, "Mask");
        PlantBtn = Utils.FindComponentInChildren<Button>(_root, "Mask");
        CDImage = Utils.FindComponentInChildren<Image>(_root, "Mask/Image");
    }
    public void Init(PlantInfo plantInfo)
    {
        PlantImage.sprite = GlobalVars.ResourceManager.LoadAsset<Sprite>(plantInfo.SpritePath);
        
    }
}
