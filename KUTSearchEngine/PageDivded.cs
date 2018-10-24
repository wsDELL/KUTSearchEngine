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
        public int pageSize = 10;      //Record number in every page
        public int recordCount = 0;    //Total number of the record
        public int pageCount = 0;      //Total number of the page
        public int currentPage = 0;    //Current page show
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
        /// <summary>
        /// make sure the begin and end of records in one page
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// divide the page base on record count
        /// </summary>
        public void DividedPage( )    
        {
            recordCount = dtSource.Rows.Count;
            pageCount = (recordCount / pageSize);
            if ((recordCount % pageSize) > 0)
            {
                pageCount++;
            }

           
            currentPage = 1;

            LoadPage();
        }
        public string PageNumber()
        {
            return currentPage.ToString() + "/" + pageCount.ToString();
        }
        public void ClearUpDataTable()
        {
            dtSource.Clear();
        }
    }
}
