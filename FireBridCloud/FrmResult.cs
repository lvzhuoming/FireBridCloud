using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FireBridCloud;

namespace FireBridCloud
{
    public partial class FrmErrorResult : Form
    {
        public FrmErrorResult()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "请选择保存位置";
            sfd.Filter = "Excel文件 (*.xls)|*.xls";
            if (sfd.ShowDialog() != DialogResult.OK) return;
            string fileName = sfd.FileName;

            try
            {
                ExcelMakerNPOI maker = new ExcelMakerNPOI(ExcelFormat.XLS);
                maker.CreateSheet("数据库结构检查");
                DataTable dt = this.dgvData.DataSource as DataTable;
                //数据
                maker.WriteDataToExcel(dt, 0, 0, true);
                //保存
                maker.Save(fileName);
            }
            catch (Exception ex)
            {
                //MapSoftLog.LogError(ex.Message, ex);
                //MessageHandler.ShowErrorMsg(ex);
                MessageBox.Show(ex.ToString(), "导出失败");
                return;
            }
            MessageBox.Show("导出成功");
        }

        private void FormErrorResult_Load(object sender, EventArgs e)
        {
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToResizeRows = false;
            this.dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
    }
}
