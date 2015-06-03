using Microsoft.FSharp.Core;
using System;
[CompilationMapping(SourceConstructFlags.Module)]
public static class MutableFields
{
	[CompilationMapping(SourceConstructFlags.ObjectType)]
	[Serializable]
	public class MutableVector
	{
		internal double y;
		internal double x;
		internal double cx;
		internal double cy;
		public double X
		{
			get { return this.cx; }
			set { this.cx = value; }
		}
		public double Y
		{
			get { return this.cy; }
			set { this.cy = value; }
		}
		public double Length
		{
			get { return Math.Sqrt(this.x * this.x + this.y * this.y); }
		}
		public MutableVector(double x, double y) : this()
		{
			this.x = x;
			this.y = y;
			this.cx = this.x;
			this.cy = this.y;
		}
	}
}
