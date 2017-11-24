﻿using System;
using System.Runtime.InteropServices;
using System.Security;
using BulletSharp.Math;


namespace BulletSharp
{
	public class Triangle : IDisposable
	{
		internal IntPtr Native;
		private bool _preventDelete;

		internal Triangle(IntPtr native, bool preventDelete)
		{
			Native = native;
			_preventDelete = preventDelete;
		}

		public Triangle()
		{
			Native = UnsafeNativeMethods.btTriangle_new();
		}

		public int PartId
		{
			get { return  UnsafeNativeMethods.btTriangle_getPartId(Native);}
			set {  UnsafeNativeMethods.btTriangle_setPartId(Native, value);}
		}

		public int TriangleIndex
		{
			get { return  UnsafeNativeMethods.btTriangle_getTriangleIndex(Native);}
			set {  UnsafeNativeMethods.btTriangle_setTriangleIndex(Native, value);}
		}

		public Vector3 Vertex0
		{
			get
			{
				Vector3 value;
				UnsafeNativeMethods.btTriangle_getVertex0(Native, out value);
				return value;
			}
			set {  UnsafeNativeMethods.btTriangle_setVertex0(Native, ref value);}
		}

		public Vector3 Vertex1
		{
			get
			{
				Vector3 value;
				UnsafeNativeMethods.btTriangle_getVertex1(Native, out value);
				return value;
			}
			set {  UnsafeNativeMethods.btTriangle_setVertex1(Native, ref value);}
		}

		public Vector3 Vertex2
		{
			get
			{
				Vector3 value;
				UnsafeNativeMethods.btTriangle_getVertex2(Native, out value);
				return value;
			}
			set {  UnsafeNativeMethods.btTriangle_setVertex2(Native, ref value);}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (Native != IntPtr.Zero)
			{
				if (!_preventDelete)
				{
					UnsafeNativeMethods.btTriangle_delete(Native);
				}
				Native = IntPtr.Zero;
			}
		}

		~Triangle()
		{
			Dispose(false);
		}
	}

	public class TriangleBuffer : TriangleCallback
	{
		/*
		public TriangleBuffer()
			: base(UnsafeNativeMethods.btTriangleBuffer_new())
		{
		}
		*/
		public TriangleBuffer()
		{
		}

		public void ClearBuffer()
		{
			UnsafeNativeMethods.btTriangleBuffer_clearBuffer(Native);
		}

		public Triangle GetTriangle(int index)
		{
			return new Triangle(UnsafeNativeMethods.btTriangleBuffer_getTriangle(Native, index), true);
		}

		public override void ProcessTriangle(ref Vector3 vector0, ref Vector3 vector1, ref Vector3 vector2, int partId, int triangleIndex)
		{
			throw new NotImplementedException();
		}

		public int NumTriangles{ get { return  UnsafeNativeMethods.btTriangleBuffer_getNumTriangles(Native);} }
	}
}
