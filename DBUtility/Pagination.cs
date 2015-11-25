using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Common;

namespace DBUtility
{
    /// <summary>
    /// ��Ϣ��ҳ
    /// Edition 1.1
    /// </summary>
    public class Pagination
    {
        private string pageBar = "";		    //��ҳ������
        private int pageBarSize = 1;            //��ҳ������ҳ����
        private string urlStr = "";		        //��ҳ�����ַ���
        private int pageSize = 0;		        //ÿҳ��ʾ��¼������
        private int pageCount = 0;		        //�ܼ�ҳ��
        private int recordCount = 0;		    //��¼����
        private int sequence = 0;		        //��ǰҳ��
        private string searchField = "";        //��ѯ�ֶ�
        private string searchSentence = "";     //��ѯ���
        private string sortSentence = "";       //�������
        private string primarykey = "";         //����
        private string tableName = "";          //Ҫ��ѯ�������
        private string itemUnit = "";           //��λ
        private string imagesPath = "";         //��ҳ��������ťͼƬ��ŵ�ַ ��: "../_imgs/"
        //�Ż�
        private int pageUpCount = 1;            //��ҳ���������´���
        private int pageBarCount = 8;           //��ҳ������ҳ������
        private string direction = "";            //��ҳ����
        private string dbConnection = "";       /// ���ݿ�����

        #region ����
        /// <summary>
        /// ���ݿ�����
        /// </summary>
        public string DbConnection
        {
            get { return dbConnection; }
            set { dbConnection = value; }
        }
        /// <summary>
        /// ��ҳ����
        /// </summary>
        public string Direction
        {
            get { return direction; }
            set { direction = value; }
        }
        /// <summary>
        /// ��ҳ������ҳ������
        /// </summary>
        public int PageBarCount
        {
            get { return pageBarCount; }
            set { pageBarCount = value; }
        }
        /// <summary>
        /// ��ҳ���������´���
        /// </summary>
        public int PageUpCount
        {
            get { return pageUpCount; }
            set { pageUpCount = value; }
        }
        /// <summary>
        /// ��ҳ������
        /// </summary>
        public string PageBar
        {
            get { return pageBar; }
            set { pageBar = value; }
        }
        /// <summary>
        /// ��ҳ������
        /// </summary>
        public int PageBarSize
        {
            get { return pageBarSize; }
            set { pageBarSize = value; }
        }
        /// <summary>
        /// ��ҳ�����ַ���,�� "default.aspx?id=3&cid=4"
        /// </summary>
        public string UrlStr
        {
            get { return urlStr; }
            set { urlStr = value; }
        }
        /// <summary>
        /// ÿҳ��ʾ��¼������
        /// </summary>
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }
        /// <summary>
        /// ����ҳ��
        /// </summary>
        public int PageCount
        {
            get {
                if ((RecordCount % PageSize) == 0)
                    pageCount = RecordCount / PageSize;
                else
                    pageCount = RecordCount / PageSize + 1;

                return pageCount;
            }
        }
        /// <summary>
        /// ��¼����
        /// </summary>
        public int RecordCount
        {
            get { return recordCount; }
            set { recordCount = value; }
        }
        /// <summary>
        /// ��ǰҳ��/ҳ��
        /// </summary>
        public int Sequence
        {
            get
            {
                return (sequence != 0) ? sequence : 1;
            }
            set
            { sequence = value; }
        }
        /// <summary>
        /// ��ѯ���,��: "AND Keywords = '' AND ID = 2"
        /// </summary>
        public string SearchSentence
        {
            get { return searchSentence; }
            set {

                //if (FilterHandler.ExistBadWord(value))
                //    searchSentence = " AND 1<>1 ";
                //else
                    searchSentence = value;
            }
        }
        /// <summary>
        /// �������,��: " ORDER BY MCardID DESC"
        /// </summary>
        public string SortSentence
        {
            get { return sortSentence; }
            set { sortSentence = value; }
        }
        /// <summary>
        /// ��ѯ����������
        /// </summary>
        public string Primarykey
        {
            get { return primarykey; }
            set { primarykey = value; }
        }
        /// <summary>
        /// ��ѯ�����,��: "News"
        /// </summary>
        public string TableName
        {
            get { return tableName; }
            set { tableName = value; }
        }
        /// <summary>
        /// ��ѯ�ֶ�,��: "*" ���� "UserName,UserPassword,RealName,..."
        /// </summary>
        public string SearchField
        {
            get { return searchField; }
            set { searchField = value; }
        }
        /// <summary>
        /// ��¼�ĵ�λ����,��:"����¼" �� "����Ʒ"
        /// </summary>
        public string ItemUnit
        {
            get { return itemUnit; }
            set { itemUnit = value; }
        }
        /// <summary>
        /// ��ҳ��������ťͼƬ��ŵ�ַ ��: "../Images/"
        /// </summary>
        public string ImagesPath
        {
            get { return (string.IsNullOrEmpty(imagesPath)) ? "../Images/" : imagesPath; }
            set { imagesPath = value; }
        }
        #endregion

        #region ����
        /// <summary>
        /// ƥ�䵱ǰҳ�Ρ���ѯ�������������Ȳ���,��ȡ���ݱ�
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable()
        {
            SqlParameter[] parms = new SqlParameter[]
            { 
                new SqlParameter("@SqlWhere", SqlDbType.VarChar,8000),
                new SqlParameter("@PageSize", SqlDbType.Int),
                new SqlParameter("@PageIndex", SqlDbType.Int),
                new SqlParameter("@SqlTable", SqlDbType.VarChar,8000),
                new SqlParameter("@SqlField", SqlDbType.VarChar,8000),
                new SqlParameter("@SqlPK", SqlDbType.VarChar,50),
                new SqlParameter("@SqlOrder", SqlDbType.VarChar,200),
                new SqlParameter("@Count", SqlDbType.Int),
            };
                parms[0].Value = searchSentence;
                parms[1].Value = pageSize;
                parms[2].Value = sequence;
                parms[3].Value = tableName;
                parms[4].Value = searchField;
                parms[5].Value = primarykey;
                parms[6].Value = sortSentence;
                parms[7].Direction = ParameterDirection.Output;

            DataTable dt = new DataTable();;
            using (SqlConnection conn = new SqlConnection(PubConstant.ConnectionString))
            {
                dt = SqlHelper.ExecuteDataTable(conn, CommandType.StoredProcedure, "pagination", parms);
                RecordCount = int.Parse((parms[7].Value.ToString()));
                conn.Close();
                conn.Dispose();
            }
            return dt;
        }

