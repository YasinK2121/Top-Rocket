using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPicker : MonoBehaviour
{
    public List<GameObject> CameraPosition;
    public List<GameObject> Image;
    public GameObject Camera;
    public int IdSaved;

    public void RightButtonOnClick()
    {
        int Id = SelectedFind();

        CameraPosition[Id].SetActive(false);
        Image[Id].SetActive(false);
        Camera.transform.position = CameraPosition[Id].transform.position;
        Camera.transform.rotation = CameraPosition[Id].transform.rotation;

        if (Id + 1 < CameraPosition.Count)
        {
            CameraPosition[Id + 1].SetActive(true);
            Image[Id + 1].SetActive(true);
            Camera.transform.position = CameraPosition[Id + 1].transform.position;
            Camera.transform.rotation = CameraPosition[Id + 1].transform.rotation;
            IdSaved = Id + 1;
        }
        else
        {
            CameraPosition[0].SetActive(true);
            Image[0].SetActive(true);
            Camera.transform.position = CameraPosition[0].transform.position;
            Camera.transform.rotation = CameraPosition[0].transform.rotation;
            IdSaved = 0;
        }
    }

    public void LeftButtonOnClick()
    {
        int Id = SelectedFind();

        CameraPosition[Id].SetActive(false);
        Image[Id].SetActive(false);
        Camera.transform.position = CameraPosition[Id].transform.position;
        Camera.transform.rotation = CameraPosition[Id].transform.rotation;

        if (Id - 1 >= 0)
        {
            CameraPosition[Id - 1].SetActive(true);
            Image[Id - 1].SetActive(true);
            Camera.transform.position = CameraPosition[Id - 1].transform.position;
            Camera.transform.rotation = CameraPosition[Id - 1].transform.rotation;
            IdSaved = Id - 1;
        }
        else
        {
            CameraPosition[CameraPosition.Count - 1].SetActive(true);
            Image[Image.Count - 1].SetActive(true);
            Camera.transform.position = CameraPosition[CameraPosition.Count - 1].transform.position;
            Camera.transform.rotation = CameraPosition[CameraPosition.Count - 1].transform.rotation;
            IdSaved = CameraPosition.Count - 1;
        }
    }

    public int SelectedFind()
    {
        int ItemId = 0;
        for (int i = 0; i < CameraPosition.Count; i++)
        {
            if (CameraPosition[i].activeInHierarchy)
            {
                ItemId = i;
                IdSaved = i;
            }
        }

        return ItemId;
    }
}
