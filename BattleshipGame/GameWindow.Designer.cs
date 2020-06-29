namespace BattleshipGame
{
    partial class GameWindow
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
            this.gridGroupBox = new System.Windows.Forms.GroupBox();
            this.newGameBtn = new System.Windows.Forms.Button();
            this.tileButtonTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.gridGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridGroupBox
            // 
            this.gridGroupBox.Controls.Add(this.tileButtonTablePanel);
            this.gridGroupBox.Location = new System.Drawing.Point(12, 4);
            this.gridGroupBox.Name = "gridGroupBox";
            this.gridGroupBox.Size = new System.Drawing.Size(467, 451);
            this.gridGroupBox.TabIndex = 0;
            this.gridGroupBox.TabStop = false;
            this.gridGroupBox.Text = "Player 1";
            // 
            // newGameBtn
            // 
            this.newGameBtn.Location = new System.Drawing.Point(492, 27);
            this.newGameBtn.Name = "newGameBtn";
            this.newGameBtn.Size = new System.Drawing.Size(141, 39);
            this.newGameBtn.TabIndex = 1;
            this.newGameBtn.Text = "New Game";
            this.newGameBtn.UseVisualStyleBackColor = true;
            this.newGameBtn.Click += new System.EventHandler(this.NewGameBtn_Click);
            // 
            // tileButtonTablePanel
            // 
            this.tileButtonTablePanel.AutoSize = true;
            this.tileButtonTablePanel.ColumnCount = 1;
            this.tileButtonTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tileButtonTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileButtonTablePanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            this.tileButtonTablePanel.Location = new System.Drawing.Point(3, 16);
            this.tileButtonTablePanel.Name = "tileButtonTablePanel";
            this.tileButtonTablePanel.RowCount = 1;
            this.tileButtonTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tileButtonTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tileButtonTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tileButtonTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tileButtonTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tileButtonTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tileButtonTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tileButtonTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tileButtonTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tileButtonTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tileButtonTablePanel.Size = new System.Drawing.Size(461, 432);
            this.tileButtonTablePanel.TabIndex = 1;
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 459);
            this.Controls.Add(this.newGameBtn);
            this.Controls.Add(this.gridGroupBox);
            this.Name = "GameWindow";
            this.Text = "GameWindow";
            this.Load += new System.EventHandler(this.GameWindow_Load);
            this.gridGroupBox.ResumeLayout(false);
            this.gridGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gridGroupBox;
        private System.Windows.Forms.Button newGameBtn;
        private System.Windows.Forms.TableLayoutPanel tileButtonTablePanel;
    }
}