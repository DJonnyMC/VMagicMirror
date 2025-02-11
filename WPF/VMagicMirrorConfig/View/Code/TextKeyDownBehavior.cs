﻿using Microsoft.Xaml.Behaviors;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Baku.VMagicMirrorConfig.View
{
    /// <summary>
    /// Hot Keyの編集をするためのテキストボックスからKeyDown情報をコマンド的に送信するやつ
    /// </summary>
    public class TextKeyDownBehavior : Behavior<TextBox>
    {
        public ICommand KeyDownCommand
        {
            get => (ICommand)GetValue(KeyDownCommandProperty);
            set => SetValue(KeyDownCommandProperty, value);
        }

        public static readonly DependencyProperty KeyDownCommandProperty
            = DependencyProperty.RegisterAttached(
                nameof(KeyDownCommand),
                typeof(ICommand),
                typeof(TextKeyDownBehavior)
                );

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.KeyDown += OnKeyDown;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.KeyDown -= OnKeyDown;
        }

        //NOTE: 必要ならpreviewにするのもあり
        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab)
            {
                //タブはショートカットとしては認めず、ナビゲーション用の入力として流す
                return;
            }

            if (e.Key == Key.LeftShift || e.Key == Key.RightShift ||
                e.Key == Key.LeftCtrl || e.Key == Key.RightCtrl || 
                e.Key == Key.LeftAlt || e.Key == Key.RightAlt || 
                e.Key == Key.LWin || e.Key == Key.RWin)
            {
                e.Handled = true;
                return;
            }

            //Lock系を含む、「さすがにそれは無いやろ」系のキーを無視
            if (e.Key == Key.NumLock || e.Key == Key.CapsLock || e.Key == Key.PrintScreen)
            {
                e.Handled = true;
                return;
            }

            if (KeyDownCommand?.CanExecute(e.Key) == true)
            {
                KeyDownCommand.Execute(e.Key);
            }
            e.Handled = true;
        }
    }
}
