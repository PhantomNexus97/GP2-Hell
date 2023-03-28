using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class ScreenEffects : MonoBehaviour
{
    public Volume vol;
    Bloom bloom;
    ChromaticAberration chromaticAberration;
    Vignette vignette;
    FilmGrain filmGrain;
    LensDistortion lensDistortion;
    ColorAdjustments colorAdjustment;

    // Start is called before the first frame update
    void Start()
    {

        vol.profile.TryGet<Bloom>(out bloom);
        vol.profile.TryGet<ChromaticAberration>(out chromaticAberration);
        vol.profile.TryGet<Vignette>(out vignette);
        vol.profile.TryGet<FilmGrain>(out filmGrain);
        vol.profile.TryGet<LensDistortion>(out lensDistortion);
        vol.profile.TryGet<ColorAdjustments>(out colorAdjustment);
        

        bloomSlider.onValueChanged.AddListener(delegate { PostProcessValueChange(); });
        chromaticAberrationSlider.onValueChanged.AddListener(delegate { PostProcessValueChange(); });
        vignetteToggle.onValueChanged.AddListener(delegate { PostProcessValueChange(); });
        filmGrainDropdown.onValueChanged.AddListener(delegate { PostProcessValueChange(); });
        lensDistortionSlider.onValueChanged.AddListener(delegate { PostProcessValueChange(); });
        redSlider.onValueChanged.AddListener(delegate { PostProcessValueChange(); });
        greenSlider.onValueChanged.AddListener(delegate { PostProcessValueChange(); });
        blueSlider.onValueChanged.AddListener(delegate { PostProcessValueChange(); });

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
