using System;
using System.Collections;
using System.Collections.Generic;
using Core.Services.Screen;
using Helpers.Screen;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(SpriteRenderer))]
public class BackgroundResizer : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    private ScreenWorldSpaceData _screenWorldSpaceData;
    private ScreenResizeDetector _screenResizeDetector;

    private SpriteRenderer SpriteRenderer
    {
        get
        {
            if (_spriteRenderer == null)
            {
                _spriteRenderer = GetComponent<SpriteRenderer>();
            }

            return _spriteRenderer;
        }
    }

    
    [Inject]
    private void Construct(ScreenResizeDetector screenResizeDetector)
    {
        _screenResizeDetector = screenResizeDetector;
    }

    private void OnEnable()
    {
        _screenResizeDetector.ScreenSizeChanged += UpdateScreenData;
    }

    private void OnDisable()
    {
        _screenResizeDetector.ScreenSizeChanged -= UpdateScreenData;
    }
    
    private void Start()
    {
        UpdateScreenData();
    }
    
    private void Update()
    {
        UpdateSize();
    }
    

    private void UpdateSize()
    { 
        transform.position = new Vector3(0, 0, transform.position.z);

        float width = SpriteRenderer.size.x;
        
        float scale = _screenWorldSpaceData.Size.x / width;;
        var localScale = transform.localScale;
        transform.localScale = new Vector3(scale, scale, localScale.z);

        float height = _screenWorldSpaceData.Size.y / scale;
        SpriteRenderer.size = new Vector2(width, height);
    }
    
    private void UpdateScreenData()
    {
        _screenWorldSpaceData = ScreenCalculator.GetScreenWorldSpaceData();
    }
}
