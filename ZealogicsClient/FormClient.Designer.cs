namespace ZealogicsClient
{
    partial class FormClient
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.RequestBtn = new System.Windows.Forms.Button();
            this.IpText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PortText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.FileNameText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SavePathText = new System.Windows.Forms.TextBox();
            this.ResultText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RequestBtn
            // 
            this.RequestBtn.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.RequestBtn.Location = new System.Drawing.Point(38, 20);
            this.RequestBtn.Name = "RequestBtn";
            this.RequestBtn.Size = new System.Drawing.Size(439, 50);
            this.RequestBtn.TabIndex = 1;
            this.RequestBtn.Text = "Request";
            this.RequestBtn.UseVisualStyleBackColor = true;
            this.RequestBtn.Click += new System.EventHandler(this.RequestBtn_Click);
            // 
            // IpText
            // 
            this.IpText.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.IpText.Location = new System.Drawing.Point(182, 109);
            this.IpText.Name = "IpText";
            this.IpText.Size = new System.Drawing.Size(295, 40);
            this.IpText.TabIndex = 2;
            this.IpText.Text = "127.0.0.1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(33, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 28);
            this.label1.TabIndex = 3;
            this.label1.Text = "Server IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(33, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 28);
            this.label2.TabIndex = 5;
            this.label2.Text = "Server Port: ";
            // 
            // PortText
            // 
            this.PortText.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.PortText.Location = new System.Drawing.Point(182, 169);
            this.PortText.Name = "PortText";
            this.PortText.Size = new System.Drawing.Size(295, 40);
            this.PortText.TabIndex = 4;
            this.PortText.Text = "8081";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(33, 257);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 28);
            this.label3.TabIndex = 7;
            this.label3.Text = "File Name:";
            // 
            // FileNameText
            // 
            this.FileNameText.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FileNameText.Location = new System.Drawing.Point(181, 254);
            this.FileNameText.Name = "FileNameText";
            this.FileNameText.Size = new System.Drawing.Size(296, 40);
            this.FileNameText.TabIndex = 6;
            this.FileNameText.Text = "test01";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(33, 323);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 28);
            this.label4.TabIndex = 9;
            this.label4.Text = "Save Path:";
            // 
            // SavePathText
            // 
            this.SavePathText.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.SavePathText.Location = new System.Drawing.Point(182, 320);
            this.SavePathText.Name = "SavePathText";
            this.SavePathText.Size = new System.Drawing.Size(295, 40);
            this.SavePathText.TabIndex = 8;
            this.SavePathText.Text = "D:\\";
            // 
            // ResultText
            // 
            this.ResultText.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ResultText.Location = new System.Drawing.Point(37, 447);
            this.ResultText.Multiline = true;
            this.ResultText.Name = "ResultText";
            this.ResultText.Size = new System.Drawing.Size(440, 147);
            this.ResultText.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(32, 408);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 28);
            this.label5.TabIndex = 11;
            this.label5.Text = "Result:";
            // 
            // FormClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 606);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ResultText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SavePathText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.FileNameText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PortText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.IpText);
            this.Controls.Add(this.RequestBtn);
            this.Name = "FormClient";
            this.Text = "Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RequestBtn;
        private System.Windows.Forms.TextBox IpText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox PortText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox FileNameText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox SavePathText;
        private System.Windows.Forms.TextBox ResultText;
        private System.Windows.Forms.Label label5;
    }
}

