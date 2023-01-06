using System.Collections;
using UnityEngine;
using Google.XR.ARCoreExtensions;
using UnityEngine.XR.ARSubsystems;
using System;

public class GpsSensor : MonoBehaviour
{
    public double Lat { get; private set; }
    public double Lng { get; private set; }
    public double Azimuth{ 
        get
        { 
            Debug.Log("--");
            return _pose.Latitude; 
        } }

    private GeospatialPose _pose;
    private bool _isGpsStarted = false;

    private WaitForSeconds _retry;
    private LocationInfo _location;
    [SerializeField] private float _retryTime;
    [SerializeField] private AREarthManager _earth;
    private bool _isGetEarth;

    private void Start()
    {
        _retry = new WaitForSeconds(_retryTime);
        StartCoroutine(GpsStart());
    }

    private double GetA()
    {
        return _pose.Latitude;
    }

    private IEnumerator GpsStart()
    {
        // 유저가 GPS 사용중인지 최초 체크
        if (!Input.location.isEnabledByUser)
        {
            yield break;
        }

        //GPS 서비스 시작
        Input.location.Start();

        //활성화될 때 까지 대기
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return _retry;
            maxWait -= 1;
        }

        //20초 지날경우 활성화 중단
        if (maxWait < 1)
        {
            yield break;
        }

        //연결 실패
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            yield break;

        }
        else
        {
            //접근 허가, 현재 위치 갱신
            _isGpsStarted = true;

            while (_isGpsStarted)
            {
                NowPositionSet();

                if(_isGetEarth)
                {
                    AzimuthSet();
                }

                yield return _retry;
            }
        }
    }

    private void NowPositionSet()
    {
        _location = Input.location.lastData;
        Lat = _location.latitude * 1.0d;
        Lng = _location.longitude * 1.0d;
    }

    private void AzimuthSet()
    {
        _pose = _earth.EarthState == EarthState.Enabled &&
        _earth.EarthTrackingState == TrackingState.Tracking ?
        _earth.CameraGeospatialPose : new GeospatialPose();
    }

    public void SetEarthManager(AREarthManager Earth)
    {
        _earth = Earth;
        if(Earth == null)
        {
            _isGetEarth = false;
        }
        else
        {
            _isGetEarth = true;
        }
    }

    //위치 서비스 종료
    public void GpsStop()
    {
        if (Input.location.isEnabledByUser)
        {
            _isGpsStarted = false;
            Input.location.Stop();
            StopCoroutine(GpsStart());
        }
    }

    public Vector2 GetEarthPos()
    {
        return new Vector2((float)Lat, (float)Lng);
    }

    public bool GetIsGpsStart()
    {
        return _isGpsStarted;
    }

    /// <summary>
    /// 위/경도 기준 A에서 B까지의 거리 반환(구체 표면거리, 미터(M) 기준)
    /// </summary>
    public double GetDistAtoB(double A_Lat, double A_Long, double B_Lat, double B_Long)
    {
        double Theta;
        double Distance;

        Theta = A_Long - B_Long;

        Distance = Math.Sin(deg2rad(A_Lat)) * Math.Sin(deg2rad(B_Lat)) + Math.Cos(deg2rad(A_Lat)) * Math.Cos(deg2rad(B_Lat)) * Math.Cos(deg2rad(Theta));
        Distance = Math.Acos(Distance);
        Distance = rad2deg(Distance);

        Distance = Distance * 60 * 1.1515;
        Distance = Distance * 1.609344;
        Distance = Distance * 1000.0;

        return Distance;
    }

    private double deg2rad(double deg)
    {
        return (double) (deg* Math.PI / (double)180d);
    }
    private double rad2deg(double rad)
    {
        return (double)(rad * (double)180d / Math.PI);
    }
}