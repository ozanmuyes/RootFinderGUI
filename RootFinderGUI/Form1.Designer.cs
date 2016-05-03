namespace RootFinderGUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.zed = new ZedGraph.ZedGraphControl();
            this.btDraw = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbExpression = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btNextStep = new System.Windows.Forms.Button();
            this.btPreviousStep = new System.Windows.Forms.Button();
            this.nmFrom = new System.Windows.Forms.TextBox();
            this.nmTo = new System.Windows.Forms.TextBox();
            this.lbRoot = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nmStep = new System.Windows.Forms.TextBox();
            this.lbZoom = new System.Windows.Forms.Label();
            this.cbMethod = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // zed
            // 
            this.zed.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zed.EditModifierKeys = System.Windows.Forms.Keys.None;
            this.zed.IsAntiAlias = true;
            this.zed.IsAutoScrollRange = true;
            this.zed.IsShowHScrollBar = true;
            this.zed.IsShowPointValues = true;
            this.zed.IsShowVScrollBar = true;
            this.zed.LinkModifierKeys = System.Windows.Forms.Keys.None;
            this.zed.Location = new System.Drawing.Point(12, 126);
            this.zed.Name = "zed";
            this.zed.PanModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)));
            this.zed.ScrollGrace = 0D;
            this.zed.ScrollMaxX = 0D;
            this.zed.ScrollMaxY = 0D;
            this.zed.ScrollMaxY2 = 0D;
            this.zed.ScrollMinX = 0D;
            this.zed.ScrollMinY = 0D;
            this.zed.ScrollMinY2 = 0D;
            this.zed.Size = new System.Drawing.Size(760, 423);
            this.zed.TabIndex = 0;
            this.zed.UseExtendedPrintDialog = true;
            this.zed.ZoomEvent += new ZedGraph.ZedGraphControl.ZoomEventHandler(this.zed_ZoomEvent);
            this.zed.KeyDown += new System.Windows.Forms.KeyEventHandler(this.zed_KeyDown);
            this.zed.KeyUp += new System.Windows.Forms.KeyEventHandler(this.zed_KeyUp);
            // 
            // btDraw
            // 
            this.btDraw.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btDraw.Location = new System.Drawing.Point(617, 37);
            this.btDraw.Name = "btDraw";
            this.btDraw.Size = new System.Drawing.Size(75, 23);
            this.btDraw.TabIndex = 1;
            this.btDraw.Text = "Draw";
            this.btDraw.UseVisualStyleBackColor = true;
            this.btDraw.Click += new System.EventHandler(this.btDraw_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Expression:";
            // 
            // tbExpression
            // 
            this.tbExpression.Location = new System.Drawing.Point(88, 39);
            this.tbExpression.Name = "tbExpression";
            this.tbExpression.Size = new System.Drawing.Size(328, 20);
            this.tbExpression.TabIndex = 3;
            this.tbExpression.Text = "x ^ 2 - 3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "From:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(102, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "to:";
            // 
            // btNextStep
            // 
            this.btNextStep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btNextStep.Location = new System.Drawing.Point(738, 37);
            this.btNextStep.Name = "btNextStep";
            this.btNextStep.Size = new System.Drawing.Size(34, 23);
            this.btNextStep.TabIndex = 5;
            this.btNextStep.Text = ">";
            this.btNextStep.UseVisualStyleBackColor = true;
            this.btNextStep.Click += new System.EventHandler(this.btNextStep_Click);
            // 
            // btPreviousStep
            // 
            this.btPreviousStep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btPreviousStep.Location = new System.Drawing.Point(698, 37);
            this.btPreviousStep.Name = "btPreviousStep";
            this.btPreviousStep.Size = new System.Drawing.Size(34, 23);
            this.btPreviousStep.TabIndex = 5;
            this.btPreviousStep.Text = "<";
            this.btPreviousStep.UseVisualStyleBackColor = true;
            this.btPreviousStep.Click += new System.EventHandler(this.btPreviousStep_Click);
            // 
            // nmFrom
            // 
            this.nmFrom.Location = new System.Drawing.Point(42, 3);
            this.nmFrom.Name = "nmFrom";
            this.nmFrom.Size = new System.Drawing.Size(54, 20);
            this.nmFrom.TabIndex = 6;
            this.nmFrom.Text = "1.72";
            // 
            // nmTo
            // 
            this.nmTo.Location = new System.Drawing.Point(127, 3);
            this.nmTo.Name = "nmTo";
            this.nmTo.Size = new System.Drawing.Size(54, 20);
            this.nmTo.TabIndex = 6;
            this.nmTo.Text = "1.74";
            // 
            // lbRoot
            // 
            this.lbRoot.AutoSize = true;
            this.lbRoot.Location = new System.Drawing.Point(614, 67);
            this.lbRoot.Name = "lbRoot";
            this.lbRoot.Size = new System.Drawing.Size(27, 13);
            this.lbRoot.TabIndex = 7;
            this.lbRoot.Text = "N/A";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(187, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "step:";
            // 
            // nmStep
            // 
            this.nmStep.Location = new System.Drawing.Point(223, 3);
            this.nmStep.Name = "nmStep";
            this.nmStep.Size = new System.Drawing.Size(54, 20);
            this.nmStep.TabIndex = 6;
            this.nmStep.Text = "0.001";
            // 
            // lbZoom
            // 
            this.lbZoom.AutoSize = true;
            this.lbZoom.Location = new System.Drawing.Point(416, 66);
            this.lbZoom.Name = "lbZoom";
            this.lbZoom.Size = new System.Drawing.Size(60, 13);
            this.lbZoom.TabIndex = 8;
            this.lbZoom.Text = "Zoom: N/A";
            // 
            // cbMethod
            // 
            this.cbMethod.FormattingEnabled = true;
            this.cbMethod.Location = new System.Drawing.Point(88, 12);
            this.cbMethod.Name = "cbMethod";
            this.cbMethod.Size = new System.Drawing.Size(328, 21);
            this.cbMethod.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Method:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.nmFrom);
            this.panel1.Controls.Add(this.nmTo);
            this.panel1.Controls.Add(this.nmStep);
            this.panel1.Location = new System.Drawing.Point(46, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(280, 26);
            this.panel1.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.textBox2);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Location = new System.Drawing.Point(46, 94);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(280, 26);
            this.panel2.TabIndex = 12;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(30, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(54, 20);
            this.textBox1.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "x0:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(117, 3);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(54, 20);
            this.textBox2.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(90, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "x1:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbMethod);
            this.Controls.Add(this.lbZoom);
            this.Controls.Add(this.lbRoot);
            this.Controls.Add(this.btPreviousStep);
            this.Controls.Add(this.btNextStep);
            this.Controls.Add(this.tbExpression);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btDraw);
            this.Controls.Add(this.zed);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl zed;
        private System.Windows.Forms.Button btDraw;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbExpression;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btNextStep;
        private System.Windows.Forms.Button btPreviousStep;
        private System.Windows.Forms.TextBox nmFrom;
        private System.Windows.Forms.TextBox nmTo;
        private System.Windows.Forms.Label lbRoot;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox nmStep;
        private System.Windows.Forms.Label lbZoom;
        private System.Windows.Forms.ComboBox cbMethod;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;

    }
}

