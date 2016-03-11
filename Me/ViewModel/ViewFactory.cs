//
// ViewFactory.cs
//
// Author:
//       Stephane Delcroix <stephane@mi8.be>
//
// Copyright (c) 2015 mobile inception
//
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Scanne
{
	public static class ViewFactory
	{
		static readonly Dictionary<Type, Type> types = new Dictionary<Type, Type> ();

		public static void Register<TView, TViewModel> ()
			where TView : VisualElement
			where TViewModel : ViewModel
		{
			types [typeof(TViewModel)] = typeof(TView);
		}

		public static TView Create<TView,TViewModel> ()
			where TView : VisualElement
			where TViewModel : class, new()
		{
			return (TView)Create<TViewModel> ();
		}

		public static TView Create<TView,TViewModel> (Func<TViewModel> viewModelFactory)
			where TView : VisualElement
			where TViewModel : class
		{
			return (TView)Create<TViewModel> (viewModelFactory);
		}

		public static object Create<TViewModel> ()
			where TViewModel : class, new()
		{
			return Create<TViewModel> (() => new TViewModel ());
		}

		public static object Create<TViewModel> (Func<TViewModel> viewModelFactory)
			where TViewModel : class
		{
			if (viewModelFactory == null)
				throw new ArgumentNullException ("viewModelFactory");

			Type tView;
			if (!types.TryGetValue (typeof(TViewModel), out tView))
				throw new InvalidOperationException ("You must Register() a TView for this TViewModel first.");

			var view = (VisualElement)Activator.CreateInstance (tView);
			view.BindingContext = viewModelFactory ();

			return view;
		}

		public static object Create (Type tViewModel)
		{
			if (tViewModel == null)
				throw new ArgumentNullException ("tViewModel");
			return Create (tViewModel, () => (ViewModel)Activator.CreateInstance (tViewModel));
		}

		public static object Create (Type tViewModel, Func<ViewModel> viewModelFactory)
		{
			try {
				if (tViewModel == null)
					throw new ArgumentNullException ("tViewModel");
				if (viewModelFactory == null)
					throw new ArgumentNullException ("viewModelFactory");

				Type tView;
				if (!types.TryGetValue (tViewModel, out tView))
					throw new InvalidOperationException ("You must Register() a TView for this TViewModel first.");

				var view = (VisualElement)Activator.CreateInstance (tView);

				view.BindingContext = viewModelFactory ();

				return view;
			} catch (Exception e) {
				System.Diagnostics.Debug.WriteLine (e);
				throw e;
			}
		}
	}
}