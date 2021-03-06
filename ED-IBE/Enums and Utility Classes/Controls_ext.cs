﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using IBE.Enums_and_Utility_Classes;
using System.Drawing.Drawing2D;

namespace System.Windows.Forms
{
    class ComboBox_ro : ComboBox
    {
        public ComboBox_ro()
        {
            TextBox_ro = new TextBox();
            TextBox_ro.ReadOnly = true;
            TextBox_ro.Visible = false;
        }

        public TextBox TextBox_ro;

        private bool readOnly = false;

        public bool ReadOnly
        {
            get { return readOnly; }
            set
            {
                readOnly = value;

                if (readOnly && !((Control)this).IsDesignMode())
                {
                    this.Visible = false;
                    TextBox_ro.Text = this.Text;
                    TextBox_ro.Location = this.Location;
                    TextBox_ro.Size = this.Size;
                    TextBox_ro.Visible = true;

                    if (TextBox_ro.Parent == null)
                        this.Parent.Controls.Add(TextBox_ro);

                    TextBox_ro.Font = this.Font;
                }
                else
                {
                    this.Visible = true;
                    this.TextBox_ro.Visible = false;
                }
            }
        }

        protected override void OnTextChanged(EventArgs e)
        {
 	        base.OnTextChanged(e);
            TextBox_ro.Text = this.Text;
        }

        private bool Visible_ro
        {
            get { return this.Visible; }
            set
            {
                if (value || ((Control)this).IsDesignMode())
                {
                    ReadOnly = ReadOnly;
                }
                else
                {
                    this.Visible = value;
                    this.TextBox_ro.Visible = !value;
                }

            }
        }

        public Color BackColor_ro { 
            get { return TextBox_ro.BackColor;}
            set { TextBox_ro.BackColor = value; }
        }

        public Color ForeColor_ro { 
            get { return TextBox_ro.ForeColor;}
            set { TextBox_ro.ForeColor = value; }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
    }

    public class CheckBox_ro : CheckBox
    {
            private bool readOnly;

            protected override void OnClick(EventArgs e)
            {
                    // pass the event up only if its not readlonly
                    if (!ReadOnly) base.OnClick(e);
            }

            public bool ReadOnly
            {
                    get { return readOnly; }
                    set { readOnly = value; }
            }
    }

    class DateTimePicker_ro : DateTimePicker
    {
        public DateTimePicker_ro()
        {
            TextBox_ro = new TextBox();
            TextBox_ro.ReadOnly = true;
            TextBox_ro.Visible = false;
        }

        public TextBox TextBox_ro;

        private bool readOnly = false;

        public bool ReadOnly
        {
            get { return readOnly; }
            set
            {
                readOnly = value;

                if (readOnly && !((Control)this).IsDesignMode())
                {
                    this.Visible = false;
                    TextBox_ro.Text = this.Text;
                    TextBox_ro.Location = this.Location;
                    TextBox_ro.Size = this.Size;
                    TextBox_ro.Visible = true;

                    if (TextBox_ro.Parent == null)
                        this.Parent.Controls.Add(TextBox_ro);

                    TextBox_ro.Font = this.Font;
                }
                else
                {
                    this.Visible = true;
                    this.TextBox_ro.Visible = false;
                }
            }
        }

        private bool Visible_ro
        {
            get { return this.Visible; }
            set
            {
                if (value || ((Control)this).IsDesignMode())
                {
                    ReadOnly = ReadOnly;
                }
                else
                {
                    this.Visible = value;
                    this.TextBox_ro.Visible = !value;
                }

            }
        }

        public Color BackColor_ro { 
            get { return TextBox_ro.BackColor;}
            set { TextBox_ro.BackColor = value; }
        }

        public Color ForeColor_ro { 
            get { return TextBox_ro.ForeColor;}
            set { TextBox_ro.ForeColor = value; }
        }
    }

    class NumericUpDown_ro : NumericUpDown
    {
        public TextBox TextBox_ro;

