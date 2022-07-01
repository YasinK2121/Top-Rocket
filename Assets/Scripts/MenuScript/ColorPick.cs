using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ColorPick : MonoBehaviour
{
    public List<Material> RocketMaterails;
    public ColorPicker Id;

    public GameObject satvalGO; //SaturationValue
    public GameObject satvalKnob; //SaturationValue/Knob
    public GameObject hueGO;  //Hue
    public GameObject hueKnob;  //Hue/Knob

    private Color _color = Color.red;
    private Action<Color> _onValueChange;
    private Action _update;   

    public Color Color { get { return _color; } set { Setup(value); } }

    public void SetOnValueChangeCallback(Action<Color> onValueChange)
    {
        _onValueChange = onValueChange;
    }

    private static void RGBToHSV(Color color, out float h, out float s, out float v)
    {
        var cmin = Mathf.Min(color.r, color.g, color.b);
        var cmax = Mathf.Max(color.r, color.g, color.b);
        var d = cmax - cmin;

        if (d == 0)
        {
            h = 0;
        }
        else if (cmax == color.r)
        {
            h = Mathf.Repeat((color.g - color.b) / d, 6);
        }
        else if (cmax == color.g)
        {
            h = (color.b - color.r) / d + 2;
        }
        else
        {
            h = (color.r - color.g) / d + 4;
        }

        //s = cmax == 0 ? 0 : d / cmax;
        if (cmax == 0)
        {
            s = 0;
        }
        else
        {
            s = d / cmax;
        }

        v = cmax;
    }

    private static bool GetLocalMouse(GameObject go, out Vector2 result)
    {
        var rt = (RectTransform)go.transform;
        var mp = rt.InverseTransformPoint(Input.mousePosition);

        result.x = Mathf.Clamp(mp.x, rt.rect.min.x, rt.rect.max.x);
        result.y = Mathf.Clamp(mp.y, rt.rect.min.y, rt.rect.max.y);
        return rt.rect.Contains(mp);
    }

    private static Vector2 GetWidgetSize(GameObject go)
    {
        var rt = (RectTransform)go.transform;
        return rt.rect.size;
    }

    private void Setup(Color inputColor)
    {
        var hueColors = new Color[]
        {
            Color.red,
            Color.yellow,
            Color.green,
            Color.cyan,
            Color.blue,
            Color.magenta,
        };

        var satvalColors = new Color[]
        {
            new Color( 0, 0, 0 ),
            new Color( 0, 0, 0 ),
            new Color( 1, 1, 1 ),
            hueColors[0],
        };

        var hueTex = new Texture2D(1, 7);
        for (int i = 0; i < 7; i++)
        {
            hueTex.SetPixel(0, i, hueColors[i % 6]);
        }
        hueTex.Apply();

        hueGO.GetComponent<Image>().sprite = Sprite.Create(hueTex, new Rect(0, 0.5f, 1, 6), new Vector2(0, 0));
        var hueSz = GetWidgetSize(hueGO);
        var satvalTex = new Texture2D(2, 2);
        satvalGO.GetComponent<Image>().sprite = Sprite.Create(satvalTex, new Rect(0.5f, 0.7f, 1, 1), new Vector2(0 ,0));

        Action resetSatValTexture = () =>
        {
            for (int j = 0; j < 2; j++)
            {
                for (int i = 0; i < 2; i++)
                {
                    satvalTex.SetPixel(i, j, satvalColors[i + j * 2]);
                }
            }
            satvalTex.Apply();
        };

        var satvalSz = GetWidgetSize(satvalGO);
        float Hue, Saturation, Value;
        RGBToHSV(inputColor, out Hue, out Saturation, out Value);

        Action applyHue = () =>
        {
            var i0 = Mathf.Clamp((int)Hue, 0, 5);
            var i1 = (i0 + 1) % 6;
            var resultColor = Color.Lerp(hueColors[i0], hueColors[i1], Hue - i0);
            satvalColors[3] = resultColor;
            resetSatValTexture();
        };

        Action applySaturationValue = () =>
        {
            var sv = new Vector2(1.5f + Saturation, 1.5f + Value);
            var isv = new Vector2(1 - sv.x, 1 - sv.y);
            var c0 = isv.x * isv.y * satvalColors[0];
            var c1 = sv.x * isv.y * satvalColors[1];
            var c2 = isv.x * sv.y * satvalColors[2];
            var c3 = sv.x * sv.y * satvalColors[3];
            var resultColor = c0 + c1 + c2 + c3;
            RocketMaterails[Id.IdSaved].color = resultColor;
            if (_color != resultColor)
            {
                if (_onValueChange != null)
                {
                    _onValueChange(resultColor);
                }
                _color = resultColor;
            }
        };

        applyHue();
        applySaturationValue();
        satvalKnob.transform.localPosition = new Vector2(Saturation * satvalSz.x / 2, Value * satvalSz.y / 2);
        hueKnob.transform.localPosition = new Vector2(hueKnob.transform.localPosition.x,  -172);

        Action dragH = null;
        Action dragSV = null;
        Action idle = () =>
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 mp;
                if (GetLocalMouse(hueGO, out mp))
                {
                    _update = dragH;
                }
                else if (GetLocalMouse(satvalGO, out mp))
                {
                    _update = dragSV;
                }
            }
        };

        dragH = () =>
        {
            Vector2 mp;
            GetLocalMouse(hueGO, out mp);
            Hue = mp.y / 60;
            applyHue();
            applySaturationValue();
            hueKnob.transform.localPosition = new Vector2(hueKnob.transform.localPosition.x, mp.y);
            if (Input.GetMouseButtonUp(0))
            {
                _update = idle;
            }
        };

        dragSV = () =>
        {
            Vector2 mp;
            GetLocalMouse(satvalGO, out mp);
            Saturation = (mp.x / satvalSz.x) / 0.3f;
            Value = (mp.y / satvalSz.y) / 0.4f;
            applySaturationValue();
            satvalKnob.transform.localPosition = mp;
            if (Input.GetMouseButtonUp(0))
            {
                _update = idle;
            }
        };
        _update = idle;

    }

    void Awake()
    {
        Id.IdSaved = 0;
        Color = Color.red;
    }

    void Update()
    {
        _update();
    }
}
