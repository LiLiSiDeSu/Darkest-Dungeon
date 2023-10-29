using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public sealed class AllInterface : MonoBehaviour { }

public interface IDrag : IDragHandler, IBeginDragHandler, IEndDragHandler { }