        private bool readOnly = false;

        public NumericUpDown_ro()
        {
            TextBox_ro              = new TextBox();
            TextBox_ro.ReadOnly     = true;
            TextBox_ro.Visible      = false;
        }

        public new bool ReadOnly
        {
            get { return readOnly; }
            set
            {
                readOnly = value;

                if (readOnly && !((Control)this).IsDesignMode())
                {
                    this.Visible = false;
                    TextBox_ro.Text = this.Text;
                    TextBox_ro.Location = this.Location;
                    TextBox_ro.Size = this.Size;
                    TextBox_ro.Visible = true;

                    if (TextBox_ro.Parent == null)
                        this.Parent.Controls.Add(TextBox_ro);

                    TextBox_ro.Font = this.Font;
                }
                else
                {
                    this.Visible = true;
                    this.TextBox_ro.Visible = false;
                }
            }
        }

        private bool Visible_ro
        {
            get { return this.Visible; }
            set
            {
                if (value || ((Control)this).IsDesignMode())
                {
                    ReadOnly = ReadOnly;
                }
                else
                {
                    this.Visible = value;
                    this.TextBox_ro.Visible = !value;
                }

            }
        }

        public Color BackColor_ro { 
            get { return TextBox_ro.BackColor;}
            set { TextBox_ro.BackColor = value; }
        }

        public Color ForeColor_ro { 
            get { return TextBox_ro.ForeColor;}
            set { TextBox_ro.ForeColor = value; }
        }

        public new HorizontalAlignment TextAlign { 
            get{
                return ((NumericUpDown)this).TextAlign;
            } 
            set
            {
                 ((NumericUpDown)this).TextAlign    = value;
                this.TextBox_ro.TextAlign           = value;
            }
        }
    }

    public class TextBoxInt32 : TextBox
    {
        [System.ComponentModel.Browsable(true)]
        public int? MinValue { get; set; }

        [System.ComponentModel.Browsable(true)]
        public int? MaxValue { get; set; }

        [System.ComponentModel.Browsable(true), System.ComponentModel.DefaultValue(0)]
        public Int32 DefaultValue { get; set; }

        /// <summary>
        ///  checks if the value is within its borders
        /// </summary>
        /// <returns></returns>
        public Boolean checkValue()
        {
            Boolean isOk = true;
            Int32 IntValue = 0;

            if(Int32.TryParse(this.Text, out IntValue))
            {
                if(MinValue.HasValue && (IntValue < MinValue))
                    isOk = false;

                if(MaxValue.HasValue && (IntValue > MaxValue))
                    isOk = false;
            }
            else
                isOk = false;
            
            if(! isOk)
                this.Text = DefaultValue.ToString();

            return isOk;
        }
        public int Int32Value
        {
            get
            {
                if(this.checkValue())
                    return Int32.Parse(this.Text);
                else
                    return DefaultValue;                    
            }
        }
    }

    public class TextBoxDouble : TextBox
    {
        [System.ComponentModel.Browsable(true)]
        public Double? MinValue { get; set; }

        [System.ComponentModel.Browsable(true)]
        public Double? MaxValue { get; set; }

        [System.ComponentModel.Browsable(true)]
        public int? Digits { get; set; }

        /// <summary>
        ///  checks if the value is within its borders
        /// </summary>
        /// <returns></returns>
        public Boolean checkValue()
        {
            Boolean isOk = true;
            Double DoubleValue = 0;

            if(Double.TryParse(this.Text, out DoubleValue))
            {
                if(Digits != null)
                { 
                    DoubleValue = Math.Round(DoubleValue, (Int32)Digits);
                    this.Text = DoubleValue.ToString(String.Format("F{0}", Digits));
                }

                if(MinValue.HasValue && (DoubleValue < MinValue))
                    isOk = false;

                if(MaxValue.HasValue && (DoubleValue > MaxValue))
                    isOk = false;
            }
            else
                isOk = false;
            
            return isOk;
        }


    }

