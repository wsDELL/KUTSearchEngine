using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace KUTSearchEngine
{
    class PageDivded
    {
        public int pageSize = 10;      //每页记录数
        public int recordCount = 0;    //总记录数
        public int pageCount = 0;      //总页数
        public int currentPage = 0;    //当前页
        DataTable dtSource = new DataTable();

        public PageDivded()
        {

        }

        public PageDivded(DataTable table)
        {
            dtSource = table;
        }

       
        private void LoadPage()
        {
            if (currentPage < 1) currentPage = 1;
            if (currentPage > pageCount) currentPage = pageCount;

            int beginRecord;
            int endRecord;
            DataTable dtTemp;
            dtTemp = dtSource.Clone();

            beginRecord = pageSize * (currentPage - 1);
            if (currentPage == 1) beginRecord = 0;
            endRecord = pageSize * currentPage;

            if (currentPage == pageCount) endRecord = recordCount;
            for (int i = beginRecord; i < endRecord; i++)
            {
                dtTemp.ImportRow(dtSource.Rows[i]);
            }
            dataGridView1.DataSource = dtTemp;  //datagridview控件名是tf_dgv1
            toolStripLabel1.Text = currentPage.ToString();//当前页
            toolStripLabel4.Text = pageCount.ToString();//总页数
            toolStripLabel6.Text = recordCount.ToString();//总记录数
        }

        private void fenye(string str)    //str是sql语句
        {
            SqlDataAdapter sda = new SqlDataAdapter(str, yb_db.yb_ConStr);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dtSource = ds.Tables[0];
            recordCount = dtSource.Rows.Count;
            pageCount = (recordCount / pageSize);
            if ((recordCount % pageSize) > 0)
            {
                pageCount++;
            }

            //默认第一页
            currentPage = 1;

            LoadPage();//调用加载数据的方法
        }
    }
}
