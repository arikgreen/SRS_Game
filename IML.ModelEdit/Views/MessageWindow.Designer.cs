namespace IML.ModelEdit
{
  partial class MessageWindow
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose (bool disposing)
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
    private void InitializeComponent ()
    {
      this.MessageBox = new System.Windows.Forms.Label();
      this.OkButton = new System.Windows.Forms.Button();
      this.ContentPanel = new System.Windows.Forms.Panel();
      this.SuspendLayout();
      // 
      // MessageBox
      // 
      this.MessageBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.MessageBox.Location = new System.Drawing.Point(12, 9);
      this.MessageBox.Margin = new System.Windows.Forms.Padding(3);
      this.MessageBox.Name = "MessageBox";
      this.MessageBox.Size = new System.Drawing.Size(420, 42);
      this.MessageBox.TabIndex = 0;
      this.MessageBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // OkButton
      // 
      this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.OkButton.Location = new System.Drawing.Point(198, 63);
      this.OkButton.Name = "OkButton";
      this.OkButton.Size = new System.Drawing.Size(60, 35);
      this.OkButton.TabIndex = 1;
      this.OkButton.Text = "OK";
      this.OkButton.UseVisualStyleBackColor = true;
      // 
      // ContentPanel
      // 
      this.ContentPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.ContentPanel.Location = new System.Drawing.Point(13, 107);
      this.ContentPanel.Name = "ContentPanel";
      this.ContentPanel.Size = new System.Drawing.Size(418, 92);
      this.ContentPanel.TabIndex = 2;
      // 
      // MessageWindow
      // 
      this.AcceptButton = this.OkButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.OkButton;
      this.ClientSize = new System.Drawing.Size(444, 207);
      this.Controls.Add(this.ContentPanel);
      this.Controls.Add(this.OkButton);
      this.Controls.Add(this.MessageBox);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "MessageWindow";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label MessageBox;
    private System.Windows.Forms.Button OkButton;
    private System.Windows.Forms.Panel ContentPanel;
  }
}