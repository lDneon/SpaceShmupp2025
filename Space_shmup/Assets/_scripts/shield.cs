using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shield : MonoBehaviour
{
    [Header("Inscribed")]
    public float rotationPerSecond = 0.1f;

    [Header("Dynamic")]
    public int levelShown = 0;//set between lines

    Material mat; //non-public variable so it will not appear in the inspector 




    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        //read the current shield level from the Hero slingleton
        int currLevel = Mathf.FloorToInt(Hero.S.shieldLevel);
        if(levelShown != currLevel)
        {
             levelShown = currLevel;
             mat.mainTextureOffset = new Vector2(0.2f * levelShown, 0);

        }
        //rotate the shield a bit every frame in a time-based way
        float rZ = (rotationPerSecond * Time.time * 360) % 360f;
        transform.rotation = Quaternion.Euler(0, 0, rZ);
    }
}
