using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SSIS_BOOT.Models;

namespace SSIS_BOOT.DB
{
    public class SSISSeeder
    {
        public SSISSeeder(SSISContext dbcontext)
        {
            // Seed Permission

            //Seed category
            Category ca1 = new Category("Clip", "C1");
            Category ca2 = new Category("Envelope", "E1");
            dbcontext.Add(ca1);
            dbcontext.Add(ca2);
            dbcontext.SaveChanges();


            //seed product
            Product p1 = new Product("C001", "Clips Double 1", 1);
            Product p2 = new Product("C002", "Clips Double 2",1);
            Product p3 = new Product("C003", "Clips Double 3/4",1);
            Product p4 = new Product("E001", "Envelop Brown (3'x6')",2);
            Product p5 = new Product("E002", "Envelop Brown (3'x6') w/Window",2);
            dbcontext.Add(p1);
            dbcontext.Add(p2);
            dbcontext.Add(p3);
            dbcontext.Add(p4);
            dbcontext.Add(p5);
            dbcontext.SaveChanges();

            //seed collection point
            CollectionPoint c1 = new CollectionPoint("Stationary Store", "9:30AM");
            CollectionPoint c2 = new CollectionPoint("Management School", "11:30AM");
            dbcontext.Add(c1);
            dbcontext.Add(c2);
            dbcontext.SaveChanges();

            //seed department
            Department d1 = new Department("STOR", "LU Stationary Store", 9999999);
            Department d2 = new Department("ENGL", "English Dept", 8742234);
            Department d3 = new Department("CPSC", "Computer Science", 8901235);
            dbcontext.Add(d1);
            dbcontext.Add(d2);
            dbcontext.Add(d3);
            dbcontext.SaveChanges();

            //seed employee
            Employee e1 = new Employee("Esther the store clerk", "STOR");
            dbcontext.Add(e1);
            dbcontext.SaveChanges();
            Employee e2 = new Employee( "Peter the store supervisor", "STOR");
            dbcontext.Add(e2);
            dbcontext.SaveChanges();
            Employee e3 = new Employee( "James the store manager", "STOR");
            dbcontext.Add(e3);
            dbcontext.SaveChanges();
            Employee e4 = new Employee( "Pamela Kow", "ENGL");
            dbcontext.Add(e4);
            dbcontext.SaveChanges();
            Employee e5 = new Employee( "Ezra Pound (M)", "ENGL");
            dbcontext.Add(e5);
            dbcontext.SaveChanges();
            Employee e6 = new Employee( "Wee Kian Fatt", "CPSC");
            dbcontext.Add(e6);
            dbcontext.SaveChanges();
            Employee e7 = new Employee( "soh Kian Wee (M)", "CPSC");
            dbcontext.Add(e7);
            dbcontext.SaveChanges();

            //set department head and employee

            d2.RepId = 4;
            d2.HeadId = 5;
            d3.RepId = 6;
            d3.HeadId = 7;
            dbcontext.Update(d2);
            dbcontext.Update(d3);
            dbcontext.SaveChanges();

            //seed supplier

            //seed tender quotation

            //seed transaction

            //seed retrieval

            //seed requsition
            Requisition r1 = new Requisition("ENGL", 4, 5, 1);
            dbcontext.Add(r1);
            Requisition r2 = new Requisition("CPSC", 6, 7, 1);
            dbcontext.Add(r2);
            dbcontext.SaveChanges();

            //seed requsition detail
            RequisitionDetail rd1 = new RequisitionDetail(1, "C001");
            dbcontext.Add(rd1);
            RequisitionDetail rd2 = new RequisitionDetail(1, "C002");
            dbcontext.Add(rd2);
            RequisitionDetail rd3 = new RequisitionDetail(1, "C003");
            dbcontext.Add(rd3);
            RequisitionDetail rd4 = new RequisitionDetail(2, "C001");
            dbcontext.Add(rd4);
            RequisitionDetail rd5 = new RequisitionDetail(2, "E001");
            dbcontext.Add(rd5);
            RequisitionDetail rd6 = new RequisitionDetail(2, "E002");
            dbcontext.Add(rd6);
            dbcontext.SaveChanges();

            //seed adjustment voucher

            //seed adjustment voucher detail

            //seed purchase request detail

            //seed purchase order

            //seed purchase order detail

        }
        

    }
}
