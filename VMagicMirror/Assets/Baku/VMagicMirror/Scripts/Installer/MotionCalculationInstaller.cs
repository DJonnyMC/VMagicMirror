﻿using UnityEngine;
using Zenject;

namespace Baku.VMagicMirror.Installer
{
    public class MotionCalculationInstaller : InstallerBase
    {
        [SerializeField] private HandIKIntegrator handIKIntegrator = null;
        [SerializeField] private FaceAttitudeController faceAttitude = null;
        [SerializeField] private HeadMotionClipPlayer headMotionClipPlayer = null;
        [SerializeField] private ColliderBasedAvatarParamLoader colliderBasedAvatarParamLoader = null;
        [SerializeField] private NonImageBasedMotion nonImageBasedMotion = null;
        [SerializeField] private FingerController fingerController = null;

        public override void Install(DiContainer container)
        {
            container.BindInstances(
                handIKIntegrator,
                faceAttitude,
                headMotionClipPlayer,
                colliderBasedAvatarParamLoader,
                nonImageBasedMotion,
                fingerController
            );

            container.BindInterfacesAndSelfTo<ClapMotionPlayer>().AsSingle();
        }
    }
}
