using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CafeLibrary;


namespace BD4
{
    public partial class CountServeInCafe : Form
    {
        List<Cafe> cafeList;
        List<Serve> serveList;
        List<Post> postList;
        int choosenIndexCafe = -1;

        public CountServeInCafe()
        {
            InitializeComponent();
        }

        private void CountServeInCafe_Load(object sender, EventArgs e)
        {
            DGVCount.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            DGVCount_FirstReload();
        }
        private bool GetCafeServ(Cafe cafe)
        {
            serveList = Serve.Get();
            postList = Post.Get();
            foreach (Serve serve in serveList)
            {
                if (cafe.idcafe == serve.cafe.idcafe)//смотрим есть ли в этом кафе сотрудники
                {
                    foreach (Post post in postList)
                    {
                        if (serve.idserve == post.serve.idserve)//смотрим есть ли должность у сотрудника
                            return true;
                    }
                }
                    
            }
            return false;
        }
        private void DGVCount_FirstReload()
        {
            DGVCount.Rows.Clear();
            cafeList = Cafe.Get();
            
            foreach (Cafe cafe in cafeList)
            {
                if(GetCafeServ(cafe) == true)
                    DGVCount.Rows.Add(cafe.idcafe, cafe.address, Cafe.GetCountServe(cafe.idcafe), Cafe.GetPostCafe(cafe.idcafe));
            }

            for (int i = 0; i < DGVCount.RowCount; ++i)
            {
                DGVCount.Rows[i].Selected = false;
            }
            choosenIndexCafe = -1;
        }

    }
}
