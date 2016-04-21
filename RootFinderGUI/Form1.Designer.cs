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
            this.nmFrom = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nmTo = new System.Windows.Forms.NumericUpDown();
            this.btNextStep = new System.Windows.Forms.Button();
            this.btPreviousStep = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nmFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmTo)).BeginInit();
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
            this.zed.Location = new System.Drawing.Point(12, 68);
            this.zed.Name = "zed";
            this.zed.PanModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)));
            this.zed.ScrollGrace = 0D;
            this.zed.ScrollMaxX = 0D;
            this.zed.ScrollMaxY = 0D;
            this.zed.ScrollMaxY2 = 0D;
            this.zed.ScrollMinX = 0D;
            this.zed.ScrollMinY = 0D;
            this.zed.ScrollMinY2 = 0D;
            this.zed.Size = new System.Drawing.Size(760, 482);
            this.zed.TabIndex = 0;
            this.zed.UseExtendedPrintDialog = true;
            this.zed.KeyDown += new System.Windows.Forms.KeyEventHandler(this.zed_KeyDown);
            this.zed.KeyUp += new System.Windows.Forms.KeyEventHandler(this.zed_KeyUp);
            this.zed.MouseEnter += new System.EventHandler(this.zed_MouseEnter);
            // 
            // btDraw
            // 
            this.btDraw.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btDraw.Location = new System.Drawing.Point(697, 10);
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
            this.label1.Location = new System.Drawing.Point(21, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Expression:";
            // 
            // tbExpression
            // 
            this.tbExpression.Location = new System.Drawing.Point(88, 12);
            this.tbExpression.Name = "tbExpression";
            this.tbExpression.Size = new System.Drawing.Size(328, 20);
            this.tbExpression.TabIndex = 3;
            this.tbExpression.Text = "pow(x, 2) - 3";
            // 
            // nmFrom
            // 
            this.nmFrom.Location = new System.Drawing.Point(88, 38);
            this.nmFrom.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nmFrom.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.nmFrom.Name = "nmFrom";
            this.nmFrom.Size = new System.Drawing.Size(54, 20);
            this.nmFrom.TabIndex = 4;
            this.nmFrom.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "From:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(148, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "to:";
            // 
            // nmTo
            // 
            this.nmTo.Location = new System.Drawing.Point(173, 38);
            this.nmTo.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nmTo.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.nmTo.Name = "nmTo";
            this.nmTo.Size = new System.Drawing.Size(54, 20);
            this.nmTo.TabIndex = 4;
            this.nmTo.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // btNextStep
            // 
            this.btNextStep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btNextStep.Location = new System.Drawing.Point(738, 39);
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
            this.btPreviousStep.Location = new System.Drawing.Point(697, 39);
            this.btPreviousStep.Name = "btPreviousStep";
            this.btPreviousStep.Size = new System.Drawing.Size(34, 23);
            this.btPreviousStep.TabIndex = 5;
            this.btPreviousStep.Text = "<";
            this.btPreviousStep.UseVisualStyleBackColor = true;
            this.btPreviousStep.Click += new System.EventHandler(this.btPreviousStep_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.btPreviousStep);
            this.Controls.Add(this.btNextStep);
            this.Controls.Add(this.nmTo);
            this.Controls.Add(this.nmFrom);
            this.Controls.Add(this.tbExpression);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btDraw);
            this.Controls.Add(this.zed);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.nmFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmTo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl zed;
        private System.Windows.Forms.Button btDraw;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbExpression;
        private System.Windows.Forms.NumericUpDown nmFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nmTo;
        private System.Windows.Forms.Button btNextStep;
        private System.Windows.Forms.Button btPreviousStep;

    }
}

