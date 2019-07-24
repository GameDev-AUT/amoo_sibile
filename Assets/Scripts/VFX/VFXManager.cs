using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.VFX;

public class VFXManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private VisualEffect visualEffect;
    
    [SerializeField,Range(0.1f,10)] private float size;
    [SerializeField] private Gradient color;
    void Start()
    {
        this.visualEffect = this.GetComponent<VisualEffect>();
        color = visualEffect.GetGradient("color");
        size = visualEffect.GetFloat("size");
    }

    public VFXManager(VisualEffect visualEffect)
    {
        this.visualEffect = visualEffect;
        color = visualEffect.GetGradient("color");
        size = visualEffect.GetFloat("size");
    }


    // Update is called once per frame
    void Update()
    {
        if(visualEffect.enabled)
            setSize(getSize()-0.0005f);

    }

    public void setSize(float size)
    {
        if (size < 0)
        {
            visualEffect.enabled = false;
            return;
        }
           
        visualEffect.SetFloat("size",size);
        this.size = size;
    }

    public void setColor(Gradient gradient)
    {
        visualEffect.SetGradient("color",gradient);
    }

    public float getSize()
    {
        return size;
    }
}
