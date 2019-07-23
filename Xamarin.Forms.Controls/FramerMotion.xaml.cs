﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin.Forms.Controls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FramerMotion : ContentPage
	{
		public FramerMotion()
		{
			InitializeComponent();
			BindingContext = this;
			var storyBoard = (boxView.Resources["animateScale"] as Storyboard);
			if (storyBoard != null)
			{
				storyBoard.Duration = 300;
				storyBoard.Easing = Easing.SpringIn;
				Storyboard.SetTarget(storyBoard, boxView);
			}
		}

		protected override void OnAppearing()
		{
			sliderX.Maximum = 600;
			sliderY.Maximum = 600;
			base.OnAppearing();
		}

		double _sliderValue = 1;
		public double SliderValue
		{
			get => _sliderValue;
			set
			{
				var val = Math.Round(value, 2);
				if (Math.Abs(val - _sliderValue) <= 0)
					return;
				_sliderValue = val;
				OnPropertyChanged();
			}
		}

		double _rotation;
		public double Rotation
		{
			get => _rotation;
			set
			{
				var val = Math.Round(value, 2);
				if (Math.Abs(val - _rotation) <= 0)
					return;
				_rotation = val;
				OnPropertyChanged();
			}
		}

		int _x;
		public int X
		{
			get => _x;
			set
			{
				if (_x == value)
					return;
				_x = value;
				OnPropertyChanged();
			}
		}

		int _y;
		public int Y
		{
			get => _y;
			set
			{
				if (_y == value)
					return;
				_y = value;
				OnPropertyChanged();
			}
		}
	}
}