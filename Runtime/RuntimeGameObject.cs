using System;
using UnityEngine;

namespace editor_values_provider
{
  public class RuntimeGameObject : MonoBehaviour
  {
    #region Editor references

    public float[] FloatValues = { };
    public int[] IntValues = { };
    public string[] StringValues = { };
    public bool[] BoolValues = { };
    public Vector2[] Vector2Values = { };
    public Vector3[] Vector3Values = { };
    public Color[] ColorValues = { };
    public GameObject[] GameObjectValues = { };

    #endregion

    public Action Action = delegate { };

    private void Update() =>
      Action.Invoke();
  }
}