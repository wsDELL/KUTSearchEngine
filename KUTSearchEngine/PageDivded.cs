using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace KUTSearchEngine
{
    class PageDivded
    {
        public int pageSize = 10;      //每页记录数
        public int recordCount = 0;    //总记录数
        public int pageCount = 0;      //总页数
        public int currentPage = 0;    //当前页
        DataTable dtSource = new DataTable();
        DataGridView gridView = new DataGridView();

        public PageDivded()
        {

        }

        public PageDivded(DataTable table)
        {
            dtSource = table;
        }

        public int PageSize
        {
            get
            {
                return pageSize;
            }

        }
        public int RecordCount
        {
            get
            {
                return recordCount; 
            }
        }
        public int PageCount
        {
            get
            {
                return pageCount;
            }
        }
        public int CurrentPage
        {
            get
            {
                return currentPage;
            }
            set
            {
                currentPage = value;
            }
        }

        public DataTable DtSource
        {
            get
            {
                return dtSource;
            }
            set
            {
                dtSource = value;
            }
        }
        public DataGridView GridView
        {
            get
            {
                return gridView;
            }
        }

        public DataTable LoadPage()
        {
            if (currentPage < 1) currentPage = 1;
            if (currentPage > pageCount) currentPage = pageCount;

            int beginRecord;
            int endRecord;
            DataTable dtTemp=new DataTable();

            
            dtTemp = dtSource.Clone();

            beginRecord = pageSize * (currentPage - 1);
            if (currentPage == 1) beginRecord = 0;
            endRecord = pageSize * currentPage;

            if (currentPage == pageCount) endRecord = recordCount;
            for (int i = beginRecord; i < endRecord; i++)
            {
                dtTemp.ImportRow(dtSource.Rows[i]);
            }
            return dtTemp;
        }

        public void DividedPage( )    //str是sql语句
        {
           
            
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
        public void ClearUpDataTable()
        {
            dtSource.Clear();
        }
    }
}