    public class TextBoxDoubleB : TextBox
    {
        [System.ComponentModel.Browsable(true)]
        public int? Digits { get; set; }

        [System.ComponentModel.Browsable(true)]
        public String Format { get; set; }

        [System.ComponentModel.Browsable(true)]
        public Object DefaultValue { get; set; }

        private Boolean TextIsChanged { get; set; }

        private Object m_Value;
        [System.ComponentModel.Browsable(true)]
        public Object Value { 
            get{ 
                return m_Value;
            }
            set
            {
                ParseValue(value.ToString());

                TextIsChanged = false;
            } 
        }

        protected override void OnTextChanged(EventArgs e)
        {
            TextIsChanged = true;
            base.OnTextChanged(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            if(TextIsChanged)
                ParseValue(this.Text);

            base.OnLostFocus(e);
        }

        private void ParseValue(String txtValue)
        {
            Double tmpValue = 0;

            if(Double.TryParse(txtValue, out tmpValue))
            {
                if(Digits != null)
                {
                    tmpValue = Math.Round(tmpValue, (Int32)Digits);
                }

                m_Value = tmpValue;

                if (!String.IsNullOrEmpty(Format))
                {
                    this.Text = tmpValue.ToString(Format);
                }
                else if(Digits != null)
                {
                    this.Text = tmpValue.ToString(String.Format("F{0}", Digits));
                }
                else
                    this.Text = tmpValue.ToString();
            }
            else
            {
                m_Value   = DefaultValue;
                this.Text = DefaultValue.ToString();
            }
                
        }
    }
    

    public class ComboBoxInt32 : ComboBox
    {
        [System.ComponentModel.Browsable(true)]
        public int? MinValue { get; set; }

        [System.ComponentModel.Browsable(true)]
        public int? MaxValue { get; set; }

        /// <summary>
        ///  checks if the value is within its borders
        /// </summary>
        /// <returns></returns>
        public Boolean checkValue()
        {
            Boolean isOk = true;
            Int32 IntValue = 0;

            if(Int32.TryParse(this.Text, out IntValue))
            {
                if(MinValue.HasValue && (IntValue < MinValue))
                    isOk = false;

                if(MaxValue.HasValue && (IntValue > MaxValue))
                    isOk = false;
            }
            else
                isOk = false;
            
            return isOk;
        }
    }
    public class ButtonExt : Button
    {
        Color disabledTextColor = Color.DimGray;

        public Color DisabledTextColor
        {
            get
            {
                return disabledTextColor;
            }
            set
            {
                disabledTextColor = value;
            }
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
           base.OnPaint(pevent);

            LinearGradientBrush br = new LinearGradientBrush(ClientRectangle, Color.White, Color.White, LinearGradientMode.Vertical);

			//ColorBlend cb = new ColorBlend();
			//cb.Colors = GetFillBlend()
			//cb.Positions = ColorFillBlend.iPoint
			//'MsgBox(cb.Colors.Length & cb.Positions.Length)
			//br.InterpolationColors = cb

			//pevent.Graphics.FillPath(br, )

            if((!this.Enabled) && (!this.UseVisualStyleBackColor))
            {
                pevent.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                pevent.Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAliasGridFit;
               

                // Draw the string to screen
                StringFormat drawFormat     = GetStringFormatFromContentAllignment(this.TextAlign);
                
                drawFormat.FormatFlags      = StringFormatFlags.LineLimit;
                drawFormat.FormatFlags      |= StringFormatFlags.FitBlackBox;
                
                Rectangle textBlock         = new Rectangle(ClientRectangle.X + 2, ClientRectangle.Y + 2, ClientRectangle.Width - 4, ClientRectangle.Height - 4);
                //g.DrawString(this.Text, this.Font, Brushes.White, textBlock, drawFormat);
                //pevent.Graphics.DrawString(this.Text, this.Font, new SolidBrush(disabledTextColor), textBlock, drawFormat);
                
                TextRenderer.DrawText(pevent.Graphics, Text, Font,textBlock, disabledTextColor, BackColor, GetTextFormatFlagsFromContentAllignment(this.TextAlign) |  TextFormatFlags.WordBreak);

                if(Text.StartsWith("Export Market"))
                    Diagnostics.Debug.Print("");


                //SizeF sf = pevent.Graphics.MeasureString(this.Text, this.Font, 
                //                                         this.Width);
                //Point ThePoint = new Point();
                //ThePoint.X = (int)((this.Width / 2) - (sf.Width / 2));
                //ThePoint.Y = (int)((this.Height / 2) - (sf.Height / 2));
                //pevent.Graphics.DrawString(this.Text, Font, 
                //          new SolidBrush(disabledTextColor), ThePoint);
            }
             else if(Text.StartsWith("Export Market"))
                    Diagnostics.Debug.Print("");
        }

