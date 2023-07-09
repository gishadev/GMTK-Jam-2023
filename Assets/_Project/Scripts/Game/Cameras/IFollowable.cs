using UnityEngine;

namespace GMTK.Cameras
{
    public interface IFollowable
    {
        Transform transform { get; }
        GameObject gameObject { get; }
    }
}