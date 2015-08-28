using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RateVideoSlider : MonoBehaviour {
	
	public VideoPlayer videoPlayer;
	public Slider rateSlider;
	private float sliderValue=0.0f;
	
	void Start () {
		if(videoPlayer== null) videoPlayer = gameObject.GetComponent<VideoPlayer>();
		if(videoPlayer == null) Debug.Log("Need VideoPlayer assigned to or on gameObject " + gameObject.name); 
		rateSlider.minValue=-4.0f;
		rateSlider.maxValue=4.0f;
	}
	
	void Update () {
		rateSlider.value=videoPlayer.rate;
	}
	
	// value 0 to 1.0. 
	public void SliderValue (float value)
	{
		if (Application.platform != RuntimePlatform.OSXEditor) {
			if( (value != 0.0f) // system can set to zero on pause/stop
			   && (value != videoPlayer.preferredRate)
			   ) 
			{ // was changed manually
				videoPlayer.preferredRate=value;
			}
		}
	}
	
}

