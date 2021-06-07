
namespace QuizScoreBoard
{
    partial class NewGame
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.addPlayerButton = new System.Windows.Forms.Button();
            this.addPlayerNameTextBox = new System.Windows.Forms.TextBox();
            this.playerList = new System.Windows.Forms.ListView();
            this.playerNames = new System.Windows.Forms.ColumnHeader();
            this.deletePlayerButton1 = new System.Windows.Forms.Button();
            this.enterPlayerNameLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.startGameButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // addPlayerButton
            // 
            this.addPlayerButton.Location = new System.Drawing.Point(430, 107);
            this.addPlayerButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.addPlayerButton.Name = "addPlayerButton";
            this.addPlayerButton.Size = new System.Drawing.Size(98, 27);
            this.addPlayerButton.TabIndex = 0;
            this.addPlayerButton.Text = "Hinzufügen";
            this.addPlayerButton.UseVisualStyleBackColor = true;
            this.addPlayerButton.Click += new System.EventHandler(this.AddPlayerButton_Click);
            // 
            // addPlayerNameTextBox
            // 
            this.addPlayerNameTextBox.Location = new System.Drawing.Point(147, 110);
            this.addPlayerNameTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.addPlayerNameTextBox.Name = "addPlayerNameTextBox";
            this.addPlayerNameTextBox.Size = new System.Drawing.Size(265, 23);
            this.addPlayerNameTextBox.TabIndex = 1;
            // 
            // playerList
            // 
            this.playerList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.playerNames});
            this.playerList.HideSelection = false;
            this.playerList.Location = new System.Drawing.Point(149, 171);
            this.playerList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.playerList.Name = "playerList";
            this.playerList.Size = new System.Drawing.Size(265, 211);
            this.playerList.TabIndex = 2;
            this.playerList.Tag = "";
            this.playerList.UseCompatibleStateImageBehavior = false;
            this.playerList.View = System.Windows.Forms.View.List;
            // 
            // deletePlayerButton1
            // 
            this.deletePlayerButton1.Location = new System.Drawing.Point(430, 171);
            this.deletePlayerButton1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.deletePlayerButton1.Name = "deletePlayerButton1";
            this.deletePlayerButton1.Size = new System.Drawing.Size(98, 27);
            this.deletePlayerButton1.TabIndex = 3;
            this.deletePlayerButton1.Text = "Löschen";
            this.deletePlayerButton1.UseVisualStyleBackColor = true;
            this.deletePlayerButton1.Click += new System.EventHandler(this.button2_Click);
            // 
            // enterPlayerNameLabel
            // 
            this.enterPlayerNameLabel.AutoSize = true;
            this.enterPlayerNameLabel.Location = new System.Drawing.Point(15, 113);
            this.enterPlayerNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.enterPlayerNameLabel.Name = "enterPlayerNameLabel";
            this.enterPlayerNameLabel.Size = new System.Drawing.Size(120, 15);
            this.enterPlayerNameLabel.TabIndex = 4;
            this.enterPlayerNameLabel.Text = "Gib Spieler Name ein:";
            this.enterPlayerNameLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 171);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Spieler:";
            // 
            // startGameButton
            // 
            this.startGameButton.Location = new System.Drawing.Point(430, 355);
            this.startGameButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.startGameButton.Name = "startGameButton";
            this.startGameButton.Size = new System.Drawing.Size(98, 27);
            this.startGameButton.TabIndex = 6;
            this.startGameButton.Text = "Spiel starten!";
            this.startGameButton.UseVisualStyleBackColor = true;
            this.startGameButton.Click += new System.EventHandler(this.startGameButton_Click_1);
            // 
            // NewGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 438);
            this.Controls.Add(this.startGameButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.enterPlayerNameLabel);
            this.Controls.Add(this.deletePlayerButton1);
            this.Controls.Add(this.playerList);
            this.Controls.Add(this.addPlayerNameTextBox);
            this.Controls.Add(this.addPlayerButton);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "NewGame";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.NewGame_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addPlayerButton;
        private System.Windows.Forms.TextBox addPlayerNameTextBox;
        private System.Windows.Forms.ListView playerList;
        private System.Windows.Forms.Button deletePlayerButton1;
        private System.Windows.Forms.Label enterPlayerNameLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button startGameButton;
        private System.Windows.Forms.ColumnHeader playerNames;
    }
}

