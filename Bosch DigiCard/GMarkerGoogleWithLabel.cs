using System;
using System.Drawing;
using GMap.NET.WindowsForms.Markers;
using GMap.NET;
using System.Collections.Generic;

namespace Bosch_DigiCard.Markers
{
	public class GMarkerGoogleWithLabel : GMarkerGoogle
	{
		public string LabelText { get; set; }
		public Font LabelFont { get; set; } = new Font("Arial", 8);
		public Brush LabelBrush { get; set; } = new SolidBrush(Color.Black);
		public Point LabelOffset { get; set; } = new Point(20, 0);

		public GMarkerGoogleWithLabel(PointLatLng p, GMarkerGoogleType type) : base(p, type)
		{
		}

		public GMarkerGoogleWithLabel(PointLatLng p, Bitmap bitmap) : base(p, bitmap)
		{
		}


		public override void OnRender(Graphics g)
		{
			base.OnRender(g);

			// Ensure there is text to draw.
			if (!string.IsNullOrWhiteSpace(LabelText))
			{
				// Calculate the position for the label based on the marker's position and the offset.
				var labelPosition = new PointF(LocalPosition.X + LabelOffset.X, LocalPosition.Y + LabelOffset.Y);

				// Draw the label text next to the marker icon.
				g.DrawString(LabelText, LabelFont, LabelBrush, labelPosition);
			}
		}
	}
}