        private TextFormatFlags GetTextFormatFlagsFromContentAllignment(ContentAlignment ca)
        {
            TextFormatFlags format;

            switch (ca)
            {
                case ContentAlignment.TopCenter:
                    format = TextFormatFlags.Top | TextFormatFlags.HorizontalCenter;
                    break;
                case ContentAlignment.TopLeft:
                    format = TextFormatFlags.Top | TextFormatFlags.Left;
                    break;
                case ContentAlignment.TopRight:
                    format = TextFormatFlags.Top | TextFormatFlags.Right;
                    break;
                case ContentAlignment.MiddleCenter:
                    format = TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter;
                    break;
                case ContentAlignment.MiddleLeft:
                    format = TextFormatFlags.VerticalCenter | TextFormatFlags.Left;
                    break;
                case ContentAlignment.MiddleRight:
                    format = TextFormatFlags.VerticalCenter | TextFormatFlags.Right;
                    break;
                case ContentAlignment.BottomCenter:
                    format = TextFormatFlags.Bottom | TextFormatFlags.HorizontalCenter;
                    break;
                case ContentAlignment.BottomLeft:
                    format = TextFormatFlags.Bottom | TextFormatFlags.Left;
                    break;
                case ContentAlignment.BottomRight:
                    format = TextFormatFlags.Bottom | TextFormatFlags.Right;
                    break;
                default:
                    format = TextFormatFlags.Default;
                    break;
            }

            return format;
        }

        private StringFormat GetStringFormatFromContentAllignment(ContentAlignment ca)
        {
            StringFormat format = new StringFormat();
            switch (ca)
            {
                case ContentAlignment.TopCenter:
                    format.Alignment = StringAlignment.Near;
                    format.LineAlignment = StringAlignment.Center;
                    break;
                case ContentAlignment.TopLeft:
                    format.Alignment = StringAlignment.Near;
                    format.LineAlignment = StringAlignment.Near;
                    break;
                case ContentAlignment.TopRight:
                    format.Alignment = StringAlignment.Near;
                    format.LineAlignment = StringAlignment.Far;
                    break;
                case ContentAlignment.MiddleCenter:
                    format.Alignment = StringAlignment.Center;
                    format.LineAlignment = StringAlignment.Center;
                    break;
                case ContentAlignment.MiddleLeft:
                    format.Alignment = StringAlignment.Center;
                    format.LineAlignment = StringAlignment.Near;
                    break;
                case ContentAlignment.MiddleRight:
                    format.Alignment = StringAlignment.Center;
                    format.LineAlignment = StringAlignment.Far;
                    break;
                case ContentAlignment.BottomCenter:
                    format.Alignment = StringAlignment.Far;
                    format.LineAlignment = StringAlignment.Center;
                    break;
                case ContentAlignment.BottomLeft:
                    format.Alignment = StringAlignment.Far;
                    format.LineAlignment = StringAlignment.Near;
                    break;
                case ContentAlignment.BottomRight:
                    format.Alignment = StringAlignment.Far;
                    format.LineAlignment = StringAlignment.Far;
                    break;
            }
            return format;
        }


    }
}
