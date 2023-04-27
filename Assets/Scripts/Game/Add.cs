using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class Add : MonoBehaviour, IUnityAdsListener
{
    private const string GAME_ID = "4226897";

    [SerializeField] private Button _showAdButton;
    [SerializeField] private string _androidAdUnitId = "Rewarded_Android";

    [SerializeField] private int _reward;
    [SerializeField] private Brains _brains;

    private void Start()
    {
        Advertisement.Initialize(GAME_ID);
        Advertisement.AddListener(this);
    }

    public void PlayRewardedAd()
    {
        if (Advertisement.IsReady(_androidAdUnitId))
            Advertisement.Show(_androidAdUnitId);
    }

    public void OnUnityAdsReady(string placementId) => _showAdButton.interactable = true;
    public void OnUnityAdsDidError(string message) => _showAdButton.interactable = false;
    public void OnUnityAdsDidStart(string placementId) => Debug.Log("Video started");
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
            if (_brains != null)
                _brains.Currency += _reward;
    }
}
