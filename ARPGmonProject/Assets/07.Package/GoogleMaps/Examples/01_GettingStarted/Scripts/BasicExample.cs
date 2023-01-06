using Google.Maps.Coord;
using Google.Maps.Event;
using Google.Maps.Examples.Shared;
using UnityEngine;

namespace Google.Maps.Examples {
  /// <summary>
  /// This example demonstrates a basic usage of the Maps SDK for Unity.
  /// </summary>
  /// <remarks>
  /// By default, this script loads the Statue of Liberty. If a new lat/lng is set in the Unity
  /// inspector before pressing start, that location will be loaded instead.
  /// </remarks>
  [RequireComponent(typeof(MapsService))]
  public class BasicExample : MonoBehaviour {
    [Tooltip("LatLng to load (must be set before hitting play).")]
    private LatLng _latLng = new LatLng(40.6892199, -74.044601);
    private MapsService _mapsService;
    private MapLoadSupporter _supporter;

    /// <summary>
    /// Use <see cref="MapsService"/> to load geometry.
    /// </summary>
    private void Start() 
    {
      // TODO : LatLng..사전에 입력해야 하는지는 추가적인 테스트 필요
      _supporter = GetComponent<MapLoadSupporter>();
      _mapsService = GetComponent<MapsService>();
      _mapsService.Events.MapEvents.Loaded.AddListener(OnLoaded);

      LoadMap(GameManager.Instance.Gps.Lat, GameManager.Instance.Gps.Lng);
    }

    public void LoadMap(double Lat, double Lng)
    {
      _latLng = new LatLng(Lat, Lng);
      _mapsService.InitFloatingOrigin(_latLng);
      _mapsService.LoadMap(ExampleDefaults.DefaultBounds, ExampleDefaults.DefaultGameObjectOptions);
    }

    /// <summary>
    /// Example of OnLoaded event listener.
    /// </summary>
    /// <remarks>
    /// The communication between the game and the MapsSDK is done through APIs and event listeners.
    /// </remarks>
    public void OnLoaded(MapLoadedArgs args) 
    {
      _supporter.MapLoadComplete();
      // The Map is loaded - you can start/resume gameplay from that point.
      // The new geometry is added under the GameObject that has MapsService as a component.
    }
  }
}
