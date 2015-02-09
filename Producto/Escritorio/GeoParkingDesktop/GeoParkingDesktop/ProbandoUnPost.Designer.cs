namespace GeoParkingDesktop
{
    partial class ProbandoUnPost
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
            this.btnHacerPost = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnHacerPost
            // 
            this.btnHacerPost.Location = new System.Drawing.Point(70, 48);
            this.btnHacerPost.Name = "btnHacerPost";
            this.btnHacerPost.Size = new System.Drawing.Size(75, 23);
            this.btnHacerPost.TabIndex = 0;
            this.btnHacerPost.Text = "Hacer Post";
            this.btnHacerPost.UseVisualStyleBackColor = true;
            this.btnHacerPost.Click += new System.EventHandler(this.btnHacerPost_Click);
            // 
            // ProbandoUnPost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnHacerPost);
            this.Name = "ProbandoUnPost";
            this.Text = "ProbandoUnPost";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnHacerPost;
    }
}