using System;
using UnityEngine;
using UnityEngine.Advertisements;

namespace Assets.Scripts.Metanoia.Services.Ads
{
    public class AdsService : IAdsService, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
    {
        private string _gameId;
        private string _rewardedVideoId;

        private const string AndroidGameId = "5007087";
        private const string IOSGameId = "5007086";

        private const string RewardedVideoPlacementAndroidId = "Rewarded_Android";
        private const string RewardedVideoPlacementIOSId = "Rewarded_iOS";

        public event Action RewardedVideoReady;
        private Action _onVideoFinished;

        private bool _testMode = true;
        private bool _isReady = false;

        public int Reward => 10;

        public void Initialize()
        {
            switch (Application.platform)
            {
                case RuntimePlatform.Android:
                    _gameId = AndroidGameId;
                    _rewardedVideoId = RewardedVideoPlacementAndroidId;
                    break;
                case RuntimePlatform.IPhonePlayer:
                    _gameId = IOSGameId;
                    _rewardedVideoId = RewardedVideoPlacementIOSId;
                    break;
                case RuntimePlatform.WindowsEditor:
                    _gameId = AndroidGameId;
                    _rewardedVideoId = RewardedVideoPlacementAndroidId;
                    break;
                default:
                    Debug.Log("Unsupported platform for ads");
                    break;
            }

            Advertisement.Initialize(_gameId, _testMode, this);
            Advertisement.Load(_gameId, this);
        }

        public void OnInitializationComplete()
        {
            
        }

        public void OnInitializationFailed(UnityAdsInitializationError error, string message)
        {
            
        }

        public void ShowRewardedVideo(Action onVideoFinished)
        {
            Advertisement.Show(_rewardedVideoId);
            _onVideoFinished = onVideoFinished;
        }

        public void OnUnityAdsAdLoaded(string placementId)
        {
            if (placementId == _rewardedVideoId)
                RewardedVideoReady?.Invoke();

            _isReady = true;
        }

        public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
        {
            
        }

        public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
        {
            
        }

        public void OnUnityAdsShowStart(string placementId)
        {
            
        }

        public void OnUnityAdsShowClick(string placementId)
        {
            
        }

        public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
        {
            if (_gameId.Equals(placementId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
            {
                Debug.Log("Unity Ads Rewarded Ad Completed");
                
                Advertisement.Load(_gameId, this);
                
                _isReady = false;
            }

            _onVideoFinished = null;
        }

        public bool IsRewardedVideoReady() => _isReady;
        
    }
}
