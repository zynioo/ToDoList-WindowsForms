namespace ToDoList
{
    partial class listForm
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
            this.listBoxTasks = new System.Windows.Forms.ListBox();
            this.buttonAddTask = new System.Windows.Forms.Button();
            this.buttonDeleteTask = new System.Windows.Forms.Button();
            this.buttonModifyTask = new System.Windows.Forms.Button();
            this.labelLogout = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxTasks
            // 
            this.listBoxTasks.FormattingEnabled = true;
            this.listBoxTasks.Location = new System.Drawing.Point(61, 125);
            this.listBoxTasks.Name = "listBoxTasks";
            this.listBoxTasks.Size = new System.Drawing.Size(681, 251);
            this.listBoxTasks.TabIndex = 0;
            // 
            // buttonAddTask
            // 
            this.buttonAddTask.Location = new System.Drawing.Point(602, 398);
            this.buttonAddTask.Name = "buttonAddTask";
            this.buttonAddTask.Size = new System.Drawing.Size(140, 37);
            this.buttonAddTask.TabIndex = 1;
            this.buttonAddTask.Text = "Dodaj Zadanie";
            this.buttonAddTask.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteTask
            // 
            this.buttonDeleteTask.Location = new System.Drawing.Point(61, 398);
            this.buttonDeleteTask.Name = "buttonDeleteTask";
            this.buttonDeleteTask.Size = new System.Drawing.Size(140, 37);
            this.buttonDeleteTask.TabIndex = 2;
            this.buttonDeleteTask.Text = "Usuń Zadanie";
            this.buttonDeleteTask.UseVisualStyleBackColor = true;
            // 
            // buttonModifyTask
            // 
            this.buttonModifyTask.Location = new System.Drawing.Point(331, 398);
            this.buttonModifyTask.Name = "buttonModifyTask";
            this.buttonModifyTask.Size = new System.Drawing.Size(140, 37);
            this.buttonModifyTask.TabIndex = 3;
            this.buttonModifyTask.Text = "Modyfikuj Zadanie";
            this.buttonModifyTask.UseVisualStyleBackColor = true;
            // 
            // labelLogout
            // 
            this.labelLogout.AutoSize = true;
            this.labelLogout.Location = new System.Drawing.Point(681, 31);
            this.labelLogout.Name = "labelLogout";
            this.labelLogout.Size = new System.Drawing.Size(61, 13);
            this.labelLogout.TabIndex = 4;
            this.labelLogout.Text = "Wyloguj się";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(251, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(307, 42);
            this.label1.TabIndex = 5;
            this.label1.Text = "Twoja lista zadań";
            // 
            // listForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 481);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelLogout);
            this.Controls.Add(this.buttonModifyTask);
            this.Controls.Add(this.buttonDeleteTask);
            this.Controls.Add(this.buttonAddTask);
            this.Controls.Add(this.listBoxTasks);
            this.Name = "listForm";
            this.Text = "Lista zadań";
            this.Load += new System.EventHandler(this.listForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxTasks;
        private System.Windows.Forms.Button buttonAddTask;
        private System.Windows.Forms.Button buttonDeleteTask;
        private System.Windows.Forms.Button buttonModifyTask;
        private System.Windows.Forms.Label labelLogout;
        private System.Windows.Forms.Label label1;
    }
}