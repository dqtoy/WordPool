using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EasyAds : MonoBehaviour {

	[Header("Admob Banner")]
	public string Android_Admob_Banner;
	public string IOS_Admob_Banner;

	[Header("Admob Interstitial")]
	public string Android_Admob_Interstitial;
	public string IOS_Admob_Interstitial;

	[Header("Admob Rewarded")]
	public string Android_Admob_Reward;
	public string IOS_Admob_Reward;

	private int frameCount = 0;

	static int count = 0;

	IEnumerator Start () {
		count = 0;

		GetComponent<GoogleMobileAdsDemoScript> ().RequestBanner (GoogleMobileAds.Api.AdPosition.Bottom,
			Android_Admob_Banner,IOS_Admob_Banner);
		GetComponent<GoogleMobileAdsDemoScript> ().RequestInterstitial (Android_Admob_Interstitial,IOS_Admob_Interstitial);


		GetComponent<GoogleMobileAdsDemoScript> ().RequestRewardBasedVideo (Android_Admob_Reward, IOS_Admob_Reward);



		yield return new WaitForSeconds (2f);
		if (PlayerPrefs.GetInt ("Ads", 0) == 0) {
			ShowAdmobBanner ();
		}

	}

	void Update() {

//		frameCount++;
//		if( frameCount > 30 )
//		{
//			// update these periodically and not every frame
//			hasInterstitial = Chartboost.hasInterstitial(CBLocation.Default);
//			hasRewardedVideo = Chartboost.hasRewardedVideo(CBLocation.Default);
//
//			frameCount = 0;
//		}
	}		

	public void ShowAdmobBanner(){
		GetComponent<GoogleMobileAdsDemoScript> ().ShowBanner ();
	}

	public void HideAdmobBanner(){
		GetComponent<GoogleMobileAdsDemoScript> ().HideBanner ();
	}

	/// <summary>
	/// INTERSTITIALS
	/// </summary>
	private void ShowAdmobInterstitial(){
		GetComponent<GoogleMobileAdsDemoScript> ().ShowInterstitial ();
		GetComponent<GoogleMobileAdsDemoScript> ().RequestInterstitial (Android_Admob_Interstitial,IOS_Admob_Interstitial);
	}
		

	public void ShowInterstitial(){
		count++;
		if (count >= 3) {
			
					ShowAdmobInterstitial ();
		}
	}

	/// <summary>
	/// REWARDED ADS
	/// </summary>

	private void ShowAdmobReward(){
		GetComponent<GoogleMobileAdsDemoScript> ().ShowRewardBasedVideo ();
		GetComponent<GoogleMobileAdsDemoScript> ().RequestRewardBasedVideo (Android_Admob_Reward, IOS_Admob_Reward);
	}



	public void ShowReward(){
		
				ShowAdmobReward ();

	}

	public void RewardPlayer(){
		if (GameObject.FindObjectOfType<BaseController> () != null) {
			//GameObject.FindObjectOfType<BaseController> ().RewardPlayer ();
		}
	}


}
