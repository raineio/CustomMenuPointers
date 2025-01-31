﻿using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.MenuButtons;
using System;
using CustomMenuPointers.UI.FlowCoordinators;
using Zenject;

namespace CustomMenuPointers.UI
{
    public class MenuButtonUI : IInitializable, IDisposable
        {
            private readonly MenuButton _menuButton;
            private readonly MainFlowCoordinator _mainFlowCoordinator;
            private readonly UIFlowCoordinator _uiFlowCoordinator;

            public MenuButtonUI(MainFlowCoordinator mainFlowCoordinator, UIFlowCoordinator uiFlowCoordinator)
            {
                _menuButton = new MenuButton("Menu Pointers!", "Custom Menu Pointers for the world!", MenuButtonClicked, true);
                _mainFlowCoordinator = mainFlowCoordinator;
                _uiFlowCoordinator = uiFlowCoordinator;
            }

            public void Initialize()
            {
                MenuButtons.instance.RegisterButton(_menuButton);
            }

            public void Dispose()
            {
                if (MenuButtons.IsSingletonAvailable && BSMLParser.IsSingletonAvailable)
                {
                    MenuButtons.instance.UnregisterButton(_menuButton);
                }
            }

            private void MenuButtonClicked()
            {
                _mainFlowCoordinator.PresentFlowCoordinator(_uiFlowCoordinator);
            }
        }
    }
