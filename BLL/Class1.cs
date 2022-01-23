using System;
using System.Collections.Generic;
using BEE;
using DAL;
namespace BLL
{
    public class blteacher
    {
        public void create(teacher teacher1)
        {
            var dlteacher = new dltacher();
            dlteacher.create(teacher1);
        }
        public List<teacher> readall_teacher()
        {
            var dlteacher = new dltacher();
            return dlteacher.readall_teacher();
        }
        public teacher serchbynid(int id)
        {
            var dlteacher = new dltacher();
            return dlteacher.serchbynid(id);
        }
        public List<teacher> serchbyname(string nameteachers)
        {
            var dlteacher = new dltacher();
            return dlteacher.serchbyname(nameteachers);
        }
        public void delet(int id)
        {
            var dlteacher = new dltacher();
            dlteacher.delet(id);
        }
        public void edit(int id, teacher teacher)
        {
            var dlteacher = new dltacher();
            dlteacher.edit(id, teacher);
        }
    }
    public class blcours
    {
        public void create(cours cours)
        {
            var dlcours = new dlcours();
            dlcours.create(cours);

        }
        public List<cours> searchbyids(List<int> ids)
        {
            var dlcours = new dlcours();
            return dlcours.searchbyids(ids);
        }
        public void createtechercours(techer_Cours techer_Cours) 
        {
            var dlcours = new dlcours();
            dlcours.createtechercours(techer_Cours);
        }

        public List<cours> readall_cours()
        {
            var dlcours = new dlcours();

            return dlcours.readall_cours();
        }
        public List<cours> serch(string seacrh)
        {
            var dlcours = new dlcours();
            return dlcours.serch(seacrh);
            
        }
        public cours serchbynid(int id)
        {
            var dlcours = new dlcours();
            return dlcours.serchbynid(id);
        }
        public void delet(int id)
        {
            var dlcours = new dlcours();
            dlcours.delet(id);
        }
        public void update( cours cours)
        {
            var dlcours = new dlcours();
            dlcours.update( cours);
        }
        public List<cours> get_skip(int c)
        {
            var dlcours = new dlcours();
           return  dlcours.get_skip(c);
        }

    }
    public class blorder
    {
        public void create(Order order)
        {
            var dlo = new dlOrder();
            dlo.create(order);


        }

        public List<Order> readall_cours()
        {
            var dlo = new dlOrder();
            return dlo.readall_Order();
        }
        public Order serchbyid(int id)
        {
            var dlo = new dlOrder();
            return dlo.serchbynid(id);

        }
       
        public void delet(int id)
        {
            var dlo = new dlOrder();
            dlo.delet(id); ;
        }
        public List<Order> get_skip(int c)
        {
            var dlo = new dlOrder();
            return dlo.get_skip(c); ;
        }
        //public void update(cours cours)
        //{
        //    var dlcours = new dlcours();
        //    dlcours.update(cours);
        //}
    }
}
