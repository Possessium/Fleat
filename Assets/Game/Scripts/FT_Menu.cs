using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//using System.Linq;

public class FT_Menu : MonoBehaviour
{
    [SerializeField] MenuMode currentMode = MenuMode.Title;

    [SerializeField] GameObject titleScreen = null;
    [SerializeField] GameObject mainMenu = null;
    [SerializeField] GameObject options = null;
    [SerializeField] GameObject credits = null;
    [SerializeField] GameObject map = null;

    private void Start()
    {
        SwitchMenuToTitle();
    }

    private void Update()
    {
        if(currentMode == MenuMode.Title)
        {
            bool _pressed = false;
            for (int i = 0; i < Keyboard.current.allKeys.Count; i++)
            {
                if(Keyboard.current.allKeys[i].wasPressedThisFrame)
                {
                    _pressed = true;
                    break;
                }
            }
            if (_pressed)
                SwitchMenuToMain();
        }
        else if (currentMode != MenuMode.None)
        {
            if (Keyboard.current.escapeKey.wasPressedThisFrame)
                SwitchMenuToMain();
        }
    }

    public void SwitchMenuToTitle() 
    {
        currentMode = MenuMode.Title;
        ChangeMenuVisible(ref titleScreen);
    }
    public void SwitchMenuToMain()
    {
        currentMode = MenuMode.MainMenu;
        ChangeMenuVisible(ref mainMenu);
    }
    public void SwitchMenuToOptions()
    {
        currentMode = MenuMode.Options;
        ChangeMenuVisible(ref options);
    }
    public void SwitchMenuToMap()
    {
        currentMode = MenuMode.Map;
        ChangeMenuVisible(ref map);
    }
    public void SwitchMenuToCredits()
    {
        currentMode = MenuMode.Credits;
        ChangeMenuVisible(ref credits);
    }

    public void SwitchMenuToNone()
    {
        currentMode = MenuMode.None;
        MenuOff();
    }

    void MenuOff()
    {
        titleScreen.SetActive(false);
        mainMenu.SetActive(false);
        options.SetActive(false);
        credits.SetActive(false);
        map.SetActive(false);
    }

    void ChangeMenuVisible(ref GameObject _g)
    {
        MenuOff();

        _g.SetActive(true);
    }

    public void Quit() => Application.Quit();
}

public enum MenuMode
{
    Title,
    MainMenu,
    Map,
    Options,
    Credits,
    None
}
