//
// ViewModel.cs
//
// Author:
//       Stephane Delcroix <stephane@mi8.be>
//
// Copyright (c) 2015 mobile inception
//
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using Xamarin.Forms;
using System;
using System.Threading.Tasks;
using System.Reflection;

namespace Me
{
	public abstract class ViewModel : INotifyPropertyChanged
	{
		protected virtual void NotifyPropertyChanged ([CallerMemberNameAttribute]string propertyName = null)
		{
			OnPropertyChanged (new PropertyChangedEventArgs (propertyName));
		}

		protected virtual void OnPropertyChanged (PropertyChangedEventArgs e)
		{
			PropertyChanged?.Invoke (this, e);
		}

		[MethodImpl (MethodImplOptions.AggressiveInlining)]
		protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null, Action<T> onChanged = null)
		{
			if (EqualityComparer<T>.Default.Equals (storage, value))
				return false;

			storage = value;
			onChanged?.Invoke (value);
			NotifyPropertyChanged (propertyName);
			return true;
		}

		public event PropertyChangedEventHandler PropertyChanged;
   

		public async Task<bool> NavigateToViewModel<TViewModel> ()
			where TViewModel : ViewModel, new()
		{
			if (isNavigating || NavigateToViewModelDelegate == null)
				return false;
			try {
				isNavigating = true;
				return await NavigateToViewModelDelegate (typeof(TViewModel), () => new TViewModel ());
			} finally {
				isNavigating = false;
			}
		}

		public async Task<bool> NavigateToViewModel<TViewModel> (Func<TViewModel> viewModelFactory)
		{
			if (viewModelFactory == null)
				throw new ArgumentNullException ("viewModelFactory");
			if (isNavigating || NavigateToViewModelDelegate == null)
				return false;
			try {
				isNavigating = true;
				return await NavigateToViewModelDelegate (typeof(TViewModel), () => viewModelFactory ());
			} finally {
				isNavigating = false;
			}
		}

		public async Task<bool> NavigateToViewModel<TViewModel> (TViewModel viewModel)
		{
			if (viewModel == null)
				throw new ArgumentNullException ("viewModel");
			if (isNavigating || NavigateToViewModelDelegate == null)
				return false;
			try {
				isNavigating = true;
				return await NavigateToViewModelDelegate (typeof(TViewModel), () => viewModel);
			} finally {
				isNavigating = false;
			}
		}

		internal Func<Type,Func<object>,Task<bool>> NavigateToViewModelDelegate { get; set; }
		internal Func<Task<bool>> NavigateBackDelegate { get; set; }
        internal Func<Task> NavigateBackToRootDelegate { get; set; }
		internal Func<string,string,string,Task> DisplayAlertDelegate { get; set; }
		internal Func<string,string,string,string,Task<bool>> DisplayOkCancelAlertDelegate { get; set; }
		internal Func<string,string,string, string[],Task<string>> DisplayActionSheetDelegate { get; set; }

		public async Task<bool> NavigateBack ()
		{
			if (NavigateBackDelegate == null)
				return false;
			return await NavigateBackDelegate ();
		}

		public async Task NavigateBackToRoot ()
		{
			if (NavigateBackToRootDelegate != null)
				await NavigateBackToRootDelegate ();
		}

		public Task DisplayAlert (string title, string message, string cancel)
		{
			var displayDelegate = DisplayAlertDelegate ?? Application.Current.MainPage.DisplayAlert;
			if (displayDelegate != null)
				return displayDelegate (title, message, cancel);
			return Task.FromResult<bool> (false);
		}

		public Task<bool> DisplayAlert (string title, string message, string accept, string cancel)
		{
			var displayDelegate = DisplayOkCancelAlertDelegate ?? Application.Current.MainPage.DisplayAlert;
			if (displayDelegate != null)
				return displayDelegate (title, message, accept, cancel);
			return Task.FromResult<bool> (false);
		}

		public async Task<string> DisplayActionSheet(string title, string cancel, string destruction, string[] buttons)
		{
			var displayDelegate = DisplayActionSheetDelegate ?? Application.Current.MainPage.DisplayActionSheet;
			if (displayDelegate != null)
				return await displayDelegate(title, cancel, destruction, buttons);
			return await Task.FromResult<string> (string.Empty);
		}

		bool isNavigating;
	}
}