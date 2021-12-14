
namespace Desa1
{
    partial class Form3
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
            this.exportaAntigo = new System.Windows.Forms.Button();
            this.consultaAntigo = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.importaNovo = new System.Windows.Forms.Button();
            this.consultaNovo = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // exportaAntigo
            // 
            this.exportaAntigo.Location = new System.Drawing.Point(549, 12);
            this.exportaAntigo.Name = "exportaAntigo";
            this.exportaAntigo.Size = new System.Drawing.Size(170, 84);
            this.exportaAntigo.TabIndex = 0;
            this.exportaAntigo.Text = "Exporta BD antigo";
            this.exportaAntigo.UseVisualStyleBackColor = true;
            this.exportaAntigo.Click += new System.EventHandler(this.exportaAntigo_Click);
            // 
            // consultaAntigo
            // 
            this.consultaAntigo.Location = new System.Drawing.Point(12, 185);
            this.consultaAntigo.Name = "consultaAntigo";
            this.consultaAntigo.Size = new System.Drawing.Size(172, 84);
            this.consultaAntigo.TabIndex = 3;
            this.consultaAntigo.Text = "Consulta BD Antigo";
            this.consultaAntigo.UseVisualStyleBackColor = true;
            this.consultaAntigo.Click += new System.EventHandler(this.consultaAntigo_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(214, 185);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(473, 301);
            this.dataGridView1.TabIndex = 4;
            // 
            // importaNovo
            // 
            this.importaNovo.Location = new System.Drawing.Point(725, 12);
            this.importaNovo.Name = "importaNovo";
            this.importaNovo.Size = new System.Drawing.Size(170, 84);
            this.importaNovo.TabIndex = 5;
            this.importaNovo.Text = "Importa BD Novo";
            this.importaNovo.UseVisualStyleBackColor = true;
            this.importaNovo.Click += new System.EventHandler(this.importaNovo_Click);
            // 
            // consultaNovo
            // 
            this.consultaNovo.Location = new System.Drawing.Point(12, 402);
            this.consultaNovo.Name = "consultaNovo";
            this.consultaNovo.Size = new System.Drawing.Size(172, 84);
            this.consultaNovo.TabIndex = 6;
            this.consultaNovo.Text = "Consulta BD Novo";
            this.consultaNovo.UseVisualStyleBackColor = true;
            this.consultaNovo.Click += new System.EventHandler(this.consultaNovo_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(753, 185);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 25;
            this.dataGridView2.Size = new System.Drawing.Size(473, 301);
            this.dataGridView2.TabIndex = 7;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1255, 566);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.consultaNovo);
            this.Controls.Add(this.importaNovo);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.consultaAntigo);
            this.Controls.Add(this.exportaAntigo);
            this.Name = "Form3";
            this.Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button exportaAntigo;
        private System.Windows.Forms.Button consultaAntigo;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button importaNovo;
        private System.Windows.Forms.Button consultaNovo;
        private System.Windows.Forms.DataGridView dataGridView2;
    }
}