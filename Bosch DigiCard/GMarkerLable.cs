using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;
using GMap.NET.WindowsForms.Properties;
using GMap.NET;

namespace Bosch_DigiCard.CustomMarkers;

[Serializable]
public class GMarkerGoogleWithLabel : GMapMarker, ISerializable, IDeserializationCallback
{
	private Bitmap _bitmap;
	private Bitmap _bitmapShadow;
	private static Bitmap _arrowShadow;
	private static Bitmap _msmarkerShadow;
	private static Bitmap _shadowSmall;
	private static Bitmap _pushpinShadow;
	public readonly GMarkerGoogleType Type;
	private static readonly Dictionary<string, Bitmap> IconCache = new Dictionary<string, Bitmap>();

	// Label properties
	public string LabelText { get; set; }
	public Font LabelFont { get; set; } = new Font("Arial", 8);
	public Brush LabelBrush { get; set; } = new SolidBrush(Color.Black);
	public Point LabelOffset { get; set; } = new Point(20, 0);

	public Bitmap Bitmap
	{
		get { return _bitmap; }
		set { _bitmap = value; }
	}

	public GMarkerGoogleWithLabel(PointLatLng p, GMarkerGoogleType type) : base(p)
	{
		Type = type;
		if (type != 0)
		{
			LoadBitmap();
		}
	}

	public GMarkerGoogleWithLabel(PointLatLng p, Bitmap bitmap) : base(p)
	{
		Bitmap = bitmap;
		base.Size = new Size(bitmap.Width, bitmap.Height);
		base.Offset = new Point(-base.Size.Width / 2, -base.Size.Height);
	}

	private void LoadBitmap()
	{
		// Identical to original LoadBitmap method, omitted for brevity
	}

	internal static Bitmap GetIcon(string name)
	{
		// Identical to original GetIcon method, omitted for brevity
	}

	public override void OnRender(Graphics g)
	{
		lock (Bitmap)
		{
			if (_bitmapShadow != null)
			{
				g.DrawImage(_bitmapShadow, base.LocalPosition.X, base.LocalPosition.Y, _bitmapShadow.Width, _bitmapShadow.Height);
			}

			g.DrawImage(Bitmap, base.LocalPosition.X, base.LocalPosition.Y, base.Size.Width, base.Size.Height);

			// Draw the label if there is text
			if (!string.IsNullOrWhiteSpace(LabelText))
			{
				var labelPosition = new PointF(LocalPosition.X + LabelOffset.X, LocalPosition.Y + LabelOffset.Y);
				g.DrawString(LabelText, LabelFont, LabelBrush, labelPosition);
			}
		}
	}

	public override void Dispose()
	{
		// Identical to original Dispose method, omitted for brevity
	}

	void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
	{
		// Identical to original GetObjectData method, plus include label properties if necessary
	}

	protected GMarkerGoogleWithLabel(SerializationInfo info, StreamingContext context) : base(info, context)
	{
		// Identical to original serialization constructor, plus load label properties if necessary
	}

	public void OnDeserialization(object sender)
	{
		// Identical to original OnDeserialization method, omitted for brevity
	}
}
