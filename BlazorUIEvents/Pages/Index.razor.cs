using BlazorUIEvents.Data;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorUIEvents.Pages
{
	public class IndexBase : OwningComponentBase
	{

		public string status { get; set; }

		public string WhereAmI { get; set; }

		[Inject]
		protected SingleService Service { get; set; }


		private async void OnStatusChangedMethod(object sender, EventArgs e)
		{

			if (e.GetType() == typeof(StringEventArgs))
			{
				status = (e as StringEventArgs).Value;
			}

			await InvokeAsync(() => StateHasChanged());
		}

		protected override void OnInitialized()
		{
			Service.MyEvent -= OnStatusChangedMethod;
			Service.MyEvent += OnStatusChangedMethod;
		}

		protected override void Dispose(bool disposing)
		{
			Service.MyEvent -= OnStatusChangedMethod;
		}

	}
}
