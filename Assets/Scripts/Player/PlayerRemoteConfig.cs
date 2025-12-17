using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.Analytics;
using Firebase.RemoteConfig;
using UnityEngine;

public class PlayerRemoteConfig : MonoBehaviour
{
    private const string PLAYER_SPEED_KEY = "player_speed";

    [SerializeField]
    private PlayerMovement playerMovement;

    async void Start()
    {
        await InitializeRemoteConfig();
        ApplyPlayerSpeed();
    }

    private async Task InitializeRemoteConfig()
    {
        // Default value if Firebase fails
        var defaults = new Dictionary<string, object>
        {
            { PLAYER_SPEED_KEY, 5.0 }
        };

        await FirebaseRemoteConfig.DefaultInstance.SetDefaultsAsync(defaults);
        await FirebaseRemoteConfig.DefaultInstance.FetchAsync();
        await FirebaseRemoteConfig.DefaultInstance.ActivateAsync();
    }

    private void ApplyPlayerSpeed()
    {
        float speedFromFirebase =
            (float)FirebaseRemoteConfig.DefaultInstance
            .GetValue(PLAYER_SPEED_KEY).DoubleValue;

        playerMovement.SetSpeed(speedFromFirebase);

        // Optional analytics logging (recommended)
        FirebaseAnalytics.LogEvent(
            "player_speed_applied",
            new Parameter("player_speed", speedFromFirebase)
        );

        Debug.Log($"[Firebase] Player speed set to {speedFromFirebase}");
    }
}