        /// <summary>
        /// ƥ�䵱ǰҳ�Ρ���ѯ�������������Ȳ���,��ȡ���ݱ�
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableFormServicesDB()
        {
            SqlParameter[] parms = new SqlParameter[]
            { 
                new SqlParameter("@SqlWhere", SqlDbType.VarChar,8000),
                new SqlParameter("@PageSize", SqlDbType.Int),
                new SqlParameter("@PageIndex", SqlDbType.Int),
                new SqlParameter("@SqlTable", SqlDbType.VarChar,8000),
                new SqlParameter("@SqlField", SqlDbType.VarChar,8000),
                new SqlParameter("@SqlPK", SqlDbType.VarChar,50),
                new SqlParameter("@SqlOrder", SqlDbType.VarChar,200),
                new SqlParameter("@Count", SqlDbType.Int),
            };
            parms[0].Value = searchSentence;
            parms[1].Value = pageSize;
            parms[2].Value = sequence;
            parms[3].Value = tableName;
            parms[4].Value = searchField;
            parms[5].Value = primarykey;
            parms[6].Value = sortSentence;
            parms[7].Direction = ParameterDirection.Output;

            DataTable dt = new DataTable(); ;
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringMembership))
            {
                dt = SqlHelper.ExecuteDataTable(conn, CommandType.StoredProcedure, "pagination", parms);
                RecordCount = int.Parse((parms[7].Value.ToString()));
                conn.Close();
                conn.Dispose();
            }
            return dt;
        }

        /// <summary>
        /// ƥ�䵱ǰҳ�Ρ���ѯ�������������Ȳ���,��ȡ���ݱ�
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataSource()
        {
            SqlParameter[] parms = new SqlParameter[]
            { 
                new SqlParameter("@SqlWhere", SqlDbType.VarChar),
                new SqlParameter("@PageSize", SqlDbType.Int),
                new SqlParameter("@PageIndex", SqlDbType.Int),
                new SqlParameter("@SqlTable", SqlDbType.VarChar),
                new SqlParameter("@SqlField", SqlDbType.VarChar),
                new SqlParameter("@SqlPK", SqlDbType.VarChar, 128),
                new SqlParameter("@SqlOrder", SqlDbType.VarChar, 256),
                new SqlParameter("@Count", SqlDbType.Int),
            };
            parms[0].Value = searchSentence;
            parms[1].Value = pageSize;
            parms[2].Value = sequence;
            parms[3].Value = tableName;
            parms[4].Value = searchField;
            parms[5].Value = primarykey;
            parms[6].Value = sortSentence;
            parms[7].Direction = ParameterDirection.Output;

            DataTable dt = new DataTable(); ;
            using (SqlConnection conn = new SqlConnection(DbConnection))
            {
                dt = SqlHelper.ExecuteDataTable(conn, CommandType.StoredProcedure, "pagination", parms);
                RecordCount = int.Parse((parms[7].Value.ToString()));
                conn.Close();
                conn.Dispose();
            }
            return dt;
        }

        /// <summary>
        /// ��ȡ��ҳ������  ģʽ: ��ҳ | ��һҳ | ��һҳ | βҳ    �� Sequence ҳ | �� RecordCount / PageSize ҳ | ÿҳ PageSize
        /// </summary>
        public void PageBarByStyle1()
        {
            string htmlText = "<table class=\"pageBar\" cellspacing=\"0\" cellpadding=\"5\">";
            htmlText += "<tr><td style=\"width:18%\" bgcolor=\"#ffffff\" align=\"center\">";
            htmlText += "<font color=\"#00000\"><span class=\"fonten_amount\">{0} {1}</span></font></td>";
            htmlText += "<td bgcolor=\"#ffffff\" style=\"width:32%\">��<b>{2}</b>ҳ | ��<b>{3}</b>ҳ | ÿҳ<b>{4}</b>{1}</td>";
            htmlText += "<td bgcolor=\"#ffffff\" style=\"width:32%\" align=\"center\">{5}</td>";
            htmlText += "</td></tr></table>";

            int PageCount = 0;

            if ((RecordCount % PageSize) == 0)
                PageCount = RecordCount / PageSize;
            else
                PageCount = RecordCount / PageSize + 1;

            if (PageCount < Sequence)
                Sequence = PageCount;
            if (PageCount <= 0)
                Sequence = 1;

            string str = "";

            if (Sequence < 2)
                str += "��ҳ | ��һҳ | ";
            else
            {
                str += "<a href=\"" + UrlStr + "page=1\" class=\"link_page\">��ҳ</a> | ";
                str += "<a href=\"" + UrlStr + "page=" + (Sequence - 1) + "\" class=\"link_page\">��һҳ</a> | ";
            }

            if ((PageCount - Sequence) < 1)
                str += "��һҳ | βҳ ";
            else
            {
                str += "<a href=\"" + UrlStr + "page=" + (Sequence + 1) + "\" class=\"link_page\">��һҳ</a> | ";
                str += "<a href=\"" + UrlStr + "page=" + PageCount + "\" class=\"link_page\">βҳ</a>";
            }

            PageBar = string.Format(htmlText, RecordCount.ToString(), ItemUnit, Sequence.ToString(), PageCount.ToString(), PageSize.ToString(), str);
        }

        /// <summary>
        /// ��ȡ��ҳ������  ģʽ: ��ҳ | ��һҳ | ��һҳ | βҳ    �� Sequence ҳ | �� RecordCount / PageSize ҳ | ÿҳ PageSize
        /// </summary>
        public void PageBarByStyles1()
        {
            string htmlText = "<table class=\"pageBar\" cellspacing=\"0\" cellpadding=\"5\">";
            htmlText += "<tr><td bgcolor=\"#ffffff\" style=\"width:32%\">��<b>{2}</b>ҳ | ��<b>{3}</b>ҳ | ÿҳ<b>{4}</b>{1}</td>";
            htmlText += "<td bgcolor=\"#ffffff\" style=\"width:32%\" align=\"center\">{5}</td>";
            htmlText += "</td></tr></table>";

            int PageCount = 0;

            if ((RecordCount % PageSize) == 0)
                PageCount = RecordCount / PageSize;
            else
                PageCount = RecordCount / PageSize + 1;

            if (PageCount < Sequence)
                Sequence = PageCount;
            if (PageCount <= 0)
                Sequence = 1;

            string str = "";

            if (Sequence < 2)
                str += "��ҳ | ��һҳ | ";
            else
            {
                str += "<a href=\"#\" onclick=\"return pagination(1);\" class=\"link_page\">��ҳ</a> | ";
                str += "<a href=\"#\" onclick=\"return pagination("+(Sequence-1)+");\" class=\"link_page\">��һҳ</a> | ";
            }

            if ((PageCount - Sequence) < 1)
                str += "��һҳ | βҳ ";
            else
            {
                str += "<a href=\"#\" onclick=\"return pagination(" + (Sequence + 1) + ");\" class=\"link_page\">��һҳ</a> | ";
                str += "<a href=\"#\" onclick=\"return pagination(" + PageCount + ");\" class=\"link_page\">βҳ</a>";
            }

            PageBar = string.Format(htmlText, RecordCount.ToString(), ItemUnit, Sequence.ToString(), PageCount.ToString(), PageSize.ToString(), str);
        }

        /// <summary>
        /// ����ģʽ��ҳ���������� << 1 2 3 4 5 6 7 8 9 >>
        /// </summary>
        public void NumeberPageBar()
        {
            if (PageCount < Sequence)
                Sequence = PageCount;

            if (PageCount <= 0)
                Sequence = 1;

            string str = "Page {0} of {1} &nbsp;&nbsp;&nbsp; {2} &nbsp;{3}&nbsp; {4}", temp = "", previous = "", next = "";
            int areaS = 1, areaE = PageCount;
            if (PageCount > 10 && Sequence > 4)
            {
                areaS = Sequence - 4;
                areaE = Sequence - 4 + 9;
            }

            if (Sequence > 1)
            {
                previous = "<a href=\"" + UrlStr + "page=" + (Sequence + 1) + "\">Previous</a>";
                next = "<a href=\"" + UrlStr + "page=" + (Sequence - 1) + "\">Next</a>";
            }
            else
            {
                previous = "Previous";
                next = "Next";
            }

            for (int i = areaS; i <= areaE; i++)
            {
                if (i == Sequence)
                    temp += "<a href=\"" + UrlStr + "page=" + i.ToString() + "\"><font color=\"#FF6600\">" + i.ToString() + "</a></font> ";
                else
                    temp += "<a href=\"" + UrlStr + "page=" + i.ToString() + "\">" + i.ToString() + "</a> ";
            }

            str = string.Format(str, Sequence.ToString(), PageCount.ToString(), previous, temp, next);

            PageBar = str;
        }

        /// <summary>
        /// ���ưٶ� google�ķ�ҳ���� <<{0} ��һҳ{1} 1 2 3 4 5 6 7 8 9{2} ��һҳ{3} >>{4}  ��ת[8]{5}
        /// </summary>
        public void GoNumeberPageBar1()
        {
            string pageHtml = "{0}&nbsp;&nbsp;&nbsp;&nbsp;{1}&nbsp;&nbsp;{2}&nbsp;&nbsp;{3}&nbsp;&nbsp;&nbsp;&nbsp;{4}&nbsp;&nbsp;&nbsp;&nbsp;{5}";
            string page0 = "", page1 = "", page2 = "", page3 = "", page4 = "", page5 = "";
            int tempallpage = 1;
            if ((RecordCount % PageSize) == 0)
                tempallpage = RecordCount / PageSize;
            else
                tempallpage = RecordCount / PageSize + 1;
            page5 = "&nbsp;&nbsp;<input id='goPageNumTemp' value='" + Sequence + "' style='width:40px;height:16px;BORDER-RIGHT: #7b9ebd 1px solid; BORDER-TOP: #7b9ebd 1px solid; FONT-SIZE: 12px; BORDER-LEFT: #7b9ebd 1px solid; BORDER-BOTTOM: #7b9ebd 1px solid;' onkeyup=\"this.value=this.value.replace(/\\D/g,'')\"  onafterpaste=\"this.value=this.value.replace(/\\D/g,'')\" />&nbsp;&nbsp;<a href=\"javascript:void(0);\" onclick=\"var strgonum=document.getElementById('goPageNumTemp').value;if(strgonum!=''){if(strgonum>" + tempallpage + "){pagination(" + tempallpage + ");}else{pagination(strgonum);}}else{pagination(" + Sequence + ");}\" class=\"cmnbtn btnG\"><span>Go</span></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;��&nbsp;" + tempallpage + "&nbsp;ҳ";
            if (Sequence <= PageBarSize)
            {
                page0 = "&lt;&lt;";
                page1 = "��һҳ";
            }
            else
            {
                if ((Sequence - PageBarSize) > 0)
                {
                    page0 = "<a href=\"#\" onclick=\"pagination(" + (Sequence - PageBarSize) + ");\">&lt;&lt;</a>";
                }
                else
                {
                    page0 = "<a href=\"#\" onclick=\"pagination(1);\">&lt;&lt;</a>";
                }
                page1 = "<a href=\"#\" onclick=\"pagination(" + (Sequence - 1) + ");\">��һҳ</a>";
            }
            if ((tempallpage - Sequence ) < PageBarSize)
            {
                page3 = "��һҳ";
                page4 = "&gt;&gt;";
            }
            else
            {
                page3 = "<a href=\"#\" onclick=\"pagination(" + (Sequence + 1) + ");\">��һҳ</a>";
                if ((Sequence + PageBarSize) > tempallpage)
                {
                    page4 = "<a href=\"#\" onclick=\"pagination(" + tempallpage + ");\">&gt;&gt;</a>";
                }
                else
                {
                    page4 = "<a href=\"#\" onclick=\"pagination(" + (Sequence + PageBarSize) + ");\">&gt;&gt;</a>";
                }
            }
            if (tempallpage < PageSize)
            {
                for (int i = 1; i <= tempallpage; i++)
                {
                    if (i == Sequence)
                    {
                        page2 += "&nbsp;<font color=Red>" + i + "</font>&nbsp;";
                    }
                    else
                    {
                        page2 += "&nbsp;<a href=\"#\" onclick=\"pagination(" + i + ");\">" + i + "</a>&nbsp;";
                    }
                }
            }
            else
            {
                int tempcount = 1;
                if (Sequence % PageBarSize == 0)
                {
                    tempcount = Sequence / PageBarSize - 1;
                }
                else
                {
                    tempcount = Sequence / PageBarSize;
                }
                tempcount = tempcount * PageBarSize;
                for (int i = 1; i <= PageBarSize; i++)
                {
                    tempcount++;
                    if (tempcount <= tempallpage)
                    {
                        if (tempcount == Sequence)
                        {
                            page2 += "&nbsp;<font color=Red>" + tempcount + "</font>&nbsp;";
                        }
                        else
                        {
                            page2 += "&nbsp;<a href=\"#\" onclick=\"pagination(" + tempcount + ");\">" + tempcount + "</a>&nbsp;";
                        }
                    }
                }
            }
            PageBar = string.Format(pageHtml, page0, page1, page2, page3, page4, page5);
        }

        /// <summary>
        /// ���ưٶ� google�ķ�ҳ���� <<{0} ��һҳ{1} 1 2 3 4 5 6 7 8 9{2} ��һҳ{3} >>{4}  ��ת[8]{5}
        /// </summary>
        public void GoNumeberPageBar()
        {
            string pageHtml = "{0}&nbsp;&nbsp;&nbsp;&nbsp;{1}&nbsp;&nbsp;&nbsp;&nbsp;{2}";
            string page0 = "", page2 = "", page4 = "";
            int tempallpage = 1;
            if ((RecordCount % PageSize) == 0)
                tempallpage = RecordCount / PageSize;
            else
                tempallpage = RecordCount / PageSize + 1;
            if (Sequence <= PageBarSize)
            {
                page0 = "";
            }
            else
            {
                if ((Sequence - PageBarSize) > 0)
                {
                    page0 = "<span><a href=\"#\" title='Previous Group' onclick=\"pagination(" + (Sequence - PageBarSize) + ");\">&lt;&lt;</a></span>";
                }
                else
                {
                    page0 = "<span><a href=\"#\" title='Previous Group' onclick=\"pagination(1);\">&lt;&lt;</a></span>";
                }
            }
            if ((tempallpage - Sequence + 1) < PageBarSize)
            {
                page4 = "";
                if (tempallpage != Sequence)
                {
                    page4 = "<span><a href=\"#\" title='Next Group' onclick=\"pagination(" + tempallpage + ");\">&gt;&gt;</a></span>";
                }
            }
            else
            {
                if ((Sequence + PageBarSize) > tempallpage)
                {
                    page4 = "<span><a href=\"#\" title='Next Group' onclick=\"pagination(" + tempallpage + ");\">&gt;&gt;</a></span>";
                }
                else
                {
                    page4 = "<span><a href=\"#\" title='Next Group' onclick=\"pagination(" + (Sequence + PageBarSize) + ");\">&gt;&gt;</a></span>";
                }
            }
            if (tempallpage < PageSize)
            {
                for (int i = 1; i <= tempallpage; i++)
                {
                    if (i == Sequence)
                    {
                        page2 += "&nbsp;<span class=\"cp\"><strong>" + i + "</strong></span>&nbsp;";
                    }
                    else
                    {
                        page2 += "&nbsp;<span><a href=\"#\" onclick=\"pagination(" + i + ");\">" + i + "</a></span>&nbsp;";
                    }
                }
            }
            else
            {
                int tempcount = 1;
                if (Sequence % PageBarSize == 0)
                {
                    tempcount = Sequence / PageBarSize - 1;
                }
                else
                {
                    tempcount = Sequence / PageBarSize;
                }
                tempcount = tempcount * PageBarSize;
                for (int i = 1; i <= PageBarSize; i++)
                {
                    tempcount++;
                    if (tempcount <= tempallpage)
                    {
                        if (tempcount == Sequence)
                        {
                            page2 += "&nbsp;<span class=\"cp\"><strong>" + tempcount + "</strong></span>&nbsp;";
                        }
                        else
                        {
                            page2 += "&nbsp;<span><a href=\"#\" onclick=\"pagination(" + tempcount + ");\">" + tempcount + "</a></span>&nbsp;";
                        }
                    }
                }
            }
            if (PageBarSize >= tempallpage)
            {
                page0 = "";
                page4 = "";
            }
            PageBar = string.Format(pageHtml, page0, page2, page4);
        }

        /// <summary>
        /// ���� Yahoo �ķ�ҳ(����)���� << Prve {0} 1 2 3 4 5 6 7 8 9{1} Next{2} >>
        /// </summary>
        public void GoNumeberPageBarCn2()
        {
            StringBuilder pageBarHTML = new StringBuilder();
            string htmlText = "<div class=\"pagePanel\"><ul>{0}{1}{2}</ul></div>";
            string prev = "";
            string next = "";
            string item = "<li><a target=\"_self\" href=\"{1}\">{0}</a></li>";
            string current = "<li><span class=\"current\">{0}</span></li>";

            int PageCount = 0;

            if ((RecordCount % PageSize) == 0)
                PageCount = RecordCount / PageSize;
            else
                PageCount = RecordCount / PageSize + 1;

            if (PageCount < Sequence)
                Sequence = PageCount;
            if (PageCount <= 0)
                Sequence = 1;

            if (PageCount == 1 || RecordCount == 0)
            {
                PageBar = "";
                return;
            }
 
            if (Direction == "next")
            {
                if ((Sequence == (PageBarCount + 1)) || (Sequence == ((PageUpCount * PageBarCount) + 1)))
                {
                    PageUpCount++;
                }
            }
            if (Direction == "prev")
            {
                if ((Sequence == ((PageUpCount - 1) * PageBarCount)) && (PageUpCount != 1))
                {
                    PageUpCount--;
                }
            }

            ///��һҳ
            if (Sequence == 1 && RecordCount == 1)
            {
                prev = "";
                next = "";
            }
            else if (Sequence == 1 && RecordCount > 1)
            {
                prev = "";
                next = "<li><a target=\"_self\" id=\"pg-next\" href=\"" + urlStr + "page=" + (Sequence + 1) + "&upcount=" + pageUpCount + "&direction=next\" class=\"control\">��һҳ&gt;&gt;</a></li>";
            }
            ///���һҳ
            else if (Sequence == PageCount && RecordCount > 1)
            {
                prev = "<li><a target=\"_self\" id=\"pg-prev\" href=\"" + urlStr + "page=" + (Sequence - 1) + "&upcount=" + pageUpCount + "&direction=prev\" class=\"control\">&lt;&lt;��һҳ</a></li>";
                next = "";
            }
            else
            {
                prev = "<li><a target=\"_self\" id=\"pg-prev\" href=\"" + urlStr + "page=" + (Sequence - 1) + "&upcount=" + pageUpCount + "&direction=prev \" class=\"control\">&lt;&lt;��һҳ</a></li>";
                next = "<li><a target=\"_self\" id=\"pg-next\" href=\"" + urlStr + "page=" + (Sequence + 1) + "&upcount=" + pageUpCount + "&direction=next\" class=\"control\">��һҳ&gt;&gt;</a></li>";
            }
 
            int itemcount = 0;
            if (PageCount >= (PageUpCount * pageBarCount))
                itemcount = pageBarCount;
            else
                itemcount = pageBarCount - (PageUpCount * pageBarCount - PageCount);

            for (int i = 1; i <= itemcount; i++)
            {
                int pagenumber = (PageUpCount - 1) * pageBarCount + i;
                if (pagenumber == Sequence)
                {
                    pageBarHTML.Append(string.Format(current, pagenumber.ToString()));
                }
                else
                {
                    string url = urlStr + "page=" + pagenumber.ToString() + "&upcount=" + pageUpCount.ToString();
                    int start = PageSize * (pagenumber - 1);
                    int end = PageSize * pagenumber;
                    pageBarHTML.Append(string.Format(item, pagenumber.ToString(), url));
                }
            }
            PageBar = string.Format(htmlText, prev, pageBarHTML.ToString(), next);
        }

        /// <summary>
        /// ���� Yahoo �ķ�ҳ(����)���� << Prve {0} 1 2 3 4 5 6 7 8 9{1} Next{2} >>
        /// </summary>
        public void GoNumeberPageBarCn3()
        {
            StringBuilder pageBarHTML = new StringBuilder();
            string htmlText = "<div class=\"pagePanel\"><p>{3}</p><ul>{0}{1}{2}</ul></div>";
            string prev = "";
            string next = "";
            string item = "<li><a target=\"_self\" href=\"{1}\">{0}</a></li>";
            string current = "<li><span class=\"current\">{0}</span></li>";

            int PageCount = 0;

            if ((RecordCount % PageSize) == 0)
                PageCount = RecordCount / PageSize;
            else
                PageCount = RecordCount / PageSize + 1;

            if (PageCount < Sequence)
                Sequence = PageCount;
            if (PageCount <= 0)
                Sequence = 1;

            if (PageCount == 1 || RecordCount == 0)
            {
                PageBar = "";
            }
            else
            {

                if (Direction == "next")
                {
                    if ((Sequence == (PageBarCount + 1)) || (Sequence == ((PageUpCount * PageBarCount) + 1)))
                    {
                        PageUpCount++;
                    }
                }
                if (Direction == "prev")
                {
                    if ((Sequence == ((PageUpCount - 1) * PageBarCount)) && (PageUpCount != 1))
                    {
                        PageUpCount--;
                    }
                }

                ///��һҳ
                if (Sequence == 1 && RecordCount == 1)
                {
                    prev = "";
                    next = "";
                }
                else if (Sequence == 1 && RecordCount > 1)
                {
                    prev = "";
                    next = "<li><a target=\"_self\" id=\"pg-next\" href=\"" + urlStr + "page=" + (Sequence + 1) + "&upcount=" + pageUpCount + "&direction=next\" class=\"control\">��һҳ&gt;&gt;</a></li>";
                }
                ///���һҳ
                else if (Sequence == PageCount && RecordCount > 1)
                {
                    prev = "<li><a target=\"_self\" id=\"pg-prev\" href=\"" + urlStr + "page=" + (Sequence - 1) + "&upcount=" + pageUpCount + "&direction=prev\" class=\"control\">&lt;&lt;��һҳ</a></li>";
                    next = "";
                }
                else
                {
                    prev = "<li><a target=\"_self\" id=\"pg-prev\" href=\"" + urlStr + "page=" + (Sequence - 1) + "&upcount=" + pageUpCount + "&direction=prev \" class=\"control\">&lt;&lt;��һҳ</a></li>";
                    next = "<li><a target=\"_self\" id=\"pg-next\" href=\"" + urlStr + "page=" + (Sequence + 1) + "&upcount=" + pageUpCount + "&direction=next\" class=\"control\">��һҳ&gt;&gt;</a></li>";
                }

                int itemcount = 0;
                if (PageCount >= (PageUpCount * pageBarCount))
                    itemcount = pageBarCount;
                else
                    itemcount = pageBarCount - (PageUpCount * pageBarCount - PageCount);

                for (int i = 1; i <= itemcount; i++)
                {
                    int pagenumber = (PageUpCount - 1) * pageBarCount + i;
                    if (pagenumber == Sequence)
                    {
                        pageBarHTML.Append(string.Format(current, pagenumber.ToString()));
                    }
                    else
                    {
                        string url = urlStr + "page=" + pagenumber.ToString() + "&upcount=" + pageUpCount.ToString();
                        int start = PageSize * (pagenumber - 1);
                        int end = PageSize * pagenumber;
                        pageBarHTML.Append(string.Format(item, pagenumber.ToString(), url));
                    }
                }
            }

            PageBar = string.Format(htmlText, prev, pageBarHTML.ToString(), next, "(��" + recordCount.ToString() + itemUnit + ")");
        }


        /// <summary>
        /// ���� Yahoo �ķ�ҳ(����)���� << Prve {0} 1 2 3 4 5 6 7 8 9{1} Next{2} >>
        /// </summary>
        public void GoNumeberPageBarCn4()
        {
            StringBuilder pageBarHTML = new StringBuilder();
            string htmlText = "<div class=\"pagePanel\"><p>{3}</p><ul>{0}{1}{2}</ul></div>";
            string prev = "";
            string next = "";
            string item = "<li><a href=\"javascript:void(0);\" onclick=\"{1}\">{0}</a></li>";
            string current = "<li><span class=\"current\">{0}</span></li>";

            int PageCount = 0;

            if ((RecordCount % PageSize) == 0)
                PageCount = RecordCount / PageSize;
            else
                PageCount = RecordCount / PageSize + 1;

            if (PageCount < Sequence)
                Sequence = PageCount;
            if (PageCount <= 0)
                Sequence = 1;

            if (PageCount == 1 || RecordCount == 0)
            {
                PageBar = "";
            }
            else
            {

                if (Direction == "next")
                {
                    if ((Sequence == (PageBarCount + 1)) || (Sequence == ((PageUpCount * PageBarCount) + 1)))
                    {
                        PageUpCount++;
                    }
                }
                if (Direction == "prev")
                {
                    if ((Sequence == ((PageUpCount - 1) * PageBarCount)) && (PageUpCount != 1))
                    {
                        PageUpCount--;
                    }
                }

                ///��һҳ
                if (Sequence == 1 && RecordCount == 1)
                {
                    prev = "";
                    next = "";
                }
                else if (Sequence == 1 && RecordCount > 1)
                {
                    prev = "";
                    next = "<li><a id=\"pg-next\" onclick=\"pagination(" + (Sequence + 1) + ", " + pageUpCount + ", 'next');\" href=\"javascript:void(0);\" class=\"control\">��һҳ&gt;&gt;</a></li>";
                }
                ///���һҳ
                else if (Sequence == PageCount && RecordCount > 1)
                {
                    prev = "<li><a id=\"pg-prev\" onclick=\"pagination(" + (Sequence - 1) + ", " + pageUpCount + ", 'prev');\" href=\"javascript:void(0);\" class=\"control\">&lt;&lt;��һҳ</a></li>";
                    next = "";
                }
                else
                {
                    prev = "<li><a id=\"pg-prev\" onclick=\"pagination(" + (Sequence - 1) + ", " + pageUpCount + ", 'prev');\" href=\"javascript:void(0);\" class=\"control\">&lt;&lt;��һҳ</a></li>";
                    next = "<li><a id=\"pg-next\" onclick=\"pagination(" + (Sequence + 1) + ", " + pageUpCount + ", 'next');\" href=\"javascript:void(0);\" class=\"control\">��һҳ&gt;&gt;</a></li>";
                }

                int itemcount = 0;
                if (PageCount >= (PageUpCount * pageBarCount))
                    itemcount = pageBarCount;
                else
                    itemcount = pageBarCount - (PageUpCount * pageBarCount - PageCount);

                for (int i = 1; i <= itemcount; i++)
                {
                    int pagenumber = (PageUpCount - 1) * pageBarCount + i;
                    if (pagenumber == Sequence)
                    {
                        pageBarHTML.Append(string.Format(current, pagenumber.ToString()));
                    }
                    else
                    {
                        int start = PageSize * (pagenumber - 1);
                        int end = PageSize * pagenumber;
                        pageBarHTML.Append(string.Format(item, pagenumber.ToString(), "pagination(" + pagenumber.ToString() + ", " + pageUpCount.ToString() + ", '');"));
                    }
                }
            }

            PageBar = string.Format(htmlText, prev, pageBarHTML.ToString(), next, "(��" + recordCount.ToString() + itemUnit + ")");
        }

        /// <summary>
        /// ���ưٶ� google�ķ�ҳ���� <<{0} ��һҳ{1} 1 2 3 4 5 6 7 8 9{2} ��һҳ{3} >>{4}  ��ת[8]{5}
        /// </summary>
        public void GoNumeberPageBar2()
        {
            string pageHtml = "{6}&nbsp;&nbsp;{0}&nbsp;&nbsp;&nbsp;&nbsp;{1}&nbsp;&nbsp;{2}&nbsp;&nbsp;{3}&nbsp;&nbsp;&nbsp;&nbsp;{4}&nbsp;&nbsp;&nbsp;&nbsp;{5}";
            string page0 = "", page1 = "", page2 = "", page3 = "", page4 = "", page5 = "", page6 = "";
            int tempallpage = 1;
            if ((RecordCount % PageSize) == 0)
                tempallpage = RecordCount / PageSize;
            else
                tempallpage = RecordCount / PageSize + 1;
            page5 = "&nbsp;&nbsp;&nbsp;&nbsp;All&nbsp;<strong>" + tempallpage + "</strong>&nbsp;Pages";// "&nbsp;&nbsp;<input id='goPageNumTemp' value='" + Sequence + "' style='width:40px;height:16px;BORDER-RIGHT: #7b9ebd 1px solid; BORDER-TOP: #7b9ebd 1px solid; FONT-SIZE: 12px; BORDER-LEFT: #7b9ebd 1px solid; BORDER-BOTTOM: #7b9ebd 1px solid;' onkeyup=\"this.value=this.value.replace(/\\D/g,'')\"  onafterpaste=\"this.value=this.value.replace(/\\D/g,'')\" />&nbsp;&nbsp;<button onclick=\"var strgonum=document.getElementById('goPageNumTemp').value;if(strgonum!=''){if(strgonum>" + tempallpage + "){pagination(" + tempallpage + ");}else{pagination(strgonum);}}else{pagination(" + Sequence + ");}\" class='btn' style='width:30px;'>Go</button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;��&nbsp;" + tempallpage + "&nbsp;ҳ";
            if (tempallpage != 1)
            {
                int start = 1;
                int end = tempallpage;
                //tempallpage % PageBarSize
                if (PageBarSize < tempallpage)
                {
                    if (Sequence <= PageBarSize)
                    {
                        end = PageBarSize;
                    }
                    else
                    {
                        if ((Sequence % PageBarSize) == 0)
                        {
                            start = ((Sequence / PageBarSize) - 1) * PageBarSize + 1;
                            end = Sequence;
                        }
                        else
                        {
                            start = ((Sequence / PageBarSize)) * PageBarSize + 1;
                            end = (Sequence / PageBarSize + 1) * PageBarSize;
                            if (end > tempallpage)
                            {
                                end = tempallpage;
                            }
                        }
                    }
                }
                page6 = "<strong>" + start.ToString() + "&nbsp;-&nbsp;" + end.ToString() + "</strong>&nbsp;&nbsp;Pages";
            }
            if (Sequence <= PageBarSize)
            {
                page0 = "";
                page1 = "";
            }
            else
            {
                if ((Sequence - PageBarSize) > 0)
                {
                    page0 = "<span><a href=\"#\" onclick=\"pagination(" + (Sequence - PageBarSize) + ");\">&lt;&lt;</a></span>";
                }
                else
                {
                    page0 = "<span><a href=\"#\" onclick=\"pagination(1);\">&lt;&lt;</a></span>";
                }
                page1 = "<span><a href=\"#\" onclick=\"pagination(" + (Sequence - 1) + ");\">Previous</a></span>";
            }
            if ((tempallpage - Sequence + 1) < PageBarSize)
            {
                page3 = "";
                page4 = "";
                if (tempallpage != Sequence)
                {
                    page3 = "<span><a href=\"#\" onclick=\"pagination(" + (Sequence + 1) + ");\">Next</a></span>";
                    page4 = "<span><a href=\"#\" onclick=\"pagination(" + tempallpage + ");\">&gt;&gt;</a></span>";
                }
            }
            else
            {
                page3 = "<span><a href=\"#\" onclick=\"pagination(" + (Sequence + 1) + ");\">Next</a></span>";
                if ((Sequence + PageBarSize) > tempallpage)
                {
                    page4 = "<span><a href=\"#\" onclick=\"pagination(" + tempallpage + ");\">&gt;&gt;</a></span>";
                }
                else
                {
                    page4 = "<span><a href=\"#\" onclick=\"pagination(" + (Sequence + PageBarSize) + ");\">&gt;&gt;</a></span>";
                }
            }
            if (tempallpage < PageSize)
            {
                for (int i = 1; i <= tempallpage; i++)
                {
                    if (i == Sequence)
                    {
                        page2 += "&nbsp;<span class=\"cp\"><strong>" + i + "</strong></span>&nbsp;";
                    }
                    else
                    {
                        page2 += "&nbsp;<span><a href=\"#\" onclick=\"pagination(" + i + ");\">" + i + "</a></span>&nbsp;";
                    }
                }
            }
            else
            {
                int tempcount = 1;
                if (Sequence % PageBarSize == 0)
                {
                    tempcount = Sequence / PageBarSize - 1;
                }
                else
                {
                    tempcount = Sequence / PageBarSize;
                }
                tempcount = tempcount * PageBarSize;
                for (int i = 1; i <= PageBarSize; i++)
                {
                    tempcount++;
                    if (tempcount <= tempallpage)
                    {
                        if (tempcount == Sequence)
                        {
                            page2 += "&nbsp;<span class=\"cp\"><strong>" + tempcount + "</strong></span>&nbsp;";
                        }
                        else
                        {
                            page2 += "&nbsp;<span><a href=\"#\" onclick=\"pagination(" + tempcount + ");\">" + tempcount + "</a></span>&nbsp;";
                        }
                    }
                }
            }
            if (PageBarSize >= tempallpage)
            {
                page0 = "";
                page1 = "";
                page3 = "";
                page4 = "";
            }
            PageBar = string.Format(pageHtml, page0, page1, page2, page3, page4, page5, page6);
        }

        /// <summary>
        /// ��ˢ�·�ҳģʽ ��ǰ�� {0} ҳ. �� {1} ҳ. ÿҳ {2} ��. �� {3} ��. ��ҳ ��һҳ ��һҳ ĩҳ ת��  ҳ
        /// </summary>
        public void GoPageBarStyle1()
        {
            string pageHtml = "<div style=\"float:left; width:48%;\">��ǰ�� {0}/{1} ҳ. ÿҳ {2} ��. �� {3} ��</div><div style=\"float:right; width:48%; text-align:right;\">{4} {5}</div>";
            string page0 = "", page1 = "", page2 = "", page3 = "", page4 = "", page5 = "";
            page0 = Sequence.ToString();
            int tempallpage = 1;
            if ((RecordCount % PageSize) == 0)
                tempallpage = RecordCount / PageSize;
            else
                tempallpage = RecordCount / PageSize + 1;
            page1 = tempallpage.ToString();
            page2 = PageSize.ToString();
            page3 = RecordCount.ToString();
            page5 = "<span onclick=\"var strgonum=document.getElementById('goPageNumTemp').value;if(strgonum!=''){if(strgonum>" + tempallpage + "){pagination(" + tempallpage + ");}else{pagination(strgonum);}}else{pagination(" + Sequence + ");}\" style='width:30px;cursor:hand;'>ת��</span>&nbsp;&nbsp;<input id='goPageNumTemp' value='" + Sequence + "' style='width:40px;height:16px;BORDER-RIGHT: #7b9ebd 1px solid; BORDER-TOP: #7b9ebd 1px solid; FONT-SIZE: 12px; BORDER-LEFT: #7b9ebd 1px solid; BORDER-BOTTOM: #7b9ebd 1px solid;' onkeyup=\"this.value=this.value.replace(/\\D/g,'')\"  onafterpaste=\"this.value=this.value.replace(/\\D/g,'')\" />&nbsp;ҳ";
            if (Sequence < 2)
                page4 += "<a href=\"javascript:void(null)\">��ҳ</a> <a href=\"javascript:void(null)\">��һҳ</a>";
            else
            {
                page4 += "<a href=\"javascript:void(null)\" onclick=\"pagination(1);\">��ҳ</a>&nbsp;";
                page4 += "<a href=\"javascript:void(null)\" onclick=\"pagination(" + (Sequence - 1) + ");\">��һҳ</a>&nbsp;";
            }

            if ((tempallpage - Sequence) < 1)
                page4 += "&nbsp;<a href=\"javascript:void(null)\">��һҳ</a> <a href=\"javascript:void(null)\">ĩҳ</a>";
            else
            {
                page4 += "&nbsp;<a href=\"javascript:void(null)\" onclick=\"pagination(" + (Sequence + 1) + ");\">��һҳ</a>&nbsp;";
                page4 += "<a href=\"javascript:void(null)\" onclick=\"pagination(" + tempallpage + ");\">ĩҳ</a>";
            }
            PageBar = string.Format(pageHtml, page0, page1, page2, page3, page4, page5);
        }

        /// <summary>
        /// ��ҳ������(��ˢ��ģʽ)
        /// </summary>
        public void PageBarUnRefresh()
        {
            string htmlText = "<div>";
            htmlText += "<h1 style=\"float: left; padding: 0px 0px 0px 0px; margin: 0px 0px 0px 0px; font-size: 12px;font-weight: normal;\">{0}</h1>";
            htmlText += "<h2 style=\"float: left; padding: 0px 0px 0px 0px; margin: 0px 0px 0px 0px; font-size: 12px;font-weight: normal;\">����: {1} {2} {3}</h2>";
            htmlText += "</div>";

            int intPageCount = 0;

            if ((RecordCount % PageSize) == 0)
                intPageCount = RecordCount / PageSize;
            else
                intPageCount = RecordCount / PageSize + 1;

            string str = "";

            if (Sequence < 2)
                str += "<img src=\"" + ImagesPath + "page_FL0.gif\" style=\"border:0px; margin: 0 5px 0 25px;\" />&nbsp;<img src=\"" + ImagesPath + "page_L0.gif\" style=\"border:0px; margin: 0 10px 0 5px;\" />&nbsp;";
            else
            {
                str += "<a href=\"#\" onclick=\"return pagination(1);\"><img src=\"" + ImagesPath + "page_FL1.gif\" style=\"border:0px; margin: 0 5px 0 25px;\" /></a>&nbsp;";
                str += "<a href=\"#\" onclick=\"return pagination(" + (Sequence - 1) + ");\"><img src=\"" + ImagesPath + "page_L1.gif\" style=\"border:0px; margin: 0 10px 0 5px;\" /></a>&nbsp;";
            }

            if ((intPageCount - Sequence) < 1)
                str += "<img src=\"" + ImagesPath + "page_R0.gif\" style=\"border:0px; margin: 0 5px 0 10px;\" />&nbsp;<img src=\"" + ImagesPath + "page_LL0.gif\" style=\"border:0px; margin: 0 25px 0 5px;\" />&nbsp;";
            else
            {
                str += "<a href=\"#\" onclick=\"return pagination(" + (Sequence + 1) + ");\"><img src=\"" + ImagesPath + "page_R1.gif\" style=\"border:0px; margin: 0 5px 0 10px;\" /></a>&nbsp;";
                str += "<a href=\"#\" onclick=\"return pagination(" + intPageCount + ");\"><img src=\"" + ImagesPath + "page_LL1.gif\" style=\"border:0px; margin: 0 25px 0 5px;\" /></a>&nbsp;";
            }

            string strPage = Sequence.ToString() + "/" + intPageCount.ToString();

            PageBar = string.Format(htmlText, str, RecordCount, ItemUnit, strPage);
        }

        /// <summary>
        /// ��ҳ������(��ˢ��ģʽ)
        /// </summary>
        public void PageBarUnRefreshbak()
        {
            string htmlText = "<div>";
            htmlText += "<h1 style=\"float: left; padding: 0px 0px 0px 0px; margin: 0px 0px 0px 0px; font-size: 12px;font-weight: normal;\">{0}</h1>";
            htmlText += "<h2 style=\"float: left; padding: 0px 0px 0px 0px; margin: 0px 0px 0px 0px; font-size: 12px;font-weight: normal;\">����: {1} {2} {3}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{4}</h2>";
            htmlText += "</div>";

            int intPageCount = 0;

            if ((RecordCount % PageSize) == 0)
                intPageCount = RecordCount / PageSize;
            else
                intPageCount = RecordCount / PageSize + 1;

            string str = "";

            if (Sequence < 2)
                str += "<img src=\"" + ImagesPath + "page_FL0.gif\" style=\"border:0px; margin: 0 5px 0 25px;\" />&nbsp;<img src=\"" + ImagesPath + "page_L0.gif\" style=\"border:0px; margin: 0 10px 0 5px;\" />&nbsp;";
            else
            {
                str += "<a href=\"#\" onclick=\"return pagination(1);\"><img src=\"" + ImagesPath + "page_FL1.gif\" style=\"border:0px; margin: 0 5px 0 25px;\" /></a>&nbsp;";
                str += "<a href=\"#\" onclick=\"return pagination(" + (Sequence - 1) + ");\"><img src=\"" + ImagesPath + "page_L1.gif\" style=\"border:0px; margin: 0 10px 0 5px;\" /></a>&nbsp;";
            }

            if ((intPageCount - Sequence) < 1)
                str += "<img src=\"" + ImagesPath + "page_R0.gif\" style=\"border:0px; margin: 0 5px 0 10px;\" />&nbsp;<img src=\"" + ImagesPath + "page_LL0.gif\" style=\"border:0px; margin: 0 25px 0 5px;\" />&nbsp;";
            else
            {
                str += "<a href=\"#\" onclick=\"return pagination(" + (Sequence + 1) + ");\"><img src=\"" + ImagesPath + "page_R1.gif\" style=\"border:0px; margin: 0 5px 0 10px;\" /></a>&nbsp;";
                str += "<a href=\"#\" onclick=\"return pagination(" + intPageCount + ");\"><img src=\"" + ImagesPath + "page_LL1.gif\" style=\"border:0px; margin: 0 25px 0 5px;\" /></a>&nbsp;";
            }
            string page5 = "";

            string strPage = Sequence.ToString() + "/" + intPageCount.ToString();
            page5 = "<input id='goPageNumTemp' value='" + Sequence + "' style='width:40px;height:16px;BORDER-RIGHT: #7b9ebd 1px solid; BORDER-TOP: #7b9ebd 1px solid; FONT-SIZE: 12px; BORDER-LEFT: #7b9ebd 1px solid; BORDER-BOTTOM: #7b9ebd 1px solid;' onkeyup=\"this.value=this.value.replace(/\\D/g,'')\"  onafterpaste=\"this.value=this.value.replace(/\\D/g,'')\" />&nbsp;ҳ&nbsp;&nbsp;<button style='width:50px;height:18px;' onclick=\"var strgonum=document.getElementById('goPageNumTemp').value;if(strgonum!=''){if(strgonum>" + intPageCount + "){pagination(" + intPageCount + ");}else{pagination(strgonum);}}else{pagination(" + Sequence + ");}\">ת��</button>";

            PageBar = string.Format(htmlText, str, RecordCount, ItemUnit, strPage, page5);
        }
        /// <summary>
        /// ��ҳ������(��ˢ��ģʽ)
        /// </summary>
        /// <param name="i">���б��ҳ����paginationNum�����б��ϼ�ID</param>
        public void ChildPageBarUnRefresh(int i)
        {
            string htmlText = "<div>";
            htmlText += "<h1 style=\"float: left; padding: 0px 0px 0px 0px; margin: 0px 0px 0px 0px; font-size: 12px;font-weight: normal;\">{0}</h1>";
            htmlText += "<h2 style=\"float: left; padding: 0px 0px 0px 0px; margin: 0px 0px 0px 0px; font-size: 12px;font-weight: normal;\">����: {1} {2} {3}</h2>";
            htmlText += "</div>";

            int intPageCount = 0;

            if ((RecordCount % PageSize) == 0)
                intPageCount = RecordCount / PageSize;
            else
                intPageCount = RecordCount / PageSize + 1;

            string str = "";

            if (Sequence < 2)
                str += "<img name=\"none\" src=\"" + ImagesPath + "page_FL0.gif\" style=\"border:0px; margin: 0 5px 0 25px;\" />&nbsp;<img name=\"none\" src=\"" + ImagesPath + "page_L0.gif\" style=\"border:0px; margin: 0 10px 0 5px;\" />&nbsp;";
            else
            {
                str += "<a href=\"#\" onclick=\"return paginationNum("+i+",1);\"><img src=\"" + ImagesPath + "page_FL1.gif\" style=\"border:0px; margin: 0 5px 0 25px;\" /></a>&nbsp;";
                str += "<a href=\"#\" onclick=\"return paginationNum(" + i + "," + (Sequence - 1) + ");\"><img src=\"" + ImagesPath + "page_L1.gif\" style=\"border:0px; margin: 0 10px 0 5px;\" /></a>&nbsp;";
            }

            if ((intPageCount - Sequence) < 1)
                str += "<img name=\"none\" src=\"" + ImagesPath + "page_R0.gif\" style=\"border:0px; margin: 0 5px 0 10px;\" />&nbsp;<img name=\"none\" src=\"" + ImagesPath + "page_LL0.gif\" style=\"border:0px; margin: 0 25px 0 5px;\" />&nbsp;";
            else
            {
                str += "<a href=\"#\" onclick=\"return paginationNum(" + i + "," + (Sequence + 1) + ");\"><img name=\"none\" src=\"" + ImagesPath + "page_R1.gif\" style=\"border:0px; margin: 0 5px 0 10px;\" /></a>&nbsp;";
                str += "<a href=\"#\" onclick=\"return paginationNum(" + i + "," + intPageCount + ");\"><img name=\"none\" src=\"" + ImagesPath + "page_LL1.gif\" style=\"border:0px; margin: 0 25px 0 5px;\" /></a>&nbsp;";
            }

            string strPage = Sequence.ToString() + "/" + intPageCount.ToString();

            PageBar = string.Format(htmlText, str, RecordCount, ItemUnit, strPage);
        }

        public void PageBarFlexigrid()
        {
            int intPageCount = PageCount;

            string str = "";

            str += "<div class=\"pGroup\">��ʾ��";
            str += "<select name=\"rp\" onchange=\"ChangePagesize(this);\" id=\"sel_pagination_rp\">";
            str += "<option value=\"10\">10&nbsp;&nbsp;</option>";
            str += "<option value=\"15\">15&nbsp;&nbsp;</option>";
            str += "<option value=\"20\">20&nbsp;&nbsp;</option>";
            str += "<option value=\"30\">30&nbsp;&nbsp;</option>";
            str += "<option value=\"50\">50&nbsp;&nbsp;</option>";
            str += "</select>";
            str += "</div>";
            str += "<div class=\"btnseparator\">";
            str += "</div> ";

            if (Sequence < 2)
            {
                str += "<div class=\"pGroup\"><div class=\"pFirst pButton\"><span></span></div><div class=\"pPrev pButton\"><span></span></div></div>";
            }
            else
            {
                str += "<div class=\"pGroup\"><div class=\"pFirst pButton\" onclick=\"return pagination(1);\"><span></span></div><div class=\"pPrev pButton\" onclick=\"return pagination(" + (Sequence - 1) + ");\"><span></span></div></div>";
            }

            str += "<div class=\"btnseparator\"></div><div class=\"pGroup\"><span class=\"pcontrol\">ҳ��<input id=\"txt_pagination_goto\" type=\"text\" size=\"4\" value=\"" + Sequence + "\" onblur=\"pagination(this.value);\"> / <span>" + intPageCount + "</span></span></div><div class=\"btnseparator\"></div>";

            if ((intPageCount - Sequence) < 1)
            {
                str += "<div class=\"pGroup\"><div class=\"pNext pButton\"><span></span></div><div class=\"pLast pButton\"><span></span></div></div>";
            }
            else
            {
                str += "<div class=\"pGroup\"><div class=\"pNext pButton\" onclick=\"return pagination(" + (Sequence + 1) + ");\"><span></span></div><div class=\"pLast pButton\" onclick=\"return pagination(" + intPageCount.ToString() + ");\"><span></span></div></div>";
            }

            str += "<div class=\"btnseparator\"></div><div class=\"pGroup\"><div class=\"pReload pButton\" onclick=\"LoadingData();\"><span></span></div></div><div class=\"btnseparator\"></div><div class=\"pGroup\"><span class=\"pPageStat\">����" + this.RecordCount.ToString() + this.ItemUnit + "</span></div>";

            PageBar = str + "&nbsp;";
        }

        #region ��ҳ ������ģʽ��ҳ

        public void PageBarFerrari1()
        {
            int intPageCount = PageCount;

            string str = "";

            if (Sequence < 2)
            {
                str += "<a class=\"toolbarbutton\" id=\"f_fastRewind\" disabled onclick=\"return false;\" href=\"javascript:onclick();\" target=\"_self\"><img id=\"f_page_FL0\" disabled alt=\"������ҳ\" src=\"" + ImagesPath + "page_FL0.gif\" align=\"absMiddle\"></a>";
                str += "<a class=\"toolbarbutton\" id=\"f__prevPageImg\" disabled onclick=\"return false;\" href=\"javascript:onclick();\" target=\"_self\"><img id=\"f_page_L0\" disabled alt=\"������һҳ\" hspace=\"6\" src=\"" + ImagesPath + "page_L0.gif\" align=\"absMiddle\"></a>";
            }
            else
            {
                str += "<a class=\"toolbarbutton\" id=\"f_fastRewind\" onclick=\"return pagination(1);\" href=\"javascript:onclick();\" target=\"_self\" ><img id=\"f_page_FL1\" alt=\"������ҳ\" src=\"" + ImagesPath + "page_FL1.gif\" align=\"absMiddle\"></a>";
                str += "<a class=\"toolbarbutton\" id=\"f__prevPageImg\" onclick=\"return pagination(" + (Sequence - 1) + ");\" href=\"javascript:onclick();\" target=\"_self\" ><img id=\"f_page_L1\" alt=\"������һҳ\" hspace=\"6\" src=\"" + ImagesPath + "page_L1.gif\" align=\"absMiddle\"></a>";
            }

            str += "�� <span id=\"f__PageNum\">" + Sequence + "</span> ҳ";

            if ((intPageCount - Sequence) < 1)
            {
                str += "<a class=\"toolbarbutton\" id=\"f__nextPageImg\" disabled onclick=\"return false;\" href=\"javascript:onclick();\" target=\"_self\"><img id=\"f_page_R0\" disabled alt=\"������һҳ\" hspace=\"6\" src=\"" + ImagesPath + "page_R0.gif\" align=\"absMiddle\"></a>";
                str += "<a class=\"toolbarbutton\" id=\"f_lastPageImg\" disabled onclick=\"return false;\" href=\"javascript:onclick();\" target=\"_self\"><img id=\"f_page_LR0\" disabled alt=\"����βҳ\" hspace=\"6\" src=\"" + ImagesPath + "page_LR0.gif\" align=\"absMiddle\"></a>";
            }
            else
            {
                str += "<a class=\"toolbarbutton\" id=\"f__nextPageImg\" onclick=\"return pagination(" + (Sequence + 1) + ");\" href=\"javascript:onclick();\" target=\"_self\" ><img id=\"f_page_R1\" alt=\"������һҳ\" hspace=\"6\" src=\"" + ImagesPath + "page_R1.gif\" align=\"absMiddle\" /></a>";
                str += "<a class=\"toolbarbutton\" id=\"f_lastPageImg\" onclick=\"return pagination(" + intPageCount + ");\" href=\"javascript:onclick();\" target=\"_self\" ><img id=\"f_page_LR1\" alt=\"����βҳ\" hspace=\"6\" src=\"" + ImagesPath + "page_LR1.gif\" align=\"absMiddle\" /></a>";
            }

            //string strPage = Sequence.ToString() + "/" + intPageCount.ToString();

            PageBar = str + "&nbsp;";//string.Format(htmlText, str, RecordCount, ItemUnit, strPage);
        }

        public void PageBarFerrari()
        {
            int intPageCount = PageCount;

            string str = "";

            str += "<input id=\"txtNum\" type=\"text\" value=\"" + Sequence + "\" class=\"pagebar_input\" />&nbsp;<input type=\"submit\" value=\"Go\" class=\"stbuttom_cn_green_btn\" onclick=\"return pagination(document.getElementById(\'txtNum\').value);\" />&nbsp;";

            if (Sequence < 2)
            {
                str += "<a class=\"toolbarbutton\" id=\"f_fastRewind\" disabled onclick=\"return false;\" href=\"javascript:onclick();\" target=\"_self\"><img id=\"f_page_FL0\" disabled alt=\"������ҳ\" src=\"" + ImagesPath + "page_FL0.gif\" align=\"absMiddle\"></a>";
                str += "<a class=\"toolbarbutton\" id=\"f__prevPageImg\" disabled onclick=\"return false;\" href=\"javascript:onclick();\" target=\"_self\"><img id=\"f_page_L0\" disabled alt=\"������һҳ\" hspace=\"6\" src=\"" + ImagesPath + "page_L0.gif\" align=\"absMiddle\"></a>";
            }
            else
            {
                str += "<a class=\"toolbarbutton\" id=\"f_fastRewind\" onclick=\"return pagination(1);\" href=\"javascript:onclick();\" target=\"_self\" ><img id=\"f_page_FL1\" alt=\"������ҳ\" src=\"" + ImagesPath + "page_FL1.gif\" align=\"absMiddle\"></a>";
                str += "<a class=\"toolbarbutton\" id=\"f__prevPageImg\" onclick=\"return pagination(" + (Sequence - 1) + ");\" href=\"javascript:onclick();\" target=\"_self\" ><img id=\"f_page_L1\" alt=\"������һҳ\" hspace=\"6\" src=\"" + ImagesPath + "page_L1.gif\" align=\"absMiddle\"></a>";
            }

            str += "�� <span id=\"f__PageNum\">" + Sequence + "</span> ҳ";

            if ((intPageCount - Sequence) < 1)
            {
                str += "<a class=\"toolbarbutton\" id=\"f__nextPageImg\" disabled onclick=\"return false;\" href=\"javascript:onclick();\" target=\"_self\"><img id=\"f_page_R0\" disabled alt=\"������һҳ\" hspace=\"6\" src=\"" + ImagesPath + "page_R0.gif\" align=\"absMiddle\"></a>";
                str += "<a class=\"toolbarbutton\" id=\"f_lastPageImg\" disabled onclick=\"return false;\" href=\"javascript:onclick();\" target=\"_self\"><img id=\"f_page_LR0\" disabled alt=\"����βҳ\" hspace=\"6\" src=\"" + ImagesPath + "page_LR0.gif\" align=\"absMiddle\"></a>";
            }
            else
            {
                str += "<a class=\"toolbarbutton\" id=\"f__nextPageImg\" onclick=\"return pagination(" + (Sequence + 1) + ");\" href=\"javascript:onclick();\" target=\"_self\" ><img id=\"f_page_R1\" alt=\"������һҳ\" hspace=\"6\" src=\"" + ImagesPath + "page_R1.gif\" align=\"absMiddle\" /></a>";
                str += "<a class=\"toolbarbutton\" id=\"f_lastPageImg\" onclick=\"return pagination(" + intPageCount + ");\" href=\"javascript:onclick();\" target=\"_self\" ><img id=\"f_page_LR1\" alt=\"����βҳ\" hspace=\"6\" src=\"" + ImagesPath + "page_LR1.gif\" align=\"absMiddle\" /></a>";
            }

            //string strPage = Sequence.ToString() + "/" + intPageCount.ToString();

            PageBar = str + "&nbsp;";//string.Format(htmlText, str, RecordCount, ItemUnit, strPage);
        }
        /// <summary>
        /// ������ҳ������, ���������˵���תҳ�湦��, ������С�ߴ��б��
        /// </summary>
        public void PageBarForHelperBox()
        {
            int intPageCount = PageCount;

            string ctlSelectHTML = "<select id=\"selPageIndexList\" onchange=\"pagination(this.value);\" class=\"pagebar_select\">{0}<select>";
            string tempOptions = "";

            for (int i = 1; i <= intPageCount; i++)
            {
                tempOptions += "<option value=\"" + i.ToString() + "\">" + i.ToString() + "</option>";
            }
            string str = "<div class=\"pagebar_divbox\">";

            if (Sequence < 2)
            {
                str += "<a class=\"toolbarbutton\" id=\"f_fastRewind\" disabled onclick=\"return false;\" href=\"javascript:onclick();\" target=\"_self\"><img id=\"f_page_FL0\" disabled alt=\"������ҳ\" src=\"" + ImagesPath + "page_FL0.gif\" align=\"absMiddle\"></a>";
                str += "<a class=\"toolbarbutton\" id=\"f__prevPageImg\" disabled onclick=\"return false;\" href=\"javascript:onclick();\" target=\"_self\"><img id=\"f_page_L0\" disabled alt=\"������һҳ\" hspace=\"6\" src=\"" + ImagesPath + "page_L0.gif\" align=\"absMiddle\"></a>";
            }
            else
            {
                str += "<a class=\"toolbarbutton\" id=\"f_fastRewind\" onclick=\"return pagination(1);\" href=\"javascript:onclick();\" target=\"_self\" ><img id=\"f_page_FL1\" alt=\"������ҳ\" src=\"" + ImagesPath + "page_FL1.gif\" align=\"absMiddle\"></a>";
                str += "<a class=\"toolbarbutton\" id=\"f__prevPageImg\" onclick=\"return pagination(" + (Sequence - 1) + ");\" href=\"javascript:onclick();\" target=\"_self\" ><img id=\"f_page_L1\" alt=\"������һҳ\" hspace=\"6\" src=\"" + ImagesPath + "page_L1.gif\" align=\"absMiddle\"></a>";
            }

            str += "&nbsp;&nbsp;�� <span id=\"f__PageNum\">" + string.Format(ctlSelectHTML, tempOptions) + "</span> ҳ&nbsp;&nbsp;";

            if ((intPageCount - Sequence) < 1)
            {
                str += "<a class=\"toolbarbutton\" id=\"f__nextPageImg\" disabled onclick=\"return false;\" href=\"javascript:onclick();\" target=\"_self\"><img id=\"f_page_R0\" disabled alt=\"������һҳ\" hspace=\"6\" src=\"" + ImagesPath + "page_R0.gif\" align=\"absMiddle\"></a>";
                str += "<a class=\"toolbarbutton\" id=\"f_lastPageImg\" disabled onclick=\"return false;\" href=\"javascript:onclick();\" target=\"_self\"><img id=\"f_page_LR0\" disabled alt=\"����βҳ\" hspace=\"6\" src=\"" + ImagesPath + "page_LR0.gif\" align=\"absMiddle\"></a>";
            }
            else
            {
                str += "<a class=\"toolbarbutton\" id=\"f__nextPageImg\" onclick=\"return pagination(" + (Sequence + 1) + ");\" href=\"javascript:onclick();\" target=\"_self\" ><img id=\"f_page_R1\" alt=\"������һҳ\" hspace=\"6\" src=\"" + ImagesPath + "page_R1.gif\" align=\"absMiddle\" /></a>";
                str += "<a class=\"toolbarbutton\" id=\"f_lastPageImg\" onclick=\"return pagination(" + intPageCount + ");\" href=\"javascript:onclick();\" target=\"_self\" ><img id=\"f_page_LR1\" alt=\"����βҳ\" hspace=\"6\" src=\"" + ImagesPath + "page_LR1.gif\" align=\"absMiddle\" /></a>";
            }
            str += "</div>";

            PageBar = str;
        }
        #endregion

        #endregion

        #region ����
        public Pagination()
        {

        }
        #endregion
    }
}
