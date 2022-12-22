using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using FormElementsLib;
using MonoHelper;

namespace MonogameLinkLabel
{
    public class LinkLabel : TextFE
    {
        public SpriteFont font;
        public int fontsize, fontinitsize;
        public Texture2D linetexture;

        public LinkLabel(GraphicsDevice graphics, int x, int y, int width, int heigth, string _text, SpriteFont _font, int _fontinitsize, int _fontsize)
        {
            color = Color.White;
            Location = new Vector2(x, y);
            font = _font;
            fontsize = _fontsize;
            fontinitsize = _fontinitsize;
            text = _text;
            Location = new Vector2(x, y);
            Size = new System.Drawing.Size(width, heigth);
            textcolor = Color.Black;
            if (width > 0 && heigth > 0) Size = new System.Drawing.Size(width, heigth);
            else
            {
                if (width < 0) width = MHeleper.GetTextWidth(text, _font, _fontinitsize, _fontsize);
                if (heigth < 0) heigth = MHeleper.GetFontHeight(_font, _fontinitsize, _fontsize);
                Size = new System.Drawing.Size(width, heigth);
            }

            linetexture = new Texture2D(graphics, Size.Width, 2);
            Microsoft.Xna.Framework.Color[] colordata = new Microsoft.Xna.Framework.Color[Size.Width * 2];
            for (int i=0; i<colordata.Length; i++)
            {
                colordata[i] = Color.White;
            }
            linetexture.SetData<Microsoft.Xna.Framework.Color>(colordata);
        }

        public override void OnElement()
        {
            Mouse.SetCursor(MouseCursor.Hand);
        }

        public override void Dispose()
        {
            linetexture.Dispose();
        }

        public override void Release()
        {
            base.Release();
            Mouse.SetCursor(MouseCursor.Arrow);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (visible)
            {
                spriteBatch.DrawString(font, text, new Vector2(Location.X + (Size.Width - (float)fontsize / fontinitsize * font.MeasureString(text).X) / 2, Location.Y + (Size.Height - (float)fontsize / fontinitsize * font.MeasureString(text).Y) / 2), textcolor, 0f, new Vector2(0, 0), ((float)fontsize / fontinitsize), SpriteEffects.None, 1f);
                spriteBatch.Draw(linetexture, new Vector2(Location.X, Location.Y + Size.Height - 2), textcolor);
            }
        }
    }

}
