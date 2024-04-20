using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace terrain_generator_version_3._0
{
    class BlockRender
    {
        public float angle;
        public float radius;
        public Bitmap sprite;
        public PointF SpriteCenter;
        public BlockRender(float angle, PointF center, Bitmap Image)
        {
            this.angle = angle;
            this.SpriteCenter = center;
            this.sprite = Image;
            radius = Math.Min(Image.Width, Image.Height) / 2f;

        }
        public void Draw(Graphics g)
        {
            GraphicsState state = g.Save();
            g.ResetTransform();
            g.RotateTransform(angle);
            g.TranslateTransform(SpriteCenter.X, SpriteCenter.Y, MatrixOrder.Append);
            g.DrawImage(sprite, new PointF(-radius, -radius));
            g.Restore(state);
        }
    }
}
