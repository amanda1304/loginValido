namespace loginValido
{
    partial class FormPrincipal
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
            this.btnPagina1 = new System.Windows.Forms.Button();
            this.btnPagina2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPagina1
            // 
            this.btnPagina1.Location = new System.Drawing.Point(195, 118);
            this.btnPagina1.Name = "btnPagina1";
            this.btnPagina1.Size = new System.Drawing.Size(209, 36);
            this.btnPagina1.TabIndex = 0;
            this.btnPagina1.Text = "página 1";
            this.btnPagina1.UseVisualStyleBackColor = true;
            this.btnPagina1.Click += new System.EventHandler(this.btnPagina1_Click);
            // 
            // btnPagina2
            // 
            this.btnPagina2.Location = new System.Drawing.Point(195, 204);
            this.btnPagina2.Name = "btnPagina2";
            this.btnPagina2.Size = new System.Drawing.Size(209, 36);
            this.btnPagina2.TabIndex = 1;
            this.btnPagina2.Text = "página 2";
            this.btnPagina2.UseVisualStyleBackColor = true;
            this.btnPagina2.Click += new System.EventHandler(this.btnPagina2_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnPagina2);
            this.Controls.Add(this.btnPagina1);
            this.Name = "FormPrincipal";
            this.Text = "FormPrincipal";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPagina1;
        private System.Windows.Forms.Button btnPagina2;
    }
}