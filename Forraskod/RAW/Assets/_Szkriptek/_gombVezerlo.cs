﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Data;
using System.IO;

public class _gombVezerlo : MonoBehaviour
{
    #region VÁLTOZÓK
    public Text profilText;
    private static bool elsoNyitasVoltE = false;
    #endregion

    #region METÓDUSOK
    public void Kilepes()
    {
        string temp = PlayerPrefs.GetString(_konstansok.NEV);
        Debug.Log(temp);
        if (PlayerPrefs.GetString(_konstansok.NEV) == "" || Application.loadedLevelName == _konstansok.FOMENU)
        {
            Application.Quit();
            Debug.Log("Kiléptünk");
        }
        else
        {
            SceneManager.LoadScene(_konstansok.BEALLITASOK);
        }
    }

    public void Jatek()
    {
        SceneManager.LoadScene(_konstansok.MODVALASZTO);
    }

    public void Beallitasok()
    {
        string temp = PlayerPrefs.GetString(_konstansok.NEV);
        Debug.Log(temp);
        if (PlayerPrefs.GetString(_konstansok.NEV) == "" || PlayerPrefs.GetString(_konstansok.NEV) == null)
        {
            Application.Quit();
        }
        else
        {
            SceneManager.LoadScene(_konstansok.BEALLITASOK);
        }
    }

    public void Kinezetek()
    {
        SceneManager.LoadScene(_konstansok.KINEZETEK);
    }

    public void Vissza()
    {
        switch (Application.loadedLevelName)
        {
            case _konstansok.MODVALASZTO:
                SceneManager.LoadScene(_konstansok.FOMENU);
                break;
            case _konstansok.PALYAVALASZTO:
                SceneManager.LoadScene(_konstansok.MODVALASZTO);
                break;
            case _konstansok.BEALLITASOK:
                SceneManager.LoadScene(_konstansok.FOMENU);
                break;
            case _konstansok.KINEZETEK:
                SceneManager.LoadScene(_konstansok.FOMENU);
                break;

        }
        if (Application.loadedLevelName.Split('_')[0] == "palya")
        {
            SceneManager.LoadScene(_konstansok.PALYAVALASZTO);
        }
    }

    public void SzimplaMod()
    {
        PlayerPrefs.SetString(_konstansok.SZIMPLA_MOD, _konstansok.ERTEK_IGEN);
        PlayerPrefs.SetString(_konstansok.CSILLAG_MOD, _konstansok.ERTEK_NEM);
        SceneManager.LoadScene(_konstansok.PALYAVALASZTO);
    }

    public void VersenyAzIdovel()
    {
        PlayerPrefs.SetString(_konstansok.SZIMPLA_MOD, _konstansok.ERTEK_NEM);
        PlayerPrefs.SetString(_konstansok.CSILLAG_MOD, _konstansok.ERTEK_NEM);
        SceneManager.LoadScene(_konstansok.PALYAVALASZTO);
    }

    public void CsillagLeszek() {
        PlayerPrefs.SetString(_konstansok.SZIMPLA_MOD, _konstansok.ERTEK_IGEN); //hogy ne legyen timer
        PlayerPrefs.SetString(_konstansok.CSILLAG_MOD, _konstansok.ERTEK_IGEN);

        SceneManager.LoadScene(_konstansok.PALYAVALASZTO);
    }

    void Start()
    {
        if (Application.loadedLevelName == _konstansok.FOMENU)
        {
            Debug.Log(string.Format("Fő menu player prefs felhasználó id: {0} | Név :{1}", PlayerPrefs.GetInt(_konstansok.FELHASZNALOID), PlayerPrefs.GetString(_konstansok.NEV)));

            if (elsoNyitasVoltE == false)
            {
                IDataReader olvaso = _adatbazisvezerlo.GetPeldany(_konstansok.AdatbazisEleres).FelhasznaloNevLekerdezese(PlayerPrefs.GetInt(_konstansok.FELHASZNALOID));
                PlayerPrefs.SetString(_konstansok.NEV, olvaso.GetValue(0).ToString());
                elsoNyitasVoltE = true;
                profilText.text = "Profil: " + PlayerPrefs.GetString(_konstansok.NEV);
                olvaso.Close();
            }
            else
            {
                profilText.text = "Profil: " + PlayerPrefs.GetString(_konstansok.NEV);
            }
        }
    }

    public void FelhasznalokMegnyitasa()
    {
        SceneManager.LoadScene(_konstansok.FELHASZNALOK);
    }

    public void FelhasznaloKeszitesMegnyitasa()
    {
        SceneManager.LoadScene(_konstansok.UJFELHASZNALO);
    }

    public void Ujra()
    {
        SceneManager.LoadScene(Application.loadedLevelName);
    }

    public void UjValasztasa()
    {
        SceneManager.LoadScene(_konstansok.PALYAVALASZTO);
    }
    #endregion
}
