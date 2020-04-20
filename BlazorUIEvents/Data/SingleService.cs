using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorUIEvents.Data
{
	public class SingleService
	{
		public delegate void MyDel(object sender, EventArgs e);

		public event MyDel MyEvent;

		public int CountValue;

		public void OnCountValueIncreased(object sender, EventArgs e)
		{
			CountValue++;
			MyEvent?.Invoke(sender, e);
		}

	}

	public class StringEventArgs : EventArgs
	{
		public string Value { get; set; }
	}
}
